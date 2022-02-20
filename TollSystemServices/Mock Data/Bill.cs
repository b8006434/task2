using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollSystemServices.Enums;

namespace TollSystemServices
{
    public class Bill
    {
        public string MotorwayEntryPoint { get; set; }

        public string MotorwayLeavingPoint { get; set; }

        public DriverType DriverType { get; set; }

        public string RegistrationPlate { get; set; }

        public string VehicleType { get; set; }

        public double AmountToPay { get; private set; }

        public bool billPaid { get; set; }

        public Bill(List<string> parameters, DriverType driverType, double amountToPay)
        {
            this.MotorwayEntryPoint = parameters[0];
            this.MotorwayLeavingPoint = parameters[1];
            this.DriverType = driverType;
            this.RegistrationPlate = parameters[2];
            this.VehicleType = parameters[3];
            this.AmountToPay = Math.Round(amountToPay,2,MidpointRounding.AwayFromZero);
            this.billPaid = false;
        }
    }
}
