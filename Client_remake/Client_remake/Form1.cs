using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client_remake
{
    public partial class Form1 : Form
    {

        private TcpClient client = null;
        private bool activeCall = false;
        private NetworkStream ns = null;
        private StreamReader sr = null;
        private StreamWriter sw = null;
        private Thread receiveThread = null;
        private string password = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            bConnect.Enabled = false;
            bStop.Enabled = true;

            string host = tb_Adrress.Text;
            int port = System.Convert.ToInt16(nUD_Port.Value);
            password = tb_password.Text;


            try
            {
                // //connection: (zgodnie z grafiką image_dd8ce1.png)
                client = new TcpClient(host, port);
                ns = client.GetStream();
                sr = new StreamReader(ns, Encoding.UTF8);
                sw = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };
                if (tb_name.Text.Length != 0)
                {
                    sw.WriteLine(tb_name.Text);
                } else
                {
                    throw new ArgumentException("You must choose a nickname!");
                }
                
                sw.WriteLine(password);

                // Klient wysyła hasło wymagane przez serwer
                //writing.Write("password");
                activeCall = true;

                listBox1.Items.Add("Nawiązano połączenie z " + host + " na porcie: " + port);

                // Odpowiednik BackgroundWorker2.RunWorkerAsync() - uruchomienie wątku tła do odbioru wiadomości
                receiveThread = new Thread(OdbierajWiadomosci);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                activeCall = false;

                // Zabezpieczenie interfejsu za pomocą MethodInvoker
                this.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add("Błąd: Nie udało się nawiązać połączenia!");
                    MessageBox.Show(ex.ToString());
                    bConnect.Enabled = true;
                    bStop.Enabled = false;
                });
            }

        }

        private void bStop_Click(object sender, EventArgs e)
        {
            if (activeCall && sw != null)
            {
                try
                {
                    // Sygnał dla serwera, że kończymy połączenie
                    sw.Write("END");
                }
                catch { }
            }

            Rozlacz();
            listBox1.Items.Add("Zakończono połączenie z serwerem.");
        }

        // Metoda działająca w tle (odpowiednik pętli BackgroundWorker2)
        private void OdbierajWiadomosci()
        {
            try
            {
                // //receive messages
                string messageReceived;
                // Serwer wielowątkowy przesyła linie tekstu, więc czytamy je bezpiecznie metodą ReadString()
                while (activeCall && (messageReceived = sr.ReadLine()) != null)
                {
                    if (messageReceived == "END")
                        break;

                    if (messageReceived == "ERR_BAD_PASS")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            listBox1.Items.Add("Incorrect password! Access denied!");
                        });
                        Rozlacz();
                    }

                    // Wrzucenie odebranej wiadomości na listę UI przy użyciu MethodInvoker
                    this.Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add(messageReceived);
                    });
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add("Połączenie z serwerem zostało utracone: " + ex.Message);
                });
            }
            finally
            {
                // Po rozłączeniu lub błędzie czytania sprzątamy zasoby sieciowe w wątku UI
                this.Invoke((MethodInvoker)delegate
                {
                    Rozlacz();
                });
            }
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            string messageSent = textBox1.Text;
            if (!string.IsNullOrEmpty(messageSent) && activeCall && sw != null)
            {
                try
                {
                    sw.WriteLine(messageSent);
                    textBox1.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas wysyłania wiadomości: " + ex.Message, "Błąd");
                }
            }
        }

        private void Rozlacz()
        {
            activeCall = false;

            try { if (sr != null) sr.Close(); } catch { }
            try { if (sw != null) sw.Close(); } catch { }
            try { if (client != null) client.Close(); } catch { }

            bConnect.Enabled = true;
            bStop.Enabled = false;
        }
    }
}
