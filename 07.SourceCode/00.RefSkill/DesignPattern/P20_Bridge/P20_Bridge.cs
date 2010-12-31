using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P20_Bridge
{
    class P20_Bridge
    {
        static void Main(string[] args)
        {
            CustomersManager customers = new CustomersManager("SV Tieu bieu 2011");
            customers.Data = new CustomersData();

            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();

            customers.Add("Le Thanh");
            customers.ShowAll();
        }
    }


    class CustomersBase
    {
        private DataObject _dataObject;
        protected string group;

        public CustomersBase(string group)
        {
            this.group = group;
        }

        public DataObject Data
        {
            set { _dataObject = value; }
            get { return _dataObject; }
        }

        public virtual void Next()
        {
            _dataObject.NextRecord();
        }

        public virtual void Prior()
        {
            _dataObject.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            _dataObject.AddRecord(customer);
        }

        public virtual void Delete(string customer)
        {
            _dataObject.DeleteRecord(customer);
        }

        public virtual void Show()
        {
            _dataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            Console.WriteLine("Customer Group: " + group);
            _dataObject.ShowAllRecords();
        }
    }

    class CustomersManager : CustomersBase
    {
        public CustomersManager(string group)
            : base(group)
        { }

        public override void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------------");
        }
    }


    abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();
    }

    class CustomersData : DataObject
    {
        private List<string> lstCustomer = new List<string>();
        private int _current = 0;

        public CustomersData()
        {
            this.lstCustomer.Add("Jim Jones");
            this.lstCustomer.Add("Samual Jackson");
            this.lstCustomer.Add("Allen Good");
            this.lstCustomer.Add("Ann Stills");
            this.lstCustomer.Add("Lisa Giolani");
        }

        public override void NextRecord()
        {
            if (_current <= lstCustomer.Count - 1)
            {
                _current++;
            }
        }

        public override void PriorRecord()
        {
            if (_current > 0)
            {
                _current++;
            }
        }

        public override void AddRecord(string customer)
        {
            this.lstCustomer.Add(customer);
        }

        public override void DeleteRecord(string customer)
        {
            this.lstCustomer.Remove(customer);
        }

        public override void ShowRecord()
        {
            Console.WriteLine(lstCustomer[_current]);
        }
        public override void ShowAllRecords()
        {
            foreach (string customer in lstCustomer)
            {
                Console.WriteLine(" " + customer);
            }
        }
    }

}
