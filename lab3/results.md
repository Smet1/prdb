# Лабораторная работа № 3
Исполнитель: Сметанкин Кирилл, ИУ5-22М (хорошо)

## Пользовательский тип
```csharp
using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[assembly: System.CLSCompliantAttribute(true)]
[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined,
    IsFixedLength = false, MaxByteSize = -1, IsByteOrdered = true)]
public class UserFullname : INullable, IBinarySerialize
{
    private string _text;
    private char _delimeter = ' ';
    private bool _null;
    public override string ToString()
    {
        return _text;
    }
    public bool IsNull
    {
        get
        {
            return _null;
        }
    }
    public static UserFullname Null
    {
        get
        {
            UserFullname h = new UserFullname();
            h._null = true;
            return h;
        }
    }
    public static UserFullname Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        UserFullname text = new UserFullname();
        string str = s.ToString();
        text._text = str;
        return text;
    }
    public char SetDelimeter(char del)
    {
        _delimeter = del;

        return _delimeter;
    }
    public string GetFirstName()
    {
        string[] array = _text.Split(_delimeter);

        return array[0];
    }

    public string GetMiddleName()
    {
        string[] array = _text.Split(_delimeter);
        if (array.Length < 2) {
            return "";
        }

        return array[1];
    }

    public string GetLastName()
    {
        string[] array = _text.Split(_delimeter);
        if (array.Length < 3)
        {
            return "";
        }

        return array[2];
    }
    public void Read(System.IO.BinaryReader r)
    {
        _null = r.ReadBoolean();
        if (!_null)
            _text = new String(r.ReadChars(r.ReadInt32()));
    }
    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(_null);
        if (!_null)
        {
            w.Write(_text.Length);
            for (int i = 0; i < _text.Length; ++i)
                w.Write(_text[i]);
        }
    }
}
```

## Создание Сборки
Собран проект, полученный файл dll загружен в БД

![](./pic/image_2020-04-05_17-38-54.png)

![](./pic/image_2020-04-05_17-40-10.png)

После создан тип UserFullname

![](./pic/image_2020-04-05_18-34-07.png)

## Проверка методов работы
- ToString - преобразование в строковый тип
- GetFirstName - получение имени
- GetMiddleName - отчества
- GetLastName - фамилии

![](./pic/image_2020-04-05_17-58-28.png)

## SQL

Создана таблица Test с колонкой пользовательского типа

![](./pic/image_2020-04-05_18-09-50.png)

Работа с записями таблицы

![](./pic/image_2020-04-05_18-14-54.png)

### Исходный текст скрипта
```sql
-- создание сборки
CREATE ASSEMBLY UserFullname
    FROM
    'C:\Users\Кирилл\source\repos\USQLCSharpProject1\USQLCSharpProject1\bin\Debug\USQLCSharpProject1.dll' WITH PERMISSION_SET = SAFE;

-- объявление типа
CREATE TYPE [UserFullname] EXTERNAL NAME [UserFullname];

-- использование
DECLARE @tryWithMyText[UserFullname];

SET @tryWithMyText = 'Кирилл Игоревич Сметанкин';

SELECT @tryWithMyText;

-- select @tryWithMyText.SetDelimeter('');
SELECT @tryWithMyText.ToString();

SELECT @tryWithMyText.GetFirstName();

SET @tryWithMyText = NULL;

SELECT @tryWithMyText.ToString();

SELECT @tryWithMyText.GetFirstName();

-- создание таблицы с типом
CREATE TABLE Test
(
    id       int,
    avatar   varchar(50),
    fullname UserFullName
);

INSERT INTO TEST (id, avatar, fullname)
VALUES (1, '/static/1.jpg', 'Лука Андреевич Пестов'),
       (2, '/static/default.png', 'Зиновий Иванович Бондаренко'),
       (3, '', 'Люся Ивановна Сасько');

-- пример использования таблицы
SELECT id,
       avatar,
       fullname.ToString()      AS fullname,
       fullname.GetFirstName()  AS firstname,
       fullname.GetMiddleName() AS middlename,
       fullname.GetLastName()   AS lastname
FROM test;

UPDATE
    test
SET fullname = 'Люся Ивановна Простая'
WHERE fullname.GetLastName() = 'Сасько';

SELECT id,
       avatar,
       fullname.ToString()      AS fullname,
       fullname.GetFirstName()  AS firstname,
       fullname.GetMiddleName() AS middlename,
       fullname.GetLastName()   AS lastname
FROM test;


```