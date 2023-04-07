DROP TABLE IF EXISTS
    "Users";

DROP TABLE IF EXISTS
    "Roles";

DROP TABLE IF EXISTS
    "UserInfo";

DROP TABLE IF EXISTS
    "Occupations";

DROP TABLE IF EXISTS
    "Departments";

DROP TABLE IF EXISTS
    "Statuses";

CREATE TABLE
    IF NOT EXISTS
    "Statuses"
    (
        "ID" bigserial
            PRIMARY KEY
            NOT NULL
            CHECK("ID" >= 0),
        "Status" varchar(100)
            UNIQUE
            NOT NULL
    );

CREATE TABLE
    IF NOT EXISTS
    "Departments"
    (
        "ID" bigserial
            PRIMARY KEY
            NOT NULL
            CHECK("ID" >= 0),
        "Department" varchar(100)
            UNIQUE
            NOT NULL
    );

CREATE TABLE
    IF NOT EXISTS
    "Occupations"
    (
        "ID" bigserial
            PRIMARY KEY
            NOT NULL
            CHECK("ID" >= 0),
        "Occupation" varchar(100)
            UNIQUE
            NOT NULL
    );

CREATE TABLE
    IF NOT EXISTS
    "UserInfo"
    (
        "Login" varchar(100)
            PRIMARY KEY
            NOT NULL
            CHECK((length("Login")) >= 10),
        "Occupation" bigint
            NOT NULL
            REFERENCES "Occupations"("ID"),
        "Department" bigint
            NOT NULL
            REFERENCES "Departments"("ID"),
        "Status" bigint
            NOT NULL
            REFERENCES "Statuses"("ID"),
        "EmailAddress" varchar(100)
            NOT NULL,
        "PhoneNumber" varchar(100)
            NOT NULL,
        "FirstName" varchar(100)
            NOT NULL,
        "SecondName" varchar(100)
            NOT NULL,
        "LastName" varchar(100)
            DEFAULT NULL
);

CREATE TABLE
    IF NOT EXISTS
    "Roles"
    (
        "ID" bigserial
            PRIMARY KEY
            NOT NULL
            CHECK("ID" >= 0),
        "Role" varchar(100)
            UNIQUE
            NOT NULL
);

CREATE TABLE
    IF NOT EXISTS
    "Users"
    (
        "ID" bigserial
            PRIMARY KEY
            NOT NULL
            CHECK("ID" >= 0),
        "Login" varchar(100)
            NOT NULL
            REFERENCES "UserInfo"("Login")
                ON UPDATE CASCADE,
        "Password" varchar(100)
            NOT NULL,
        "Role" bigint
            NOT NULL
            REFERENCES "Roles"("ID")
);
