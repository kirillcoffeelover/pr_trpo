using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace DBLib
{
public enum DbParseMode
{
    Normal,
    OutOnly
}
public class DbTableReader : IDisposable
{
    public bool HasMoreRows => !dataReader.IsClosed;
    public bool IsReaderClosed => dataReader.IsClosed;
    readonly NpgsqlDataReader dataReader;
    readonly DbTableHeader tableHeader;
    readonly List<DbDataRow> tableRows;
    private DataTable dataTable = null;
    DataTable AsDataTable => dataTable ?? ConvertToDataTable();
    public DbTableReader(NpgsqlDataReader npgsqlDataReader)
    {
        this.tableHeader = new DbTableHeader();
        this.tableRows = new List<DbDataRow>();
        this.dataReader = npgsqlDataReader;

        var reader = dataReader.GetSchemaTable()?.CreateDataReader();
        if (reader == null)
            throw new ArgumentNullException(
                "DbTableReader(): npgsqlDataReader.GetSchemaTable()?.CreateDataReader() returned NULL");

        while (reader.Read())
            this.tableHeader.Add(reader.GetValue(0).ToString() ?? string.Empty);
    }
    ~DbTableReader()
    {
        this.Clear();
        if (!this.dataReader.IsClosed)
            this.dataReader.Close();
        this.Dispose();
    }
    public bool ReadRow()
    {
        if (dataReader.IsClosed)
            return false;
        else if (!dataReader.Read())
        {
            dataReader.Close();
            return false;
        }

        DbDataRow dataRow = new DbDataRow(tableHeader.Collumns);
        for (int i = 0; i < dataReader.FieldCount; i++)
            dataRow.Add(dataReader.GetValue(i));

        this.tableRows.Add(dataRow);

        return true;
    }
    public bool ReadRow(out DbDataRow dataRow, DbParseMode mode = DbParseMode.Normal)
    {
        dataRow = new DbDataRow();
        if (dataReader.IsClosed)
            return false;
        else if (!dataReader.Read())
        {
            dataReader.Close();
            return false;
        }

        dataRow = new DbDataRow(tableHeader.Collumns);
        for (int i = 0; i < dataReader.FieldCount; i++)
            dataRow.Add(dataReader.GetValue(i));

        if (mode == DbParseMode.Normal)
            this.tableRows.Add(dataRow);

        return true;
    }
    public void ReadAllRows()
    {
        while (ReadRow())
            ;
        ;
    }
    public void ReadAllRows(out DataTable dataTable)
    {
        while (ReadRow())
            ;
        ;
        dataTable = ConvertToDataTable();
    }
    private DataTable ConvertToDataTable()
    {
        this.dataTable = new DataTable();

        foreach (var name in tableHeader.HeadValues)
            this.dataTable.Columns.Add(name);

        foreach (var row in tableRows)
            this.dataTable.Rows.Add(row.RowFields);

        return this.dataTable;
    }
    public void UpdateDataTable()
    {
        ConvertToDataTable();
    }
    public void UpdateDataTable(out DataTable dataTable)
    {
        dataTable = ConvertToDataTable();
    }
    private void Clear()
    {
        this.tableHeader.Clear();
        this.tableRows.Clear();
    }
    public void Dispose()
    {
        this.dataReader.Dispose();
    }
}
}
