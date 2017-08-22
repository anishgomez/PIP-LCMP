using System.Data.Entity;

namespace PIP_LCMP.Repositories.ContextProvider
{
    public interface IDbContextProvider
    {
        DbContext GetDbContext();
    }
}
