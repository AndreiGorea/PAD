﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Publisher
{
     internal class PublisherSocket
     {
          private Socket _socket;
          public bool IsConnected;

          public PublisherSocket()
          {
               _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
          }

          public void Connect(string ipAddress, int port)
          {
               _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectedCallback, null);
               Thread.Sleep(2000);
          }

          public void Send(byte[] data) 
          {
               try
               {
                    _socket?.Send(data);
               }
               catch (Exception e)
               {
                    Console.WriteLine($"Could not send data. {e.Message}");
               }
          }

          private void ConnectedCallback(IAsyncResult asyncResult) 
          { 
               if (_socket.Connected) 
               {
                    Console.WriteLine("Sender connected to Broker");
               }
               else
               {
                    Console.WriteLine("Error: Sender not connected to Broker");
               } 

               IsConnected = _socket.Connected;
          }
     }
}
