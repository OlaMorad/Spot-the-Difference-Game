using System;
using System.Drawing;
using System.Windows.Forms;
using static Spot_the_Difference_Game.UI.GameForm;
using Spot_the_Difference_Game.Audio;
using Spot_the_Difference_Game.logic;

namespace Spot_the_Difference_Game.UI
{
    internal class PlayForm : Form
    {
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox overlayPictureBox;
        private Label statusLabel;
        private System.Windows.Forms.Timer gameTimer;
        private int timeLeft;
        private int attemptsLeft;
        private bool timerMode;
        private GameLevel level;

        private string leftClickSoundPath = "Audio\\error.wav";
        private string rightClickSoundPath = "Audio\\success.wav";

        private string image1Path;
        private string image2Path;

        private Bitmap overlayBitmap;
        private Graphics overlayGraphics;

        public PlayForm(GameLevel selectedLevel, bool isTimerMode)
        {
            level = selectedLevel;
            timerMode = isTimerMode;

            // تحميل الصور المناسبة حسب المستوى
            LevelImages images = LevelImageProvider.GetImagesForLevel(level);
            image1Path = images.Image1Path;
            image2Path = images.Image2Path;

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
                    GameLevel.Easy => 180,
                    GameLevel.Medium => 360,
                    GameLevel.Hard => 600,
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

            pictureBox1 = new PictureBox
            {
                Image = Image.FromFile(image1Path),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(50, 100),
                Size = new Size(400, 400)
            };

            pictureBox2 = new PictureBox
            {
                Image = Image.FromFile(image2Path),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(550, 100),
                Size = new Size(400, 400)
            };

            pictureBox1.MouseClick += Picture_MouseClick;
            pictureBox2.MouseClick += Picture_MouseClick;

            overlayBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            overlayGraphics = Graphics.FromImage(overlayBitmap);

            overlayPictureBox = new PictureBox
            {
                Image = overlayBitmap,
                Size = pictureBox1.Size,
                Location = pictureBox1.Location,
                BackColor = Color.Transparent
            };

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;

            this.Controls.Add(statusLabel);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(overlayPictureBox);
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
                int min = timeLeft / 60;
                int sec = timeLeft % 60;
                statusLabel.Text = $"Time Left: {min:D2}:{sec:D2}";
            }
            else
            {
                statusLabel.Text = $"Attempts Left: {attemptsLeft}";
            }
        }

        private void Picture_MouseClick(object sender, MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            var globalPoint = pictureBox.PointToScreen(e.Location);
            var relativeToOverlay = overlayPictureBox.PointToClient(globalPoint);

            bool isCorrect = SimulateCorrectClick(); // سيتم استبدالها لاحقاً بمنطق فعلي

            if (e.Button == MouseButtons.Left)
            {
                AudioPlayer.PlaySoundAsync(leftClickSoundPath);
            }
            else if (e.Button == MouseButtons.Right)
            {
                AudioPlayer.PlaySoundAsync(rightClickSoundPath);
                DrawRedCircle(relativeToOverlay);
            }

            if (!timerMode && !isCorrect)
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

        private void DrawRedCircle(Point location)
        {
            int radius = 15;
            Rectangle circle = new Rectangle(location.X - radius, location.Y - radius, radius * 2, radius * 2);

            using (Pen pen = new Pen(Color.Red, 3))
            {
                overlayGraphics.DrawEllipse(pen, circle);
            }

            overlayPictureBox.Image = overlayBitmap;
            overlayPictureBox.Refresh();
        }

        private bool SimulateCorrectClick()
        {
            Random rand = new Random();
            return rand.Next(0, 2) == 1;
        }
    }
}
