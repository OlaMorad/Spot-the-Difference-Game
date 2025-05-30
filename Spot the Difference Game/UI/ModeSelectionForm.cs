using System;
using System.Drawing;
using System.Windows.Forms;
using static Spot_the_Difference_Game.UI.GameForm;

namespace Spot_the_Difference_Game.UI
{
    internal class ModeSelectionForm : Form
    {
        private Label modeLabel;
        private Button timerModeButton;
        private Button attemptsModeButton;
<<<<<<< HEAD

        private GameLevel selectedLevel;

        public ModeSelectionForm(GameLevel level)
        {
            selectedLevel = level;
=======
        private Button backButton;

        private GameLevel selectedLevel;
        private GameForm parentForm;

        public ModeSelectionForm(GameLevel level, GameForm parent)
        {
            selectedLevel = level;
            parentForm = parent;
>>>>>>> c867f6c (finall)

            this.Text = "Select Game Mode";
            this.ClientSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile("Images\\Background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            modeLabel = new Label
            {
                Text = "Choose your play mode",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100
            };

<<<<<<< HEAD
            timerModeButton = new Button
            {
                Text = "Play with Timer",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 250,
                Height = 60,
                Location = new Point((this.ClientSize.Width - 250) / 2, 200)
            };
            timerModeButton.FlatAppearance.BorderSize = 0;
            timerModeButton.Click += TimerModeButton_Click;

            attemptsModeButton = new Button
            {
                Text = "Play with Attempts",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 250,
                Height = 60,
                Location = new Point((this.ClientSize.Width - 250) / 2, 300)
            };
            attemptsModeButton.FlatAppearance.BorderSize = 0;
            attemptsModeButton.Click += AttemptsModeButton_Click;

            this.Controls.Add(modeLabel);
            this.Controls.Add(timerModeButton);
            this.Controls.Add(attemptsModeButton);
=======
            // زر المؤقت
            timerModeButton = CreateStyledButton("Play with Timer", new Point((this.ClientSize.Width - 250) / 2, 200));
            timerModeButton.Click += TimerModeButton_Click;

            // زر المحاولات
            attemptsModeButton = CreateStyledButton("Play with Attempts", new Point((this.ClientSize.Width - 250) / 2, 300));
            attemptsModeButton.Click += AttemptsModeButton_Click;

            // زر الرجوع  
            backButton = CreateStyledButton("Back", new Point((this.ClientSize.Width - 250) / 2, 400));
            backButton.BackColor = Color.DarkRed;
            backButton.Click += BackButton_Click;

            this.Controls.Add(modeLabel);
            this.Controls.Add(timerModeButton);
            this.Controls.Add(attemptsModeButton);
            this.Controls.Add(backButton);
        }

        private Button CreateStyledButton(string text, Point location)
        {
            var button = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 250,
                Height = 60,
                Location = location
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
>>>>>>> c867f6c (finall)
        }

        private void TimerModeButton_Click(object sender, EventArgs e)
        {
            PlayForm playForm = new PlayForm(selectedLevel, isTimerMode: true);
            playForm.Show();
            this.Hide();
        }

        private void AttemptsModeButton_Click(object sender, EventArgs e)
        {
            PlayForm playForm = new PlayForm(selectedLevel, isTimerMode: false);
            playForm.Show();
            this.Hide();
        }

<<<<<<< HEAD
=======
        private void BackButton_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }
>>>>>>> c867f6c (finall)
    }
}
