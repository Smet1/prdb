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
CREATE OR REPLACE FUNCTION get_topics_short_info (user_id INTEGER)
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

SELECT * FROM get_topics_short_info(1);
