using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollSystemServices.Enums;

namespace TollSystemServices
{
    /// <summary>
    /// Bill data class used to represent data from the Database
    /// </summary>
    public class Bill
    {
        public int ID { get; }
        public string MotorwayEntryPoint { get; set; }

        public string MotorwayLeavingPoint { get; set; }

        public DriverType DriverType { get; set; }

        public string RegistrationPlate { get; set; }

        public string VehicleType { get; set; }

        public double AmountToPay { get; private set; }

        public bool BillPaid { get; set; }

        public DateTime? PaidDateTime { get; set; }

        /// <summary>
        /// Default constructor accepting parameters to create a new bill
        /// Sets the properties from the parameters passed in
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <param name="driverType"></param>
        /// <param name="amountToPay"></param>
        /// <param name="paid"></param>
        /// <param name="paidDate"></param>
        public Bill(int id,List<string> parameters, DriverType driverType, 
                    double amountToPay, bool paid, DateTime? paidDate)
        {
            this.ID = id;
            this.MotorwayEntryPoint = parameters[0];
            this.MotorwayLeavingPoint = parameters[1];
            this.DriverType = driverType;
            this.RegistrationPlate = parameters[2];
            this.VehicleType = parameters[3];
            this.AmountToPay = Math.Round(amountToPay,2,MidpointRounding.AwayFromZero);
            this.BillPaid = paid;
            this.PaidDateTime = paidDate;
        }
    }
}
