using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Npgsql;

namespace DBLib
{
public class DbWorker : IDisposable
{
    private readonly NpgsqlConnection connection;
    public NpgsqlConnection Connection => connection;
    private readonly string username;
    public string Username => username;
    private readonly string host;
    public DbWorker(string host, string username, string password)
    {
        if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            throw new ArgumentException("Argument server, username or password is an empty string");

        this.host = host;
        this.username = username;

        string connectionString = string.Format("Host={0};Username={1};Password={2};Database={3}", this.host,
                                                this.username, password, DbSchema.DatabaseName);

        connection = new NpgsqlConnection(connectionString);

        connection.Open();
        if (connection.State != System.Data.ConnectionState.Open)
            throw new DataException(
                string.Format("DbWorker(): could not open connection to {0} on {1}", DbSchema.DatabaseName, this.host));
    }
    ~DbWorker()
    {
        this.Dispose();
    }
    public void Dispose()
    {
        connection.Close();
        connection.Dispose();
    }
    public static string DecodeNpgsqlException(string message)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(message);

        byte[] convertedBytes = Encoding.Convert(Encoding.UTF8, Encoding.Default, bytes);

        string decodedMessage = Encoding.Default.GetString(convertedBytes);

        return decodedMessage;
    }
}
}
