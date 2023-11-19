namespace BasicSchoolList
{
    public class User : BaseClass
    {
        public string Name { get; set; } = default!;
        public string StudentClass { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public int Age { get; set; }
        public string UserType { get; set; } = default!;
        public string ParentContact { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string HomeAddress { get; set; } = default!;
        public string AdmissionNumber { get; set; } = default!; // Randomly generated admission number for students

        // Additional properties for the user staffs 
        public string EducationQualification { get; set; } = default!;
        public string MaritalStatus { get; set; } = default!;
        public string StaffID { get; set; }  = default!; // Randomly generated staff ID for staff

        internal object CreatedAtHumanize()
        {
            throw new NotImplementedException();
        }

    }
}