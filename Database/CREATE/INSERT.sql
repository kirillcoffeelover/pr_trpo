DELETE FROM
        "Users";

DELETE FROM
        "Roles";

DELETE FROM
        "UserInfo";

DELETE FROM
        "Occupations";

DELETE FROM
        "Departments";

DELETE FROM
        "Statuses";

INSERT INTO
        "Statuses"
        (
        "Status"
        )
VALUES
        (
                'Default'
        ),
        (
                'Works'
        ),
        (
                'OnSickLeave'
        ),
        (
                'Fired'
        );

INSERT INTO
        "Departments"
        (
        "Department"
        )
VALUES
        (
                'Default'
        ),
        (
                'Accounting'
        ),
        (
                'Managment'
        ),
        (
                'IT'
        );

INSERT INTO
        "Occupations"
        (
        "Occupation"
        )
VALUES
        (
                'Default'
        ),
        (
                'Manager'
        ),
        (
                'Accountant'
        );

INSERT INTO
        "UserInfo"
        (
        "Login",
        "FirstName",
        "SecondName",
        "LastName",
        "Occupation",
        "Department",
        "Status",
        "PhoneNumber",
        "EmailAddress"
        )
VALUES
        (
                'default_manager',
                'default',
                'manager',
                null,
                get_occupation_id('Manager'),
                get_department_id('Managment'),
                get_status_id('Works'),
                '8-800-000-00-00',
                'noname@example.com'
        ),
        (
                'default_accountant',
                'default',
                'accountant',
                null,
                get_occupation_id('Accountant'),
                get_department_id('Accounting'),
                get_status_id('Works'),
                '8-800-000-00-00',
                'noname@example.com'
        );

INSERT INTO
        "Roles"
        (
        "Role"
        )
VALUES
        (
                'Default'
        ),
        (
                'Admin'
        ),
        (
                'Common'
        );

INSERT INTO
        "Users"
        (
        "Login",
        "Password",
        "Role"
        )
VALUES
        (
                'default_accountant',
                '1234567890',
                get_role_id('Common')
        ),
        (
                'default_manager',
                '1234567890',
                get_role_id('Admin')
        );
