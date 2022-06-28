using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Shiny.Mqtt
{
    /// <summary>
    /// Mqtt客户端扩展类
    /// </summary>
    public static class MqttClientSetup
    {
        /// <summary>
        /// 添加Mqtt客户端服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddMqttClient(this IServiceCollection services, IConfiguration configuration, string section = "MqttSetting")
        {

            if (services == null) throw new ArgumentNullException(nameof(services));
            var config = configuration.GetSection(section);
            services.Configure<MqttSettingOptions>(config);
            services.AddSingleton<IMqttClientService, MqttClientService>();
        }
    }
}
