# отчет

[Задание](README.md)

## Задание 1 *Базовая часть (удовлетворительно)*

### 1.1 *Создание и заполнение таблицы*

[Смотри](./../lab1/lab_1.sql)

### 1.2 *Программирование функций  с применением  SQL\PSM*

#### 1. Создать **скалярную функцию**

Получаем количество пользователей с заданным настроением

```sql
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
```

Использование
```sql
SELECT
    *
FROM
    users_with_mood ('ok');
```

#### 2. Создать **табличную функцию**
возвращает таблицу с инфой о созданных постах

```sql 
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
```

пример
```sql
SELECT * FROM get_topics_short_info(1);
```

|id (integer)| header (citext)| short_topic (citext)| show (boolean)| created (timestamp with time zone)|
|------------|----------------|---------------------|---------------|-----------------------------------|
|1	|6	|test_header_2	|short_2	|false	|2020-02-20T16:15:16.176Z|
|2	|1	|test_header	|short	|false	|2020-02-20T16:01:28.762Z|

#### 3. Создать **хранимую процедуру**