using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NewLife.MQTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shiny.Mqtt
{

    /// <summary>
    /// MQTT客户端服务
    /// </summary>
    public class MqttClientService : IMqttClientService
    {
        private readonly ILogger<MqttClientService> _logger;
        private readonly MqttSettingOptions _options;
        private MqttClient mq;
        public MqttClientService(ILogger<MqttClientService> logger, IOptions<MqttSettingOptions> options)
        {
            this._logger = logger;
            this._options = options.Value;
            Connect();

        }


        public MqttClient GetClient()
        {
            return mq;
        }



        private async void Connect()
        {
            if (!string.IsNullOrEmpty(_options.Host))
            {
                mq = new MqttClient
                {
                    Server = $"tcp://{_options.Host}:{_options.Port}",
                    UserName = _options.UserName,
                    Password = _options.SecretKey,
                    ClientId = _options.ClientId,

                };
            }
            else
            {
                throw new ArgumentException("mqtt配置未找到，请配置mqtt链接信息", nameof(MqttSettingOptions));
            }
            mq.KeepAlive = _options.KeepAlive;
            mq.Connected += MqttClient_Connected;
            mq.Disconnected += MqttClient_Disconnected;
            mq.Reconnect = true;
            await mq.ConnectAsync();
        }

        private void MqttClient_Disconnected(object sender, EventArgs e)
        {
            _logger.LogInformation("已断开MQTT服务端!:" + DateTime.Now);
            Thread.Sleep(5000);
        }

        private void MqttClient_Connected(object sender, EventArgs e)
        {
            _logger.LogInformation("已连接MQTT服务端!:" + DateTime.Now);

        }
    }
}
