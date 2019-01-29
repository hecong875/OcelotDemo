namespace Ctr.AhphOcelot.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class AhphReRoute
    {
        [Key]
        public int ReRouteId { get; set; }

        public int? ItemId { get; set; }
        /// <summary>
        /// 上游路径模板
        /// </summary>

        [Required]
        [StringLength(150)]
        public string UpstreamPathTemplate { get; set; }
        /// <summary>
        /// 上游请求方法
        /// </summary>

        [Required]
        [StringLength(50)]
        public string UpstreamHttpMethod { get; set; }
        /// <summary>
        /// 上游域名地址
        /// </summary>

        [StringLength(100)]
        public string UpstreamHost { get; set; }
        /// <summary>
        /// 下游使用架构
        /// </summary>

        [Required]
        [StringLength(50)]
        public string DownstreamScheme { get; set; }
        /// <summary>
        /// 下游路径模板
        /// </summary>

        [Required]
        [StringLength(200)]
        public string DownstreamPathTemplate { get; set; }
        /// <summary>
        /// 下游请求地址和端口
        /// </summary>

        [StringLength(500)]
        public string DownstreamHostAndPorts { get; set; }
        /// <summary>
        /// 授权配置
        /// </summary>

        [StringLength(300)]
        public string AuthenticationOptions { get; set; }
        /// <summary>
        /// 全局请求默认Key
        /// </summary>

        [StringLength(100)]
        public string RequestIdKey { get; set; }
        /// <summary>
        /// 缓存配置
        /// </summary>

        [StringLength(200)]
        public string CacheOptions { get; set; }
        /// <summary>
        /// 服务发现名称
        /// </summary>

        [StringLength(100)]
        public string ServiceName { get; set; }
        /// <summary>
        /// 全局负载均衡配置
        /// </summary>

        [StringLength(500)]
        public string LoadBalancerOptions { get; set; }
        /// <summary>
        /// 请求安全配置
        /// </summary>

        [StringLength(200)]
        public string QoSOptions { get; set; }
        /// <summary>
        /// /委托处理方法
        /// </summary>

        [StringLength(200)]
        public string DelegatingHandlers { get; set; }
        /// <summary>
        /// 路由优先级
        /// </summary>

        public int? Priority { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>

        public int InfoStatus { get; set; }
    }
}
