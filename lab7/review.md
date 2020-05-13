## Задание 1. Создание БД (базовая часть)
### 1.1 Создать в среде CassandraDb свое пространство ключей
```sql
CREATE KEYSPACE journal WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 1 };
```

### 1.3 Определить семейство столбцов по теме своего ДЗ
```sql
CREATE TABLE IF NOT EXISTS user_posts
(
    user_id     uuid,
    user_name   text,
    user_avatar text,
    user_karma  int,
    post_id     uuid,
    header      text,
    short_topic text,
    main_topic  text,
    created     timestamp,
    PRIMARY KEY (user_id, post_id)
);

INSERT INTO user_posts (user_id, user_name, user_avatar, user_karma, post_id, header, short_topic, main_topic, created)
VALUES (9f1acc62-ca31-4907-968a-d980ca6c2970, 'smet_k', '/static/default.png', 0, uuid(), 'test header',
        'test short topic',
        'test main topic', toTimeStamp(now()));

INSERT INTO user_posts (user_id, user_name, user_avatar, user_karma, post_id, header, short_topic, main_topic, created)
VALUES (9f1acc62-ca31-4907-968a-d980ca6c2970, 'smet_k', '/static/default.png', 0, uuid(), 'test header 1',
        'test short topic 1',
        'test main topic 1', toTimeStamp(now()));
```

## Задание 2. CRUD и работа с индексами (базовая часть)
### Продемонстрировать добавление, изменение и удаление данных в БД
```sql
-- добавление
INSERT INTO user_posts (user_id, user_name, user_avatar, user_karma, post_id, header, short_topic, main_topic, created)
VALUES (uuid(), 'smet_k_1', '/static/default.png', 0, uuid(), 'test header 3',
        'test short topic 3',
        'test main topic 3', toTimeStamp(now()));

-- обновление
update user_posts set user_karma = 1
where user_id = 9f1acc62-ca31-4907-968a-d980ca6c2970
and post_id in (12192bc2-126a-4998-b464-1a5f5e83725a, 86755c25-7b05-41fd-90fc-90e1eddc1706);

-- удаление
delete
from user_posts
where user_id = 9f1acc62-ca31-4907-968a-d980ca6c2970
  and post_id in (5abc67f3-d691-4c4f-aa7a-511ca00c210c, df246440-dd5d-419c-ae99-51d67a03f363)
```

### Определить для семейства столбцов индекс(ы). Выполнить запросы к с фильтрацией по ключам и индексам. Продемонстрировать работу allow filtering.
```sql
CREATE INDEX on user_posts (created);
CREATE INDEX on user_posts (main_topic);
CREATE INDEX on user_posts (user_name);
```

```sql
select *
from user_posts
where post_id = 12192bc2-126a-4998-b464-1a5f5e83725a
    allow filtering;

select *
from user_posts
where user_name = 'smet_k';
```

## Задание 3. Запросы к БД. (базовая часть)
### Выполнить запросы к базе данных с селекцией и проекцией
```sql
select user_id
from user_posts
where created >= '2020-05-13Z'
  and created < '2020-05-14Z'
    allow filtering;
```

### Выполнить запрос с использованием агрегатных функций
```sql
select count(*)
from user_posts
where created >= '2020-05-13Z'
  and created < '2020-05-14Z'
    allow filtering;
```

### Добавить строку с указанием TTL, продемонстрировать действие TTL (время существования значения в секундах)
```sql
INSERT INTO user_posts (user_id, user_name, user_avatar, user_karma, post_id, header, short_topic, main_topic, created)
VALUES (9f1acc62-ca31-4907-968a-d980ca6c2970, 'smet_k', '/static/default.png', 1, uuid(), 'test header 2',
        'test short topic 2',
        'test main topic 2', toTimeStamp(now()))
    USING TTL 64;
```

## Задание 4. Группировка и сортировка  (Хорошо)
### Выполнить запросы с группировкой и сортировкой данных. 
```sql
select count(*), user_name
from user_posts
group by user_id;

select *
from user_posts
where user_id = 9f1acc62-ca31-4907-968a-d980ca6c2970
order by post_id;
```

### Создать еще одно семейство столбцов по теме ДЗ, определить для него кластерный и распределительный ключи. Выполнить запросы к с фильтрацией по ключам.
См. выше

### Продемонстрировать усечение таблицы и удаление таблицы/индекса
```sql
drop table user_posts;
drop index user_posts_created_idx;
alter table user_posts
    drop user_karma;
```