using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace OfficeBoy.Receive
{
    public class Receive
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ituranDigital_Json",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    NotificacaoEnvio deserializedProduct = JsonConvert.DeserializeObject<NotificacaoEnvio>(message);
                    RetornaDados(deserializedProduct);

                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "ituranDigital_Json",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public static void RetornaDados(NotificacaoEnvio notificacao)
        {

            Console.WriteLine("CdPessoa: {0}", notificacao.CdPessoa);
            Console.WriteLine("Mensagem: {0}", notificacao.Mensagem);
            Console.WriteLine("PlayerId: {0}", notificacao.PushNotificationDados.PlayerIds);
            Console.WriteLine("CdPessoa: {0}", notificacao.TipoComunicacao);
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
