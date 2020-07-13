using System;
using System.Collections.Generic;

namespace PromotionEngineConsole
{
    class PromotionEngine
    {
        //ip format
        //A 3
        //B 5
        //C 1
        //D 1
        static void Main(string[] args)
        {
            string ip = string.Empty;
            List<string> ipList = new List<string>();
            while (!string.IsNullOrWhiteSpace(ip = Console.ReadLine()))
            {
                ipList.Add(ip);
            }
            PromotionEngine obj = new PromotionEngine();
            SKUModel sKUModelObj = obj.mapToSKU(ipList);

            if(!string.IsNullOrWhiteSpace(sKUModelObj.ErrorMessage))
            {
                Console.WriteLine(sKUModelObj.ErrorMessage);
            }
        }

        // Parse and Validate Input 
        private SKUModel mapToSKU(List<string> ip)
        {
            SKUModel sKUModelObj = new SKUModel();
            if (ip != null && ip.Count > 0)
            {
                sKUModelObj.ErrorMessage = "Invalid Input ! Please Enter a Valid Input";
                return sKUModelObj;
            }
            else
            {
                foreach (var item in ip)
                {
                    if (item.Contains("A"))
                    {
                        sKUModelObj.QuatityOfA = int.Parse(item.Split(" ")[1]);
                    }
                    else if (item.Contains("B"))
                    {
                        sKUModelObj.QuatityOfA = int.Parse(item.Split(" ")[1]);
                    }
                    else if (item.Contains("C"))
                    {
                        sKUModelObj.QuatityOfA = int.Parse(item.Split(" ")[1]);
                    }
                    else if (item.Contains("D"))
                    {
                        sKUModelObj.QuatityOfA = int.Parse(item.Split(" ")[1]);
                    }
                }
            }

            return sKUModelObj;
        }
    }

    class SKUModel
    {
        public int QuatityOfA { get; set; }
        public int QuatityOfB { get; set; }
        public int QuatityOfC { get; set; }
        public int QuatityOfD { get; set; }
        public string ErrorMessage { get; set; }
    }
}
