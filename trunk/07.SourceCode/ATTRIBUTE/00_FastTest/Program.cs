using System;
using System.Reflection;
using System.Collections;

public class IsTestedAttribute : Attribute
{
    public override string ToString()
    {
        return "Is Tested";
    }
}

// The AuthorAttribute class is a user-defined attribute class.
// It can be applied to classes and struct declarations only.
// It takes one unnamed string argument (the author's name).
// It has one optional named argument Version, which is of type int.
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class AuthorAttribute : Attribute
{
    // This constructor specifies the unnamed arguments to the attribute class.
    public AuthorAttribute(string name)
    {
        this.name = name;
        this.version = 0;
    }

    // This property is readonly (it has no set accessor)
    // so it cannot be used as a named argument to this attribute.
    public string Name
    {
        get
        {
            return name;
        }
    }

    // This property is read-write (it has a set accessor)
    // so it can be used as a named argument when using this
    // class as an attribute class.
    public int Version
    {
        get { return version; }
        set { version = value; }
    }

    public override string ToString()
    {
        string value = "Author : " + Name;
        if (version != 0)
        {
            value += " Version : " + Version.ToString();
        }
        return value;
    }

    private string name;
    private int version;
}

// Here you attach the AuthorAttribute user-defined custom attribute to 
// the Account class. The unnamed string argument is passed to the 
// AuthorAttribute class's constructor when creating the attributes.
[Author("Joe Programmer")]
class Account
{
    // Attach the IsTestedAttribute custom attribute to this method.
    [IsTested]
    public void AddOrder(Order orderToAdd)
    {
        orders.Add(orderToAdd);
    }

    private ArrayList orders = new ArrayList();
}

// Attach the AuthorAttribute and IsTestedAttribute custom attributes 
// to this class.
// Note the use of the 'Version' named argument to the AuthorAttribute.
[Author("Jane Programmer", Version = 2), IsTested()]
class Order
{
    // add stuff here ...
}

class MainClass
{
    private static bool IsMemberTested(MemberInfo member)
    {
        foreach (object attribute in member.GetCustomAttributes(true))
        {
            if (attribute is IsTestedAttribute)
            {
                return true;
            }
        }
        return false;
    }

    private static void DumpAttributes(MemberInfo member)
    {
        Console.WriteLine("Attributes for : " + member.Name);
        foreach (object attribute in member.GetCustomAttributes(true))
        {
            Console.WriteLine(attribute);
        }
    }

    public static void Main()
    {

        string s1 = "abc def";
        string s2 = null;
        
        Console.WriteLine("so sanh chuoi: " + s1.Equals(s2));

        // display attributes for Account class
        DumpAttributes(typeof(Account));

        // display list of tested members
        foreach (MethodInfo method in (typeof(Account)).GetMethods())
        {
            if (IsMemberTested(method))
            {
                Console.WriteLine("Member {0} is tested!", method.Name);
            }
            else
            {
                Console.WriteLine("Member {0} is NOT tested!", method.Name);
            }
        }
        Console.WriteLine();

        // display attributes for Order class
        DumpAttributes(typeof(Order));

        // display attributes for methods on the Order class
        foreach (MethodInfo method in (typeof(Order)).GetMethods())
        {
            if (IsMemberTested(method))
            {
                Console.WriteLine("Member {0} is tested!", method.Name);
            }
            else
            {
                Console.WriteLine("Member {0} is NOT tested!", method.Name);
            }
        }
        Console.WriteLine();
    }
}



/*
using System;


public class Program
{
    public static void Main()
    {
        User admin = new User();
        nguoidung a = new nguoidung();
        a.KiemTraHangHoa();

        admin.LogOn();
        admin.ChangePassword();
    }
}

class AuthorizeAttribute : Attribute
{
    public string Roles { get; set; }
}

[AttributeUsage(AttributeTargets.Method)]
public class QuyenThucThiAttribute : Attribute
{
    public string TenQuyen { get; set; }
}

public class nguoidung
{
    [QuyenThucThi(TenQuyen = "Admin")]
    public void KiemTraHangHoa()
    {
        Console.WriteLine("Kiem tra hang hoa!..");
    }

}


public class User
{ 
    //public string Roles;


    public void LogOn()
    {
        Console.WriteLine("logining to system!.");
        
    }

    public void SetAdmin()
    { 

    }

    [Authorize(Roles = "Administrator")]
    public void ChangePassword()
    {
        Console.WriteLine("change password successful!.");
    }
}

//*/