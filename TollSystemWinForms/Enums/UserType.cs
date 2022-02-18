using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollSystemWinForms.Enums
{
    /// <summary>
    /// Password score used when signing up to make sure strong passwords are enforced
    /// </summary>
    public enum UserType
    {
        TollOperator = 0,
        Driver = 1
    }
}
