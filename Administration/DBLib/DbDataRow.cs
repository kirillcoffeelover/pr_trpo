using System;

namespace DBLib
{
public class DbDataRow
{
    public bool IsEmpty => values == Array.Empty<object>();
    private int pointer = 0;
    private readonly int count;
    public int Count => count;
    private readonly object[] values;
    public object[] RowFields => values;
    public DbDataRow()
    {
        count = 0;
        values = Array.Empty<object>();
    }
    public DbDataRow(int size)
    {
        count = size;
        values = new object[size];
    }
    public void Add(object value)
    {
        values[pointer] = value;
        pointer++;
    }
}
}
