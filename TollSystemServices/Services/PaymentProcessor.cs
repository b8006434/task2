using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollSystemServices.Services
{
    /// <summary>
    /// This class simulates a payment processor
    /// </summary>
   public class PaymentProcessor
    {
        /// <summary>
        /// This simulates the paying of a bill
        /// This method is called by the UI, when the 'Pay Bill' button in the grid view is clicked
        /// </summary>
        /// <param name="billID"></param>
        /// <returns></returns>
        public bool PayBill(int billID)
        {
            //Return the bill, that is supposed to be paid
            var bill = DataConnection.ReturnBillByID(billID);

            //If bill does not exist, or is already paid return false
            if (bill == null || bill.BillPaid == true)
            {
                return false;
            }

            //If the calculation of the bill amount due failed, return false
            else if (CalculateBill(bill) == 0)
            {
                return false;
            }

            //If the procession of the payment fails, return false
            else if (!ProcessPayment(bill))
            {
                return false;
            }

            //Every operation to pay and process the bill passed, so return true
            return true;

        }

        /// <summary>
        /// This method calculates the amount due for a bill
        /// Currently simulated
        /// </summary>
        /// <param name="billToCalculate"></param>
        /// <returns></returns>
        public double CalculateBill(Bill billToCalculate)
        {
            //If the entry point caught by the camera is invalid, return 0 for fail
            if(!Validation.CheckForValidString(billToCalculate.MotorwayEntryPoint))
            {
                return 0;
            }

            //If the leaving point caught by the camera is invalid, return 0 for fail
            else if(!Validation.CheckForValidString(billToCalculate.MotorwayLeavingPoint))
            {
                return 0;
            }

            //If the entry point is the same as leaving point, this is also invalid so return 0 for fail
            else if(billToCalculate.MotorwayEntryPoint == billToCalculate.MotorwayLeavingPoint)
            {
                return 0;
            }

            //Simulated - this would calculate the difference between the 2 points and amount due
            //This would update the 'Due' field for a bill in the DB, however this is pre-populated,
            //So just return this pre-populated value
            return billToCalculate.AmountToPay;
        }
        
        /// <summary>
        /// This is what should call the 3rd party payment processor API
        /// This is currently simulated
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public bool ProcessPayment(Bill bill)
        {
            //This is currently simulated - This would call the payment company API
            //This would verify and take the payment needed to clear the bill balance
            var amountPaid = bill.AmountToPay;

            //If the payment taken doesn't match the amount due, log a message and return false
            if (amountPaid != bill.AmountToPay)
            {
                Debug.WriteLine($"Only taken £{amountPaid} instead of £{bill.AmountToPay}!!!");
                return false;
            }

            //Process the bill in the DB, which sets the payment date and the 'Paid' field in the DB
            //For the given bill
            var billProcessed = DataConnection.ProcessedBill(bill.ID);

            //If the processing of the bill failed, return false
            if (billProcessed == 0 || billProcessed == -1)
            {
                return false;
            }

            //The bill payment and processing were succesfull so return true
            return true;
        }

    }
}
