using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPlugin
{
    /// <summary>
    /// MONEY PACIFIC PLUGIN
    /// COMMAND
    /// </summary>
    #region MAIN
    class Program
    {
        static void Main(string[] args)
        {
            BuyCommandPlugin b = new BuyCommandPlugin();
            //Type t = b.GetType();
            Type t = Type.GetType("MPPlugin.BuyCommandPlugin");
            AbsMyPlugin myObj = (AbsMyPlugin) Activator.CreateInstance(t);
            myObj.ThongBao();
            
        }
    }
    #endregion MAIN

    #region SERVICES
    public abstract class AbsMyPlugin
    { 
        protected abstract AbsMyPlugin CreateObject();
        public abstract void ThongBao();
    }

    public class BuyCommandPlugin : AbsMyPlugin
    {
        protected  override AbsMyPlugin CreateObject()
        {
            return new BuyCommandPlugin();
        }

        public override void ThongBao()
        {
            Console.WriteLine("Buying...");
        }

    }

    public class SellCommandPlugin : AbsMyPlugin
    {
        protected override AbsMyPlugin CreateObject()
        {
            return new SellCommandPlugin();
        }

        public override void ThongBao()
        {
            Console.WriteLine("Selling...");
        }
    }

    #endregion SERVICES

}
