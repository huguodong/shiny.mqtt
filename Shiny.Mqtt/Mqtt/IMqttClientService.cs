using NewLife.MQTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiny.Mqtt
{
    public interface IMqttClientService
    {
        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();

        /// <summary>
        /// 开始连接
        /// </summary>
        void Start();
    }
}
