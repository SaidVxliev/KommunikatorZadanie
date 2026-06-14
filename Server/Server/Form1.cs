using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server
{
    public partial class Form1 : Form
    {
        private static string adres;
        private static int port;
        private static TcpListener server = null;
        private static List<string> names = new List<string>();
        private static List<Client> users = new List<Client>();
        private static bool isRunning = false;
        private static string password = null;

        public class Client
        {
            public TcpClient tcpClient;
            public NetworkStream stream = null;
            public StreamReader reading;
            public StreamWriter writing;
            public string nazwa;
            public string connectionTime;
            public Thread messageThread;

            public Client(TcpClient tcpClient, NetworkStream ns, string connectionTime)
            {
                this.tcpClient = tcpClient;
                this.stream = ns;
                this.reading = new StreamReader(stream, Encoding.UTF8);
                this.nazwa = reading.ReadLine();
                this.connectionTime = connectionTime;
                this.writing = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load (object sender, EventArgs e)
        {

        }



        private void OdbierajWiadomosciKlienta(Client klient)
        {
            try
            {
                string messageRecived;
                while ((messageRecived = klient.reading.ReadLine()) != null)
                {
                    if (messageRecived == "END")
                        break;

                    string nadawca = klient.nazwa;
                    Broadcast(messageRecived, nadawca);
                }
            }
            catch (Exception ex2)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lbMessage.Items.Add($"Utracono połączenie z {klient.nazwa}: {ex2.Message}");
                });
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Delete(klient);
                });
            }
        }
        
        public void Broadcast(string message, string sender)
        {
            lock (users)
            {
                foreach (Client client in users)
                {
                    try
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            lbMessage.Items.Add( sender + ": " + message);
                        });
                        client.writing.WriteLine(sender + ": " + message);
                    }
                    catch (Exception ex3)
                    {
                        System.Diagnostics.Debug.WriteLine($"Nieudany Broadcast do {client.nazwa}: {ex3.Message}");
                    }
                }
            }
        }

        public void Delete(Client disconnectedClient)
        {
            names.Remove(disconnectedClient.nazwa);

            lock (users)
            {
                users.Remove(disconnectedClient);
            }
            ListBox1.Items.Remove(disconnectedClient.nazwa);
            lbMessage.Items.Add("Użytkownik " + disconnectedClient.nazwa + " rozłączył się.");

            try { disconnectedClient.reading.Close(); } catch { }
            try { disconnectedClient.writing.Close(); } catch { }
            try { disconnectedClient.tcpClient.Close(); } catch { }
        }
        

        private void lB1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bStart_Click_1(object sender, EventArgs e)
        {
            bStart.Enabled = false;
            bStop.Enabled = true;

            try
            {
                adres = tbHostAddress.Text;
                IPAddress ipAddr = IPAddress.Parse(adres);
                port = System.Convert.ToInt32(nUDPort.Value);
                password = tb_password.Text;

                server = new TcpListener(new IPEndPoint(ipAddr, port));
                server.Start();
                isRunning = true;

                lbMessage.Items.Add("Serwer został uruchomiony.");

                Thread waitForConnect = new Thread(() => {
                    try
                    {
                        while (isRunning)
                        {
                            if (!server.Pending())
                            {
                                Thread.Sleep(100);
                                continue;
                            }

                            

                            TcpClient tcpClient = server.AcceptTcpClient();
                            NetworkStream ns = tcpClient.GetStream();
                            Client nowyKlient = new Client(tcpClient, ns, DateTime.Now.ToString("h:mm:ss tt"));
                            string pass = nowyKlient.reading.ReadLine();
                            if (pass != password)
                            {
                                nowyKlient.writing.WriteLine("ERR_BAD_PASS");
                                continue;
                                
                            }

                            while (names.Contains(nowyKlient.nazwa))
                            {
                                nowyKlient.nazwa += "-sobowtór";
                            }

                            names.Add(nowyKlient.nazwa);

                            nowyKlient.messageThread = new Thread(() => OdbierajWiadomosciKlienta(nowyKlient));
                            nowyKlient.messageThread.IsBackground = true;

                            lock (users)
                            {
                                users.Add(nowyKlient);
                            }

                            this.Invoke((MethodInvoker)delegate
                            {
                                lbMessage.Items.Add("[" + nowyKlient.nazwa + "] :Nawiązano połączenie");
                                ListBox1.Items.Add(nowyKlient.nazwa);
                            });
                            nowyKlient.messageThread.Start();
                        }
                    }
                    catch (Exception ex1)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            lbMessage.Items.Add("Błąd inicjacji serwera!");
                            MessageBox.Show(ex1.ToString(), "Błąd");
                            bStart.Enabled = true;
                            bStop.Enabled = false;
                        });
                    }
                });

                waitForConnect.IsBackground = true;
                waitForConnect.Start();
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lbMessage.Items.Add("Błąd inicjacji serwera!");
                    MessageBox.Show(ex.ToString(), "Błąd");
                    bStart.Enabled = true;
                    bStop.Enabled = false;
                });
            }
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            string messageSent = TextBox1.Text;
            if (!string.IsNullOrEmpty(messageSent) && isRunning)
            {
                string systemSender = "SERWER";
                Broadcast(messageSent, systemSender);
                TextBox1.Text = string.Empty;
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            isRunning = false;
            lock (users)
            {
                for (int i = users.Count - 1; i >= 0; i--)
                {
                    Delete(users[i]);
                }
            }

            if (server != null)
            {
                server.Stop();
            }

            lbMessage.Items.Add("Zakończono pracę serwera ...");
            bStart.Enabled = true;
            bStop.Enabled = false;
        }
    }
}
