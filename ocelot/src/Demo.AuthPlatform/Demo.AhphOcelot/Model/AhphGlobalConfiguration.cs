namespace Ctr.AhphOcelot.Model
{
    using System.ComponentModel.DataAnnotations;
    public partial class AhphGlobalConfiguration
    {
        /// <summary>
        /// 网关主键
        /// </summary>
        [Key]
        public int AhphId { get; set; }

        /// <summary>
        /// 网关名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string GatewayName { get; set; }
        /// <summary>
        /// 全局请求默认Key
        /// </summary>

        [StringLength(100)]
        public string RequestIdKey { get; set; }
        /// <summary>
        /// 请求路由根地址
        /// </summary>

        [StringLength(100)]
        public string BaseUrl { get; set; }
        /// <summary>
        /// 下游使用框架
        /// </summary>

        [StringLength(50)]
        public string DownstreamScheme { get; set; }
        /// <summary>
        /// 服务发现全局配置
        /// </summary>

        [StringLength(500)]
        public string ServiceDiscoveryProvider { get; set; }
        /// <summary>
        /// 全局负载均衡配置
        /// </summary>

        [StringLength(500)]
        public string LoadBalancerOptions { get; set; }
        /// <summary>
        /// Http请求配置
        /// </summary>

        [StringLength(500)]
        public string HttpHandlerOptions { get; set; }
        /// <summary>
        /// 请求安全配置
        /// </summary>

        [StringLength(200)]
        public string QoSOptions { get; set; }
        /// <summary>
        /// 是否默认配置
        /// </summary>

        public int IsDefault { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>

        public int InfoStatus { get; set; }
    }
}
