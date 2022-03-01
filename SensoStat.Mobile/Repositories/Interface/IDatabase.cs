using SQLite;

namespace SensoStat.Mobile.Repositories.Interface
{
    public interface IDatabase
    {
        SQLiteConnection GetConnection();
    }
}
