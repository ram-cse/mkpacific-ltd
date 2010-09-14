using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.MoneyPacific._03
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Staff" in both code and config file together.
    public class Staff : IStaff
    {
        public string DisplayStaff()
        {
            return "1.Le Thanh Dung\n 2.Truong Thuong Han\n 3.Vo Minh Cat";
        }

        public DateTime GetBirthday(int staffId)
        {
            DateTime ngaySinh;
            switch (staffId)
            {
                case 1:
                    ngaySinh = new DateTime(1983,4,13);
                    break;
                case 2:
                    ngaySinh = new DateTime(1983, 4, 13);
                    break;
                case 3:
                    ngaySinh = new DateTime(1983, 4, 13);
                    break;
                default:
                    ngaySinh = new DateTime(1983, 4, 13);
                    break;
            }
            return ngaySinh;
            
        }
    }
}
