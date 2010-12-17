using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Collections.Generic;

using SimpleLinqToSQL;

[Table(Name = "Customer")]
public class Customer
{
    [Column]
    public int Id { get; set; }
    [Column]
    public string FirstName { get; set; }
    [Column]
    public string LastName { get; set; }
    [Column]
    public string EmailAddress { get; set; }

    public override string ToString()
    {
        return string.Format("{0} {1} \n Email: {2}", FirstName, LastName, EmailAddress);
    }    
}

public class Tester
{
    static void Main()
    {
        DataContext db = new DataContext("Data Source=alex-pc;" +
            "Initial Catalog=mpdb;Integrated Security=True");
        Table<Customer> customers = db.GetTable<Customer>();
                

        List<Customer> lstCustomer = customers.ToList<Customer>();
        var query = from customer in customers
                    where customer.FirstName.Length >= 4
                    select customer;
        foreach (var c in lstCustomer)
        {
            Console.WriteLine(c.ToString());
        }

        MoneyPacificDBDataContext mydb = new MoneyPacificDBDataContext();

        List<SimpleLinqToSQL.Customer> lstCustomerA = mydb.Customers.ToList();
        foreach (var c in lstCustomerA)
        {
            Console.WriteLine(c.FirstName + " " + c.LastName);
        }
    }
}