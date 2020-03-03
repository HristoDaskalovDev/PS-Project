using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class LoginValidation
    {
        public static UserRole currentUserRole;
        public static string username;
        private string password;
        private string errorMessage;
        private ActionOnError actionOnError;

        public delegate void ActionOnError(string errorMsg);

        private const int FIELD_MIN_LENGTH = 5;

        public LoginValidation(string username, string password, ActionOnError actionOnError) 
        {
            this.Username = username;
            this.Password = password;
            this.actionOnError = actionOnError;
        }

        public bool ValidateUserInput()
        {   
            if (validateField(this.Username, "Username"))
            {
                if (validateField(this.Password, "Password"))
                {
                    User user = UserData.isUserPassCorrect(this.Username, this.Password);
                    Console.WriteLine(user.ToString());

                    if (user != null) 
                    {
                        CurrentUserRole = user.Role;
                        Logger.logActivity("Successful login\n");
                        return true;
                    }

                    this.errorMessage = String.Format("User with name {0} does not exist.", this.Username);
                    this.actionOnError(this.errorMessage);
                }
            }

            CurrentUserRole = UserRole.ANONYMOUS;
            return false;
        }

        private UserRole CurrentUserRole
        {
            set
            {
                currentUserRole = value;
            }
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        private bool validateField(String field, String fieldName) 
        {
            if (field.Equals(String.Empty))
            {
                this.errorMessage = String.Format("{0} cannot be empty.", fieldName);
                this.actionOnError(this.errorMessage);

                return false;
            }

            if (field.Length < FIELD_MIN_LENGTH) 
            {
                this.errorMessage = String.Format(
                    "{0} cannot be less than {1} characters long.", fieldName, FIELD_MIN_LENGTH
                );
                this.actionOnError(this.errorMessage);

                return false;
            }

            return true;
        }
    }
}
