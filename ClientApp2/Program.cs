using System.Net.Sockets;
using System.Text;

internal class Program
{
    class User
    {
        private string Name {get; set;  }
        private string Message { get; set; }
    }
    //static void ConnectServer(string server, int port)
    //{
    //    string message, responseData;
    //    int bytes;
    //    try
    //    {
    //        //Create a TcpClient
    //        TcpClient client = new TcpClient(server, port);
    //        Console.Title = "Client Application 2";
    //        NetworkStream stream = null;
    //        while (true)
    //        {
    //            Console.WriteLine("Input message <press Enter to exit>:");
    //            message = Console.ReadLine();
    //            if (message == string.Empty)
    //            {
    //                break;
    //            }
    //            //Translate the passed message into ASCII and store in a byte array
    //            Byte[] data = System.Text.Encoding.ASCII.GetBytes($"{message}");
    //            //Get a client stream for reading and writing
    //            stream = client.GetStream();
    //            //Send the message to the connected TcpServer
    //            stream.Write(data, 0, data.Length);
    //            Console.WriteLine("Sent: {0}", message);
    //            //Receive the TcpServer response
    //            //Use buffer to store response bytes
    //            data = new Byte[256];
    //            //Read the first batch of the TcpServer response bytes
    //            bytes = stream.Read(data, 0, data.Length);
    //            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
    //            Console.WriteLine("Received {0}", responseData);
    //        }
    //        //Shutdown and end connection
    //        client.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("Exception: {0}", ex.Message);
    //    }
    //}

    static void ConnectServer(string server, int port)
    {
        string message;
        try
        {
            // Create a TcpClient
            TcpClient client = new TcpClient(server, port);
            Console.Title = "Client Application 2";
            NetworkStream stream = client.GetStream();

            // Start a new thread to receive messages from the server
            Thread receiveThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        byte[] data = new byte[256];
                        int bytes = stream.Read(data, 0, data.Length);
                        string responseData = Encoding.ASCII.GetString(data, 0, bytes);
                        Console.WriteLine($"Received from {responseData}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error receiving message: {ex.Message}");
                        break;
                    }
                }
            });
            receiveThread.Start();

            while (true)
            {
                Console.WriteLine("Input message (Press Enter to exit):");
                message = Console.ReadLine();
                if (message == string.Empty)
                {
                    break;
                }
                // Translate the passed message into ASCII and store in a byte array
                byte[] data = Encoding.ASCII.GetBytes($"{message}");
                // Send the message to the connected TcpServer
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Sent: {message}");
            }

            // Shutdown and end connection
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    private static void Main(string[] args)
    {
        string server = "127.0.0.1";
        //Set the TcpListener on port 13000
        int port = 13000;
        ConnectServer(server, port);
    }
}