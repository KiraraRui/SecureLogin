using SecurePass.Models;
using System;

namespace SecurePass
{
    internal class Program
    {
        private static SaltAndPepper saltAndPepper;
        private static UserDatabase userDatabase;

        public static void Main(string[] args)
        {
            saltAndPepper = new SaltAndPepper();
            userDatabase = new UserDatabase();

            Console.WriteLine(@"

                                       _ _           _   _             
                     /\               | (_)         | | (_)            
                    /  \   _ __  _ __ | |_  ___ __ _| |_ _  ___  _ __  
                   / /\ \ | '_ \| '_ \| | |/ __/ _` | __| |/ _ \| '_ \ 
                  / ____ \| |_) | |_) | | | (_| (_| | |_| | (_) | | | |
                 /_/    \_\ .__/| .__/|_|_|\___\__,_|\__|_|\___/|_| |_|
                          | |   | |                                    
                          |_|   |_|                                    

            ");

            Console.WriteLine("Welcome to the application, please login or register");


            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(@"
                        +------------------------------------+
                        | +------------------------------------+
                        | |                                  | |
                        | |        Click 1 for register      | |
                        | |       click 2 for login          | |
                        | |         click 3 for exit         | |
                        | |    ==========================    | |
                        | |  Press enter after your choice   | |
                        +------------------------------------+ |
                          +------------------------------------+ ");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("plz write your usename:");
                    string txtUsername = Console.ReadLine();

                    Console.WriteLine("plz enter your password:");
                    string txtPassword = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(txtUsername) || string.IsNullOrWhiteSpace(txtPassword))
                    {
                        Console.WriteLine("Welp hellu there seems like your username or password was empty, try again!");
                    }
                    else
                    {
                        string salt = saltAndPepper.GetSalt();
                        string hashedpass = saltAndPepper.ComputeHashWithSalt(txtPassword, salt);

                        if (userDatabase.RegisterUser(txtUsername, salt, hashedpass))
                        {
                            Console.Clear();
                            Console.WriteLine("wow u registered as an user");

                            Console.WriteLine(@"
                         +------------------------------------+
                         | +------------------------------------+
                         | |                                  | |
                         | |        Heyyyy u registered       | |
                         | |             gj buddy             | |
                         | |    ==========================    | |
                         | |                                  | |
                         +------------------------------------+ |
                           +------------------------------------+ ");

                        }
                        else
                        {
                            Console.WriteLine("WWRRROOONNNG TRY AGAIN B....buddy :> ");
                            Console.WriteLine(@"
                         +------------------------------------+
                         | +------------------------------------+
                         | |                                  | |
                         | |           WRROOOONNGGGG          | |
                         | |        Try registering again     | |
                         | |    ==========================    | |
                         | |                                  | |
                         +------------------------------------+ |
                           +------------------------------------+ ");
                        }
                    }

                }
                if (input == "2")
                {
                    Console.WriteLine("plz write your usename:");
                    string txtUsername = Console.ReadLine();

                    Console.WriteLine("plz enter your password:");
                    string txtPassword = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(txtUsername) || string.IsNullOrWhiteSpace(txtPassword))
                    {
                        Console.WriteLine("Welp hellu there seems like your username or password was empty, try again!");
                    }
                    else
                    {
                        SaltyPass saltyPass = userDatabase.Getusers(txtUsername);
                        string computedHash = saltAndPepper.ComputeHashWithSalt(txtPassword, saltyPass.Salt);

                        if (saltAndPepper.ValidateHash(computedHash, saltyPass.Hashpassword))
                        {
                            Console.Clear();
                            Console.WriteLine(@"
                         +------------------------------------+
                         | +------------------------------------+
                         | |                                  | |
                         | |        Heyyyy u logged in        | |
                         | |             gj buddy             | |
                         | |    ==========================    | |
                         | |                                  | |
                         +------------------------------------+ |
                           +------------------------------------+ ");
                        }
                        else
                        {
                            Console.WriteLine("Welp hellu there seems like your username or password was wrong, try again!");
                        }
                    }
                }

                else if (input == "3")
                {
                    isRunning = false;
                }

            }

        }
    }
}

