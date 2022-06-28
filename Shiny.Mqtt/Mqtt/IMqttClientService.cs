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
        /// 获取客户端
        /// </summary>
        /// <returns></returns>
        MqttClient GetClient();
    }
}
