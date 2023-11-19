using BasicSchoolList;

Menu menu = new Menu();
menu.MyMenu();


// using System.Data.Common;
// using ConsoleTables;
// using Humanizer;

// namespace BasicSchoolList
// {
//     internal sealed class DataCollection
//     {
//         // Properties for students
//         // public static int Id { get; set; }
//         public string Name { get; set; } = default!;
//         public string StudentClass { get; set; } = default!;
//         public string PhoneNumber { get; set; } = default!;
//         public string Email { get; set; } = default!;
//         public int Age { get; set; }
//         public string UserType { get; set; } = default!;
//         public string ParentContact { get; set; } = default!;
//         public string Gender { get; set; } = default!;
//         public string HomeAddress { get; set; } = default!;
//         public int AdmissionNumber { get; set; } // Randomly generated admission number for students

//         // Additional properties for the user staffs 
//         public string EducationQualification { get; set; } = default!;
//         public string MaritalStatus { get; set; } = default!;
//         public int StaffID { get; set; } // Randomly generated staff ID for staff

//         public DataCollection()
//         {
//             Random random = new Random();
//             AdmissionNumber = random.Next(1000, 9999);
//             StaffID = random.Next(0001, 1000);
//         }
//         public DateTime CreatedAt = DateTime.Now;

//     }

//     public class Program
//     {

//         public static int Id { get; private set; }

//         public static void Main(string[] args)
//         {
//             List<DataCollection> user = new List<DataCollection>();

//             Console.WriteLine("===Students And Staffs Data Collection!===");

//             while (true)
//             {
//                 Console.WriteLine("\nSelect an option:");
//                 Console.WriteLine("1. Add a student");
//                 Console.WriteLine("2. Add a staff");
//                 Console.WriteLine("3. Print all users data");
//                 Console.WriteLine("4. Print all staffs data");
//                 Console.WriteLine("5. Print all students data");
//                 Console.WriteLine("6. Search User");
//                 Console.WriteLine("7. Delete User");
//                 Console.WriteLine("8. Update User Data");
//                 Console.WriteLine("0. Exit");

//                 string choice = Console.ReadLine()!;

//                 switch (choice)
//                 {
//                     case "0":
//                         MessageAndColor($"Exiting program...", ConsoleColor.Cyan);
//                         return;
//                     case "1":
//                         AddStudent(user);
//                         break;
//                     case "2":
//                         AddStaff(user);
//                         break;
//                     case "3":
//                         PrintUsersData(user);
//                         break;
//                     case "4":
//                         PrintStaffsData(user);
//                         break;
//                     case "5":
//                         PrintStudentsData(user);
//                         break;
//                     case "6":
//                         SearchUser(user);
//                         break;
//                     case "7":
//                         DeleteUser(user);
//                         break;
//                     case "8":
//                         UpdateUser(user);
//                         break;
//                     default:
//                         MessageAndColor($"Invalid choice. Please try again.");
//                         break;
//                 }
//             }
//         }

//         public static void AddStudent(List<DataCollection> user)
//         {
//             MessageAndColor("Enter Student Details:", ConsoleColor.Cyan);

//             DataCollection student = new DataCollection();

//             Console.Write("Enter Fullname [surname/firstname/middle name]: ");
//             student.Name = Console.ReadLine()!;

//             Console.Write("Enter Student's Class: ");
//             student.StudentClass = Console.ReadLine()!;

//             Console.Write("Enter Student Age: ");
//             student.Age = Convert.ToInt32(Console.ReadLine());

//             Console.Write("Enter Student Gender M/F: ");
//             student.Gender = Console.ReadLine()!;

//             Console.Write("Enter Active E-mail: ");
//             student.Email = Console.ReadLine()!;

//             Console.Write("Enter Parent's Contact: ");
//             student.ParentContact = Console.ReadLine()!;

//             Console.Write("Enter HomeAddress: ");
//             student.HomeAddress = Console.ReadLine()!;

//             student.UserType = "Student";

//             user.Add(student);

//             MessageAndColor($"Student added successfully!", ConsoleColor.Green);

//             Console.WriteLine($"Admission Number: {student.AdmissionNumber}");

//         }

//         public static void AddStaff(List<DataCollection> user)
//         {
//             MessageAndColor("Enter staff details:", ConsoleColor.Cyan);

//             DataCollection staff = new DataCollection();

//             Console.Write("Enter Fullname [surname/firstname/middle name]: ");
//             staff.Name = Console.ReadLine()!;

//             Console.Write("Enter Education Qualification: ");
//             staff.EducationQualification = Console.ReadLine()!;

//             Console.Write("Age: ");
//             staff.Age = Convert.ToInt32(Console.ReadLine()!);

//             Console.Write("Enter Staff Gender M/F: ");
//             staff.Gender = Console.ReadLine()!;

//             Console.Write("Enter Active E-mail: ");
//             staff.Email = Console.ReadLine()!;

//             Console.Write("Enter Phone Number: ");
//             staff.PhoneNumber = Console.ReadLine()!;

//             Console.Write("HomeAddress: ");
//             staff.HomeAddress = Console.ReadLine()!;

//             Console.Write("Marital Status: ");
//             staff.MaritalStatus = Console.ReadLine()!;

//             staff.UserType = "Staff";

//             user.Add(staff);

//             MessageAndColor($"Staff added successfully!", ConsoleColor.Green);
//             Console.WriteLine($"Staff ID: S{staff.StaffID}");

//         }

//         public static DataCollection FindUser(List<DataCollection> user)  //return type of the FindUser method is DataCollection and not void 'cause it returns the foundUser.
//         {
//             Console.WriteLine("\nEnter user admission number or staff ID:");
//             string input = Console.ReadLine()!;

//             // Find the user using admission number or staff ID
//             DataCollection? foundUser = user.Find(u => u.AdmissionNumber.ToString() == input || u.StaffID.ToString() == input);
//             return foundUser;
//         }

//         public static void SearchUser(List<DataCollection> user)
//         {
//             int userCount = user.Count;

//             if (userCount == 0)
//             {
//                 MessageAndColor($"There is no student contact added yet.", ConsoleColor.Red);
//                 return;
//             }
//             DataCollection foundUser = FindUser(user);
//             if (foundUser == null)
//             {
//                 MessageAndColor($"User Not Found.", ConsoleColor.Red);
//                 return;
//             }

//             MessageAndColor($"Searching user...", ConsoleColor.Cyan);

//             if (foundUser != null)
//             {
//                 MessageAndColor($"User found!", ConsoleColor.Green);

//                 Console.WriteLine($"Name: {foundUser.Name}");
//                 Console.WriteLine($"User Type: {foundUser.UserType}");
//                 Console.WriteLine($"User ID: {foundUser.StaffID}{foundUser.AdmissionNumber}");
//                 Console.WriteLine($"User Email: {foundUser.Email}");
//                 Console.WriteLine($"User Contact: {foundUser.PhoneNumber}{foundUser.ParentContact}");
//             }
//         }

//         public static void DeleteUser(List<DataCollection> user)
//         {
//             int userCount = user.Count;

//             if (userCount == 0)
//             {
//                 MessageAndColor($"There is no user added yet.", ConsoleColor.Red);
//                 return;
//             }
//             DataCollection foundUser = FindUser(user);
//             if (foundUser == null)
//             {
//                 MessageAndColor($"User Not Found.", ConsoleColor.Red);
//                 return;
//             }
//             MessageAndColor($"Deleting User...", ConsoleColor.Cyan);

//             if (foundUser != null)
//             {
//                 // Removing the found user from the list
//                 user.Remove(foundUser);
//                 MessageAndColor($"User deleted successfully!", ConsoleColor.Green);
//             }
//             else
//             {
//                 MessageAndColor($"User not found.", ConsoleColor.Red);
//             }
//         }

//         public static void UpdateUser(List<DataCollection> user)
//         {
//             int userCount = user.Count;

//             if (userCount == 0)
//             {
//                 MessageAndColor($"There is no user added yet.", ConsoleColor.Red);
//                 return;
//             }
//             DataCollection foundUser = FindUser(user);

//             if (foundUser is null)
//             {
//                 MessageAndColor($"User does not exist!", ConsoleColor.Red);
//                 return;
//             }
//             MessageAndColor($"Update initiated.... ", ConsoleColor.Cyan);
//             Console.Write("Enter User Name: ");
//             var name = Console.ReadLine()!;
//             Console.Write("Enter Email: ");
//             var email = Console.ReadLine()!;
//             Console.Write("Enter Parent Contact: ");
//             var parentContact = Console.ReadLine()!;
//             Console.Write("Enter Phone No: ");
//             var phoneNumber = Console.ReadLine()!;
//             Console.Write("Enter Marital Statis: ");
//             var maritalStatus = Console.ReadLine()!;
//             Console.Write("Enter Education Qualification: ");
//             var educationQualification = Console.ReadLine()!;

//             foundUser.Name = name;
//             foundUser.Email = email;
//             foundUser.ParentContact = parentContact;
//             foundUser.PhoneNumber = phoneNumber;
//             foundUser.MaritalStatus = maritalStatus;
//             foundUser.EducationQualification = educationQualification;
//             MessageAndColor($"Contact updated successfully.", ConsoleColor.Green);
//         }

//         public static void PrintStaffsData(List<DataCollection> user)
//         {
//             int userCount = user.Count;

//             if (userCount == 0)
//             {
//                 MessageAndColor($"There is no staff added yet.", ConsoleColor.Red);
//                 return;
//             }
//             MessageAndColor($"\nPrinting all staffs data...", ConsoleColor.Cyan);

//             var table = new ConsoleTable("Id", "Name", "User Type", "Staff ID", "Qualification", "Age", "Gender", "Phone Number", "Email", "Address", "Marital Status", "Time Created");
//             foreach (DataCollection DataCollection in user)
//             {
//                 if (DataCollection.UserType == "Staff")
//                 {
//                     table.AddRow(Id, DataCollection.Name, DataCollection.UserType, "S" + DataCollection.StaffID, DataCollection.EducationQualification, DataCollection.Age, DataCollection.Gender, DataCollection.PhoneNumber, DataCollection.Email, DataCollection.HomeAddress, DataCollection.MaritalStatus, DataCollection.CreatedAt.Humanize());
//                 }
//                 Console.WriteLine();
//             }
//             table.Write(Format.Alternative);
//         }

//         public static void PrintStudentsData(List<DataCollection> user)
//         {
//             int userCount = user.Count;

//             if (userCount == 0)
//             {
//                 MessageAndColor($"There is no student added yet.", ConsoleColor.Red);
//                 return;
//             }
//             MessageAndColor($"\nPrinting all students data...", ConsoleColor.Cyan);

//             var table = new ConsoleTable("Id", "Name", "User Type", "Admission No", "Class", "Age", "Gender", "Parent Contact", "Email", "Address", "Time Created");
//             foreach (DataCollection DataCollection in user)
//             {
//                 if (DataCollection.UserType == "Student")
//                 {
//                     table.AddRow(Id, DataCollection.Name, DataCollection.UserType, DataCollection.AdmissionNumber, DataCollection.StudentClass, DataCollection.Age, DataCollection.Gender, DataCollection.ParentContact, DataCollection.Email, DataCollection.HomeAddress, DataCollection.CreatedAt.Humanize());
//                 }
//                 Console.WriteLine();
//             }
//             table.Write(Format.Alternative);
//         }

//         public static void PrintUsersData(List<DataCollection> user)
//         {
//             int userCount = user.Count;

//             if (userCount == 0)
//             {
//                 MessageAndColor($"There is no user added yet.", ConsoleColor.Red);
//                 return;
//             }
//             MessageAndColor($"==PRINTING ALL USER DATA==", ConsoleColor.Blue);
//             Console.WriteLine("You have " + "users".ToQuantity(userCount));
//             PrintStaffsData(user);
//             PrintStudentsData(user);
//         }

//         public static void MessageAndColor(string message, ConsoleColor ConsoleColor = ConsoleColor.Red)
//         {
//             Console.ForegroundColor = ConsoleColor;
//             Console.WriteLine(message);
//             Console.ResetColor();
//         }
//     }
// }