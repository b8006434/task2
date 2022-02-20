using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollSystemServices.Enums;

namespace TollSystemServices
{
    public static class MockBills
    {
        public static List<Bill> GetMockBills(int driverType)
        {
            List<Bill> returnList = new List<Bill>();
            Random random = new Random();

            for (int a = 0; a < 10; a++)
            {
                string motorwayEntryPoint = "Highway " + a;
                string motorwayLeavingPoint = "Highway " + (a + 3);
                DriverType driver = (DriverType)driverType;
                string regPlate = "BA" + a + " 14" + a;
                string carType = "Car";
                double amountToPay  = random.NextDouble() * (299.99 - 4.99) + 4.99;

                List<string> parameters = new List<string> { motorwayEntryPoint, motorwayLeavingPoint, regPlate, carType };

                Bill mockBill = new Bill(parameters, driver,amountToPay);

                returnList.Add(mockBill);
            }

            return returnList;
        }
    }
}
