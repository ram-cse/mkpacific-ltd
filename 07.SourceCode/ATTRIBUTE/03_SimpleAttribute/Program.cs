using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_SimpleAttribute
{
    [AttributeUsage(AttributeTargets.All)]
    class RemarkAttribuite : Attribute
    {
        string remarkValue;
        public RemarkAttribuite(string comment)
        {
            remarkValue = comment;
        }

        public string remark
        {
            get { return remarkValue; }
        }
    }

    
    [RemarkAttribuite("Lớp này sử dung thuoc tinh Remark. Thuoc tinh Remark "
        + " là thuộc tính LuuY" )]
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
        }
    }
}

