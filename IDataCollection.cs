namespace BasicSchoolList
{
    public interface IDataCollection
    {
        void AddStudent(string name, string studentClass, int age, string gender, string email, string parentContact, string homeAddress, string userType, string admissionNumber);
        void AddStaff(string sName, string educationQualification, int sAge, string sGender, string sEmail, string phoneNumber, string sHomeAddress, string maritalStatus, string userType, string staffID);
        bool FindUser(string admissionNumber, string staffID);
        bool IsUserExist(string admissionNumber, string staffID);
        void SearchUser(string admissionNumber, string staffID);
        void DeleteUser(string admissionNumber, string staffID);
        void UpdateUser(string admissionNumber, string staffID, string name, string email, string parentContact, string phoneNumber, string maritalStatus, string educationQualification);
        void PrintStaffsData();
        void PrintStudentsData();
        void PrintUsersData();
        void MessageAndColor(string message, ConsoleColor ConsoleColor = ConsoleColor.Red);
        void Print(User user);
    }
}