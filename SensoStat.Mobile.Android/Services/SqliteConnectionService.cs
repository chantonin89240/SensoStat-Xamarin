using System;
using System.IO;
using SensoStat.Mobile.Repositories.Interface;
using SQLite;

namespace SensoStat.Mobile.Droid.Services
{
    public class SqliteConnectionService : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var filename = "SensoStat.db";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, filename);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}