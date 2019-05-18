using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace SampleUWP
{
    public sealed class AzureDC
    {
        private async Task<MethodResponse> TestCallback(MethodRequest methodRequest, object userContext)
        {
            // _logger.Information($"Test Callback called.");
            MethodResponse mr = new MethodResponse(200);
            return mr;
        }
        public async void initialize()
        {
            
            // TODO: change connection string here.
            var deviceConnectionString = "<change connection string here.>";


            var _deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString,
                    new ITransportSettings[]
                    {
                        new AmqpTransportSettings(TransportType.Amqp_WebSocket_Only)
                        {
                            AmqpConnectionPoolSettings = new AmqpConnectionPoolSettings()
                            // TODO:Pooling is disabled due to issue in SDK and Windows update.
                            //{
                            //    Pooling = true,
                            //    MaxPoolSize = 100
                            //}
                        }
                    }
                    );


            //debugging
            await _deviceClient.SetMethodHandlerAsync("TestMethod", TestCallback, null);
        }
    }
}
