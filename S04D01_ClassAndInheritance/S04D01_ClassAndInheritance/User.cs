using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D01_ClassAndInheritance
{
    /// <summary>
    /// Class representing a user, with Username, Password, Email
    /// and age
    /// </summary>
    class User
    {
        public static int UserCount = 0;
        private string 
            username,
            password,
            email;

        private int age;

        public string Username { 
            get {
                return username;
            } set {
                username = value; 
            }
        }

        /// <summary>
        /// Constructor for the user class
        /// </summary>
        /// <param name="username">the users username</param>
        /// <param name="password">the users password</param>
        public User(string username, string password) :
            this(username, password, "", 0) { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="email">email</param>
        /// <param name="age">age</param>
        public User(string username, string password,
            string email, int age)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.age = age;
            UserCount++;
        }

        /// <summary>
        /// Checks if the passed password is correct
        /// </summary>
        /// <param name="loginPassword">The entered password</param>
        /// <returns>true if the passwords match</returns>
        public bool CheckPassword(string loginPassword)
        {
            return this.password == loginPassword;
        }

    }
}
