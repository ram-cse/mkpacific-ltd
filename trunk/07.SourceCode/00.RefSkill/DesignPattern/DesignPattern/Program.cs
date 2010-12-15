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

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public int IDRole
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
}
public class MainClass
{
    public static void Main()
    {
        List<Employee> people = new List<Employee> {
              new Employee  { ID = 1, IDRole = 1, LastName = "A", FirstName = "B"},
              new Employee  { ID = 2, IDRole = 2, LastName = "G", FirstName = "T"}
            };
        var query = from p in people
                    where p.LastName.Length == 4
                    select p.LastName;

        List<string> names = query.ToList<string>();
        Console.Write(names);
    }
}
