﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Server
    {
        public static Database serverDatabase;

        public void connectToDatabase(Database database)
        {
            serverDatabase = database;
        }
        public void run()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1302);
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting for connection...");
                TcpClient client = acceptConnectionToClient(listener);

                NetworkStream networkStream = client.GetStream();
                StreamReader streamReader = new StreamReader(client.GetStream());
                StreamWriter streamWriter = new StreamWriter(client.GetStream());

                try
                {
                    byte[] buffer = new byte[1024];
                    networkStream.Read(buffer);

                    Message messageFromClient = new Message();
                    messageFromClient.setText(Encoding.UTF8.GetString(buffer));
                    networkStream.Write(Encoding.ASCII.GetBytes("Server received your request"));
                    handleIncomingMessage(messageFromClient);
                    
                    Console.WriteLine();

                    streamWriter.Flush();
                    streamWriter.Close();
                }
                catch (Exception e)
                {

                    Console.WriteLine("Failed to start...");
                }
            }
        }

        private static TcpClient acceptConnectionToClient(TcpListener listener)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client accepted...");
            return client;
        }
        public void handleLogin(string username, string password)
        {
            Login login = new Login();
            login.verifyLoginData(username, password);
        }
        public static void getChatHistoryFromDB()
        {

        }
        public static void sendChatHistoryToClient()
        {

        }
        public void newSignUp()
        {

        }
        public static void createUserInDB()
        {

        }
        public static void deleteUserFromDB()
        {

        }
        public static void sendDeleteConfirmationToClient()
        {

        }
        public static void getMessageInfoFromDB()
        {

        }
        public static void sendMessageInfoToClient()
        {

        }
        public static void getUserInfoFromDB()
        {

        }
        public static void sendUserInfoToClient()
        {

        }
        public void handleIncomingMessage(Message messageFromClient)
        {
            Console.WriteLine("The message from the client is: " + messageFromClient);
        }
        public void sendPrivateMessage()
        {

        }
        public void sendPublicMessage()
        {

        }
        public void saveMessageToDB()
        {

        }
        public void disconnectFromClient()
        {

        }
        public void disconnectFromDB()
        {

        }
    }
}
