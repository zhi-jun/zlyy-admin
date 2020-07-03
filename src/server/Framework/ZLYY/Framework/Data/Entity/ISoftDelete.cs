// Creator: 程邵磊
// CreateTime: 2020/03/17

namespace ZLYY.Framework.Data.Entity
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}