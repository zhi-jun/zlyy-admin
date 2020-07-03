// Creator: 程邵磊
// CreateTime: 2020/03/18

namespace ZLYY.Framework.Service
{
    public class PagedQueryDto
    {
        public int PageIndex { get; set; } = 0;

        public int PageSize { get; set; } = 20;

        public string SearchString { get; set; }
    }
}