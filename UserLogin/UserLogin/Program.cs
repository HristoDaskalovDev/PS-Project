using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = UserData.TestUsers;
            displayLoginScreen();
        }

        public static void displayErrorMessage(string errMsg) {
            Console.WriteLine(errMsg);
            Console.ReadLine();
        }

        public static void displayMenu() {
            Console.WriteLine(
                "Choose an option:\n" +
                "0: Exit\n" +
                "1: Change user role\n" +
                "2: Change user valid period\n" +
                "3: Display users\n" + 
                "4: Show all logs\n"
            );

            String userChoice = Console.ReadLine();

            try {
                int parsedUserChoice = Int32.Parse(userChoice);

                switch(parsedUserChoice){
                case 0: 
                    Console.Clear();
                    saveUserLogs();
                    displayLoginScreen();
                    break;  
                case 1:
                    assignUserRole();
                    break;
                case 2:
                    changeUserValidPeriod();
                    break;
                case 3:
                    displayUserList();
                    break;
                case 4:
                    showAllLogs();
                    break;
                default:
                    Console.WriteLine("Tuka nqq nishto brat");
                    break;
            }
            } catch(Exception ex) {
                Console.WriteLine("Invalid input");
                displayMenu();
            }
        }

        public static void displayLoginScreen() {
        
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            LoginValidation loginValidation = new LoginValidation(username, password, displayErrorMessage);
            if (loginValidation.ValidateUserInput()) {
                displayMenu();
            } else {
                Console.WriteLine("Invalid credentials");
            }
        }

        private static void assignUserRole() {
            
            Console.WriteLine("Enter user's name: ");
            String username = Console.ReadLine();

            Console.WriteLine("Choose a role: ");
            int counter = 0;
            foreach (String roleName in Enum.GetNames(typeof(UserRole))) {
                
                Console.WriteLine(counter + ": " + roleName);
                counter++;
            }

            String roleIndex = Console.ReadLine();

            try{
                int roleIndexParsed = Int32.Parse(roleIndex);
                
                counter = 0;
                foreach (UserRole userRole in Enum.GetValues(typeof(UserRole))) {
                    
                    if (roleIndexParsed.Equals(counter)) {
                        UserData.assignUserRole(username, userRole);
                        Console.WriteLine("User role changed successfully");
                        displayMenu();
                    }
                    counter ++;
                }
            } catch(Exception ex) {
                Console.WriteLine("Invalid input");
                assignUserRole();
            }
        }

        private static void changeUserValidPeriod() {
            
            Console.WriteLine("Enter user's name: ");
            String username = Console.ReadLine();

            Console.WriteLine("Enter valid date in the format dd/mm/yyyy: ");
            String date = Console.ReadLine();

            DateTime dateTime;
            try{
                dateTime = Convert.ToDateTime(date);
                
                if (dateTime < DateTime.Now) {
                    Console.WriteLine("Cannot set date that is in the past");
                    displayMenu();
                }

                UserData.setUserActiveTo(username, dateTime);
                Console.WriteLine("Date changed successfully");

            } catch (Exception ex) {
                Console.WriteLine("Invalid date");
                displayMenu();
            }
        }

        private static void displayUserList()
        {
            foreach (User user in UserData.TestUsers)
            {
                Console.WriteLine("Username: " + user.Name);
            }

            Console.WriteLine("Press any key to go back to menu");
            Console.ReadLine();

            displayMenu();
        }

        private static void saveUserLogs()
        {
            if (Logger.currentSessionActivities.Any())
            {
                Logger.saveLogToFile();
            }
        }

        private static void showAllLogs()
        {
            Logger.displayLogs();
            displayMenu();
        }
    }
}
