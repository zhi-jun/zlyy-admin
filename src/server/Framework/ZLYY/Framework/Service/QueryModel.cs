namespace ZLYY.Framework.Service
{
    /// <summary>
    /// 查询抽象
    /// </summary>
    public class QueryModel
    {
        /// <summary>
        /// 总数
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>
        public QueryPagingModel Page { get; set; } = new QueryPagingModel();
    }
}
