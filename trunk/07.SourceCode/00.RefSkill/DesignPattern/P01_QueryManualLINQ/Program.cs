using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Employee
{

    int _id;
    int _idRole;
    string _lastName;
    string _firstName;

    public int IdRole
    {
        get { return _idRole; }
        set { _idRole = value; }
    }  

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }    

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }


}

public class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Manual LINQ");
        List<Employee> nhanvien = new List<Employee>{
            new Employee{Id = 1
                , IdRole = 1
                , LastName = "Le Thanh"
                , FirstName = "Dung"
            }
            , new Employee{
                Id = 2
                , IdRole = 2
                , LastName = "Truong Thuong"
                , FirstName = "Quoc"
            }
            , new Employee{
                Id = 3
                , IdRole = 2
                , LastName = "Truong Thuong"
                , FirstName = "Minh"
            }
            , new Employee{
                Id = 3
                , IdRole = 2
                , LastName = "Truong Thuong"
                , FirstName = "Anh"
            }
            , new Employee{
                Id = 3
                , IdRole = 2
                , LastName = "Truong Thuong"
                , FirstName = "KyLan"
            }
        };

        var query = from q in nhanvien
                    where q.FirstName.Length >= 4
                    select q.FirstName;
        List<string> names = query.ToList<string>();
        foreach (string n in names)
        {
            Console.WriteLine(n);
        }

    }
}

