using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace OfficeBoy.Send
{
    public class Send
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };



            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
            NotificacaoEnvio notificacaoEnvio = new NotificacaoEnvio
            {
                CdPessoa = 1000,
                TipoComunicacao = TipoComunicacaoEnum.PushNotification,
                Mensagem = "Teste Ituran",
                PushNotificationDados = new PushNotificationDados
                {
                    PlayerIds = new string[] { "AS29102902901sajs", "129029012901sahu" },
                    Segmento = null,
                    TipoEnvioNotificacaoEnum = TipoEnvioNotificacaoEnum.PlayerIds
                }
            };
                channel.QueueDeclare(queue: "ituranDigital_Json",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonConvert.SerializeObject(notificacaoEnvio); 
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "ituranDigital_Json",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    public class NotificacaoEnvio
    {
        public int CdPessoa { get; set; }
        public string Mensagem { get; set; }
        public PushNotificationDados PushNotificationDados { get; set; }
        public TipoComunicacaoEnum TipoComunicacao { get; set; }
    }

    public class PushNotificationDados
    {
        public string[] PlayerIds { get; set; }
        public string Segmento { get; set; }
        public TipoEnvioNotificacaoEnum TipoEnvioNotificacaoEnum { get; set; }


    }

    public enum TipoEnvioNotificacaoEnum
    {
        PlayerIds = 1,
        Tags = 2,
        Segment = 3,
        AllSubscribers = 4 
    }

    public enum TipoComunicacaoEnum
    {
        Email = 1,
        SMS = 2,
        PushNotification = 3
    }

}
