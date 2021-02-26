using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace task2 {
    class Program {
        static void Main() {

            List<string> Strings = new List<string>(){"FOCUSRS10", "DRIVER"};



            string Name = "0xb6b731d0";

            uint Hash = uint.Parse(Name.Substring(2), NumberStyles.AllowHexSpecifier);

            Console.WriteLine("uint Hash: " + Hash);


                int hash = 0;
                hash ^= (int)(Hash * 397);
                //hash ^= (int)(GetValueHashCode() * 397);

                // //if (Strings.Count == 0)
                // {
                //     hash ^= (int)(GetValueHashCode() * 397);
                // }

                hash ^= (int)(GetStringsHashCode(Strings) * 397);

            Console.WriteLine("int hash: " + hash);

        }

        public static int GetStringsHashCode(List<string> Strings)
        {
            int res = 0x2D2816FE;
            foreach (var item in Strings)
            {
                res = res * 31 + (item?.GetHashCode() ?? 0);
            }
            return res;
        }


    }
}
