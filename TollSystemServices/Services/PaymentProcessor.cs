using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollSystemServices.Services
{
   public class PaymentProcessor
    {

        public bool PayBill(int billID)
        {
                var bill = DataConnection.ReturnBillByID(billID);

            if (bill == null || bill.BillPaid == true)
            {
                return false;
            }

            else if(CalculateBill(bill) == 0)
            {
                return false;
            }
            else if(!ProcessPayment(bill))
            {
                return false;
            }

            return true;

        }

        public double CalculateBill(Bill billToCalculate)
        {
            if(!Validation.CheckForValidString(billToCalculate.MotorwayEntryPoint))
            {
                return 0;
            }
            else if(!Validation.CheckForValidString(billToCalculate.MotorwayLeavingPoint))
            {
                return 0;
            }
            else if(billToCalculate.MotorwayEntryPoint == billToCalculate.MotorwayLeavingPoint)
            {
                return 0;
            }

            return billToCalculate.AmountToPay;
        }

        public bool ProcessPayment(Bill bill)
        {
            //Payment Simulation - payment interface would be here
            var amountPaid = bill.AmountToPay;

            if (amountPaid != bill.AmountToPay)
            {
                return false;
            }

            var billProcessed = DataConnection.ProcessedBill(bill.ID);

            if (billProcessed == 0 || billProcessed == -1)
            {
                return false;
            }

            return true;
        }

    }
}
