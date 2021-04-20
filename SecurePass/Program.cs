using System;
using System.Data.SqlClient;
using System.Threading;

namespace SecurePass
{
    internal class Program
    {
        private static void Main(string[] args)
        {
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

            Console.WriteLine(@"
                        +------------------------------------+
                        | +------------------------------------+
                        | |                                  | |
                        | |     Click 1 for login            | |
                        | |        click 2 for register      | |
                        | |           click 3 for exit       | |
                        | |    ==========================    | |
                        | |                                  | |
                        +------------------------------------+ |
                          +------------------------------------+ ");

            bool successfull = false;
            string input = Console.ReadLine();
            //int loginAttempts = 0;
            while (!successfull)
            {
                if (input == "1")
                {
                    Console.WriteLine("plz write your usename:");
                    string txtUsername = Console.ReadLine();

                    Console.WriteLine("plz enter your password:");
                    string txtPassword = Console.ReadLine();
                    SqlDataReader reader = UserDatabase.Getusers(txtUsername);

                    if (reader.HasRows)
                    {
                        reader.Read();
                        string salt = reader.GetString(0);
                        string hashedPassword = reader.GetString(1);


                    }

                }

                /*
                 *  Console.WriteLine("Heyyyy u logged in gj buddy");

                         Console.WriteLine(@"
                         +------------------------------------+
                         | +------------------------------------+
                         | |                                  | |
                         | |          Heyyyy u logged         | |
                         | |            in gj buddy           | |
                         | |    ==========================    | |
                         | |                                  | |
                         +------------------------------------+ |
                           +------------------------------------+ ");
                */

                //if (!successfull)
                //{
                //    Console.WriteLine("WWRRROOONNNG TRY AGAIN B....buddy :> ");
                //    Console.ReadLine();



                //    break;
                //}

                //else if (input == "2")
                //{

                //    Console.WriteLine("Enter your username:");
                //    string username = Console.ReadLine();

                //    Console.WriteLine("Enter your password:");
                //    string password = Console.ReadLine();

                //    Console.WriteLine("Register");
                //    string addingUser = Console.ReadLine();

                //    Array.Resize(ref user, Users.Length + 1);
                //    Users[Users.Length - 1] = new Users(username, password);

                //    successfull = true;


                //}

                else if (input == "3")
                {
                    Console.WriteLine("you have choose to exit the application please wait\n");
                    Thread.Sleep(3999);
                    Environment.Exit(0);
                }


                //else
                //{
                //    if (loginAttempts > 2)
                //    {
                //        Console.WriteLine("Login failure");
                //        successfull = false;
                //    }
                //}


            }
            Console.ReadKey();

            }
        }
    }

