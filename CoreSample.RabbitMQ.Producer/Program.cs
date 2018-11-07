using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace CoreSample.RabbitMQ.Producer
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
                        while(true)
                        {
                            Console.Write("输入信息：");
                            var message = Console.ReadLine().Trim();
                            var body = Encoding.UTF8.GetBytes(message);
                            var properties = channel.CreateBasicProperties();
                            properties.Persistent = true;//消息持久化
                            channel.BasicPublish("", queuename, properties, body); //开始传递
                        }
                        //Console.WriteLine("已发送： {0}", message);
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