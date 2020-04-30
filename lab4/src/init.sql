CREATE TABLE users
(
    id         integer PRIMARY KEY,
    login      varchar(100) NOT NULL UNIQUE,
    password   TEXT,
    avatar     varchar(100) NOT NULL UNIQUE,
    karma      INT         DEFAULT 0
);

insert into users(id, login, password, avatar, karma) VALUES (1, 'user_1', 'password_1', '/static/default.jpg', 0);

CREATE TABLE posts
(
    id          integer PRIMARY KEY,
    header      varchar(100) NOT NULL UNIQUE,
    short_topic varchar(255) NOT NULL UNIQUE,
    main_topic  text NOT NULL,
    user_id     integer    NOT NULL REFERENCES users (id)
);

insert into posts(id, header, short_topic, main_topic, user_id) VALUES (1, 'header', 'short topic', 'main topic', 1);

CREATE TABLE comments
(
    id        integer PRIMARY KEY,
    parent_id integer REFERENCES comments (id),
    user_id   integer  NOT NULL REFERENCES users (id),
    post_id   integer  NOT NULL REFERENCES posts (id),
    payload   text NOT NULL
);

insert into comments(id, parent_id, user_id, post_id, payload) VALUES (1, null, 1, 3, 'отличная статья, больше не пиши');
insert into comments(id, parent_id, user_id, post_id, payload) VALUES (2, 1, 1, 3, 'спасибо');