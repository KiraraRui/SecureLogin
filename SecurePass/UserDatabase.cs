using System.Data.SqlClient;

namespace SecurePass
{
    public class UserDatabase
    {
        private static readonly string connectionstring = "SERVER=127.0.0.1; DATABASE=MyDatabase; UID=***; PWD=***";


        public static SqlDataReader Getusers(string username)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            using (SqlCommand sqlcmd = new SqlCommand("SELECT salt,password FROM Users  WHERE username = @username", connection))
            {
                sqlcmd.Parameters.AddWithValue("@username", username);
                connection.Open();
                SqlDataReader reader = sqlcmd.ExecuteReader();
                connection.Close();

                return reader;
            }
        }


        public static bool AddAUser(string username, string password)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            using (SqlCommand sqlcmd = new SqlCommand("INSERT INTO [Users] VALUES (@username, @password)", connection))
            {
                sqlcmd.Parameters.AddWithValue("@username", username);
                sqlcmd.Parameters.AddWithValue("@password", password);

                connection.Open();
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }


        //protected void AddingUser(object sender)
        //{
        //    string username = txtUsername.Text;
        //    string password = txtPassword.Text;

        //    bool result = UserDatabase.AddAUser(username, password);
        //}
    }
}

