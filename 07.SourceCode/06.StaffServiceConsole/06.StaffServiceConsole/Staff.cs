using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _06.StaffServiceConsole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.

    public class Staff : IStaff
    {
        public string DisplayStaff()
        {
            return "1. LE THANH DUNG\n 2. TRUONG THUONG HAN\n 3. VO MINH CAT\n 4. ...";
        }

        public DateTime GetBirthday(int staffId)
        {
            DateTime kq;
            
            switch (staffId)
            { 
                case 1:
                    kq = new DateTime(1983, 04, 13);
                    break;
                case 2:
                    kq = new DateTime(1987, 07, 7);
                    break;
                case 3:
                    kq = new DateTime(1983, 01, 06);
                    break;
                default:
                    kq = DateTime.Now;
                    break;
            }

            return kq;
        }
    }
}
