# отчет

## Задание 1

### 1.1

[Смотри](./../lab1/lab_1.sql)

### 1.2

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
#### 3. Создать **хранимую процедуру**