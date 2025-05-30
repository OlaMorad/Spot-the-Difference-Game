using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spot_the_Difference_Game.UI
{
    internal class Start_Form : Form
    {
        private Label titleLabel;
        private Button button1;

        public Start_Form()
        {
            this.Text = "Spot the Difference Game";
            this.ClientSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;


            this.BackgroundImage = Image.FromFile("Images\\Background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
<<<<<<< HEAD
            // إنشاء وتخصيص عنوان اللعبة
            titleLabel = new Label
            {
                Text = "Spot the Difference Game",
                Font = new Font("Segoe UI", 36, FontStyle.Bold), // حجم خط أكبر
=======
            titleLabel = new Label
            {
                Text = "Spot the Difference Game",
                Font = new Font("Segoe UI", 36, FontStyle.Bold), 
>>>>>>> c867f6c (finall)
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
<<<<<<< HEAD
                Size = new Size(700, 100), // حجم مناسب للنص
                Location = new Point(
                    (this.ClientSize.Width - 700) / 2,
                    (this.ClientSize.Height / 2) - 150 // وضعها أعلى منتصف الشاشة
=======
                Size = new Size(700, 100),
                Location = new Point(
                    (this.ClientSize.Width - 700) / 2,
                    (this.ClientSize.Height / 2) - 150 
>>>>>>> c867f6c (finall)
                )
            };


            button1 = new Button
            {
                Text = "Start Game",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 60,
            };
            button1.FlatAppearance.BorderSize = 0;

            button1.Location = new Point(
                (this.ClientSize.Width - button1.Width) / 2,
                (this.ClientSize.Height - button1.Height) / 2
            );

            button1.Click += BtnStart_Click;

<<<<<<< HEAD
            this.Controls.Add(titleLabel); // إضافة العنوان أولاً
=======
            this.Controls.Add(titleLabel); 
>>>>>>> c867f6c (finall)
            this.Controls.Add(button1);
        }


        private void BtnStart_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();
            this.Hide();
<<<<<<< HEAD
            //MessageBox.Show("Start Game clicked!");
            // لاحقًا: فتح GameForm أو شاشة اختيار المستوى
=======
>>>>>>> c867f6c (finall)
        }
    }
}

