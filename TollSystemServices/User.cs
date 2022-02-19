using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollSystemServices.Enums;

namespace TollSystemServices
{
    public class User
    {
        public int ID { get; }

        public string Username { get; }

        public string HashedPassword { get; }

        public UserType UserType { get;}

        public string StreetName { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }


        public User(int ID, List<string> userDetails,UserType usertype )
        {
            this.ID = ID;
            this.Username = userDetails[0];
            this.HashedPassword = userDetails[1];
            this.Name = userDetails[2];
            this.UserType = usertype;
            this.StreetName = userDetails[3];
            this.City = userDetails[4];
            this.PostCode = userDetails[5];
            this.Country = userDetails[6];
  
        }

    }
}
