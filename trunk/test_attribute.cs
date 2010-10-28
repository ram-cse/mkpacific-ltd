
#region 06 Attribute in class inheritance

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 06 Attribute in class inheritance

using System;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

public class Starter {
    public static void Main() {
        GenericIdentity g = new GenericIdentity("Person1");
        GenericPrincipal p = new GenericPrincipal(g,new string[] { "Manager" });
        Thread.CurrentPrincipal = p;
        MyClass.MethodA();
        YClass.MethodA();
    }
}

[PrincipalPermission(SecurityAction.Demand, Role = "Manager")]
public class MyClass {
    static public void MethodA() {
        Console.WriteLine("MyClass.MethodA");
    }
}

[PrincipalPermission(SecurityAction.Demand,Role = "Accountant")]
public class YClass : MyClass {

    static public void MethodB() {
        Console.WriteLine("MyClass.MethodB");
    }
}
#endregion

#region 07 Defining New Attribute Classes

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 07 Defining New Attribute Classes
using System;
using System.Diagnostics;
using System.Reflection;
   
[AttributeUsage(AttributeTargets.Class)]
public class ClassAuthorAttribute : Attribute
{
    private string AuthorName;
   
    public ClassAuthorAttribute(string AuthorName)
    {
        this.AuthorName = AuthorName;
    }
   
    public string Author
    {
        get
        {
            return AuthorName;
        }
    }
}
   
[ClassAuthor("AA")]
public class TestClass
{
    public void Method1()
    {
        Console.WriteLine("Hello from Method1!");
    }
   
    [Conditional("DEBUG")]
    public void Method2()
    {
        Console.WriteLine("Hello from Method2!");
    }
   
    public void Method3()
    {
        Console.WriteLine("Hello from Method3!");
    }
   
}
   
public class MainClass
{
    public static void Main()
    {
        TestClass MyTestClass = new TestClass();
   
        MyTestClass.Method1();
        MyTestClass.Method2();
        MyTestClass.Method3();
   
        object []  ClassAttributes;
        MemberInfo TypeInformation;
   
        TypeInformation = typeof(TestClass);
        ClassAttributes = TypeInformation.GetCustomAttributes(typeof(ClassAuthorAttribute), false);
        if(ClassAttributes.GetLength(0) != 0)
        {
            ClassAuthorAttribute ClassAttribute;
   
            ClassAttribute = (ClassAuthorAttribute)(ClassAttributes[0]);
            Console.WriteLine("Class Author: {0}", ClassAttribute.Author);
        }
    }
}
#endregion

#region 08 Use AttributeUsage
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 08 Use AttributeUsage
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct,Inherited = false)]
public class ClassVersionAttribute : System.Attribute {
    public ClassVersionAttribute(string target) : this(target, target) {
    }

    public ClassVersionAttribute(string target,string current) {
        m_TargetVersion = target;
        m_CurrentVersion = current;
    }

    private bool m_UseCurrentVersion = false;
    public bool UseCurrentVersion {
        set {
            if (m_TargetVersion != m_CurrentVersion) {
                m_UseCurrentVersion = value;
            }
        }
        get {
            return m_UseCurrentVersion;
        }
    }

    private string m_CurrentName;
    public string CurrentName {
        set {
            m_CurrentName = value;
        }
        get {
            return m_CurrentName;
        }
    }

    private string m_TargetVersion;
    public string TargetVersion {
        get {
            return m_TargetVersion;
        }
    }

    private string m_CurrentVersion;
    public string CurrentVersion {
        get {
            return m_CurrentVersion;
        }
    }
}

 
#endregion

#region 09 Use a property as a named attribute parameter
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 09 Use a property as a named attribute parameter
/*
C#: The Complete Reference 
by Herbert Schildt 

Publisher: Osborne/McGraw-Hill (March 8, 2002)
ISBN: 0072134852
*/


// Use a property as a named attribute parameter. 
  
using System;  
using System.Reflection; 
  
[AttributeUsage(AttributeTargets.All)] 
class RemarkAttribute : Attribute { 
  string remarkValue; // underlies remark property 
 
  int pri_priority; // underlies priority property 
 
  public string supplement; // this is a named parameter 
 
  public RemarkAttribute(string comment) { 
    remarkValue = comment; 
    supplement = "None"; 
  } 
 
  public string remark { 
    get { 
      return remarkValue; 
    } 
  } 
 
  // Use a property as a named parameter. 
  public int priority { 
    get { 
      return pri_priority; 
    } 
    set { 
      pri_priority = value; 
    } 
  } 
}  
 
[RemarkAttribute("This class uses an attribute.", 
                 supplement = "This is additional info.", 
                 priority = 10)] 
class UseAttrib { 
  // ... 
} 
 
public class NamedParamDemo11 {  
  public static void Main() {  
    Type t = typeof(UseAttrib); 
 
    Console.Write("Attributes in " + t.Name + ": "); 
 
    object[] attribs = t.GetCustomAttributes(false);  
    foreach(object o in attribs) { 
      Console.WriteLine(o); 
    } 
 
    // Retrieve the RemarkAttribute. 
    Type tRemAtt = typeof(RemarkAttribute); 
    RemarkAttribute ra = (RemarkAttribute) 
          Attribute.GetCustomAttribute(t, tRemAtt); 
 
    Console.Write("Remark: "); 
    Console.WriteLine(ra.remark); 
 
    Console.Write("Supplement: "); 
    Console.WriteLine(ra.supplement); 
 
    Console.WriteLine("Priority: " + ra.priority); 
  }  
} 
#endregion

#region 10 Demonstrate the Conditional attribute
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 10 Demonstrate the Conditional attribute
#define TRIAL 
 
using System; 
using System.Diagnostics; 
 
public class TestAno { 
 
  [Conditional("TRIAL")]  
  void trial() { 
    Console.WriteLine("Trial version, not for distribution."); 
  } 
 
  [Conditional("RELEASE")]  
  void release() { 
    Console.WriteLine("Final release version."); 
  } 
 
  public static void Main() { 
    TestAno t = new TestAno(); 
 
    t.trial(); // call only if TRIAL is defined 
    t.release(); // called only if RELEASE is defined 
  } 
}

#endregion

#region 11 Define contant and use it in Conditional attribute
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 11 	Define contant and use it in Conditional attribute
#define LOG

using System;
using System.IO;
using System.Diagnostics;


class Starter {
    static void Main() {
        LogInfo(new StreamWriter(@"c:\logfile.txt"));
    }

    [Conditional("LOG")]
    private static void LogInfo(StreamWriter sr) {
        // write information to log file
    }
}

#endregion

#region 12  Demonstrate the Obsolete attribute
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 12 Demonstrate the Obsolete attribute
 
using System; 
 
public class TestAno1 { 
 
  [Obsolete("Use myMeth2, instead.")]  
  static int myMeth(int a, int b) { 
    return a / b; 
  } 
 
  // Improved version of myMeth. 
  static int myMeth2(int a, int b) { 
    return b == 0 ? 0 : a /b; 
  } 
 
  public static void Main() { 
    Console.WriteLine("4 / 3 is " + TestAno1.myMeth(4, 3)); 
 
    Console.WriteLine("4 / 3 is " + TestAno1.myMeth2(4, 3));  
  } 
}
#endregion

#region 13 Illustrates use of the Obsolete attribute
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 13 Illustrates use of the Obsolete attribute
/*
illustrates use of the Obsolete attribute
*/

using System;

public class Example17_1 
{
  // warn the user that Method1 is obsolete
  [Obsolete("Method1 has been replaced by NewMethod1", false)]
  public static int Method1()
  {
    return 1;
  }

  // throw an error if the user tries to use Method2
  [Obsolete("Method2 has been replaced by NewMethod2", true)]
  public static int Method2()
  {
    return 2;
  }

  public static void Main() 
  {
    Console.WriteLine(Method1());
    Console.WriteLine(Method2());
  }
}

#endregion

#region 14 Compiles into a library defining the RamdomSupplier attribute and the RandomMethod attribute
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 14 .	Compiles into a library defining the RamdomSupplier attribute and the RandomMethod attribute
/*
Mastering Visual C# .NET
by Jason Price, Mike Gunderloy

Publisher: Sybex;
ISBN: 0782129110
*/

/*
  Example17_5a compiles into a library defining the RamdomSupplier attribute
  and the RandomMethod attribute
*/

using System;

// declare an attribute named RandomSupplier
[AttributeUsage(AttributeTargets.Class)]
public class RandomSupplier : Attribute
{
  public RandomSupplier()
  {
    // doesn't have to do anything
    // we just use this attribute to mark selected classes
  }
}

// declare an attribute named RandomMethod
[AttributeUsage(AttributeTargets.Method )]
public class RandomMethod : Attribute
{
  public RandomMethod()
  {
    // doesn't have to do anything
    // we just use this attribute to mark selected methods
  }
}
//===================================================
/*
  Example17_5b implements one class to supply random numbers
*/

// flag the class as a random supplier
[RandomSupplier]
public class OriginalRandom
{
  [RandomMethod]
  public int GetRandom()
  {
    return 5;
  }
}

//===================================================
/*
  Example17_5c implements one class to supply random numbers
*/

using System;

// flag the class as a random supplier
[RandomSupplier]
public class NewRandom
{
  [RandomMethod]
  public int ImprovedRandom()
  {
    Random r = new Random();
    return r.Next(1, 100);
  }
}

// this class has nothing to do with random numbers
public class AnotherClass
{
  public int NotRandom()
  {
    return 1;
  }
}
//===================================================
/*
  Example17_5d illustrates runtime type discovery
*/

using System;
using System.Reflection;

class Example17_5d 
{

  public static void Main(string[] args) 
  {

    RandomSupplier rs;
    RandomMethod rm;

    // iterate over all command-line arguments
    foreach(string s in args)
    {
      Assembly a = Assembly.LoadFrom(s);

      // Look through all the types in the assembly
      foreach(Type t in a.GetTypes())
      {
        rs = (RandomSupplier) Attribute.GetCustomAttribute(
         t, typeof(RandomSupplier));
        if(rs != null)
        {
          Console.WriteLine("Found RandomSupplier class {0} in {1}",
           t, s);
          foreach(MethodInfo m in t.GetMethods())
          {
            rm = (RandomMethod) Attribute.GetCustomAttribute(
             m, typeof(RandomMethod));
            if(rm != null)
            {
              Console.WriteLine("Found RandomMethod method {0}"
               , m.Name );
            }
          }        
        }
      }
    }

  }

}

#endregion

#region 15 Shows the use of assembly attributes
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 15 	Shows the use of assembly attributes
/*
shows the use of assembly attributes
*/

using System;
using System.Reflection;
using System.Windows.Forms;

[assembly:AssemblyVersionAttribute("1.0.0.0")]
[assembly:AssemblyTitleAttribute("Example 16.1")]

public class Example16_1 
{
    string privateString;

    public string inString 
    {
        get 
        {
            return privateString;
        }
        set
        {
            privateString = inString;
        }
    }

    public void upper(out string upperString)
    {
        upperString = privateString.ToUpper();
    }

    public static void Main() 
    {
    }
}
#endregion

#region 16 How to create a custom attribute
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 16 	How to create a custom attribute
using System;

public class Example17_3 
{

    public static void Main() 
    {

        UnitTest u;

        // retrieve and display the UnitTest attributes of the classes
        Console.Write("Class1 UnitTest attribute: ");
        u = (UnitTest) Attribute.GetCustomAttribute(
            typeof(Class1), typeof(UnitTest));
        Console.WriteLine(u.Written());
        Console.Write("Class2 UnitTest attribute: ");
        u = (UnitTest) Attribute.GetCustomAttribute(
            typeof(Class2), typeof(UnitTest));
        Console.WriteLine(u.Written());

    }

}


// declare an attribute named UnitTest
// UnitTest.Written is either true or false
public class UnitTest : Attribute
{
    bool bWritten;

    public bool Written()
    {
        return bWritten;
    }

    public UnitTest(bool Written)
    {
        bWritten = Written;
    }
}

// apply the UnitTest attribute to two classes
[UnitTest(true)]
public class Class1
{
}

[UnitTest(false)]
public class Class2
{
}

#endregion

#region 17 Illustrates use of the Conditional attribute
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 17 Illustrates use of the Conditional attribute
#define USE_METHOD_1

using System;
using System.Diagnostics;

public class Example17_2 
{
    [Conditional("USE_METHOD_1")]
    public static void Method1()
    {
        Console.WriteLine("In Method 1");
    }

    public static void Main() 
    {

        Console.WriteLine("In Main");
        Method1();
    }
}
#endregion

#region 18 Illustrates the GetCustomAttributes method
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 18 Illustrates the GetCustomAttributes method	
using System;


public class Example17_4 
{

    public static void Main() 
    {

        // retrieve all attributes of Class1
        Console.WriteLine("Class1 attributes: ");
        object[] aAttributes = Attribute.GetCustomAttributes(
            typeof(Class1));
        foreach (object attr in aAttributes)
        {
            Console.WriteLine(attr);
        }

    }

}


// declare an attribute named UnitTest
// UnitTest.Written is either true or false
public class UnitTest : Attribute
{
    bool bWritten;

    public bool Written()
    {
        return bWritten;
    }

    public UnitTest(bool Written)
    {
        bWritten = Written;
    }
}


// declare another attribute named LifeCycle
// LifeCycle.Stage returns a string
public class LifeCycle : Attribute
{
    string sStage;

    public string Stage()
    {
        return sStage;
    }

    public LifeCycle(string Stage)
    {
        sStage = Stage;
    }
}

// apply the attribues to a class
[UnitTest(true)]
[LifeCycle("Coding")]
public class Class1
{
}

#endregion

#region 19 demonstrates the flags attribute of an enumeration
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
// 19 demonstrates the flags attribute of an enumeration
using System;


[Flags]
public enum Contribution {
    Pension = 0x01,
    ProfitSharing = 0x02,
    CreditBureau = 0x04,
    SavingsPlan = 0x08,

    All = Pension | ProfitSharing | CreditBureau | SavingsPlan
}

public class Employee {
    private Contribution prop_contributions;
    public Contribution contributions {
        get {
            return prop_contributions;
        }
        set {
            prop_contributions = value;
        }
    }
}

public class Starter {
    public static void Main() {
        Employee bob = new Employee();
        bob.contributions = Contribution.ProfitSharing | Contribution.CreditBureau;
        if ((bob.contributions & Contribution.ProfitSharing)== Contribution.ProfitSharing) {
            Console.WriteLine("Bob enrolled in profit sharing");
        }
    }
}
#endregion


