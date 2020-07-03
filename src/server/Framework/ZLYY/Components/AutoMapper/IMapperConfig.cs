namespace ZLYY.Components.AutoMapper
{
    /// <summary>
    /// 对象映射
    /// </summary>
    public interface IMapperConfig
    {
        /// <summary>
        /// 绑定映射关系
        /// </summary>
        void Bind(MapperProfile cfg);
    }
}
