﻿namespace JwtSample
{
    internal class Program
    {

        /// <summary>
        /// https://jwt.io/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter user name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter user password: ");
            string userPassword = Console.ReadLine();

            UserService userService = new UserService();
            Console.WriteLine(userService.Login(userName, userPassword));

            Console.ReadKey();
        }
    }
}