using SecurePass.Models;
using System.Data.SqlClient;

namespace SecurePass
{
    public class UserDatabase
    {
        private readonly string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SecurePassData;Integrated Security=True";


        public SaltyPass Getusers(string username)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            using (SqlCommand sqlcmd = new SqlCommand("SELECT Salt,HashedPass FROM Users  WHERE Username = @username", connection))
            {
                sqlcmd.Parameters.AddWithValue("@username", username);

                try
                {


                    connection.Open();
                    SqlDataReader reader = sqlcmd.ExecuteReader();

                    SaltyPass salty = new SaltyPass();

                    if (reader.Read())
                    {
                        salty.Salt = (reader["Salt"].ToString());
                        salty.Hashpassword = (reader["HashedPass"].ToString());
                    }

                    return salty;
                }
                finally
                {
                    connection.Close();
                }


            }

        }

        public bool RegisterUser(string username, string salt, string hashedpass)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            using (SqlCommand sqlcmd = new SqlCommand("INSERT INTO Users (Salt, Username, HashedPass) VALUES (@Salt, @Username, @HashedPass);", connection))
            {
                sqlcmd.Parameters.AddWithValue("@Salt", salt);
                sqlcmd.Parameters.AddWithValue("@Username", username);
                sqlcmd.Parameters.AddWithValue("@HashedPass", hashedpass);

                try
                {


                    connection.Open();
                    _ = sqlcmd.ExecuteNonQuery();

                    return true;
                }

                finally
                {
                    connection.Close();
                }

                return false;
            }
        }


    }
}

