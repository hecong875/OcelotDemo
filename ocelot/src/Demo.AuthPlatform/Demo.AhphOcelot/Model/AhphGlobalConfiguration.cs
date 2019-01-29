namespace Ctr.AhphOcelot.Model
{
    using System.ComponentModel.DataAnnotations;
    public partial class AhphGlobalConfiguration
    {
        /// <summary>
        /// ��������
        /// </summary>
        [Key]
        public int AhphId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required]
        [StringLength(100)]
        public string GatewayName { get; set; }
        /// <summary>
        /// ȫ������Ĭ��Key
        /// </summary>

        [StringLength(100)]
        public string RequestIdKey { get; set; }
        /// <summary>
        /// ����·�ɸ���ַ
        /// </summary>

        [StringLength(100)]
        public string BaseUrl { get; set; }
        /// <summary>
        /// ����ʹ�ÿ��
        /// </summary>

        [StringLength(50)]
        public string DownstreamScheme { get; set; }
        /// <summary>
        /// ������ȫ������
        /// </summary>

        [StringLength(500)]
        public string ServiceDiscoveryProvider { get; set; }
        /// <summary>
        /// ȫ�ָ��ؾ�������
        /// </summary>

        [StringLength(500)]
        public string LoadBalancerOptions { get; set; }
        /// <summary>
        /// Http��������
        /// </summary>

        [StringLength(500)]
        public string HttpHandlerOptions { get; set; }
        /// <summary>
        /// ����ȫ����
        /// </summary>

        [StringLength(200)]
        public string QoSOptions { get; set; }
        /// <summary>
        /// �Ƿ�Ĭ������
        /// </summary>

        public int IsDefault { get; set; }
        /// <summary>
        /// ��ǰ״̬
        /// </summary>

        public int InfoStatus { get; set; }
    }
}
