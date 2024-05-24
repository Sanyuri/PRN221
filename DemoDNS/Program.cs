// See https://aka.ms/new-console-template for more information
//DNS
using System.Net;

Console.WriteLine(new string('*', 50));
var domainEntry = Dns.GetHostEntry("www.fpt.edu.vn");
Console.WriteLine("Name: " + domainEntry.HostName);
foreach (var ip in domainEntry.AddressList)
{
    Console.WriteLine(ip);
}
Console.WriteLine(new string('*',30));
domainEntry = Dns.GetHostEntry("127.0.0.1");
Console.WriteLine("Name: " + domainEntry.HostName);
foreach (var ip in domainEntry.AddressList)
{
    Console.WriteLine(ip);
}
Console.WriteLine();

