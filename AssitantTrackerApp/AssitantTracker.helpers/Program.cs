using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssitantTracker.helpers
{
    public class ConsoleIO
    {
        public int getShopID()
        {
            string shopString = "";
            int shopID = 0;
            Console.WriteLine("Please enter a ShopID");
            shopString = Console.ReadLine();
            Console.ReadKey();

            shopID = int.Parse(shopString);
            //// needs validation
            return shopID;
        }

        public string getShopName()
        {
            string shopName = "";
            Console.WriteLine("Please enter a ShopName");
            shopName = Console.ReadLine();
            Console.ReadKey();
            return shopName;
        }

        public string getShopTelephone()
        {
            string shopTelephone = "";
            Console.WriteLine("Please enter a ShopTelephone");
            shopTelephone = Console.ReadLine();
            Console.ReadKey();
            return shopTelephone;
        }

    }
}
