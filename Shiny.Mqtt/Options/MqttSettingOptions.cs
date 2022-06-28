using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiny.Mqtt
{
    /// <summary>
    /// mqtt客户端配置
    /// </summary>
    public class MqttSettingOptions
    {

        /// <summary>
        /// 主机地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }


        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }



        /// <summary>
        /// 秘钥
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 客户端ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Topic { get; set; }

    }
}
