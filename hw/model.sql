SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS USER;

DROP TABLE IF EXISTS Admin;

DROP TABLE IF EXISTS Post;

DROP TABLE IF EXISTS Tag;

DROP TABLE IF EXISTS PostTag;

SET FOREIGN_KEY_CHECKS = 1;

-- Наследование

-- Сущностный подход
CREATE TABLE `User` (
    ID integer NOT NULL,
    about text NOT NULL,
    karma text NOT NULL,
    avatar text NOT NULL,
    `password` text NOT NULL,
    `login` text NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    middle_name text NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE `Admin` (
    LIKE `User` INCLUDING defaults INCLUDING constraints INCLUDING indexes,
    `role` text NOT NULL,
    active text NOT NULL
);

-- Пустые значения
CREATE TABLE `User` (
    ID integer NOT NULL,
    about text NOT NULL,
    karma text NOT NULL,
    avatar text NOT NULL,
    `password` text NOT NULL,
    `login` text NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    middle_name text NOT NULL,
    `role` text NULL,
    active text NULL,
    PRIMARY KEY (ID)
);

-- Объектный
CREATE TABLE `User` (
    ID integer NOT NULL,
    about text NOT NULL,
    karma text NOT NULL,
    avatar text NOT NULL,
    `password` text NOT NULL,
    `login` text NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    middle_name text NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE `Admin` (
    user_id integer,
    `role` text NOT NULL,
    active text NOT NULL,
    FOREIGN KEY (user_id) REFERENCES `User` (ID)
);

CREATE TABLE Post (
    ID integer NOT NULL,
    header text NOT NULL,
    short_topic text NOT NULL,
    main_topic text NOT NULL,
    `date` date NOT NULL,
    user_id integer NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE Tag (
    ID integer NOT NULL,
    `name` text NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE PostTag (
    tag_id integer NOT NULL,
    post_id integer NOT NULL
);

ALTER TABLE Post
    ADD FOREIGN KEY (user_id) REFERENCES `User` (ID);

ALTER TABLE PostTag
    ADD FOREIGN KEY (post_id) REFERENCES Post (ID),
    ADD FOREIGN KEY (tag_id) REFERENCES Tag (ID),
    ADD CONSTRAINT u_post_tag UNIQUE (post_id, tag_id);

