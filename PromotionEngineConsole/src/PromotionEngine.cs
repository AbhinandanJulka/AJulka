using System;
using System.Collections.Generic;

namespace PromotionEngineConsole
{
    public class PromotionEngine
    {
        //ip format
        //3 A
        //5 B
        //1 C
        //1 D
        static void Main(string[] args)
        {
            string ip = string.Empty;
            List<string> ipList = new List<string>();
            while (!string.IsNullOrWhiteSpace(ip = Console.ReadLine()))
            {
                ipList.Add(ip.Trim().ToUpper());
            }
            PromotionEngine obj = new PromotionEngine();
            SKUModel sKUModelObj = obj.MapToSKU(ipList);

            if (sKUModelObj.ErrorMessage != null && sKUModelObj.ErrorMessage.Count != 0)
            {
                foreach (var item in sKUModelObj.ErrorMessage)
                    Console.WriteLine(item);
            }
            else
            {
                Console.WriteLine("Total: " + obj.CalculateInvoice(sKUModelObj));
            }
            Console.ReadLine();
        }

        // Parse and Validate Input 
        public SKUModel MapToSKU(List<string> ip)
        {
            SKUModel sKUModelObj = new SKUModel();
            sKUModelObj.ErrorMessage = new List<string>();
            if (ip == null || ip.Count == 0)
            {
                sKUModelObj.ErrorMessage.Add("Invalid Input ! Please Enter a Valid Input");
                return sKUModelObj;
            }
            else
            {
                foreach (var item in ip)
                {
                    string[] SKU = item.Split(" ");
                    int quantity = 0;

                    if(SKU.Length != 2)
                    {
                        sKUModelObj.ErrorMessage.Add("Invalid Input ! Please Enter a Valid Input");
                        continue;
                    }
                    switch(SKU[1])
                    {
                        case "A":
                            {
                                if (int.TryParse(SKU[0], out quantity))
                                    sKUModelObj.QuatityOfA = quantity;
                                else
                                    sKUModelObj.ErrorMessage.Add("Invalid Input Count for A");
                            }
                            break;
                        case "B":
                            {
                                if (int.TryParse(SKU[0], out quantity))
                                    sKUModelObj.QuatityOfB = quantity;
                                else
                                    sKUModelObj.ErrorMessage.Add("Invalid Input Count for B");
                            }
                            break;
                        case "C":
                            {
                                if (int.TryParse(SKU[0], out quantity))
                                    sKUModelObj.QuatityOfC = quantity;
                                else
                                    sKUModelObj.ErrorMessage.Add("Invalid Input Count for C");
                            }
                            break;
                        case "D":
                            {
                                if (int.TryParse(SKU[0], out quantity))
                                    sKUModelObj.QuatityOfD = quantity;
                                else
                                    sKUModelObj.ErrorMessage.Add("Invalid Input Count for D");
                            }
                            break;
                        default:
                            {
                                sKUModelObj.ErrorMessage.Add("Invalid Input ! Please Enter a Valid Input");
                            }
                            break;
                    }
                }
            }

            return sKUModelObj;
        }

        // Calculate Total Amount
        public long CalculateInvoice(SKUModel sKUModelObj)
        {
            // 3 of A's for 130
            int aPromotionCount = sKUModelObj.QuatityOfA / 3;
            int aTotalAmount = (130 * aPromotionCount) + (50 * (sKUModelObj.QuatityOfA % 3));

            // 2 of B's for 45
            int bPromotionCount = sKUModelObj.QuatityOfB / 2;
            int bTotalAmount = (45 * bPromotionCount) + (30 * (sKUModelObj.QuatityOfB % 2));

            // C & D for 30
            int cdPromotionCount = (sKUModelObj.QuatityOfC < sKUModelObj.QuatityOfD) ? sKUModelObj.QuatityOfC : sKUModelObj.QuatityOfD;
            int cdTotalAmount = (cdPromotionCount * 30);

            // C individual price 20
            int cTotalAmount = (sKUModelObj.QuatityOfC - cdPromotionCount) * 20;

            // D individual price 15
            int dTotalAmount = (sKUModelObj.QuatityOfD - cdPromotionCount) * 15;

            long totalAmount = aTotalAmount + bTotalAmount + cdTotalAmount + cTotalAmount + dTotalAmount;

            return totalAmount;
        }
    }

    public class SKUModel
    {
        public int QuatityOfA { get; set; }
        public int QuatityOfB { get; set; }
        public int QuatityOfC { get; set; }
        public int QuatityOfD { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
