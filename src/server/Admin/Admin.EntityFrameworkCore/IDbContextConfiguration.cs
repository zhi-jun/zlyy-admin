// Creator: 程邵磊
// CreateTime: 2020/03/18

using Microsoft.EntityFrameworkCore;

namespace Admin.EntityFrameworkCore
{
    public interface IDbContextConfiguration
    {
        DbContextOptions GetDbContextOptions();
    }
}