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
