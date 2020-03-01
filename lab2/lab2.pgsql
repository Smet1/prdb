SELECT
    count(id)
FROM
    users
WHERE
    mood = 'sad';

-- 1.1 see lab_1.sql
-- 1.2
-- 1.2.1

DROP FUNCTION sad_users ();

-- получает количество пользователей с заданным настроением
CREATE OR REPLACE FUNCTION users_with_mood (
    mood
)
    RETURNS SETOF BIGINT
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        count(id)
    FROM
        users
    WHERE
        mood = $1;
END
$$
LANGUAGE plpgsql;

SELECT
    *
FROM
    users_with_mood ('ok');

-- 1.2.2
DROP FUNCTION get_topics_short_info ();

-- возвращает таблицу с инфой о созданных постах
CREATE OR REPLACE FUNCTION get_topics_short_info (
    user_id integer
)
    RETURNS TABLE (
            id integer,
            header CITEXT,
            short_topic CITEXT,
            SHOW BOOLEAN,
            created timestamptz
        )
        AS $$
BEGIN
    RETURN QUERY
    SELECT
        p.id,
        p.header,
        p.short_topic,
        p.show,
        p.created
    FROM
        posts p
        JOIN users u ON p.user_id = u.id
    WHERE
        u.id = $1;
END
$$
LANGUAGE plpgsql;

SELECT
    p.id,
    p.header,
    p.short_topic,
    p.show,
    p.created
FROM
    posts p
    JOIN users u ON p.user_id = u.id
WHERE
    u.id = 1;

SELECT
    *
FROM
    get_topics_short_info (1);

-- 1.2.3
SELECT
    *
FROM
    posts;

SELECT
    *
FROM
    users
WHERE
    LOGIN = 'lol';

-- создание поста пользователя
CREATE OR REPLACE PROCEDURE create_post (
    header citext,
    short_topic citext,
    main_topic citext,
    authors citext[],
    username citext
)
LANGUAGE plpgsql
AS $$
DECLARE
    userID int;
BEGIN
    SELECT
        id INTO STRICT userID
    FROM
        users
    WHERE
        LOGIN = create_post.username;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE EXCEPTION 'User % not found', create_post.username INSERT INTO posts (header, short_topic, main_topic, user_id, authors)
        VALUES (create_post.header, create_post.short_topic, create_post.main_topic, userID, create_post.authors);
COMMIT;
END;
$$;

CALL create_post ('kek', 'kek1', 'kek2', '{"e", "w", "d"}', 'smet_k_121');

-- 2.1
SELECT
    *
FROM
    posts
LIMIT 3;

UPDATE
    posts p
SET
    header = 'test_header_1_updated'
WHERE
    id = 5
RETURNING
    p.*;

-- 2.2
WITH RECURSIVE r AS (
    SELECT
        1 AS i,
        1 AS factorial
    UNION
    SELECT
        i + 1 AS i,
        factorial * (i + 1) AS factorial
    FROM
        r
)
SELECT
    factorial
FROM
    r
LIMIT 12;

-- 2.3
DROP FUNCTION create_valid_post ();

CREATE OR REPLACE PROCEDURE create_valid_post (
    header citext,
    short_topic citext,
    main_topic citext,
    authors citext[],
    username citext
)
LANGUAGE plpgsql
AS $$
DECLARE
    authors citext[];
    userID int;
    author citext;
BEGIN
    SELECT
        id INTO STRICT userID
    FROM
        users
    WHERE
        LOGIN = create_valid_post.username;
    IF NOT FOUND THEN
        RAISE EXCEPTION 'User % not found', create_valid_post.username;
    END IF;
    authors = create_valid_post.authors;
    author = '';
    IF NOT create_valid_post.username = ANY (authors) THEN
        authors = array_append(authors, create_valid_post.username);
    END IF;
    INSERT INTO posts (header, short_topic, main_topic, user_id, authors)
        VALUES (create_valid_post.header, create_valid_post.short_topic, create_valid_post.main_topic, userID, authors);
    COMMIT;
END;
$$;

CALL create_valid_post ('kek_t_3', 'kek1_t_4', 'kek2_t_5', '{"a", "b", "c e"}', 'smet_k');

SELECT
    array_length(p.authors, 1),
    p.*
FROM
    posts p;

UPDATE
    posts p
SET
    p.authors = array_append(p.authors,
        SELECT
            LOGIN FROM users
        WHERE
            id = p.user_id);

SELECT
    *
FROM
    posts;

