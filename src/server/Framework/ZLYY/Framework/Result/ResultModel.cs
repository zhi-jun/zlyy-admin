namespace ZLYY.Framework
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class ResultModel<T> : IResultModel<T>
    {
        /// <summary>
        /// 处理是否成功
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// 状态码 1,0
        /// </summary>
        public int Code => IsSuccess ? 1 : 0;

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// 错误
        /// </summary>
        public string Msg { get; private set; }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="msg">说明</param>
        public ResultModel<T> Success(T data, string msg = "success")
        {
            IsSuccess = true;
            Data = data;
            Msg = msg;
            return this;
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">说明</param>
        public ResultModel<T> Failed(string msg = "failed")
        {
            IsSuccess = false;
            Msg = msg;
            return this;
        }

    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public static class ResultModel
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IResultModel<T> Success<T>(T data = default)
        {
            return new ResultModel<T>().Success(data);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static IResultModel Success(string msg = null)
        {
            return Success<string>(msg);
        }


        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static IResultModel<T> Failed<T>(string error = null)
        {
            return new ResultModel<T>().Failed(error ?? "failed");
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static IResultModel Failed(string error = null)
        {
            return Failed<string>(error);
        }
    }
}
