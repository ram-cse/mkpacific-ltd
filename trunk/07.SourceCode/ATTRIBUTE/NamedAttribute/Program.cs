using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamedAttribute
{
    [AttributeUsage(AttributeTargets.All)]
    class RemarkAttribuite : Attribute
    {
        string remarkValue;

        public string supplement;

        public RemarkAttribuite(string comment)
        {
            remarkValue = comment;
            supplement = "NONE";
        }

        public string remark
        {
            get { return remarkValue; }
        }
    }


    [RemarkAttribuite("Lớp này sử dung thuoc tinh Remark. Thuoc tinh Remark "
        + " là thuộc tính LuuY", supplement="Day la gia tri BO SUNG")]
    class UseAttrib
    {
        // ... 
    }

    public class AttribDemo
    {
        public static void Main()
        {
            Type t = typeof(UseAttrib);
            Console.Write("Attribute in " + t.Name + ": ");

            object[] attribs = t.GetCustomAttributes(false);
            foreach (object o in attribs)
            {
                Console.Write(o);
            }

            Console.WriteLine("\nRemark: ");

            Type tRemAtt = typeof(RemarkAttribuite);
            // Lấy các thuộc tính của t ra
            // hiển thị tất cả các thuộc tính đó ra ngoài màn hình
            RemarkAttribuite ra = (RemarkAttribuite)Attribute.GetCustomAttribute(t, tRemAtt);
            Console.WriteLine(ra.remark);
            Console.WriteLine(ra.supplement);
        }
    }
}

/*
 * using System;  
using System.Reflection; 
  
[AttributeUsage(AttributeTargets.All)] 
class RemarkAttribute : Attribute { 
  string remarkValue; // underlies remark property 
 
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
}  
 
[RemarkAttribute("This class uses an attribute.", 
                 supplement = "This is additional info.")] 
class UseAttrib { 
  // ... 
} 
 
public class NamedParamDemo {  
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
  }  
} 

//*/