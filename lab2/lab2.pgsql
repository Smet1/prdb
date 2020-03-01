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


