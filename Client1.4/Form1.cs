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
        private string password = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bSend.Enabled = false;
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            bConnect.Enabled = false;
            bStop.Enabled = true;

            string host = tb_Adrress.Text;
            int port = System.Convert.ToInt16(nUD_Port.Value);
            if (tb_password.Text != "")
            {
                password = tb_password.Text;
            }
            

            try
            {
                client = new TcpClient(host, port);
                ns = client.GetStream();
                sr = new StreamReader(ns, Encoding.UTF8);
                sw = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };

                if (tb_name.Text.Length != 0)
                {
                    sw.WriteLine(tb_name.Text);
                }
                else
                {
                    throw new ArgumentException("You must choose a nickname!");
                }

                sw.WriteLine(password);
                activeCall = true;

                bSend.Enabled = true;

                listBox1.Items.Add("Nawiązano połączenie z " + host + " na porcie: " + port);

                receiveThread = new Thread(OdbierajWiadomosci);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                activeCall = false;

                this.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add("Błąd: Nie udało się nawiązać połączenia!");
                    MessageBox.Show(ex.ToString());
                    bConnect.Enabled = true;
                    bStop.Enabled = false;
                    bSend.Enabled = false;
                });
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            if (activeCall && sw != null)
            {
                try
                {
                    sw.Write("END");
                }
                catch { }
            }

            Rozlacz();
            listBox1.Items.Add("Zakończono połączenie z serwerem.");
        }

        private void OdbierajWiadomosci()
        {
            try
            {
                string messageReceived;
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
                        break;
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add(messageReceived);
                    });
                }
            }
            catch (Exception ex)
            {
                if (activeCall)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add("Połączenie z serwerem zostało utracone: " + ex.Message);
                    });
                }
            }
            finally
            {
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

            try { if (sr != null) { sr.Close(); sr = null; } } catch { }
            try { if (sw != null) { sw.Close(); sw = null; } } catch { }
            try { if (client != null) { client.Close(); client = null; } } catch { }

            bConnect.Enabled = true;
            bStop.Enabled = false;

            bSend.Enabled = false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Write message...")

            {

                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))

            {

                textBox1.Text = "Write message...";

                textBox1.ForeColor = Color.Gray;

            }
        }
    }
}