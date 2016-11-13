using SpeedTyperDataObjects;
using SpeedTyperDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

            if (username.Length < 4)
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
                    throw new ApplicationException("Authentication Failed!");
                }


                // return the user object
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }


        public User CreateUser(string username, string displayname, string password)
        {
            /**
             * Creates user and then returns the user if successful
             */
            // username can only contain letters, numbers, and underscores
            String nameRegexString = @"^\w+$";
            Regex nameRegex = new Regex(nameRegexString);

            // password  - Minimum 8 characters at least 1 Alphabet and 1 Number with Optional Special Chars
            String passwordRegexString = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!$%@#£€*?&]{8,}$"; // http://stackoverflow.com/a/21456918/7124631
            Regex passwordRegex = new Regex(passwordRegexString);

            User _user = null;

            if (nameRegex.Match(username).Success == false)
            {
                throw new ApplicationException("Username can only contain letters, numbers, and underscores.");
            }
            else if (nameRegex.Match(displayname).Success == false)
            {
                throw new ApplicationException("Display Name can only contain letters, numbers, and underscores.");
            }
            else if (passwordRegex.Match(password).Success == false)
            {
                throw new ApplicationException("Password must have at least 8 characters, 1 letter, and 1 number");
            }


            try
            {
                // can't use a username that already exists.
                if (VerifyIfUserNameExists(username) == true)
                {
                    throw new ApplicationException("Username already exists!");
                }
                else
                {
                    if (1 == UserAccessor.CreateUser(username, displayname, HashSHA256(password)))
                    {
                        password = null;
                        _user = UserAccessor.RetrieveUserByUsername(username);
                    }
                    else
                    {
                        throw new ApplicationException("Account Creation Failed!");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return _user;
        }

        public User CreateGuestUser()
        {
            return new User()
            {
                UserID = 0,
                UserName = "Guest",
                DisplayName = "<none>",
                TitleID = 0,
                CurrentXP = 0,
                XPToLevel = 0,
                Level = 0,
                IsGuest = true
            };
        }

        public bool VerifyIfUserNameExists(string username)
        {
            bool userNameFound = false;
            // If we find a user with supplied username, then return true
            try
            {
                if (UserAccessor.RetrieveUserByUsername(username) != null)
                {
                    userNameFound = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return userNameFound;
        }
    }


}
