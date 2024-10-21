using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static System.Net.WebRequestMethods;

class SimpleHttpServer
{
    private TcpListener listener;
    private bool isRunning;

    public SimpleHttpServer(string ip, int port)
    {
        listener = new TcpListener(IPAddress.Parse(ip), port);
    }

    public void Start()
    {
        listener.Start();
        isRunning = true;
        Console.WriteLine("Сервер запущен. Ожидание подключений...");

        while (isRunning)
        {
            try
            {
                // Шаг 3: Принимать клиента
                TcpClient client = listener.AcceptTcpClient();
                // Обработка клиента в потоке
                ThreadPool.QueueUserWorkItem(HandleClient, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при принятии клиента: {ex.Message}");
            }
        }
    }

    private void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;

        try
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
            {
                // Шаг 4: Распарсить поступивший запрос
                string requestLine = reader.ReadLine();
                Console.WriteLine($"Получен запрос: {requestLine}");

                if (string.IsNullOrEmpty(requestLine))
                {
                    SendNotFoundResponse(writer);
                    return;
                }

                string[] requestParts = requestLine.Split(' ');

                // Убедимся, что запрос корректный
                if (requestParts.Length < 3)
                {
                    SendNotFoundResponse(writer);
                    return;
                }

                string filePath = requestParts[1].TrimStart('/');

                // Шаг 7: Чтение HTML-файла
                string fullPath = (filePath == ""? "index" : filePath) + ".html"; // Замените на ваш путь

                // Шаг 6: Обработать ошибки
                if (!System.IO.File.Exists(fullPath))
                {
                    SendNotFoundResponse(writer);
                    return;
                }

                // Шаг 8: Создать тело HTTP ответа с необходимыми заголовками
                string content = System.IO.File.ReadAllText(fullPath);
                string response = "HTTP/1.1 200 OK\n" +
                                  "Content-Type: text/html; charset=UTF-8\n" +
                                  "Content-Length: " + content.Length + "\n" +
                                  "Connection: close\n\n" +
                                  content;

                // Шаг 8: Передать клиенту
                writer.Write(response);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка обработки клиента: {ex.Message}");
        }
        finally
        {
            // Шаг 9: Закрыть соединение с клиентом
            client.Close();
        }
    }

    private void SendNotFoundResponse(StreamWriter writer)
    {
        string response = "HTTP/1.1 404 Not Found\n" +
                          "Content-Type: text/html; charset=UTF-8\n" +
                          "Connection: close\n\n" +
                          "<h1>404 - Not Found</h1>";
        writer.Write(response);
    }

    public void Stop()
    {
        isRunning = false;
        listener.Stop();
        Console.WriteLine("Сервер остановлен.");
    }

    ~SimpleHttpServer()
    {
        Stop(); // Шаг 10: Остановка сервера в деструкторе
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Задайте IP и порт
        string ip = "127.0.0.1";
        int port = 49424; // Замените на нужный номер порта
        SimpleHttpServer server = new SimpleHttpServer(ip, port);

        // Запустите сервер
        server.Start();

        Console.WriteLine("Нажмите Enter для остановки сервера...");
        Console.ReadLine();

        // Остановка сервера
        server.Stop();
    }
}
