using APIOracleDB.Models;

namespace APIOracleDB.Repository
{
    public interface IDataAccess
    {
        List<PayItem> GetItemsFromStoredProcedure();
        List<PayItem> GetItemsFromQuery();

    }
}
