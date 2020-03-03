using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        private static List<User> testUsers = new List<User>();

        private static void ResetTestUsersData()
        {
            testUsers.Add(new User("Icoslav", "12345", "000000000", UserRole.ADMIN));
            testUsers.Add(new User("Silvaq", "12345", "000000000", UserRole.STUDENT));
            testUsers.Add(new User("Georgius", "12345", "000000000", UserRole.STUDENT));
        }

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUsersData();
                return testUsers;
            }
            set{}
        }

        public static User isUserPassCorrect(String username, String password)
        {
            User user = findUserByUsername(username);    
            if(user.Password.Equals(password)) {
                    return user;
            }
            
            return null;
        }

        public static void setUserActiveTo(String username, DateTime dateTime) {
            User user = findUserByUsername(username);
            if (user != null) {
                user.ValidUntil = dateTime;
                Logger.logActivity("Change of user validity period for user: " + user.Name + "\n");
            }
        }

        public static void assignUserRole(String username, UserRole userRole){
            User user = findUserByUsername(username);
            if (user != null) {
                user.Role = userRole;
                Logger.logActivity("Change of user role for user: " + user.Name + "\n");
            }
        }

        private static User findUserByUsername(String username) {
            foreach (User user in testUsers) 
            {
                if (user.Name.Equals(username)) {
                     return user;
                }
            }

            return null;
        }
    }
}
