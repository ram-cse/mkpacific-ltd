using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using Merchant.Helper;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
namespace Merchant.Models
{

    #region Models
    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public class ChangePasswordModel
    {
        [Required(ErrorMessage="*")]
        [DataType(DataType.Password)]
        [DisplayName("Current password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage="*")]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("New password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage="*")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm new password")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessage="*")]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage="*")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }

    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public class RegisterModel
    {
        [Required(ErrorMessage="*")]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("City")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("ATM")]
        public string ATM { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Bank")]
        public string Bank { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("CompanyName")]
        public string CompanyName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Tax Code")]
        public string TaxCode { get; set; }
        
      
        [DisplayName("Account Type")]
        public int AccountType { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("ZipCode")]
        public string ZipCode { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Address1")]
        public string Address1 { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Address2")]
        public string Address2 { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Country")]
        public string Country { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Status")]
        public int Status { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Verify Code")]
        public string VerifyCode { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("State")]
        public string State { get; set; }

    }
    #endregion

    #region Services
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        int ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        MembershipCreateStatus pCreateUser(string FirstName, string LastName, string Username, string Password, string Email, string Phone);
        MembershipCreateStatus bCreateUser(string CompanyName, string Username, string Password, string Email, string TaxCode, string Phone);
        
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;
        public MPWebmasterEntities StoreDb = new MPWebmasterEntities();

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public int ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            //check for webmaster
            var check = from m in StoreDb.Webmasters
                        where (m.Username == userName && m.Password == password)
                        select m;

            //check for user problem
            var checkUserProplem = from p in StoreDb.BuyCustomers
                                   where (p.BuyingId == userName && p.Password == password)
                                   select p;
            //var check for Money Pacific Admin here

            var checkMPAdmin = from admin in StoreDb.MPAdmins
                               where (admin.Username == userName && admin.Password == password)
                               select admin;
            
            if (check.Count() == 1)// Check Webmaster account ton tai
            {
                if (check.SingleOrDefault().Status == 0)// staus 0:chua active, -1: disable; 1 :enable
                    return 2;// account chua active
                else if (check.SingleOrDefault().Status == -1)
                    return 5;//account da bi disable
                else
                    return 1; //ok for webmaster
            }
            else if (checkUserProplem.Count() == 1) {

                return 3; // ok for Customer Login
            }
            else if(checkMPAdmin.Any())
            {
                return 4;//ok for Money Pacific Admin

            }
            else
                return 0; // username hoac password khong dung.
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public MembershipCreateStatus pCreateUser(string FirstName, string LastName, string Username, string Password, string Email, string Phone)
        {
            if (String.IsNullOrEmpty(FirstName)) throw new ArgumentException("Value cannot be null or empty.", "FirstName");
            if (String.IsNullOrEmpty(LastName)) throw new ArgumentException("Value cannot be null or empty.", "LastName");
            if (String.IsNullOrEmpty(Username)) throw new ArgumentException("Value cannot be null or empty.", "UserName");
            if (String.IsNullOrEmpty(Email)) throw new ArgumentException("Value cannot be null or empty.", "Email");
            if (String.IsNullOrEmpty(Password)) throw new ArgumentException("Value cannot be null or empty.", "Password");

            MembershipCreateStatus status;

            var checkUser = from m in StoreDb.Webmasters
                            where (m.Username == Username)
                            select m;
            if (checkUser.Count() != 0)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return status;
            }
            var checkEmail =  from m in StoreDb.Webmasters
                              where(m.Email == Email)
                              select m;
            if (checkEmail.Count() != 0)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return status;
            }

            Webmaster web = new Webmaster();
            web.Username = Username;
            web.FirstName = FirstName;
            web.LastName = LastName;
            web.Password = Password;
            web.Phone = Phone;
            web.Email = Email;
            web.Status = 0;
            web.DateJoin = DateTime.Now;
            web.AccountType = 0; //0 la personal account  1 la bussiness account

            string hash = MPHash.hash(Username+Password);
            web.VerifyCode = hash;

            StoreDb.Webmasters.AddObject(web);
            StoreDb.SaveChanges();
            status = MembershipCreateStatus.Success;
            
            //Tao bang Earning tuong ung
            var checknow = StoreDb.Webmasters.Single(m=>m.Username == Username);

            Earning e = new Earning();
            e.Amount = 0;
            e.Currency = "VND";
            e.WebmasterId = checknow.Id;
            e.Status = 0;//keep money
            StoreDb.Earnings.AddObject(e);
            StoreDb.SaveChanges();
            //tao bang Payment tuong ung
            Payment p = new Payment();
            p.Address = "";
            p.Amount = 0;
            p.City = "";
            p.DatePayment = null;
            p.Email = "";
            p.LastPayment = null;
            p.Name = "";
            p.Phone = "";
            p.TypePayment = 0;
            p.Ward = "";
            p.WebmasterId = checknow.Id;
            StoreDb.Payments.AddObject(p);
            StoreDb.SaveChanges();


            //tao Role cho user nay
            string[] webmaster = new string[] { "Webmaster"};
            string[] user = new string[] {Username };
            MyRoleProvider role = new MyRoleProvider();
            role.AddUsersToRoles(user,webmaster);

            //tao Setting table cho webmaster nay
            int webmt = StoreDb.Webmasters.Single(w => w.Username == Username).Id;
            Setting set = new Setting();
            set.WebmasterId = webmt;
            set.Language = "EN";//default is EN
            StoreDb.Settings.AddObject(set);
            StoreDb.SaveChanges();

            return status;

 
        }
        public MembershipCreateStatus bCreateUser(string CompanyName, string Username, string Password, string Email, string TaxCode, string Phone)
        {
            if (String.IsNullOrEmpty(CompanyName)) throw new ArgumentException("Value cannot be null or empty.", "CompanyName");
            if (String.IsNullOrEmpty(Username)) throw new ArgumentException("Value cannot be null or empty.", "UserName");
            if (String.IsNullOrEmpty(Email)) throw new ArgumentException("Value cannot be null or empty.", "Email");
            if (String.IsNullOrEmpty(Password)) throw new ArgumentException("Value cannot be null or empty.", "Password");

            MembershipCreateStatus status;

            var checkUser = from m in StoreDb.Webmasters
                            where (m.Username == Username)
                            select m;
            if (checkUser.Count() != 0)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return status;
            }
            var checkEmail = from m in StoreDb.Webmasters
                             where (m.Email == Email)
                             select m;
            if (checkEmail.Count() != 0)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return status;
            }

            Webmaster web = new Webmaster();
            web.Username = Username;
            web.FirstName = CompanyName;
            web.CompanyName = CompanyName;
            web.Password = Password;
            web.Phone = Phone;
            web.Email = Email;
            web.Status = 0;
            web.DateJoin = DateTime.Now;
            web.AccountType = 1; //0 la personal account  1 la bussiness account
            web.TaxCode = TaxCode;

            string hash = MPHash.hash(Username + Password);
            web.VerifyCode = hash;

            StoreDb.Webmasters.AddObject(web);
            StoreDb.SaveChanges();

            status = MembershipCreateStatus.Success;

            //Tao bang Earning tuong ung
            var checknow = StoreDb.Webmasters.Single(m => m.Username == Username);

            Earning e = new Earning();
            e.Amount = 0;
            e.Currency = "VND";
            e.WebmasterId = checknow.Id;
            e.Status = 0;//keep money
            StoreDb.Earnings.AddObject(e);
            StoreDb.SaveChanges();

            //tao Role cho user nay
            string[] webmaster = new string[] { "Webmaster" };
            string[] user = new string[] { Username };
            MyRoleProvider role = new MyRoleProvider();
            role.AddUsersToRoles(user, webmaster);

            //tao Setting table cho webmaster nay
            int webmt = StoreDb.Webmasters.Single(w => w.Username == Username).Id;
            Setting set = new Setting();
            set.WebmasterId = webmt;
            set.Language = "EN";//default is EN
            StoreDb.Settings.AddObject(set);
            StoreDb.SaveChanges();


            return status;

        }
    
        


        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.

            var check = StoreDb.Webmasters.Single(m=>m.Username == userName);
            if (check.Password == oldPassword)
            {
                check.Password = newPassword;
                StoreDb.SaveChanges();
                return true;
            }
            return false;

      



        }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
            
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion

    #region Validation
    public static class AccountValidation
    {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "USERNAME_ALREADY_EXISTS._PLEASE_ENTER_A_DIFFERENT_USER_NAME.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        public static string User { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' and '{1}' do not match.";
        private readonly object _typeId = new object();

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Object.Equals(originalValue, confirmValue);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' must be at least {1} characters long.";
        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        public ValidatePasswordLengthAttribute()
            : base(_defaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }
    }
    #endregion

}
