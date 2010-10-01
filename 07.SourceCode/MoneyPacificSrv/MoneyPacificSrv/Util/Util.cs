
namespace MoneyPacificSrv.Util
{
    public class Util
    {
        internal static string removeSpaceChar(string sInput)
        {
            sInput = sInput.Trim();
            string sResult = "";
            foreach (char c in sInput)
            {
                if (c != ' ')
                {
                    sResult += "" + c;
                }
            }
            return sResult;
        }
    }
}