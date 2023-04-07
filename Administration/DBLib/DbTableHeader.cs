using System;
using System.Collections.Generic;

namespace DBLib
{
internal class DbTableHeader
{
    internal int Collumns => headValues.Count;
    private List<string> headValues;
    internal string[] HeadValues => headValues.ToArray();
    internal DbTableHeader()
    {
        headValues = new List<string>();
    }
    internal DbTableHeader(string[] headValues)
    {
        this.headValues = new List<string>();
        foreach (var val in headValues)
            this.headValues.Add(val);
    }
    internal void Add(string value)
    {
        headValues.Add(value);
    }
    internal void Clear()
    {
        headValues.Clear();
    }
}
}
