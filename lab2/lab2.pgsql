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
CREATE OR REPLACE FUNCTION users_with_mood (mood)
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
CREATE OR REPLACE FUNCTION get_topics_short_info (user_id integer)
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
CREATE OR REPLACE PROCEDURE create_post (header citext, short_topic citext, main_topic citext, authors citext[], username citext)
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
    IF NOT FOUND THEN
        RAISE EXCEPTION 'User % not found', create_post.username
            USING HINT = 'Проверьте ваш пользовательский ID';
    END IF;
    INSERT INTO posts (header, short_topic, main_topic, user_id, authors)
        VALUES (create_post.header, create_post.short_topic, create_post.main_topic, userID, create_post.authors);
    COMMIT;
END;
$$;

CALL create_post ('kek', 'kek1', 'kek2', '{"e", "w", "d"}', 'smet_k');

