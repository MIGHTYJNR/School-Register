using ConsoleTables;
using Humanizer;

namespace BasicSchoolList
{
    internal class DataCollection : IDataCollection
    {
        public static List<User> User = new();


        public void AddStudent(string name, string studentClass, int age, string gender, string email, string parentContact, string homeAddress, string userType, string admissionNumber)
        {
            int id = User.Count > 0 ? User.Count + 1 : 1;

            var user = IsUserExist(name, name);
            if (user)
            {
                MessageAndColor($"\nStudent with name {name} already exist", ConsoleColor.Red);
                return;
            }

            var student = new User
            {
                Id = id,
                Name = name,
                StudentClass = studentClass,
                Age = age,
                Gender = gender,
                Email = email,
                ParentContact = parentContact,
                HomeAddress = homeAddress,
                UserType = "Student",
                AdmissionNumber = admissionNumber,
                CreatedAt = DateTime.Now
            };

            User.Add(student);
            MessageAndColor($"\nStudent added successfully!", ConsoleColor.Green);
        }

        public void AddStaff(string sName, string educationQualification, int sAge, string sGender, string sEmail, string phoneNumber, string sHomeAddress, string maritalStatus, string userType, string staffID)
        {
            int id = User.Count > 0 ? User.Count + 1 : 1;

            var user = IsUserExist(sName, sName);
            if (user)
            {
                MessageAndColor($"\nStaff with name {sName} already exist", ConsoleColor.Red);
                return;
            }

            var staff = new User
            {
                Id = id,
                Name = sName,
                EducationQualification = educationQualification,
                Age = sAge,
                Gender = sGender,
                Email = sEmail,
                PhoneNumber = phoneNumber,
                HomeAddress = sHomeAddress,
                MaritalStatus = maritalStatus,
                UserType = "Staff",
                StaffID = staffID,
                CreatedAt = DateTime.Now
            };

            User.Add(staff);

            MessageAndColor($"\nStaff added successfully!", ConsoleColor.Green);
        }

        public void DeleteUser(string admissionNumber, string staffID)
        {
            int UserCount = User.Count;

            if (UserCount == 0)
            {
                MessageAndColor($"\nThere is no User added yet.", ConsoleColor.Red);
                return;
            }

            var user = FindUser(admissionNumber, staffID);
            if (user is null)
            {
                MessageAndColor($"\nUser with admission number {admissionNumber} or staff Id {staffID} not found", ConsoleColor.Red);
                return;
            }
            else
            {
                MessageAndColor($"\nDeleting User...", ConsoleColor.Cyan);

                User.Remove(user);

                MessageAndColor($"\nUser deleted successfully!", ConsoleColor.Green);
            }
        }

        public User? FindUser(string admissionNumber, string staffID)
        {
            return User.Find(u => u.AdmissionNumber == admissionNumber || u.StaffID == staffID);
            // Find the user using admission number or staff ID
        }

        public void MessageAndColor(string message, ConsoleColor ConsoleColor = ConsoleColor.Red)
        {
            Console.ForegroundColor = ConsoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Print(User user)
        {
            Console.WriteLine($"Name: {user!.Name}\nUsertype: {user!.UserType}\nUser ID: {user!.StaffID}{user!.AdmissionNumber}\nPhone Number: {user!.PhoneNumber}{user!.ParentContact}\nEmail: {user!.Email}");
        }

        public void PrintStaffsData()
        {
            // int sId = User.Count > 0 ? User.Count + 1 : 1;

            // var user = new User
            // {
            //     SId = sId,
            // };

            // while (sId < User.Count)
            // {
            //     sId++;
            // }

            int UserCount = User.Count;

            if (UserCount == 0)
            {
                MessageAndColor($"There is no staff added yet.", ConsoleColor.Red);
                return;
            }
            MessageAndColor($"\nPrinting all staffs data...", ConsoleColor.Cyan);

            var table = new ConsoleTable("Id", "Name", "User Type", "Staff ID", "Qualification", "Age", "Gender", "Phone Number", "Email", "Address", "Marital Status", "Time Created");
            foreach (var staff in User)
            {
                if (staff.UserType == "Staff")
                {
                    table.AddRow(staff.Id, staff.Name, staff.UserType, staff.StaffID, staff.EducationQualification, staff.Age, staff.Gender, staff.PhoneNumber, staff.Email, staff.HomeAddress, staff.MaritalStatus, staff.CreatedAt.Humanize());
                }
                Console.WriteLine();
            }
            table.Write(Format.Alternative);
        }

        public void PrintStudentsData()
        {
            int UserCount = User.Count;

            if (UserCount == 0)
            {
                MessageAndColor($"There is no student added yet.", ConsoleColor.Red);
                return;
            }
            MessageAndColor($"\nPrinting all students data...", ConsoleColor.Cyan);

            var table = new ConsoleTable("Id", "Name", "User Type", "Admission No", "Class", "Age", "Gender", "Parent Contact", "Email", "Address", "Time Created");
            foreach (var student in User)
            {
                if (student.UserType == "Student")
                {
                    table.AddRow(student.Id, student.Name, student.UserType, student.AdmissionNumber, student.StudentClass, student.Age, student.Gender, student.ParentContact, student.Email, student.HomeAddress, student.CreatedAt.Humanize());
                }
                Console.WriteLine();
            }
            table.Write(Format.Alternative);
        }

        public void PrintUsersData()
        {
            int UserCount = User.Count;

            if (UserCount == 0)
            {
                MessageAndColor($"There is no User added yet.", ConsoleColor.Red);
                return;
            }
            MessageAndColor($"\n==PRINTING ALL USER DATA==", ConsoleColor.Blue);
            Console.WriteLine("\nYou have " + "Users".ToQuantity(UserCount));

            PrintStudentsData();
            PrintStaffsData();
            // foreach (var user in User)
            // {
            //     if (user.UserType == "Student")
            //     {
            //         var table = new ConsoleTable("Id", "Name", "User Type", "Admission No", "Class", "Age", "Gender", "Parent Contact", "Email", "Address", "Time Created");

            //         table.AddRow(user.Id, user.Name, user.UserType, user.AdmissionNumber, user.StudentClass, user.Age, user.Gender, user.ParentContact, user.Email, user.HomeAddress, user.CreatedAt.Humanize());

            //         table.Write(Format.Alternative);
            //     }
            //     else
            //     {
            //         var table = new ConsoleTable("Id", "Name", "User Type", "Staff ID", "Qualification", "Age", "Gender", "Phone Number", "Email", "Address", "Marital Status", "Time Created");

            //         table.AddRow(user.Id, user.Name, user.UserType, user.StaffID, user.EducationQualification, user.Age, user.Gender, user.PhoneNumber, user.Email, user.HomeAddress, user.MaritalStatus, user.CreatedAt.Humanize());

            //         table.Write(Format.Alternative);
            //     }

            //     Console.WriteLine();
            // }
        }

        public void SearchUser(string admissionNumber, string staffID)
        {
            int userCount = User.Count;

            if (userCount == 0)
            {
                MessageAndColor($"\nThere is no user added yet.", ConsoleColor.Red);
                return;
            }

            var user = FindUser(admissionNumber, staffID);
            if (user is null)
            {
                MessageAndColor($"\nUser with admission number {admissionNumber} or staff Id {staffID} not found", ConsoleColor.Red);
                return;
            }
            else
            {
                MessageAndColor($"\nSearching User...", ConsoleColor.Cyan);

                MessageAndColor($"\nUser Found!", ConsoleColor.Green);

                Print(user);
            }
        }

        public void UpdateUser(string admissionNumber, string staffID, string name, string email, string parentContact, string phoneNumber, string maritalStatus, string educationQualification)
        {
            int UserCount = User.Count;

            if (UserCount == 0)
            {
                MessageAndColor($"\nThere is no User added yet.", ConsoleColor.Red);
                return;
            }

            var user = FindUser(admissionNumber, staffID);
            if (user is null)
            {
                MessageAndColor($"\nUser does not exist!", ConsoleColor.Red);
                return;
            }

            user.Name = name;
            user.Email = email;
            user.ParentContact = parentContact;
            user.PhoneNumber = phoneNumber;
            user.MaritalStatus = maritalStatus;
            user.EducationQualification = educationQualification;
            MessageAndColor($"\nUser updated successfully.", ConsoleColor.Green);
        }

        bool IDataCollection.FindUser(string admissionNumber, string staffID)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(string name, string sName)
        {
            return User.Any(u => u.Name == name || u.Name == sName);
        }
    }
}
// public void AddStudent(string name, string studentClass, int age, string gender, string email, string parentContact, string homeAddress, string userType, string admissionNumber)
// {
//     int id = User.Count > 0 ? User.Count + 1 : 1;

//     var user = IsUserExist(name, name);
//     if (user)
//     {
//         MessageAndColor($"\nStudent with name {name} already exist", ConsoleColor.Red);
//         return;
//     }

//     var student = new User
//     {
//         Id = id,
//         Name = name,
//         StudentClass = studentClass,
//         Age = age,
//         Gender = gender,
//         Email = email,
//         ParentContact = parentContact,
//         HomeAddress = homeAddress,
//         UserType = "Student",
//         AdmissionNumber = admissionNumber,
//         CreatedAt = DateTime.Now
//     };

//     User.Add(student);
//     MessageAndColor($"\nStudent added successfully!", ConsoleColor.Green);
// }

// public void AddStaff(string sName, string educationQualification, int sAge, string sGender, string sEmail, string phoneNumber, string sHomeAddress, string maritalStatus, string userType, string staffID)
// {
//     int id = User.Count > 0 ? User.Count + 1 : 1;

//     var user = IsUserExist(sName, sName);
//     if (user)
//     {
//         MessageAndColor($"\nStaff with name {sName} already exist", ConsoleColor.Red);
//         return;
//     }

//     var staff = new User
//     {
//         Id = id,
//         Name = sName,
//         EducationQualification = educationQualification,
//         Age = sAge,
//         Gender = sGender,
//         Email = sEmail,
//         PhoneNumber = phoneNumber,
//         HomeAddress = sHomeAddress,
//         MaritalStatus = maritalStatus,
//         UserType = "Staff",
//         StaffID = staffID,
//         CreatedAt = DateTime.Now
//     };

//     User.Add(staff);

//     MessageAndColor($"\nStaff added successfully!", ConsoleColor.Green);
// }

// public User? FindUser(string admissionNumber, string staffID)
// {
//     return User.Find(u => u.AdmissionNumber == admissionNumber || u.StaffID == staffID);
//     // Find the user using admission number or staff ID
// }

// public static bool IsUserExist(string name, string sName)
// {
//     return User.Any(u => u.Name == name || u.Name == sName);
// }

// public void SearchUser(string admissionNumber, string staffID)
// {
//     int userCount = User.Count;

//     if (userCount == 0)
//     {
//         MessageAndColor($"\nThere is no user added yet.", ConsoleColor.Red);
//         return;
//     }

//     var user = FindUser(admissionNumber, staffID);
//     if (user is null)
//     {
//         MessageAndColor($"\nUser with admission number {admissionNumber} or staff Id {staffID} not found", ConsoleColor.Red);
//         return;
//     }
//     else
//     {
//         MessageAndColor($"\nSearching User...", ConsoleColor.Cyan);

//         MessageAndColor($"\nUser Found!", ConsoleColor.Green);

//         Print(user);
//     }
// }

// public void DeleteUser(string admissionNumber, string staffID)
// {
//     int UserCount = User.Count;

//     if (UserCount == 0)
//     {
//         MessageAndColor($"\nThere is no User added yet.", ConsoleColor.Red);
//         return;
//     }

//     var user = FindUser(admissionNumber, staffID);
//     if (user is null)
//     {
//         MessageAndColor($"\nUser with admission number {admissionNumber} or staff Id {staffID} not found", ConsoleColor.Red);
//         return;
//     }
//     else
//     {
//         MessageAndColor($"\nDeleting User...", ConsoleColor.Cyan);

//         User.Remove(user);

//         MessageAndColor($"\nUser deleted successfully!", ConsoleColor.Green);
//     }
// }

// public void PrintStaffsData()
// {
//     // int sId = User.Count > 0 ? User.Count + 1 : 1;

//     // var user = new User
//     // {
//     //     SId = sId,
//     // };

//     // while (sId < User.Count)
//     // {
//     //     sId++;
//     // }

//     int UserCount = User.Count;

//     if (UserCount == 0)
//     {
//         MessageAndColor($"There is no staff added yet.", ConsoleColor.Red);
//         return;
//     }
//     MessageAndColor($"\nPrinting all staffs data...", ConsoleColor.Cyan);

//     var table = new ConsoleTable("Id", "Name", "User Type", "Staff ID", "Qualification", "Age", "Gender", "Phone Number", "Email", "Address", "Marital Status", "Time Created");
//     foreach (var staff in User)
//     {
//         if (staff.UserType == "Staff")
//         {
//             table.AddRow(staff.Id, staff.Name, staff.UserType, staff.StaffID, staff.EducationQualification, staff.Age, staff.Gender, staff.PhoneNumber, staff.Email, staff.HomeAddress, staff.MaritalStatus, staff.CreatedAt.Humanize());
//         }
//         Console.WriteLine();
//     }
//     table.Write(Format.Alternative);
// }

// public void PrintStudentsData()
// {
//     int UserCount = User.Count;

//     if (UserCount == 0)
//     {
//         MessageAndColor($"There is no student added yet.", ConsoleColor.Red);
//         return;
//     }
//     MessageAndColor($"\nPrinting all students data...", ConsoleColor.Cyan);

//     var table = new ConsoleTable("Id", "Name", "User Type", "Admission No", "Class", "Age", "Gender", "Parent Contact", "Email", "Address", "Time Created");
//     foreach (var student in User)
//     {
//         if (student.UserType == "Student")
//         {
//             table.AddRow(student.Id, student.Name, student.UserType, student.AdmissionNumber, student.StudentClass, student.Age, student.Gender, student.ParentContact, student.Email, student.HomeAddress, student.CreatedAt.Humanize());
//         }
//         Console.WriteLine();
//     }
//     table.Write(Format.Alternative);
// }

// public void PrintUsersData()
// {
//     int UserCount = User.Count;

//     if (UserCount == 0)
//     {
//         MessageAndColor($"There is no User added yet.", ConsoleColor.Red);
//         return;
//     }
//     MessageAndColor($"\n==PRINTING ALL USER DATA==", ConsoleColor.Blue);
//     Console.WriteLine("\nYou have " + "Users".ToQuantity(UserCount));

//     PrintStudentsData();
//     PrintStaffsData();
//     // foreach (var user in User)
//     // {
//     //     if (user.UserType == "Student")
//     //     {
//     //         var table = new ConsoleTable("Id", "Name", "User Type", "Admission No", "Class", "Age", "Gender", "Parent Contact", "Email", "Address", "Time Created");

//     //         table.AddRow(user.Id, user.Name, user.UserType, user.AdmissionNumber, user.StudentClass, user.Age, user.Gender, user.ParentContact, user.Email, user.HomeAddress, user.CreatedAt.Humanize());

//     //         table.Write(Format.Alternative);
//     //     }
//     //     else
//     //     {
//     //         var table = new ConsoleTable("Id", "Name", "User Type", "Staff ID", "Qualification", "Age", "Gender", "Phone Number", "Email", "Address", "Marital Status", "Time Created");

//     //         table.AddRow(user.Id, user.Name, user.UserType, user.StaffID, user.EducationQualification, user.Age, user.Gender, user.PhoneNumber, user.Email, user.HomeAddress, user.MaritalStatus, user.CreatedAt.Humanize());

//     //         table.Write(Format.Alternative);
//     //     }

//     //     Console.WriteLine();
//     // }
// }

// public void UpdateUser(string admissionNumber, string staffID, string name, string email, string parentContact, string phoneNumber, string maritalStatus, string educationQualification)
// {
//     int UserCount = User.Count;

//     if (UserCount == 0)
//     {
//         MessageAndColor($"\nThere is no User added yet.", ConsoleColor.Red);
//         return;
//     }

//     var user = FindUser(admissionNumber, staffID);
//     if (user is null)
//     {
//         MessageAndColor($"\nUser does not exist!", ConsoleColor.Red);
//         return;
//     }

//     user.Name = name;
//     user.Email = email;
//     user.ParentContact = parentContact;
//     user.PhoneNumber = phoneNumber;
//     user.MaritalStatus = maritalStatus;
//     user.EducationQualification = educationQualification;
//     MessageAndColor($"\nUser updated successfully.", ConsoleColor.Green);
// }


// public void MessageAndColor(string message, ConsoleColor ConsoleColor = ConsoleColor.Red)
// {
//     Console.ForegroundColor = ConsoleColor;
//     Console.WriteLine(message);
//     Console.ResetColor();
// }

// private static void Print(User user)
// {
//     Console.WriteLine($"Name: {user!.Name}\nUsertype: {user!.UserType}\nUser ID: {user!.StaffID}{user!.AdmissionNumber}\nPhone Number: {user!.PhoneNumber}{user!.ParentContact}\nEmail: {user!.Email}");
// }

// bool IDataCollection.IsUserExist(string admissionNumber, string staffID)
// {
//     throw new NotImplementedException();
// }

// void IDataCollection.Print(User user)
// {
//     throw new NotImplementedException();
// }

// bool IDataCollection.FindUser(string admissionNumber, string staffID)
// {
//     throw new NotImplementedException();
// }