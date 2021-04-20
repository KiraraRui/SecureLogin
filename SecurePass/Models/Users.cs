namespace SecurePass.Models
{
    public class Users
    {
        public string username;
        public string password;

        public Users(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

    }
}
