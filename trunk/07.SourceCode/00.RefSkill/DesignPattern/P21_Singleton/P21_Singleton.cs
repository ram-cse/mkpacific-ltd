using System;
namespace GOF
{
    class P21_UtilitySingleton
    {
        public static void Main()
        {
            Singleton s1 = Singleton.Instance;
            s1.Name = "ABC DEF";

            Singleton s2 = Singleton.Instance;            
            Console.WriteLine(s2.Name);

        }
    }

    class Singleton
    {
        private static Singleton _singleton;
        static readonly object padlock = new object();
        private string _name;

        public Singleton()
        { }

        public static Singleton Instance
        {
            get
            {
                // Không tốt cho performance vì làm chậm chương trình
                lock (padlock)
                {
                    if (_singleton == null)
                    {
                        _singleton = new Singleton();
                    }
                    return _singleton;
                }
            }
        }

        public string Name
        {
            set { this._name = value; }
            get { return this._name; }
        }
    }

}