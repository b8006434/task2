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
    /// <summary>
    /// This class is the middleware between business logic and the database
    /// Connection string needs changing, if running the program on a different PC
    /// This would be fixed, if a remote server was to be used for the DB
    /// </summary>
    public static class DataConnection
    {
        /// <summary>
        /// Property returning the SQL Connection for SQL Command creation
        /// </summary>
        private static SqlConnection myConnection;

        /// <summary>
        /// The connection string which is read only currently
        /// Needs changing if using on a differnt PC
        /// </summary>
        private static string ConnectionString => @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\TollSystemWinForms\TollSystemWinForms\Database\TollSystemDB.mdf;Integrated Security=True";

        #region Generic methods, which run any queries passed into them
        /// <summary>
        /// A generic method to run a parameterized query and return a datatable
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
        /// A generic method to run a parameterized query with no return data
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

        #endregion

        #region Connection methods

        /// <summary>
        /// Open the connection to the DB
        /// </summary>
        public static void OpenConnection()
        {
            //Create a new connection
            myConnection = new SqlConnection(ConnectionString);

            //See, if connection can be opened, if it can't log the error message
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
            //Try closing the connection, if it can't be closed log the error message
            try
            {
                myConnection.Close();
            }
            catch (Exception ex)
            {
                Debug.Write($"Close Connection Error - {ex.Message} ");
            }
        }
        #endregion


        #region Insertion methods

        /// <summary>
        /// Insert a user into the users table
        /// </summary>
        /// <param name="userDetails"></param>
        /// <param name="usertype"></param>
        public static void InsertIntoUsersTable(List<string> userDetails, UserType usertype)
        {
            //Open the connection and create an SQL Command
            OpenConnection();
            SqlCommand comm = myConnection.CreateCommand();

            //Set the command query to insert given user into the users table
            comm.CommandText = "INSERT INTO users(Username,HashedPassword,Name,UserType,StreetName,City,PostCode,Country) " +
                                "VALUES(@emailParam, @passwordParam, @nameParam, @userTypeParam, @streetNameParam," +
                                       "@cityParam, @postCodeParam,@countryParam) ";

            //Add parameters to the command
            comm.Parameters.AddWithValue("@emailParam", userDetails[0]);
            comm.Parameters.AddWithValue("@passwordParam", userDetails[1]);
            comm.Parameters.AddWithValue("@nameParam", userDetails[2]);
            comm.Parameters.AddWithValue("@userTypeParam", (int)usertype);
            comm.Parameters.AddWithValue("@streetNameParam", userDetails[3]);
            comm.Parameters.AddWithValue("@cityParam", userDetails[4]);
            comm.Parameters.AddWithValue("@postCodeParam", userDetails[5]);
            comm.Parameters.AddWithValue("@countryParam", userDetails[6]);

            //Run the query, and close the connection
            comm.ExecuteNonQuery();
            CloseConnection();

        }

        /// <summary>
        /// Insert a bill into the bills table
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="userID"></param>
        public static void InsertIntoBillsTable(Bill bill, int userID)
        {
            //Open the connection and create an SQL Command
            OpenConnection();
            SqlCommand comm = myConnection.CreateCommand();

            //Set the command query to insert given bill into the bills table
            comm.CommandText = "INSERT INTO Bills(UserID,EntryPoint,ExitPoint,DriverType,RegPlate,VehicleType,Amount,Paid) " +
                                "VALUES(@userIDParam,@entryPointParam, @exitPointParam, @driverTypeParam, @regPlateParam, @vehicleTypeParam," +
                                       "@amountParam, @paidParam) ";

            
            int bitValueForBool;

            //Set the bit value for the 'Paid' column, as this is using bits to represent bool
            if (bill.BillPaid)
            {
                bitValueForBool = 1;
            }
            else
            {
                bitValueForBool = 0;
            }

            //Add command parameters
            comm.Parameters.AddWithValue("@userIDParam", userID);
            comm.Parameters.AddWithValue("@entryPointParam", bill.MotorwayEntryPoint);
            comm.Parameters.AddWithValue("@exitPointParam", bill.MotorwayLeavingPoint);
            comm.Parameters.AddWithValue("@driverTypeParam", bill.DriverType.ToString());
            comm.Parameters.AddWithValue("@regPlateParam", bill.RegistrationPlate);
            comm.Parameters.AddWithValue("@vehicleTypeParam", bill.VehicleType);
            comm.Parameters.AddWithValue("@amountParam", bill.AmountToPay);
            comm.Parameters.AddWithValue("@paidParam", bitValueForBool);

            //Execute the query and close the connection
            comm.ExecuteNonQuery();
            CloseConnection();

        }

        #endregion

        #region Select statements, that return data

        //Return unpaid bills for a given user
        public static List<Bill> ReturnUnpaidBillsForUser(int userID)
        {
            OpenConnection();

            //Create a new SQL Command with the query to return unpaid bills by a given user ID
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bills WHERE UserID=@userIDParam AND Paid=@paidParam ", myConnection))
            {
                //Add parameters to the command
                cmd.Parameters.AddWithValue("@userIDParam", userID);
                cmd.Parameters.AddWithValue("@paidParam", 0);

                //Execute the command, returning matching data
                SqlDataReader dr = cmd.ExecuteReader();

                //If data has been returned, process the data into the list of bills,
                //else return nothing
                if (dr.HasRows)
                {
                    //Create the datatable to comb through, and load it from the SQL reader
                    DataTable billsTable = new DataTable();
                    billsTable.Load(dr);


                    List<Bill> billsToShow = new List<Bill>();

                    //Parse each row of data from the returned query into a bill and add that into the bills list
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

                    CloseConnection();
                    return billsToShow;
                }

                
                CloseConnection();
                return null;
            }
        }
        /// <summary>
        /// Return the travel history for a given user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Bill> ReturnTravelHistoryForUser(int userID)
        {
            OpenConnection();

            //Create a new SQL Command with the query to return paid bills by a given user ID
            //Currently with the way the system is set up, the travel history = paid bills
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bills WHERE UserID=@userIDParam AND Paid=@paidParam ", myConnection))
            {
                //Add the parameters into the command
                cmd.Parameters.AddWithValue("@userIDParam", userID);
                cmd.Parameters.AddWithValue("@paidParam", 1);

                //Execute the SQL and return the data
                SqlDataReader dr = cmd.ExecuteReader();

                //If data has been returned by the query, process it
                //Else just return nothing
                if (dr.HasRows)
                {
                    //Create a datatable to comb through, and load it with the returned data
                    DataTable billsTable = new DataTable();
                    billsTable.Load(dr);

                    List<Bill> billsToShow = new List<Bill>();

                    //Process each row in the returned data into a bill and add that to the bills list
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

                    CloseConnection();
                    return billsToShow;
                }

                CloseConnection();
                return null;
            }
        }

        /// <summary>
        /// Return all bills for a given user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Bill> ReturnAllBillsByUserID(int userID)
        {
            OpenConnection();

            //Create a new SQL Command with the query to return all bills for a given user id
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bills WHERE UserID=@userIDParam ", myConnection))
            {
                //Add the user id into the parameters for the command
                cmd.Parameters.AddWithValue("@userIDParam", userID);

                //Execute the query and return query data
                SqlDataReader dr = cmd.ExecuteReader();

                //If the query returned data, process it
                //Else just return nothing
                if (dr.HasRows)
                {
                    //Create a data table to comb through, and load it with the returned data
                    DataTable billsTable = new DataTable();
                    billsTable.Load(dr);

                    List<Bill> billsToShow = new List<Bill>();

                    //Process each row in datatable into a bill, and add that to the list of bills
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

                    CloseConnection();
                    return billsToShow;
                }

                CloseConnection();
                return null;
            }
        }

        /// <summary>
        /// Return a given bill for a given Bill ID
        /// </summary>
        /// <param name="billID"></param>
        /// <returns></returns>
        public static Bill ReturnBillByID(int billID)
        {
            OpenConnection();

            //Create a new SQL Command with a query to return all bills that match the bill id given
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bills WHERE Id=@billId ", myConnection))
            {
                //Add the parameters into the command
                cmd.Parameters.AddWithValue("@billId", billID);

                //Execute and load the data returned from the query
                SqlDataReader dr = cmd.ExecuteReader();

                //If data has been returned, process it
                //Else just return nothing
                if (dr.HasRows)
                {
                    //Create a new datatable and load it with the returned data
                    DataTable billsTable = new DataTable();
                    billsTable.Load(dr);

                    //Only one record is ever to be returned, as the Bill ID's can't be duplicates
                    //Therefore, the row should always be 0, so retrieve all the data from row 0
                    //Create a ne bill from the retrieved data and return it
                    int id;
                    int userIDBill;
                    double amount;
                    int.TryParse(billsTable.Rows[0][0].ToString(), out id);
                    int.TryParse(billsTable.Rows[0][1].ToString(), out userIDBill);
                    double.TryParse(billsTable.Rows[0][7].ToString(), out amount);

                    DriverType driverType = (DriverType)Enum.Parse(typeof(DriverType), billsTable.Rows[0][4].ToString());
                    bool paid = Convert.ToBoolean(billsTable.Rows[0][8].ToString());

                    List<string> parameters = new List<string> {billsTable.Rows[0][2].ToString(), billsTable.Rows[0][3].ToString(),
                                                                   billsTable.Rows[0][5].ToString(), billsTable.Rows[0][6].ToString()};

                    Bill billToAdd = new Bill(billID, parameters, driverType, amount, paid, default);

                    CloseConnection();
                    return billToAdd;
                }

                CloseConnection();
                return null;
            }
        }

        /// <summary>
        /// Return all users of type 'Driver' from the database
        /// </summary>
        /// <returns></returns>
        public static List<User> ReturnAllDrivers()
        {
            OpenConnection();

            //Create a new SQL command with the query to return all users, which are not toll operators
            //This is done this way, as in case there are other user types added, they will be returned also
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserType != @userTypeParam ", myConnection))
            {
                //Add the parameters into the command
                cmd.Parameters.AddWithValue("@userTypeParam", UserType.TollOperator);

                //Execute the query and return given data
                SqlDataReader dr = cmd.ExecuteReader();

                //If data has been returned, process it
                //Else just return nothing
                if (dr.HasRows)
                {
                    //Create a new datatable and load it with the returned data
                    DataTable usersTable = new DataTable();
                    usersTable.Load(dr);

                    List<User> usersToShow = new List<User>();

                    //Process each row into a new User object, and add that to the return list
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

                    CloseConnection();
                    return usersToShow;
                }

                CloseConnection();
                return null;
            }
        }

        /// <summary>
        /// Login a user by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="hashedPassword"></param>
        /// <returns>Return the user corresponding from the DB</returns>
        public static User LoginUser(string username, string hashedPassword)
        {
            OpenConnection();

            //Create a new SQL Command with the query to return a matching user by given username and password
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE UserName=@userEmail AND HashedPassword=@userPassword", myConnection))
            {
                //Add the parameters to the command
                cmd.Parameters.AddWithValue("@userEmail", username);
                cmd.Parameters.AddWithValue("@userPassword", hashedPassword);

                //Execute the query and return user data
                SqlDataReader dr = cmd.ExecuteReader();

                //If the user has been returned, process it
                //Else return nothing
                if (dr.HasRows)
                {
                    //Create a new datatable and load it with the returned data
                    DataTable userTable = new DataTable();
                    userTable.Load(dr);

                    //The returned data should always be a single user, as it is not possible to create a duplicate user
                    //Therefore, always look at the first row returned, which is 0
                    //Retrieve the returned data, create a new user and return that user

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

        /// <summary>
        /// Check if a given user already exists in the system
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckForExistingEmail(string email)
        {
            OpenConnection();

            //Create a new SQL Command with a query to return a matching email
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE UserName=@userEmail", myConnection))
            {
                //Add parameters to the sql command
                cmd.Parameters.AddWithValue("@userEmail", email);

                //Run the sql query and return result data
                SqlDataReader dr = cmd.ExecuteReader();
                
                //If data is returned, that means that the email is already in the system so return true
                if (dr.HasRows)
                {
                    CloseConnection();
                    return true;
                }

                //The email is not already in the system, so return false
                CloseConnection();
                return false;
            }
        }

        /// <summary>
        /// Return the hashed password for a given user ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string ReturnUserHashedPassword(int ID)
        {
            OpenConnection();

            //Create a new SQL Command, with the query to return hashed password for a given user ID
            //Add the parameters into the command
            SqlCommand comm = myConnection.CreateCommand();
            comm.CommandText = "SELECT HashedPassword FROM users WHERE ID = @idParam ";
            comm.Parameters.AddWithValue("@idParam", ID);

            //Run the sql query and return the result data
            SqlDataReader dr = comm.ExecuteReader();

            //If data has been returned, process it
            //Otherwise just return nothing
            if (dr.HasRows)
            {
                //Create a new datatable and load it with the returned data
                DataTable userTable = new DataTable();
                userTable.Load(dr);

                //As only it is not possible to have duplicate users, and we are retrieving a single column,
                //The returned password will always be in Row 0, column 0
                string passWord = userTable.Rows[0][0].ToString();

                CloseConnection();
                return passWord;
            }

            CloseConnection();
            return null;

        }
        #endregion

        #region Update methods

        /// <summary>
        /// Update info for a given user
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="parameters"></param>
        public static void UpdateUserInTable(int ID, List<string> parameters)
        {
            OpenConnection();

            //Create a new command with the query to update all user data
            SqlCommand comm = myConnection.CreateCommand();
            comm.CommandText = "UPDATE Users SET Username = @emailParam,HashedPassword = @passwordParam, Name = @nameParam, StreetName = @streetParam, " +
                               "City = @cityParam, PostCode = @postCodeParam, Country = @countryParam WHERE ID = @idParam ";

            //Add parameters to the command
            comm.Parameters.AddWithValue("@idParam", ID);
            comm.Parameters.AddWithValue("@emailParam", parameters[0]);
            comm.Parameters.AddWithValue("@passwordParam", parameters[1]);
            comm.Parameters.AddWithValue("@nameParam", parameters[2]);
            comm.Parameters.AddWithValue("@streetParam", parameters[3]);
            comm.Parameters.AddWithValue("@cityParam", parameters[4]);
            comm.Parameters.AddWithValue("@postCodeParam", parameters[5]);
            comm.Parameters.AddWithValue("@countryParam", parameters[6]);

            //Run the sql query and close the connection
            comm.ExecuteNonQuery();
            CloseConnection();
        }

        public static int ProcessedBill(int ID)
        {
            OpenConnection();

            //Create a new command with the query to update a bill
            SqlCommand comm = myConnection.CreateCommand();
            comm.CommandText = "UPDATE Bills SET Paid = @billPaid, DatePaid = @paidParam WHERE ID = @idParam ";

            //Add parameters to the command
            comm.Parameters.AddWithValue("@idParam", ID);
            comm.Parameters.AddWithValue("@billPaid", 1);
            comm.Parameters.AddWithValue("@paidParam", DateTime.Now);

            //Run the sql query and return the query success
            //Close the connection
            var rowsAffected = comm.ExecuteNonQuery();
            
            CloseConnection();
            return rowsAffected;
        }
        #endregion
    }
}
