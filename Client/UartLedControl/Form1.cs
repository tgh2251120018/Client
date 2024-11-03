using System;
using System.Drawing; 
using System.Windows.Forms;

namespace UartLedControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowIntroduction();
        }

        private void ShowIntroduction()
        {
            mainPanel.Controls.Clear();
            Label introLabel = new Label
            {
                Text = "Ứng dụng gọi Audio giữa Server và Client (Client)",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.White 
            };
            mainPanel.Controls.Add(introLabel);
        }

        private void ShowCallInterface()
        {
            mainPanel.Controls.Clear();

            Label ipLabel = new Label
            {
                Location = new Point(200, 20),
                Name = "ipLabel",
                Size = new Size(100, 30),
                Text = "IP Address:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black 
            };

            TextBox ipTextBox = new TextBox
            {
                Location = new Point(300, 20),
                Name = "ipTextBox",
                Size = new Size(200, 30),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.White, 
                ForeColor = Color.Black 
            };

            Button connectButton = new Button
            {
                Location = new Point(200, 70),
                Name = "connectButton",
                Size = new Size(120, 60),
                Text = "Connect",
                UseVisualStyleBackColor = false,
                BackColor = Color.FromArgb(50, 205, 50), 
                Font = new Font("Arial", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            connectButton.Anchor = AnchorStyles.Top;
            connectButton.MouseEnter += (s, e) => connectButton.BackColor = Color.Green; 
            connectButton.MouseLeave += (s, e) => connectButton.BackColor = Color.FromArgb(50, 205, 50);
            connectButton.MouseDown += (s, e) => connectButton.BackColor = Color.DarkGreen; 
            connectButton.MouseUp += (s, e) => connectButton.BackColor = Color.Green; 
            connectButton.Click += new EventHandler(this.StartButton_Click);

            Button endButton = new Button
            {
                Location = new Point(350, 70),
                Name = "endButton",
                Size = new Size(120, 60),
                Text = "End Call",
                UseVisualStyleBackColor = false,
                BackColor = Color.FromArgb(255, 69, 0), 
                Font = new Font("Arial", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            endButton.Anchor = AnchorStyles.Top;
            endButton.MouseEnter += (s, e) => endButton.BackColor = Color.Red; 
            endButton.MouseLeave += (s, e) => endButton.BackColor = Color.FromArgb(255, 69, 0);
            endButton.MouseDown += (s, e) => endButton.BackColor = Color.DarkRed; 
            endButton.MouseUp += (s, e) => endButton.BackColor = Color.Red; 
            endButton.Click += new EventHandler(this.EndButton_Click);

            Label myLabel = new Label
            {
                Location = new Point(200, 150),
                Name = "myLabel",
                Size = new Size(270, 50),
                Text = "Status: Idle",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black 
            };
            myLabel.Anchor = AnchorStyles.Top;

            TrackBar volumeBar = new TrackBar
            {
                Location = new Point(200, 220),
                Name = "volumeBar",
                Size = new Size(270, 45),
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                TickFrequency = 10,
                BackColor = Color.White 
            };
            volumeBar.Anchor = AnchorStyles.Top;

            
            Label volumeLabel = new Label
            {
                Location = new Point(480, 220),
                Name = "volumeLabel",
                Size = new Size(60, 45),
                Text = "50%",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft
            };
            volumeLabel.Anchor = AnchorStyles.Top;

            volumeBar.Scroll += (s, e) =>
            {
                volumeLabel.Text = $"{volumeBar.Value}%";
            };

            mainPanel.Controls.Add(ipLabel);        
            mainPanel.Controls.Add(ipTextBox);     
            mainPanel.Controls.Add(connectButton);  
            mainPanel.Controls.Add(endButton);      
            mainPanel.Controls.Add(myLabel);        
            mainPanel.Controls.Add(volumeBar);       
            mainPanel.Controls.Add(volumeLabel);     
        }

        private void IntroductionButton_Click(object sender, EventArgs e)
        {
            ShowIntroduction();
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            ShowCallInterface();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in mainPanel.Controls)
            {
                if (control is Label label && label.Name == "myLabel")
                {
                    label.Text = "Status: Connecting...";
                    label.ForeColor = Color.Lime;
                }
            }
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in mainPanel.Controls)
            {
                if (control is Label label && label.Name == "myLabel")
                {
                    label.Text = "Status: Call Ended";
                    label.ForeColor = Color.Red; 
                }
            }
        }
    }
}
