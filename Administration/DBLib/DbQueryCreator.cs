namespace DBLib
{
    public static class DbQueryCreator
    {
        public static string SelectLogin()
        {
            string query = string.Format(
                "SELECT\n\t{0}\nFROM\n\t{1};",
                DbSchema.DoubleQuoted(DbSchema.Users.Login),
                DbSchema.DoubleQuoted(DbSchema.Users.This));

            return query;
        }
        public static string SelectDepartments()
        {
            string query =
                string.Format(
                    "SELECT\n\t{0}\nFROM\n\t{1};",
                    DbSchema.DoubleQuoted(DbSchema.Departments.Department),
                    DbSchema.DoubleQuoted(DbSchema.Departments.This));

            return query;
        }
        public static string InsertIntoDepartments(string value)
        {
            string query =
                string.Format(
                    "INSERT INTO"
                    + "\n\t{0}"
                    + "\n\t({1})"
                    + "\nVALUES"
                    + "\n\t({2});",
                    DbSchema.DoubleQuoted(DbSchema.Departments.This),
                    DbSchema.DoubleQuoted(DbSchema.Departments.Department),
                    DbSchema.SingleQuoted(value));

            return query;
        }
        public static string SelectOccupations()
        {
            string query =
                string.Format(
                    "SELECT\n\t{0}\nFROM\n\t{1};",
                    DbSchema.DoubleQuoted(DbSchema.Occupations.Occupation),
                    DbSchema.DoubleQuoted(DbSchema.Occupations.This));

            return query;
        }
        public static string InsertIntoOccupations(string value)
        {
            string query =
                string.Format(
                    "INSERT INTO"
                    + "\n\t{0}"
                    + "\n\t({1})"
                    + "\nVALUES"
                    + "\n\t({2});",
                    DbSchema.DoubleQuoted(DbSchema.Occupations.This),
                    DbSchema.DoubleQuoted(DbSchema.Occupations.Occupation),
                    DbSchema.SingleQuoted(value));

            return query;
        }
        public static string SelectStatuses()
        {
            string query = string.Format(
                "SELECT\n\t{0}\nFROM\n\t{1};",
                DbSchema.DoubleQuoted(DbSchema.Statuses.Status),
                DbSchema.DoubleQuoted(DbSchema.Statuses.This));

            return query;
        }
        public static string InsertIntoStatuses(string value)
        {
            string query =
                string.Format(
                    "INSERT INTO"
                    + "\n\t{0}"
                    + "\n\t({1})"
                    + "\nVALUES"
                    + "\n\t({2});",
                    DbSchema.DoubleQuoted(DbSchema.Statuses.This),
                    DbSchema.DoubleQuoted(DbSchema.Statuses.Status),
                    DbSchema.SingleQuoted(value));

            return query;
        }
        public static string SelectRoles()
        {
            string query = string.Format(
                "SELECT\n\t{0}\nFROM\n\t{1};",
                DbSchema.DoubleQuoted(DbSchema.Roles.Role),
                DbSchema.DoubleQuoted(DbSchema.Roles.This));

            return query;
        }
        public static string InsertIntoRoles(string value)
        {
            string query =
                string.Format(
                    "INSERT INTO"
                    + "\n\t{0}"
                    + "\n\t({1})"
                    + "\nVALUES"
                    + "\n\t({2});",
                    DbSchema.DoubleQuoted(DbSchema.Roles.This),
                    DbSchema.DoubleQuoted(DbSchema.Roles.Role),
                    DbSchema.SingleQuoted(value));

            return query;
        }
        public static string SelectPassword(string login)
        {
            string query =
                string.Format(
                    "SELECT\n\t{0}\nFROM\n\t{1}\nWHERE\n\t{2} = {3};",
                    DbSchema.DoubleQuoted(DbSchema.Users.Password),
                    DbSchema.DoubleQuoted(DbSchema.Users.This),
                    DbSchema.DoubleQuoted(DbSchema.Users.Login),
                    DbSchema.SingleQuoted(login));

            return query;
        }
        public static string SelectRole(string login)
        {
            string query =
                string.Format(
                    "SELECT\n\t{0}\nFROM\n\t{1}\nWHERE\n\t{2} = {3}",
                    DbSchema.DoubleQuoted(DbSchema.Users.Role),
                    DbSchema.DoubleQuoted(DbSchema.Users.This),
                    DbSchema.DoubleQuoted(DbSchema.Users.Login),
                    DbSchema.SingleQuoted(login));

            query =
                string.Format(
                    "SELECT\n\t{0}FROM{1}\nWHERE\n\t{2} = ({3});",
                    DbSchema.DoubleQuoted(DbSchema.Roles.Role),
                    DbSchema.DoubleQuoted(DbSchema.Roles.This),
                    DbSchema.DoubleQuoted(DbSchema.Roles.ID),
                    query);

            return query;
        }
        public static string InsertIntoUserInfo(
            string login,
            string firstName,
            string secongName,
            string lastName,
            string phoneNumber,
            string emailAddress,
            string department,
            string occupation,
            string status)
        {
            string query = string.Format(
                "INSERT INTO"
                + "\n\t{0}"
                + "\n\t("
                + "\n\t\t{1},"
                + "\n\t\t{2},"
                + "\n\t\t{3},"
                + "\n\t\t{4},"
                + "\n\t\t{5},"
                + "\n\t\t{6},"
                + "\n\t\t{7},"
                + "\n\t\t{8},"
                + "\n\t\t{9}"
                + "\n\t)"
                + "\nVALUES"
                + "\n\t("
                + "\n\t\t{10},"
                + "\n\t\t{11},"
                + "\n\t\t{12},"
                + "\n\t\t{13},"
                + "\n\t\t{14},"
                + "\n\t\t{15},"
                + "\n\t\t{16},"
                + "\n\t\t{17},"
                + "\n\t\t{18}"
                + "\n\t);",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.FirstName),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.SecondName),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.LastName),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.phoneNumber),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.EmailAddress),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Department),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Occupation),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Status),
                DbSchema.SingleQuoted(login),
                DbSchema.SingleQuoted(firstName),
                DbSchema.SingleQuoted(secongName),
                DbSchema.SingleQuoted(lastName),
                DbSchema.SingleQuoted(phoneNumber),
                DbSchema.SingleQuoted(emailAddress),
                string.Format(
                    "get_department_id({0})",
                    DbSchema.SingleQuoted(department)),
                string.Format(
                    "get_occupation_id({0})",
                    DbSchema.SingleQuoted(occupation)),
                string.Format(
                    "get_status_id({0})",
                    DbSchema.SingleQuoted(status)));

            return query;
        }
        public static string InsertIntoUsers(
            UserRole userRole,
            string login,
            string password)
        {
            string role = string.Empty;

            switch (userRole)
            {
                case UserRole.Admin:
                    {
                        role = "Admin";
                        break;
                    }
                case UserRole.Common:
                    {
                        role = "Common";
                        break;
                    }
                default:
                    {
                        throw new System.ArgumentException(
                            $"userRole: invalid value {userRole.ToString()}");
                    }
            }

            string query =
                string.Format("INSERT INTO"
                + "\n\t{0}"
                + "\n\t("
                + "\n\t\t{1},"
                + "\n\t\t{2},"
                + "\n\t\t{3}"
                + "\n\t)"
                + "\nVALUES"
                + "\n\t("
                + "\n\t\t{4},"
                + "\n\t\t{5},"
                + "\n\t\t{6}"
                + "\n\t);",
                DbSchema.DoubleQuoted(DbSchema.Users.This),
                DbSchema.DoubleQuoted(DbSchema.Users.Login),
                DbSchema.DoubleQuoted(DbSchema.Users.Password),
                DbSchema.DoubleQuoted(DbSchema.Users.Role),
                DbSchema.SingleQuoted(login),
                DbSchema.SingleQuoted(password),
                string.Format(
                    "get_role_id({0})",
                    DbSchema.SingleQuoted(role)));

            return query;
        }
        public static string SelectAllUserInfo(string login)
        {
            string query = string.Format(
                "SELECT"
                + "\n\t{0}.{1},"
                + "\n\t{2},"
                + "\n\t{3},"
                + "\n\t{4},"
                + "\n\t{5},"
                + "\n\t{6},"
                + "\n\t{7},"
                + "\n\t{8}.{9},"
                + "\n\t{10}.{11},"
                + "\n\t{12}.{13},"
                + "\n\t{14}.{15}"
                + "\nFROM"
                + "\n\t(((({0} INNER JOIN {16} ON {0}.{1} = {16}.{1})"
                + "\n\t\tINNER JOIN {8} ON {16}.{9} = {8}.{17})"
                + "\n\t\t\tINNER JOIN {10} ON {16}.{11} = {10}.{17})"
                + "\n\t\t\t\tINNER JOIN {12} ON {16}.{13} = {12}.{17})"
                + "\n\t\t\t\t\tINNER JOIN {14} ON {0}.{15} = {14}.{17}"
                + "\nWHERE"
                + "\n\t{0}.{1} = {18};",
                DbSchema.DoubleQuoted(DbSchema.Users.This),
                DbSchema.DoubleQuoted(DbSchema.Users.Login),
                DbSchema.DoubleQuoted(DbSchema.Users.Password),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.FirstName),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.SecondName),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.LastName),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.phoneNumber),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.EmailAddress),
                DbSchema.DoubleQuoted(DbSchema.Departments.This),
                DbSchema.DoubleQuoted(DbSchema.Departments.Department),
                DbSchema.DoubleQuoted(DbSchema.Occupations.This),
                DbSchema.DoubleQuoted(DbSchema.Occupations.Occupation),
                DbSchema.DoubleQuoted(DbSchema.Statuses.This),
                DbSchema.DoubleQuoted(DbSchema.Statuses.Status),
                DbSchema.DoubleQuoted(DbSchema.Roles.This),
                DbSchema.DoubleQuoted(DbSchema.Roles.Role),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.Users.ID),
                DbSchema.SingleQuoted(login)
                );

            return query;
        }
        public static string UpdateUsersPassword(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.Users.This),
                DbSchema.DoubleQuoted(DbSchema.Users.Password),
                DbSchema.SingleQuoted(newValue),
                DbSchema.DoubleQuoted(DbSchema.Users.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUsersRole(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.Users.This),
                DbSchema.DoubleQuoted(DbSchema.Users.Role),
                string.Format(
                    "get_role_id({0})",
                    DbSchema.SingleQuoted(newValue)),
                DbSchema.DoubleQuoted(DbSchema.Users.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoLogin(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{1} = {3}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(newValue),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoFirstName(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.FirstName),
                DbSchema.SingleQuoted(newValue),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoSecondName(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.SecondName),
                DbSchema.SingleQuoted(newValue),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoLastName(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.LastName),
                DbSchema.SingleQuoted(newValue),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoPhoneNumber(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.phoneNumber),
                DbSchema.SingleQuoted(newValue),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoEmailAddress(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.EmailAddress),
                DbSchema.SingleQuoted(newValue),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoDepartment(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Department),
                string.Format(
                    "get_department_id({0})",
                    DbSchema.SingleQuoted(newValue)),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoOccupation(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Occupation),
                string.Format(
                    "get_occupation_id({0})",
                    DbSchema.SingleQuoted(newValue)),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
        public static string UpdateUserInfoStatus(string login, string newValue)
        {
            string query = string.Format(
                "UPDATE"
                + "\n\t{0}"
                + "\nSET"
                + "\n\t{1} = {2}"
                + "\nWHERE"
                + "\n\t{3} = {4}",
                DbSchema.DoubleQuoted(DbSchema.UserInfo.This),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Status),
                string.Format(
                    "get_status_id({0})",
                    DbSchema.SingleQuoted(newValue)),
                DbSchema.DoubleQuoted(DbSchema.UserInfo.Login),
                DbSchema.SingleQuoted(login)
            );

            return query;
        }
    }
}
