namespace Ctr.AhphOcelot.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class AhphReRoute
    {
        [Key]
        public int ReRouteId { get; set; }

        public int? ItemId { get; set; }
        /// <summary>
        /// ����·��ģ��
        /// </summary>

        [Required]
        [StringLength(150)]
        public string UpstreamPathTemplate { get; set; }
        /// <summary>
        /// �������󷽷�
        /// </summary>

        [Required]
        [StringLength(50)]
        public string UpstreamHttpMethod { get; set; }
        /// <summary>
        /// ����������ַ
        /// </summary>

        [StringLength(100)]
        public string UpstreamHost { get; set; }
        /// <summary>
        /// ����ʹ�üܹ�
        /// </summary>

        [Required]
        [StringLength(50)]
        public string DownstreamScheme { get; set; }
        /// <summary>
        /// ����·��ģ��
        /// </summary>

        [Required]
        [StringLength(200)]
        public string DownstreamPathTemplate { get; set; }
        /// <summary>
        /// ���������ַ�Ͷ˿�
        /// </summary>

        [StringLength(500)]
        public string DownstreamHostAndPorts { get; set; }
        /// <summary>
        /// ��Ȩ����
        /// </summary>

        [StringLength(300)]
        public string AuthenticationOptions { get; set; }
        /// <summary>
        /// ȫ������Ĭ��Key
        /// </summary>

        [StringLength(100)]
        public string RequestIdKey { get; set; }
        /// <summary>
        /// ��������
        /// </summary>

        [StringLength(200)]
        public string CacheOptions { get; set; }
        /// <summary>
        /// ����������
        /// </summary>

        [StringLength(100)]
        public string ServiceName { get; set; }
        /// <summary>
        /// ȫ�ָ��ؾ�������
        /// </summary>

        [StringLength(500)]
        public string LoadBalancerOptions { get; set; }
        /// <summary>
        /// ����ȫ����
        /// </summary>

        [StringLength(200)]
        public string QoSOptions { get; set; }
        /// <summary>
        /// /ί�д�����
        /// </summary>

        [StringLength(200)]
        public string DelegatingHandlers { get; set; }
        /// <summary>
        /// ·�����ȼ�
        /// </summary>

        public int? Priority { get; set; }
        /// <summary>
        /// ��ǰ״̬
        /// </summary>

        public int InfoStatus { get; set; }
    }
}
