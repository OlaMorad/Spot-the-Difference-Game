using System;
using System.Drawing;
using System.Windows.Forms;
using static Spot_the_Difference_Game.UI.GameForm;


namespace Spot_the_Difference_Game.UI
{
    internal class PlayForm : Form
    {
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label statusLabel;
        private System.Windows.Forms.Timer gameTimer;
        private int timeLeft;     // بالثواني
        private int attemptsLeft;
        private bool timerMode;
        private GameLevel level;

        public PlayForm(GameLevel selectedLevel, bool isTimerMode)
        {
            level = selectedLevel;
            timerMode = isTimerMode;

            this.Text = "Spot the Differences";
            this.ClientSize = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile("Images\\Background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            InitializeComponents();

            if (timerMode)
            {
                timeLeft = level switch
                {
                    GameLevel.Easy => 3 * 60,
                    GameLevel.Medium => 6 * 60,
                    GameLevel.Hard => 10 * 60,
                    _ => 180
                };
                StartTimer();
            }
            else
            {
                attemptsLeft = level switch
                {
                    GameLevel.Easy => 5,
                    GameLevel.Medium => 10,
                    GameLevel.Hard => 15,
                    _ => 5
                };
                UpdateStatus();
            }
        }

        private void InitializeComponents()
        {
            pictureBox1 = new PictureBox
            {
                Image = Image.FromFile("Images\\image1.jpg"), // استبدل باسم الصورة
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(50, 100),
                Size = new Size(400, 400)
            };

            pictureBox2 = new PictureBox
            {
                Image = Image.FromFile("Images\\image2.jpg"), // استبدل باسم الصورة
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(550, 100),
                Size = new Size(400, 400)
            };

            pictureBox1.MouseClick += PictureBox_MouseClick;
            pictureBox2.MouseClick += PictureBox_MouseClick;

            statusLabel = new Label
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(1000, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top
            };

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;

            this.Controls.Add(statusLabel);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(pictureBox2);
        }

        private void StartTimer()
        {
            UpdateStatus();
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateStatus();

            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                MessageBox.Show("Time's up! You lost!");
                this.Close();
            }
        }

        private void UpdateStatus()
        {
            if (timerMode)
            {
                int minutes = timeLeft / 60;
                int seconds = timeLeft % 60;
                statusLabel.Text = $"Time Left: {minutes:D2}:{seconds:D2}";
            }
            else
            {
                statusLabel.Text = $"Attempts Left: {attemptsLeft}";
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            bool isCorrect = CheckDifference(e.Location); // افتراضي: ليس صحيحًا

            if (!isCorrect)
            {
                if (!timerMode)
                {
                    attemptsLeft--;
                    UpdateStatus();
                    if (attemptsLeft <= 0)
                    {
                        MessageBox.Show("No more attempts! You lost!");
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Correct!");
                // تابع اكتشاف الفروقات
            }
        }

        private bool CheckDifference(Point clickLocation)
        {
            // لاحقًا: تحقق إن كان النقر في مكان اختلاف فعلي
            // حالياً: محاكاة عشوائية
            Random rand = new Random();
            return rand.Next(0, 2) == 1;
        }
    }
}
