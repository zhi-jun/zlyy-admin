// Creator: 程邵磊
// CreateTime: 2020/03/18

using System.Collections.Generic;

namespace ZLYY.Framework.Service
{
    public class PagedModel<T>
    {
        public int PageIndex { get; set; } = 0;

        public int PageSize { get; set; } = 20;

        public int PageCount { get; set; }

        public int DataCount { get; set; }

        public List<T> Data { get; set; }
    }
}