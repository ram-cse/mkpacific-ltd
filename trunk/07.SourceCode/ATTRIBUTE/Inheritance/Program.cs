using System;
public class Program
{
    static public void Main()
    {
        Console.WriteLine("aaa");
        user adm = new Admin("admin", "123");

        bool bLogin = adm.Validate("aaa", "123");
        Console.WriteLine("Login: " + bLogin.ToString());

        user manager = new Manager("manager", "456");
        bLogin = manager.Validate("newuser", "abc");
        Console.WriteLine("Login: " + bLogin.ToString());
    }

    partial class Admin
    {
        public string username;
        public string password;

    }

    partial class Admin : user
    {
        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }

    class Manager : user
    {
        public Manager(string username, string password)
            : base("newuser", "abc")
        {

        }
    }

    public abstract class user
    {
        public string username;
        public string password;

        public user(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public user()
        {
        }

        public bool Validate(string username, string password)
        {
            return ((this.username == username) && (this.password == password));
        }
    }


}