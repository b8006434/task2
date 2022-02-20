using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollSystemServices.Enums
{
    /// <summary>
    /// Payment Options available to pay the bill
    /// </summary>
    public enum PaymentOptions
    { 
        Visa_Debit = 0,
        Visa_Credit = 1,
        MasterCard_Debit = 2,
        MasterCard_Credit = 3,
        PayPal = 4,
        BTC = 5,
        XRP = 6
    }

}
