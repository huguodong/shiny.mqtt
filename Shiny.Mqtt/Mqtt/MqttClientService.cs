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

        private readonly MqttSettingOptions _options;
        /// <summary>
        /// mqtt对象
        /// </summary>
        public MqttClient mq;
        public MqttClientService(IOptions<MqttSettingOptions> options)
        {
            this._options = options.Value;
            Config();
            Connect();
        }

        public MqttClientService(MqttSettingOptions options)
        {
            this._options = options;
            Config();
        }


        /// <summary>
        /// 开始连接
        /// </summary>
        public async void Start()
        {
            if (mq.IsConnected)
            {
                await mq.DisconnectAsync();
            }
            Connect();
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public async void Close() => await mq.DisconnectAsync();


        /// <summary>
        /// 配置mqtt服务器
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void Config()
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
        }

        /// <summary>
        /// 连接mqtt服务器
        /// </summary>
        private async void Connect()
        {
            await mq.ConnectAsync();
        }

        private void MqttClient_Disconnected(object sender, EventArgs e)
        {
            Console.WriteLine("已断开MQTT服务端!:" + DateTime.Now);
            Thread.Sleep(5000);
        }

        private void MqttClient_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("已连接MQTT服务端!:" + DateTime.Now);
        }
    }
}
