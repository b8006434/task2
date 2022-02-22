using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollSystemServices.Enums;

namespace TollSystemServices
{
    public static class DataConnection
    {

        private static SqlConnection myConnection;

        private static string connectionString => @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\TollSystemWinForms\TollSystemWinForms\Database\TollSystemDB.mdf;Integrated Security=True";

        /// <summary>
        /// Run a parameterized query and return a datatable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public static DataTable SelectData(string query, string[] paramName, object[] paramValue)
        {
            OpenConnection();
            using (var cmd = new SqlCommand(query, myConnection))
            {
                //Verify if the name's count equals the value's count
                if (paramName.Count() != paramValue.Count())
                {
                    Debug.WriteLine("ParamName Count != ParamValue Count");
                    return null;
                }

                //Add params in the arrays
                for (int i = 0; i < paramName.Count(); i++)
                {
                    cmd.Parameters.AddWithValue(paramName[i], paramValue[i]);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet _ds = new DataSet();
                DataTable _dt = new DataTable();

                da.Fill(_ds);

                try
                {
                    _dt = _ds.Tables[0];
                }
                catch (Exception ex)

                {
                    Debug.WriteLine("Error: ---> " + ex.Message);
                }

                CloseConnection();
                return _dt;

            }
        }

        /// <summary>
        /// Run a parameterized query with no return data
        /// </summary>
        /// <param name="query"></param>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        public static void ExecuteNonQuery(string query, string[] paramName, object[] paramValue)
        {

            OpenConnection();

            using (var cmd = new SqlCommand(query, myConnection))
            {
                //Verify if the name's count equals the value's count
                if (paramName.Count() != paramValue.Count())
                {
                    Debug.WriteLine("ParamName Count != ParamValue Count");
                    return;
                }

                //Add params in the arrays
                for (int i = 0; i < paramName.Count(); i++)
                {
                    cmd.Parameters.AddWithValue(paramName[i], paramValue[i]);
                }

                cmd.ExecuteNonQuery();
                CloseConnection();
            }

        }

        public static void OpenConnection()
        {
            myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                Debug.Write($"Open Connection Error - {ex.Message} ");
            }

        }

        public static void CloseConnection()
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception ex)
            {
                Debug.Write($"Close Connection Error - {ex.Message} ");
            }
        }

        public static List<User> ReturnAllDrivers()
        {
            OpenConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserType != @userTypeParam ", myConnection))
            {
                cmd.Parameters.AddWithValue("@userTypeParam", UserType.TollOperator);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable usersTable = new DataTable();
                    usersTable.Load(dr);
                    List<User> usersToShow = new List<User>();

                    foreach (DataRow row in usersTable.Rows)
                    {
                        int userID;
                        int.TryParse(row[0].ToString(), out userID);

                        string email = row[1].ToString();
                        string hashedPassword = row[2].ToString();
                        string name = row[3].ToString();
                        UserType userType = (UserType)Enum.Parse(typeof(UserType), row[4].ToString());
                        string streetName = row[5].ToString();
                        string city = row[6].ToString();
                        string postCode = row[7].ToString();
                        string country = row[8].ToString();

                        List<string> parameters = new List<string> {email,hashedPassword,name,streetName,
                                                                    city,postCode,country};

                        User userToAdd = new User(userID, parameters, userType);
                        usersToShow.Add(userToAdd);
                    }

                    return usersToShow;
                }

                CloseConnection();
                return null;
            }
        }

        public static void InsertIntoUsersTable(List<string> userDetails, UserType usertype)
        {
            OpenConnection();
            SqlCommand comm = myConnection.CreateCommand();
            comm.CommandText = "INSERT INTO users(Username,HashedPassword,Name,UserType,StreetName,City,PostCode,Country) " +
                                "VALUES(@emailParam, @passwordParam, @nameParam, @userTypeParam, @streetNameParam," +
                                       "@cityParam, @postCodeParam,@countryParam) ";

            comm.Parameters.AddWithValue("@emailParam", userDetails[0]);
            comm.Parameters.AddWithValue("@passwordParam", userDetails[1]);
            comm.Parameters.AddWithValue("@nameParam", userDetails[2]);
            comm.Parameters.AddWithValue("@userTypeParam", (int)usertype);
            comm.Parameters.AddWithValue("@streetNameParam", userDetails[3]);
            comm.Parameters.AddWithValue("@cityParam", userDetails[4]);
            comm.Parameters.AddWithValue("@postCodeParam", userDetails[5]);
            comm.Parameters.AddWithValue("@countryParam", userDetails[6]);

            comm.ExecuteNonQuery();
            CloseConnection();

        }

        public static void InsertIntoBillsTable(Bill bill, int userID)
        {
            OpenConnection();
            SqlCommand comm = myConnection.CreateCommand();
            comm.CommandText = "INSERT INTO Bills(UserID,EntryPoint,ExitPoint,DriverType,RegPlate,VehicleType,Amount,Paid) " +
                                "VALUES(@userIDParam,@entryPointParam, @exitPointParam, @driverTypeParam, @regPlateParam, @vehicleTypeParam," +
                                       "@amountParam, @paidParam) ";
            int bitValueForBool;

            if (bill.BillPaid)
            {
                bitValueForBool = 1;
            }
            else
            {
                bitValueForBool = 0;
            }
            comm.Parameters.AddWithValue("@userIDParam", userID);
            comm.Parameters.AddWithValue("@entryPointParam", bill.MotorwayEntryPoint);
            comm.Parameters.AddWithValue("@exitPointParam", bill.MotorwayLeavingPoint);
            comm.Parameters.AddWithValue("@driverTypeParam", bill.DriverType.ToString());
            comm.Parameters.AddWithValue("@regPlateParam", bill.RegistrationPlate);
            comm.Parameters.AddWithValue("@vehicleTypeParam", bill.VehicleType);
            comm.Parameters.AddWithValue("@amountParam", bill.AmountToPay);
            comm.Parameters.AddWithValue("@paidParam", bitValueForBool);

            comm.ExecuteNonQuery();
            CloseConnection();

        }

        public static List<Bill> ReturnUnpaidBillsForUser(int userID)
        {
            OpenConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bills WHERE UserID=@userIDParam AND Paid=@paidParam ", myConnection))
            {
                cmd.Parameters.AddWithValue("@userIDParam", userID);
                cmd.Parameters.AddWithValue("@paidParam", 0);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable billsTable = new DataTable();
                    billsTable.Load(dr);
                    List<Bill> billsToShow = new List<Bill>();

                    foreach (DataRow row in billsTable.Rows)
                    {
                        int billID;
                        double amount;
                        int.TryParse(row[0].ToString(), out billID);
                        double.TryParse(row[7].ToString(), out amount);

                        DriverType driverType = (DriverType)Enum.Parse(typeof(DriverType), row[4].ToString());
                        bool paid = Convert.ToBoolean(row[8].ToString());
                        List<string> parameters = new List<string> {row[2].ToString(), row[3].ToString(),
                                                                    row[5].ToString(), row[6].ToString()};

                        Bill billToAdd = new Bill(billID,parameters, driverType, amount, paid, default);
                        billsToShow.Add(billToAdd);
                    }

                    return billsToShow;
                }

                CloseConnection();
                return null;
            }
        }
        public static List<Bill> ReturnPaidBillsForUser(int userID)
        {
            OpenConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bills WHERE UserID=@userIDParam AND Paid=@paidParam ", myConnection))
            {
                cmd.Parameters.AddWithValue("@userIDParam", userID);
                cmd.Parameters.AddWithValue("@paidParam", 1);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable billsTable = new DataTable();
                    billsTable.Load(dr);
                    List<Bill> billsToShow = new List<Bill>();

                    foreach (DataRow row in billsTable.Rows)
                    {
                        int billID;
                        double amount;
                        DateTime paidDate = default;
                        int.TryParse(row[0].ToString(), out billID);
                        double.TryParse(row[7].ToString(), out amount);
                        DateTime.TryParse(row[9].ToString(), out paidDate);

                        DriverType driverType = (DriverType)Enum.Parse(typeof(DriverType), row[4].ToString());
                        bool paid = Convert.ToBoolean(row[8].ToString());
                        List<string> parameters = new List<string> {row[2].ToString(), row[3].ToString(),
                                                                    row[5].ToString(), row[6].ToString()};

                        Bill billToAdd = new Bill(billID, parameters, driverType, amount,paid, paidDate);
                        billsToShow.Add(billToAdd);
                    }

                    return billsToShow;
                }

                CloseConnection();
                return null;
            }
        }

        public static List<Bill> ReturnAllBillsByUserID(int userID)
        {
            OpenConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bills WHERE UserID=@userIDParam ", myConnection))
            {
                cmd.Parameters.AddWithValue("@userIDParam", userID);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable billsTable = new DataTable();
                    billsTable.Load(dr);
                    List<Bill> billsToShow = new List<Bill>();

                    foreach (DataRow row in billsTable.Rows)
                    {
                        int billID;
                        double amount;
                        DateTime paidDate = default;
                        int.TryParse(row[0].ToString(), out billID);
                        double.TryParse(row[7].ToString(), out amount);
                        DateTime.TryParse(row[9].ToString(), out paidDate);

                        DriverType driverType = (DriverType)Enum.Parse(typeof(DriverType), row[4].ToString());
                        bool paid = Convert.ToBoolean(row[8].ToString());
                        List<string> parameters = new List<string> {row[2].ToString(), row[3].ToString(),
                                                                    row[5].ToString(), row[6].ToString()};

                        Bill billToAdd = new Bill(billID, parameters, driverType, amount,paid, paidDate);
                        billsToShow.Add(billToAdd);
                    }

                    return billsToShow;
                }

                CloseConnection();
                return null;
            }
        }

        public static Bill ReturnBillByID(int billID)
        {
            OpenConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bills WHERE Id=@billId ", myConnection))
            {
                cmd.Parameters.AddWithValue("@billId", billID);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable billsTable = new DataTable();
                    billsTable.Load(dr);

                    int id;
                    int userIDBill;
                    double amount;
                    int.TryParse(billsTable.Rows[0][0].ToString(), out id);
                    int.TryParse(billsTable.Rows[0][1].ToString(), out userIDBill);
                    double.TryParse(billsTable.Rows[0][7].ToString(), out amount);

                    DriverType driverType = (DriverType)Enum.Parse(typeof(DriverType), billsTable.Rows[0][4].ToString());
                    bool paid = Convert.ToBoolean(billsTable.Rows[8].ToString());
                    List<string> parameters = new List<string> {billsTable.Rows[0][2].ToString(), billsTable.Rows[0][3].ToString(),
                                                                   billsTable.Rows[0][5].ToString(), billsTable.Rows[0][6].ToString()};

                    Bill billToAdd = new Bill(billID, parameters, driverType, amount, paid, default);

                    return billToAdd;
                }

                CloseConnection();
                return null;
            }
        }

        public static User LoginUser(string username, string hashedPassword)
        {
            OpenConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE UserName=@userEmail AND HashedPassword=@userPassword", myConnection))
            {
                cmd.Parameters.AddWithValue("@userEmail", username);
                cmd.Parameters.AddWithValue("@userPassword", hashedPassword);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable userTable = new DataTable();
                    userTable.Load(dr);

                    int id = Convert.ToInt32(userTable.Rows[0][0]);
                    UserType usertype = (UserType)userTable.Rows[0][4];

                    List<string> userDetails = new List<string> {userTable.Rows[0][1].ToString(), userTable.Rows[0][2].ToString(),
                                               userTable.Rows[0][3].ToString(),userTable.Rows[0][5].ToString(),userTable.Rows[0][6].ToString(),
                                               userTable.Rows[0][7].ToString(),userTable.Rows[0][8].ToString()};

                    

                    User currentUser = new User(id, userDetails, usertype);

                    CloseConnection();
                    return currentUser;
                }

                CloseConnection();
                return null;
            }
        }

        public static bool CheckForExistingEmail(string email)
        {
            OpenConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE UserName=@userEmail", myConnection))
            {
                cmd.Parameters.AddWithValue("@userEmail", email);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    CloseConnection();
                    return true;
                }

                CloseConnection();
                return false;
            }
        }

        public static void UpdateUserInTable(int ID, List<string> parameters)
        {
            OpenConnection();
            SqlCommand comm = myConnection.CreateCommand();
            comm.CommandText = "UPDATE Users SET Username = @emailParam,HashedPassword = @passwordParam, Name = @nameParam, StreetName = @streetParam, " +
                               "City = @cityParam, PostCode = @postCodeParam, Country = @countryParam WHERE ID = @idParam ";

            comm.Parameters.AddWithValue("@idParam", ID);
            comm.Parameters.AddWithValue("@emailParam", parameters[0]);
            comm.Parameters.AddWithValue("@passwordParam", parameters[1]);
            comm.Parameters.AddWithValue("@nameParam", parameters[2]);
            comm.Parameters.AddWithValue("@streetParam", parameters[3]);
            comm.Parameters.AddWithValue("@cityParam", parameters[4]);
            comm.Parameters.AddWithValue("@postCodeParam", parameters[5]);
            comm.Parameters.AddWithValue("@countryParam", parameters[6]);
            comm.ExecuteNonQuery();
            CloseConnection();
        }

        public static int ProcessedBill(int ID)
        {
            OpenConnection();
            SqlCommand comm = myConnection.CreateCommand();
            comm.CommandText = "UPDATE Bills SET Paid = @billPaid, DatePaid = @paidParam WHERE ID = @idParam ";

            comm.Parameters.AddWithValue("@idParam", ID);
            comm.Parameters.AddWithValue("@billPaid", 1);
            comm.Parameters.AddWithValue("@paidParam", DateTime.Now);

            var rowsAffected =comm.ExecuteNonQuery();
            CloseConnection();

            return rowsAffected;
        }

        public static string ReturnUserHashedPassword(int ID)
        {
            OpenConnection();

            SqlCommand comm = myConnection.CreateCommand();
            comm.CommandText = "SELECT HashedPassword FROM users WHERE ID = @idParam ";
            comm.Parameters.AddWithValue("@idParam", ID);

            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable userTable = new DataTable();
                userTable.Load(dr);

                string passWord = userTable.Rows[0][0].ToString();

                CloseConnection();
                return passWord;
            }

            CloseConnection();
            return null;

        }
    }
}
