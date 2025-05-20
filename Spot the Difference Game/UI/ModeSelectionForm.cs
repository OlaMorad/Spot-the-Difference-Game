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

        private GameLevel selectedLevel;

        public ModeSelectionForm(GameLevel level)
        {
            selectedLevel = level;

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

    }
}
