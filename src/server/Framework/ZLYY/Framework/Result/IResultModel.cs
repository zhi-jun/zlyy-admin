namespace ZLYY.Framework
{
    /// <summary>
    /// 结果模型
    /// </summary>
    public interface IResultModel
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        int Code { get; }

        /// <summary>
        /// 错误
        /// </summary>
        string Msg { get; }
    }

    /// <summary>
    /// 结果模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResultModel<out T> : IResultModel
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        T Data { get; }
    }
}
