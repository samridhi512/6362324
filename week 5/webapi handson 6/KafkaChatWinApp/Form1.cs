using System;
using System.Windows.Forms;
using Confluent.Kafka;
using System.Threading;

namespace KafkaChatWinApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();

            Thread thread = new Thread(() =>
            {
                var config = new ConsumerConfig
                {
                    GroupId = "chat-consumer-group",
                    BootstrapServers = "localhost:9092",
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    EnableAutoCommit = true
                };

                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        var result = consumer.Consume(cancellationTokenSource.Token);

                        // Display other people's messages only
                        if (!result.Message.Value.StartsWith(txtName.Text + ":"))
                        {
                            Invoke(new Action(() =>
                            {
                                lstChat.Items.Add(result.Message.Value);
                            }));
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Expected when token is cancelled
                }
                finally
                {
                    consumer.Close();
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Name and message cannot be empty.");
                return;
            }

            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            string fullMessage = $"{txtName.Text}: {txtMessage.Text}";

            try
            {
                await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = fullMessage });
                lstChat.Items.Add($"You: {txtMessage.Text}");
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel(); // Stop the receiving thread gracefully
            base.OnFormClosing(e);
        }
    }
}
