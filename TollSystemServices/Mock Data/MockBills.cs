using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollSystemServices.Enums;

namespace TollSystemServices
{
    /// <summary>
    /// This class is used to generate mock data
    /// Uncomment, change parametrs and run this to insert 10 bill records
    /// </summary>
    public static class MockBills
    {
        //public static List<Bill> GetMockBills(int driverType)
        //{
        //    List<Bill> returnList = new List<Bill>();
        //    Random random = new Random();

        //    for (int a = 0; a < 10; a++)
        //    {
        //        string motorwayEntryPoint = "Highway " + a;
        //        string motorwayLeavingPoint = "Highway " + (a + 3);
        //        DriverType driver = (DriverType)driverType;
        //        string regPlate = "BA" + a + " 14" + a;
        //        string carType = "Car";
        //        double amountToPay = random.NextDouble() * (299.99 - 4.99) + 4.99;

        //        List<string> parameters = new List<string> { motorwayEntryPoint, motorwayLeavingPoint, regPlate, carType };

        //        Bill mockBill = new Bill(parameters, driver, amountToPay);

        //        DataConnection.InsertIntoBillsTable(mockBill, 2);
        //    }

        //    return returnList;
        //}
    }
}
