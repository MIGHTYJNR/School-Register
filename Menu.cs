using System.Security.Cryptography;
using System.IO; // include the System.IO namespace
using Humanizer;  

namespace BasicSchoolList
{
    public class Menu
    {
        public Menu()
        {
            dataCollection = new DataCollection();
        }
        private readonly IDataCollection dataCollection;


        public static void PrintMenu()
        {
            Console.Title = "SCHOOL CONSOLE";

            string greetings = "HELLO USER!\n";  // Create a text string
            File.WriteAllText("filegreetings.txt", greetings); // Create a file and write the content of greetings to it

            string readGreetings = File.ReadAllText("filegreetings.txt");  // Read the contents of the file
            Console.WriteLine(readGreetings);  // Output the content

            MessageAndColor("===Students And Staffs Data Collection!===", ConsoleColor.Yellow);
            

            Console.WriteLine("Enter 1 to Add a student");
            Console.WriteLine("Enter 2 to Add a staff");
            Console.WriteLine("Enter 3 to Print all users data");
            Console.WriteLine("Enter 4 to Print all staffs data");
            Console.WriteLine("Enter 5 to Print all students data");
            Console.WriteLine("Enter 6 to Search User");
            Console.WriteLine("Enter 7 to Delete User");
            Console.WriteLine("Enter 8 to Update User Data");
            Console.WriteLine("Enter 0 to Exit");
        }
        public void MyMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                PrintMenu();
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    string S = "S";

                    string P = "P";

                    switch (option)
                    {
                        case 0:
                            exit = true;
                            MessageAndColor($"Exiting program...", ConsoleColor.Cyan);
                            return;
                        case 1:
                            MessageAndColor("Enter Student Details:", ConsoleColor.Cyan);

                            Console.Write("Enter Fullname [Surname Firstname Middlename]: ");
                            var name = Console.ReadLine()!;

                            Console.Write("Enter Student's Class: ");
                            var studentClass = Console.ReadLine()!;
                            studentClass = studentClass.ToUpper();

                            Console.Write("Enter Student Age: ");
                            var age = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Student Gender M/F: ");
                            var gender = Console.ReadLine()!;
                            gender = gender.ToUpper();

                            Console.Write("Enter Active E-mail: ");
                            var email = Console.ReadLine()!;
                            email = email.ToLower();

                            Console.Write("Enter Parent's Contact: ");
                            var parentContact = Console.ReadLine()!;

                            Console.Write("Enter HomeAddress: ");
                            var homeAddress = Console.ReadLine()!;

                            var userType = "Student";

                            Random random = new();
                            var admissionNum = random.Next(1000, 9999);
                            string admissionNumber = P + admissionNum;
                            Console.WriteLine($"Admission Number: {admissionNumber}");


                            dataCollection.AddStudent(name, studentClass, age, gender, email, parentContact, homeAddress, userType, admissionNumber);
                            break;
                        case 2:
                            MessageAndColor("Enter staff details:", ConsoleColor.Cyan);

                            Console.Write("Enter Fullname [surname/firstname/middle name]: ");
                            var sName = Console.ReadLine()!;

                            Console.Write("Enter Education Qualification: ");
                            var educationQualification = Console.ReadLine()!;

                            Console.Write("Age: ");
                            var sAge = Convert.ToInt32(Console.ReadLine()!);

                            Console.Write("Enter Staff Gender M/F: ");
                            var sGender = Console.ReadLine()!;
                            sGender = sGender.ToUpper();

                            Console.Write("Enter Active E-mail: ");
                            var sEmail = Console.ReadLine()!;
                            sEmail = sEmail.ToLower();

                            Console.Write("Enter Phone Number: ");
                            var phoneNumber = Console.ReadLine()!;

                            Console.Write("HomeAddress: ");
                            var sHomeAddress = Console.ReadLine()!;

                            Console.Write("Enter Marital Status M/S: ");
                            var maritalStatus = Console.ReadLine()!;
                            maritalStatus = maritalStatus.ToUpper();

                            var UserType = "Staff";

                            Random sRandom = new Random();
                            var staffId = sRandom.Next(0100, 1000);
                            string staffID = S + staffId;
                            Console.WriteLine($"Staff ID: {staffID}");
                            

                            dataCollection.AddStaff(sName, educationQualification, sAge, sGender, sEmail, phoneNumber, sHomeAddress, maritalStatus, UserType, staffID);
                            break;
                        case 3:
                            dataCollection.PrintUsersData();
                            break;
                        case 4:
                            dataCollection.PrintStaffsData();
                            break;
                        case 5:
                            dataCollection.PrintStudentsData();
                            break;
                        case 6:
                            MessageAndColor($"\nEnter user admission number or staff ID you want to search:", ConsoleColor.Cyan);
                            var input =Console.ReadLine()!;
                            input = input.ToUpper();
                            dataCollection.SearchUser(input, input);
                            break;
                        case 7:
                            MessageAndColor($"\nEnter user admission number or staff ID you want to delete:", ConsoleColor.Cyan);
                            var deleteUser = Console.ReadLine()!;
                            deleteUser = deleteUser.ToUpper();
                            dataCollection.DeleteUser(deleteUser, deleteUser);
                            break;
                        case 8:
                            MessageAndColor($"\nEnter user admission number or staff ID you want to update:", ConsoleColor.Cyan);
                            var updateUser = Console.ReadLine()!;
                            updateUser = updateUser.ToUpper();

                            MessageAndColor($"Update initiated.... ", ConsoleColor.Cyan);
                            Console.Write("Enter User Name: ");
                            var nameToEdit = Console.ReadLine()!;
                            Console.Write("Enter Email: ");
                            var emailToEdit = Console.ReadLine()!;
                            Console.Write("Enter Parent Contact: ");
                            var parentContactToEdit = Console.ReadLine()!;
                            Console.Write("Enter Phone No: ");
                            var phoneNumberToEdit = Console.ReadLine()!;
                            Console.Write("Enter Marital Status: ");
                            var maritalStatusToEdit = Console.ReadLine()!;
                            Console.Write("Enter Education Qualification: ");
                            var educationQualificationToEdit = Console.ReadLine()!;

                            dataCollection.UpdateUser(updateUser, updateUser, nameToEdit, emailToEdit, parentContactToEdit, phoneNumberToEdit, maritalStatusToEdit, educationQualificationToEdit);

                            break;
                        default:
                            MessageAndColor($"Invalid input. Please try again.");
                            break;
                    }
                    if (!exit)
                    {
                        HoldScreen();
                    }
                }

            }
        }

        private static void MessageAndColor(string message, ConsoleColor ConsoleColor = ConsoleColor.Red)
        {
            Console.ForegroundColor = ConsoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void HoldScreen()
        {
            MessageAndColor("Press any key to continue.", ConsoleColor.Yellow);
            Console.ReadKey();
        }
    }
}
