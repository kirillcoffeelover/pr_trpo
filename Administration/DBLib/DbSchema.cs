namespace DBLib
{
    public enum UserRole
    {
        Invalid = -1,
        Admin,
        Common
    }
    public enum UserStatusStatus
    {
        Default,
        Works,
        OnSickLeave,
        Fired
    }
    internal static class DbSchema
    {
        public const string DatabaseName = "\"Administration\"";
        public static class Occupations
        {
            public static string This = "Occupations";
            public static string ID = "ID";
            public static string Occupation = "Occupation";
        }
        public static class Departments
        {
            public static string This = "Departments";
            public static string ID = "ID";
            public static string Department = "Department";
        }
        public static class Statuses
        {
            public static string This = "Statuses";
            public static string ID = "ID";
            public static string Status = "Status";
        }
        public static class Roles
        {
            public static string This = "Roles";
            public static string ID = "ID";
            public static string Role = "Role";
        }
        public static class UserInfo
        {
            public static string This = "UserInfo";
            public static string Login = "Login";
            public static string FirstName = "FirstName";
            public static string SecondName = "SecondName";
            public static string LastName = "LastName";
            public static string phoneNumber = "PhoneNumber";
            public static string EmailAddress = "EmailAddress";
            public static string Department = "Department";
            public static string Occupation = "Occupation";
            public static string Status = "Status";
        }
        public static class Users
        {
            public static string This = "Users";
            public static string ID = "ID";
            public static string Login = "Login";
            public static string Password = "Password";
            public static string Role = "Role";
        }
        public static string DoubleQuoted(string name)
        {
            return $"\"{name}\"";
        }
        public static string SingleQuoted(string name)
        {
            return $"\'{name}\'";
        }
    }
}
