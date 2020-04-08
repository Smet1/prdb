CREATE TYPE FIO AS (
    last_name text,
    first_name text,
    father_name text
) 
method fullName () RETURNS text;

CREATE method fullName RETURNS text
FOR FIO
BEGIN
    RETURN SELF.last_name || SELF.first_name || SELF.father_name
END;

CREATE TYPE UserT AS (
    ID integer,
    about text,
    karma text,
    avatar text,
    `password` text,
    `login` text,
    fullname FIO,
);

CREATE TYPE AdminT under UserT AS (
    ROLE text,
    active text
);

CREATE TYPE PostT AS (
    ID integer,
    header text,
    short_topic text,
    main_topic text,
    `date` date,
    Users REF (UserT) SCOPE `User`
);

CREATE TYPE TagT AS (
    ID integer,
    `name` text,
);

CREATE TYPE PostTag (
    tag_id integer,
    post_id integer
);

-- tables
CREATE TABLE `User` OF UserT (
    PRIMARY KEY (ID),
);

CREATE TABLE `Post` OF PostT (
    PRIMARY KEY (ID),
    REF IS Idc SYSTEM GENERATED
);

CREATE TABLE `Tag` OF TagT (
    PRIMARY KEY (ID),
);

CREATE TABLE PostTag (
    Tags REF (PostT) SCOPE Post,
    Users REF (UserT) SCOPE `User`,
);

CREATE TABLE `Admin` OF AdminT ();

CREATE ORDERING FOR TextType EQUALS ONLY BY STATE

CREATE ORDERING PostT ORDER FULL BY RELATIVE WITH Fun 
CREATE FUNCTION Fun (IN S1 PostT, IN S2 PostT) 
RETURNS integer
IF S1.header()<>S2.header() THEN RETURN (-1)
ELSEIF S1.short_topic()>S2.short_topic() THEN RETURN (-1) 
ELSEIF S1.main_topic()<>S2.main_topic() THEN RETURN (-1) 
ELSEIF S1.date()<S2.date() THEN RETURN (-1) 
ELSEIF S1.date()>S2.date() THEN RETURN (1) 
ELSE RETURN(0) 
ENDIF;
