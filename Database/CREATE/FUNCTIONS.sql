DROP FUNCTION IF EXISTS get_occupation_id;

DROP FUNCTION IF EXISTS get_department_id;

DROP FUNCTION IF EXISTS get_status_id;

DROP FUNCTION IF EXISTS get_role_id;

CREATE FUNCTION
    get_occupation_id(occupation varchar(100))
RETURNS bigint AS '
    SELECT
        "ID" AS result
    FROM
        "Occupations"
    WHERE
        "Occupation" = get_occupation_id.occupation;
' LANGUAGE SQL;

CREATE FUNCTION
    get_department_id(department varchar(100))
RETURNS bigint AS '
    SELECT
        "ID" AS result
    FROM
        "Departments"
    WHERE
        "Department" = get_department_id.department;
' LANGUAGE SQL;

CREATE FUNCTION
    get_status_id("status" varchar(100))
RETURNS bigint AS '
    SELECT
        "ID" AS result
    FROM
        "Statuses"
    WHERE
        "Status" = get_status_id.status;
' LANGUAGE SQL;

CREATE FUNCTION
    get_role_id("role" varchar(100))
RETURNS bigint AS '
    SELECT
        "ID" AS result
    FROM
        "Roles"
    WHERE
        "Role" = get_role_id.role;
' LANGUAGE SQL;
