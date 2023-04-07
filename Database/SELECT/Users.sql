SELECT
    "Login",
    "Password",
    "Roles"."Role"
FROM
    "Users" LEFT JOIN "Roles" on "Users"."Role" = "Roles"."ID";

SELECT
    *
FROM
    "Users";
