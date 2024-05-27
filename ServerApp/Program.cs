using System.Net.Sockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

internal class Program
{
    //static void ProcessMessage(object parm)
    //{
    //    string data;
    //    int count;
    //    List<NetworkStream> connectedClients = new List<NetworkStream>();
    //    try
    //    {
    //        TcpClient client = parm as TcpClient;
    //        //Buffer for reading data
    //        Byte[] bytes = new Byte[256];
    //        //Get a stream object for reading and writing
    //        NetworkStream stream = client.GetStream();

    //        connectedClients.Add(stream);
    //        //Loop to receive all the data sent by the client
    //        while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
    //        {
    //            //Translate data bytes to a ASCII string
    //            data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
    //            Console.WriteLine($"Recieved: {data} at {DateTime.Now:t}");
    //            //Process the data sent by the client
    //            data = $"{data.ToUpper()}";
    //            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
    //            //Send back a response
    //            stream.Write(msg, 0, msg.Length);
    //            Console.WriteLine($"Send: {data}");
    //        }
    //        //Shutdown and end connection
    //        client.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("{0}", ex.Message);
    //        Console.WriteLine("Waiting message...");
    //    }
    //}
    //--------------------------------------------------------------------------------
    static List<NetworkStream> connectedClients = new List<NetworkStream>();

    static void ProcessMessage(object parm)
    {
        TcpClient? client = parm as TcpClient;
        // Get a stream object for reading and writing
        NetworkStream stream = client.GetStream();
        try
        {
            // Add client to the list of connected clients
            lock (connectedClients)
            {
                connectedClients.Add(stream);
            }

            int count;
            byte[] bytes = new byte[256];

            while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                string data = Encoding.ASCII.GetString(bytes, 0, count);
                Console.WriteLine($"Received: {data} from {client.Client.RemoteEndPoint}");

                // Broadcast the message to all clients
                BroadcastMessage(data, stream);

                // Log the message sent
                Console.WriteLine($"Sent: {data} to all clients");

                // Clear buffer
                Array.Clear(bytes, 0, bytes.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
        finally
        {
            // Remove client from the list when disconnected
            lock (connectedClients)
            {
                connectedClients.Remove(stream);
            }
            client.Close();
        }
    }

    static void BroadcastMessage(string message, NetworkStream sender)
    {
        lock (connectedClients)
        {
            foreach (var client in connectedClients)
            {
                if (client != sender) // Don't send the message back to the sender
                {
                    try
                    {
                        // Send the sender's IP address along with the message
                        IPEndPoint? iPEndPoint = sender.Socket.RemoteEndPoint as IPEndPoint;
                        message = $"{iPEndPoint}: {message}";
                        // Send the message to the client
                        //convert the message to byte array
                        client.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error broadcasting message to {(client.Socket.RemoteEndPoint as IPEndPoint).Address}: {ex}");
                    }
                }
            }
        }
    }

    static void ExecuteServer(string host, int port)
        {
            int Count = 0;
            TcpListener server = null;
            try
            {
                Console.Title = "Server Application";
                IPAddress localAddr = IPAddress.Parse(host);
                server = new TcpListener(localAddr, port);
                //Start listening for client request
                server.Start();
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("Waiting for a connection...");
                //Enter the listening loop
                while (true)
                {
                    //Perform a blocking call to accept requests
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Number of client connected: {++Count}");
                    Console.WriteLine(new string('*', 40));
                    //Create a thread to receive and send message
                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex);
            }
            finally
            {
                server.Stop();
                Console.WriteLine("Server stopped. Press any key to exit!");
            }
            Console.Read();
        }
    private static void Main(string[] args)
    {
        string host = "127.0.0.1";
        int port = 13000;
        ExecuteServer(host, port);
    }
}