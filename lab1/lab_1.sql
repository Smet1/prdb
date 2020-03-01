CREATE EXTENSION IF NOT EXISTS CITEXT;

DROP TABLE IF EXISTS users, posts, tag, comments;

CREATE TYPE fullname AS
(
    firstname  CITEXT,
    lastname   CITEXT,
    middlename CITEXT
);

CREATE TYPE mood AS ENUM ('sad', 'ok', 'happy');

CREATE TABLE IF NOT EXISTS users
(
    id         SERIAL PRIMARY KEY,
    login      CITEXT   NOT NULL UNIQUE,
    password   TEXT,
    name       fullname NOT NULL DEFAULT ('empty', 'empty', 'empty')::fullname,
    avatar     CITEXT   NOT NULL,
    karma      INT               DEFAULT 0,
    registered timestamptz       DEFAULT now(),
    mood       mood              DEFAULT 'ok'
);

ALTER TABLE users
    ADD CHECK ( length(password) > 5 );

CREATE TYPE super_users_level AS ENUM ('base', 'ok', 'incredible');

CREATE TABLE IF NOT EXISTS super_users
(
    level super_users_level DEFAULT 'base'
)
    INHERITS (users);

CREATE TABLE IF NOT EXISTS posts
(
    id          SERIAL PRIMARY KEY,
    header      CITEXT   NOT NULL UNIQUE,
    short_topic CITEXT   NOT NULL UNIQUE,
    main_topic  CITEXT   NOT NULL UNIQUE,
    user_id     int      NOT NULL REFERENCES users (id),
    authors     CITEXT[] NOT NULL,
    show        bool        DEFAULT False,
    created     timestamptz DEFAULT now()
);

CREATE TABLE IF NOT EXISTS tag
(
    id   SERIAL PRIMARY KEY,
    name CITEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS comments
(
    id        SERIAL PRIMARY KEY,
    parent_id int REFERENCES comments (id),
    user_id   int  NOT NULL REFERENCES users (id),
    post_id   int  NOT NULL REFERENCES posts (id),
    payload   text NOT NULL,
    show      bool        DEFAULT True,
    created   timestamptz DEFAULT now()
);

-- ===================== working with ===============

insert into users(login, password, avatar)
VALUES ('smet_k', 'password', 'empty');

insert into users(login, password, avatar)
VALUES ('smet_k_2', 'password', 'empty');

select *
from users;

select authors[1:2]
from posts;


-- добавление, удаление и изменение всего массива
-- добавление, удаление, изменение одного из элементов
insert into posts (header, short_topic, main_topic, user_id, authors)
values ('test_header', 'short', 'main', 1, '{"me", "my friend 1", "my friend 2"}');
insert into posts (header, short_topic, main_topic, user_id, authors)
values ('test_header_1', 'short_1', 'main_1', 3, '{"me", "my friend 1", "my friend 2"}');
insert into posts (header, short_topic, main_topic, user_id, authors)
values ('test_header_2', 'short_2', 'main_2', 1, '{"me", "my friend 1", "my friend 2"}');

-- update
update posts
set authors[1:2] = '{"me too", "second me", "third me"}'
where header = 'test_header';

update posts
set authors = array_remove(authors, 'me too');


-- вывод всех элементов, удовлетворяющих условию
select *
from posts
         join users u on posts.user_id = u.id
where 'me too' = ANY (authors);

-- вывод строк таблицы, содержащих указанный элемент или набор элементов
-- вывод количества элементов массива для одной записи и группы записей, например, количество преподавателей по кафедре и по вузу

select id, array_length(authors, 1)
from posts
where header = 'test_header';


-- composite types

select *
from users;

select (name::fullname).firstname
from users;

update users
set name.lastname = 'my_last_name'
where id = 1;

update users
set name = ('kek', 'kek', 'kek')::fullname
where id = 1;


-- enum
update users
SET mood = 'kek'
where id = 1;

update users
SET mood = 'sad'
where id = 1;

select *
from users;

-- inherit
insert into super_users (login, password, name, avatar, karma, mood)
VALUES ('super', 'super_pass', ('super-kek', 's', 'a')::fullname, '', 0, 'ok');

select *
from users;

select *
from ONLY users;

select *
from super_users;

