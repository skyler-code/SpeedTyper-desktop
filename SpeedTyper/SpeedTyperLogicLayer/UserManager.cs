using SpeedTyperDataObjects;
using SpeedTyperDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyperLogicLayer
{
    public class UserManager
    {
        internal string HashSHA256(string source)
        {
            var result = "";
            byte[] data;
            using (SHA256 sha256hash = SHA256.Create())
            {
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            
            var s = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString();
            return result;
        }
        public User AuthenticateUser(string username, string password)
        {
            User user = null;

            if (username.Length < 4 || username.Length > 20)
            {
                throw new ApplicationException("Invalid Username");
            }
            if (password.Length < 7) // we really need a better method
            {                        // possibly a regex for complexity
                throw new ApplicationException("Invalid Password");
            }


            try
            {
                if (1 == UserAccessor.VerifyUsernameAndPassword(username, HashSHA256(password)))
                {
                    password = null;

                    // need to create a user object to use as an access token
                    // get a user object
                    user = UserAccessor.RetrieveUserByUsername(username);
                }
                else
                {
                    throw new ApplicationException("Authentication Fialed!");
                }


                // return the user object
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }
    }

    
}
