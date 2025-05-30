using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spot_the_Difference_Game.UI
{
    public class GameForm : Form
    {
        private Label instructionLabel;
        private Button easyButton;
        private Button mediumButton;
        private Button hardButton;

        public enum GameLevel
        {
            Easy,
            Medium,
            Hard
        }

        public GameForm()
        {
            this.Text = "Select Game Level";
            this.ClientSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

<<<<<<< HEAD
            // نفس صورة الخلفية من Start_Form
=======
>>>>>>> c867f6c (finall)
            this.BackgroundImage = Image.FromFile("Images\\Background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
<<<<<<< HEAD
            // العنوان العلوي
=======
>>>>>>> c867f6c (finall)
            instructionLabel = new Label
            {
                Text = "To start your game, choose level",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100
            };

            easyButton = CreateLevelButton("Easy", GameLevel.Easy, 200);
            mediumButton = CreateLevelButton("Medium", GameLevel.Medium, 280);
            hardButton = CreateLevelButton("Hard", GameLevel.Hard, 360);

            this.Controls.Add(instructionLabel);
            this.Controls.Add(easyButton);
            this.Controls.Add(mediumButton);
            this.Controls.Add(hardButton);
        }

        private Button CreateLevelButton(string text, GameLevel level, int yPosition)
        {
            var button = new Button
            {
                Text = text,
                Tag = level,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 60,
                Location = new Point((this.ClientSize.Width - 200) / 2, yPosition)
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += LevelButton_Click;
            return button;
        }

        private void LevelButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedLevel = (GameLevel)button.Tag;

            // افتح ModeSelectionForm
<<<<<<< HEAD
            ModeSelectionForm modeForm = new ModeSelectionForm(selectedLevel);
=======
            ModeSelectionForm modeForm = new ModeSelectionForm(selectedLevel, this);
>>>>>>> c867f6c (finall)
            modeForm.Show();
            this.Hide();
        }
    }
}
