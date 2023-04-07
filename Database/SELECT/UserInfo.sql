SELECT
    "Users"."Login",
    "Password",
    "FirstName",
    "SecondName",
    "LastName",
    "PhoneNumber",
    "EmailAddress",
    "Occupations"."Occupation",
    "Departments"."Department",
    "Statuses"."Status",
    "Roles"."Role"
FROM
    (((("Users" INNER JOIN "UserInfo" ON "Users"."Login" = "UserInfo"."Login")
        INNER JOIN "Occupations" ON "UserInfo"."Occupation" = "Occupations"."ID")
            INNER JOIN "Departments" ON "UserInfo"."Department" = "Departments"."ID")
                INNER JOIN "Statuses" ON "UserInfo"."Status" = "Statuses"."ID")
                    INNER JOIN "Roles" ON "Users"."Role" = "Roles"."ID"
WHERE
    "Users"."Login" = 'new_test_admin';

SELECT
    *
FROM
    "UserInfo";
