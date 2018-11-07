using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace CoreSample.RabbitMQ.Customer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("输入队列名称：");
            var queuename = Console.ReadLine().Trim();
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";//RabbitMQ服务在本地运行
            factory.UserName = "test";//用户名
            factory.Password = "test";//密码
            try
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        bool durable = true;//队列是否持久化
                        channel.QueueDeclare(queuename, durable, false, false, null);//创建一个消息队列,如果有则不创建
                        channel.BasicQos(0, 1, false);//公平分发配置,使得每个Consumer在同一个时间点最多处理一个Message【在创建消费者之前设置，才会有效】

                        var consumer = new EventingBasicConsumer(channel);//创建消费者
                        channel.BasicConsume(queuename, false, consumer);
                        consumer.Received += (model, ea) =>
                        {
                            var body2 = ea.Body;
                            var message2 = Encoding.UTF8.GetString(body2);
                            int dots = message2.Split('.').Length - 1;
                            Thread.Sleep(dots * 1000);
                            Console.WriteLine("已接收： {0}", message2);
                            channel.BasicAck(ea.DeliveryTag, false);
                        };
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}