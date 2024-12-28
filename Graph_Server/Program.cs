using System.Net;
using System.Net.Sockets;
using System.Text;
using org.mariuszgromada.math.mxparser;

namespace Graph_Server
{
    public class Program
    {
        private const int Port = 5000;

        public static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, Port);
            server.Start();
            Console.WriteLine($"Сервер запущен на {Port} порте...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Клиент подключен.");

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[4096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Полученный запрос: {request}");

                string response = ProcessRequest(request);
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);

                stream.Write(responseBytes, 0, responseBytes.Length);
                Console.WriteLine("Запрос отправлен.");

                client.Close();
            }
        }

        private static string ProcessRequest(string request)
        {
            try
            {
                string[] parts = request.Split('|');
                if (parts.Length != 3)
                    throw new Exception("Неправильный формат запроса.");

                string expression = parts[0];
                double min = double.Parse(parts[1]);
                double max = double.Parse(parts[2]);

                return FunctionCalculator.Calculate(expression, min, max);
            }
            catch(Exception ex) 
            {
                return ($"Ошибка: {ex.Message}");
            }
        } 
    }

    public static class FunctionCalculator
    {
        public static string Calculate(string expression, double min, double max)
        {
            StringBuilder result = new StringBuilder();
            for (double x = min; x <= max; x += 0.1)
            {
                Argument arg = new Argument($"x = {x}");
                Expression exp = new Expression(expression, arg);
                double y = exp.calculate();

                if (double.IsNaN(y)) y = 0;

                result.AppendLine($"{x}:{y}");
            }
            return result.ToString();
        }
    }

}
