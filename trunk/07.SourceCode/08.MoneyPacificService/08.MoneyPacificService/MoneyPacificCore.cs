using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService;
using _08.MoneyPacificService.DTO;
using _08.MoneyPacificService.DAO;
using _08.MoneyPacificService.BUS;

namespace _08.MoneyPacificService
{
    public class MoneyPacificCore
    {
        internal static DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();

        internal static string GetRequest(string smsContent)
        {

            string smsResponse = "";
            string sErrorMessage = "";

            // NHẬN THÔNG TIN 
            // *** GIẢI MÃ - DECODE *** (not yet)

            // Cách xử lý này chưa chuẩn...
            // Cần sửa lại theo 1 trong hai cách sau: 
            //    1. Dùng XML có các parameter, gồm có các giá trị: name, value, index (vị trí tham số trong lời gọi)
            //    2. Dùng 1 cấu trúc lệnh dạng mảng giống DOS Command

            // command: chưa sử dụng
            string command = AnalystSyntaxBUS.getCommand(smsContent);

            Store senderStore = AnalystSyntaxBUS.getSender(smsContent);
            int amountBuy = AnalystSyntaxBUS.getAmount(smsContent);
            int amountBuyConfirm = AnalystSyntaxBUS.getAmountConfirm(smsContent);
            Customer newCustomer = AnalystSyntaxBUS.getCustomer(smsContent);


            // KIỂM TRA

            // 01. Kiểm tra người gửi có phải là STORE hay không?
            //     a. Sai => "Yêu cầu bị từ chối" - bSender.. = false
            //     b. Đúng => bSenderExist = .. true. 
            //        RETURN luôn kết quả, send về cho người dùng
            // (lý do tách 2 phần: kiểm tra tồn tại và kiểm tra pass ra riêng là
            // để tách 2 phần thông báo lỗi cho người dùng cho rõ ràng 
            
            bool bSenderExist = StoreDAO.checkExist(senderStore);

            // Nếu không tồn tại Store này
            if (!bSenderExist)
            {
                smsResponse = MessageManager.GenNotExistStoreMessage(senderStore.Phone);
                return smsResponse;
            }


            // 02. Kiểm tra thông tin PASSWORD của STORE chính xác hay không?
            //     a. Sai => ErrorMessage += "-Sai mật khẩu";
            //     b. Đúng => bCheckValidPassword = true

            bool bCheckValidPassword = false;
            
            bCheckValidPassword = StoreDAO.checkPassword(senderStore);
            
            if (!bCheckValidPassword)
            {
                sErrorMessage += MessageManager.GenErrorPasswordStoreMessage();
            }

            // 03. Kiểm tra AMOUNT hợp lệ hay không (các loại thẻ sẽ bán)
            //     a. Sai => .. & ErrorMessage += "-Số tiền không hợp lệ"
            //     b. Đúng => b.. = true

            bool bValidAmount = MoneyCardBUS.checkValid(amountBuy);
            if (!bValidAmount)
            {
                sErrorMessage += MessageManager.GenInValidAmountMessage(amountBuy);
            }

            // 04. Kiểm tra AMOUNT_CONFIRM - chứng thực số tiền có đúng hay không
            //     a. Sai => .. false & ErrorMessage += "-Số tiền đăng ký và tiền chứng thực không khớp."
            //     b. Đúng => b.. = true

            bool bValidConfirm = (amountBuy == amountBuyConfirm);
            if (!bValidConfirm)
            {
                sErrorMessage += MessageManager.GenInValidAmountConfirmMessage();
            }

            // 05. Kiểm tra CUSTOMER_PHONE hợp lệ
            //     a. Sai => .. false & ErrorMessage += "-Số điện thoại này không có thật"
            //     b. Đúng => b.. = true

            bool bValidPhone = checkPhoneNumber(newCustomer.Phone);
            if (!bValidPhone)
            {
                sErrorMessage += MessageManager.GenInValidPhoneMessage();
            }


            // Kiểm tra lại: nếu bất kỳ biến nào ở trên có giá trị false thì Tổng hợp lại ErrorMessage
            // và gửi về lại - RETURN cho SENDER_STORE

            //     TẠO PACIFIC_CODE mới

            // 06. Kiểm tra CUSTOMER_PHONE có tồn tại chưa
            //     a. Đã tồn tại: lưu PacificCode mới với customer này
            //     b. Chưa tồn tại:
            //           - tạo mới customer với những thông tin cá nhân chưa có, chỉ có số điện thoại
            //           - lưu PacificCode mới với customer vừa tạo này

            // Gửi 2 tin nhắn cho CUSTOMER & STORE (chưa làm cái này, phải xác định lại cấu trúc tin nhắn mới có thể làm được)

            bool bGetNewPacificCode = false;            
            PacificCode newPacificCode;
            do
            {
                newPacificCode = PacificCodeBUS.GenerateNew();
                // Nếu không bị trùng (trường hợp này rất ít khi xảy ra, tỉ lệ xảy ra là 1/10^11)
                bGetNewPacificCode = !PacificCodeBUS.checkExist(newPacificCode.PacificCode1);
            } while (bGetNewPacificCode == false);

            bool bRegisterSuccess = (
                bCheckValidPassword 
                && bValidAmount 
                && bValidConfirm
                && bValidPhone
                );

            // Lưu:
            // Thông tin khách hàng (nếu là khách hàng mới thì thêm mới)
            // Thông tin PacificCode với người sử dụng là newCustomer

            // Cần viết một lóp có phương thức hoạt động như sau: truyền
            // giá trị PCODE vào sẽ tự động sinh ra lời nhắn chuẩn
            // Lời nhắn này được đọc từ tập tin XML

            // Sau khi tạo thành công sẽ gửi 2 tin nhắn:
            //
            // + 1 tin nhắn gửi cho Store: thông báo là đã tạo thành công + mã số, không phải pacific_code
            // trong ngày đầu tiên mua, store có thể yêu cầu gửi lại mã số cho người dùng (người đã mua số)
            //
            // + 1 tin nhắn gửi cho Customer: thông báo "Bạn vừa mua thành công mã PacificCode có giá trị: xyx.
            // Mã PacificCode này có giá trị đến ngày DD tháng MM năm YYYY"

            // Kiểm tra đúng, thỏa đk mua mới
            if (bRegisterSuccess)
            {
                smsResponse = newCustomer.Phone;
                smsResponse += "*" + MessageManager.GenSucessCreatePacificCodeMessage(newPacificCode.PacificCode1, amountBuy);
            }
            else
            {
                smsResponse = senderStore.Phone;
                smsResponse += "*" + sErrorMessage;
            }

            return smsResponse;
        }

        //internal static string 

        private static bool checkPhoneNumber(string sPhoneNumber)
        {
            // throw new NotImplementedException();
            // Chiều dài số điện thoại cần được định nghĩa lại
            // Cần quy định lại số dt như thế nào thì được gọi là số điện thoại hợp lệ..

            bool bResult = true;

            bResult = bResult && (sPhoneNumber.Length < 13) && (sPhoneNumber.Length >= 10);
            
            for (int i = 0; i < sPhoneNumber.Length; i++)
            {
                bResult = bResult && Char.IsDigit(sPhoneNumber[i]);                
            }

            return bResult;
        }
    }
}