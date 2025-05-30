<<<<<<< HEAD
﻿using System;
using System.Drawing;
using System.Windows.Forms;
using static Spot_the_Difference_Game.UI.GameForm;
using Spot_the_Difference_Game.Audio;
using Spot_the_Difference_Game.logic;
=======
﻿using Spot_the_Difference_Game.logic;
using Spot_the_Difference_Game.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Spot_the_Difference_Game.UI.GameForm;
>>>>>>> c867f6c (finall)

namespace Spot_the_Difference_Game.UI
{
    internal class PlayForm : Form
    {
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox overlayPictureBox;
        private Label statusLabel;
        private System.Windows.Forms.Timer gameTimer;
<<<<<<< HEAD
=======
        private Button backButton;

>>>>>>> c867f6c (finall)
        private int timeLeft;
        private int attemptsLeft;
        private bool timerMode;
        private GameLevel level;

<<<<<<< HEAD
        private string leftClickSoundPath = "Audio\\error.wav";
        private string rightClickSoundPath = "Audio\\success.wav";

        private string image1Path;
        private string image2Path;

        private Bitmap overlayBitmap;
        private Graphics overlayGraphics;

=======
        private string image1Path;
        private string image2Path;

        private string correctSound = "Audio\\success.wav";
        private string wrongSound = "Audio\\error.wav";
        private string winSound = "Audio\\win1.wav";

        private Bitmap overlayBitmap;
        private Graphics overlayGraphics;

        private List<DifferencePair> differencePairs;
        private List<DifferencePair> foundPairs = new List<DifferencePair>();

>>>>>>> c867f6c (finall)
        public PlayForm(GameLevel selectedLevel, bool isTimerMode)
        {
            level = selectedLevel;
            timerMode = isTimerMode;

<<<<<<< HEAD
            // تحميل الصور المناسبة حسب المستوى
            LevelImages images = LevelImageProvider.GetImagesForLevel(level);
            image1Path = images.Image1Path;
            image2Path = images.Image2Path;
=======
            var levelImages = LevelImageProvider.GetImagesForLevel(level);
            image1Path = levelImages.Image1Path;
            image2Path = levelImages.Image2Path;
>>>>>>> c867f6c (finall)

            this.Text = "Spot the Differences";
            this.ClientSize = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile("Images\\Background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            InitializeComponents();
<<<<<<< HEAD
=======
            LoadDifferences();
>>>>>>> c867f6c (finall)

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
<<<<<<< HEAD
                BackColor = Color.Transparent
            };
=======
                BackColor = Color.Transparent,
            };
            overlayPictureBox.Parent = pictureBox1;
            overlayPictureBox.BringToFront();


            backButton = new Button
            {
                Text = "Back",
                Font = new Font("Segoe UI", 14, FontStyle.Bold), 
                BackColor = Color.DarkRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80,50), 
                Location = new Point(10,40),
                TextAlign = ContentAlignment.MiddleCenter,
                UseCompatibleTextRendering = true 
            };
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Click += BackButton_Click;


>>>>>>> c867f6c (finall)

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;

            this.Controls.Add(statusLabel);
            this.Controls.Add(pictureBox1);
<<<<<<< HEAD
            this.Controls.Add(pictureBox2);
            this.Controls.Add(overlayPictureBox);
=======
            this.Controls.Add(overlayPictureBox); 
            this.Controls.Add(pictureBox2);
            this.Controls.Add(backButton);

        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to go back? You will lose the game progress.",
                                         "Confirm Exit",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var levelForm = new GameForm();
                levelForm.Show();
                this.Close();
            }
        }
        private void LoadDifferences()
        {
            try
            {
                switch (level)
                {
                    case GameLevel.Easy:
                        differencePairs = PredefinedDifferences.EasyLevel;
                        break;
                    case GameLevel.Medium:
                        differencePairs = PredefinedDifferences.MediumLevel;
                        break;
                    case GameLevel.Hard:
                        differencePairs = PredefinedDifferences.HardLevel;
                        break;
                    default:
                        differencePairs = new List<DifferencePair>();
                        break;
                }

                UpdateStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading differences: " + ex.Message);
                differencePairs = new List<DifferencePair>();
            }
>>>>>>> c867f6c (finall)
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
<<<<<<< HEAD
=======
            string status = "";

>>>>>>> c867f6c (finall)
            if (timerMode)
            {
                int min = timeLeft / 60;
                int sec = timeLeft % 60;
<<<<<<< HEAD
                statusLabel.Text = $"Time Left: {min:D2}:{sec:D2}";
            }
            else
            {
                statusLabel.Text = $"Attempts Left: {attemptsLeft}";
            }
=======
                status += $"Time Left: {min:D2}:{sec:D2}    ";
            }
            else
            {
                status += $"Attempts Left: {attemptsLeft}    ";
            }

            status += $"Found: {foundPairs.Count} / {differencePairs?.Count ?? 0}";
            statusLabel.Text = status;
>>>>>>> c867f6c (finall)
        }

        private void Picture_MouseClick(object sender, MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            var globalPoint = pictureBox.PointToScreen(e.Location);
<<<<<<< HEAD
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
=======
            var relativeToOverlay = pictureBox1.PointToClient(globalPoint); 

            bool isCorrect = false;

            foreach (var pair in differencePairs)
            {
                if (!foundPairs.Contains(pair) && pair.Contains(relativeToOverlay, 15))
                {
                    foundPairs.Add(pair);

                    using (Graphics g = pictureBox2.CreateGraphics())
                    {
                        DrawCircleOnPictureBox(g, pair.Rect1Center, 60); // الصورة الأولى
                        DrawCircleOnPictureBox(g, pair.Rect2Center, 60); // الصورة الثانية
                    }
                    using (Graphics g = pictureBox1.CreateGraphics())
                    {
                        DrawCircleOnPictureBox(g, pair.Rect1Center, 60); 
                        DrawCircleOnPictureBox(g, pair.Rect2Center, 60); 
                    }

                    AudioPlayer.PlaySoundAsync(correctSound);
                    isCorrect = true;
                    break;
                }
            }

            if (!isCorrect)
            {
                using (Graphics g1 = pictureBox1.CreateGraphics())
                {
                    DrawRedXOnPictureBox(g1, relativeToOverlay, 30);
                }
                using (Graphics g2 = pictureBox2.CreateGraphics())
                {
                    var relativeToOverlay2 = pictureBox2.PointToClient(pictureBox.PointToScreen(e.Location));
                    DrawRedXOnPictureBox(g2, relativeToOverlay2, 30);
                }
                AudioPlayer.PlaySoundAsync(wrongSound);
                if (!timerMode)
                {
                    attemptsLeft--;
                    if (attemptsLeft <= 0)
                    {
                        UpdateStatus();
                        MessageBox.Show("No more attempts! You lost!");
                        this.Close();
                        return;
                    }
                }
            }

            UpdateStatus();

            if (foundPairs.Count == differencePairs.Count)
            {
                gameTimer.Stop();
                AudioPlayer.PlaySoundAsync(winSound);
                MessageBox.Show("Congratulations! You found all differences!");
                this.Close();
            }

            // إحداثيات النقرة
            //MessageBox.Show($"Clicked pixel at: X = {relativeToOverlay.X}, Y = {relativeToOverlay.Y}");
        }



        private void DrawCircleOnPictureBox(Graphics g, Point center, int diameter)
        {
            Rectangle circle = new Rectangle(
                center.X - diameter / 2,
                center.Y - diameter / 2,
                diameter,
                diameter
            );

            using (Pen pen = new Pen(Color.Red,3))
            {
                g.DrawEllipse(pen, circle);
            }
        }
        private void DrawRedXOnPictureBox(Graphics g, Point center, int size)
        {
            Point topLeft = new Point(center.X - size / 2, center.Y - size / 2);
            Point bottomRight = new Point(center.X + size / 2, center.Y + size / 2);
            Point topRight = new Point(center.X + size / 2, center.Y - size / 2);
            Point bottomLeft = new Point(center.X - size / 2, center.Y + size / 2);

            using (Pen pen = new Pen(Color.Red, 3))
            {
                g.DrawLine(pen, topLeft, bottomRight);
                g.DrawLine(pen, topRight, bottomLeft);
            }
        }



>>>>>>> c867f6c (finall)
    }
}
