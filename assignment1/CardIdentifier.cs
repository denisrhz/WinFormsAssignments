using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CardImagesApp
{
    public partial class MainForm : Form
    {
        private PictureBox[] cardPictureBoxes;
        private TextBox cardInfoTextBox;
        private string[] cardImageFiles;

        public MainForm()
        {
            InitializeCards();
            this.Size = new Size(800, 400);
        }

        private void InitializeCards()
        {
            string imagesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cards");
            cardImageFiles = Directory.GetFiles(imagesDirectory, "*.png");

            cardPictureBoxes = new PictureBox[cardImageFiles.Length];
            for (int i = 0; i < cardImageFiles.Length; i++)
            {
                cardPictureBoxes[i] = new PictureBox();
                cardPictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                cardPictureBoxes[i].Image = Image.FromFile(cardImageFiles[i]);
                cardPictureBoxes[i].Click += CardPictureBox_Click;
                cardPictureBoxes[i].Location = new Point(50 + i * 120, 50);
                cardPictureBoxes[i].Size = new Size(100, 150);
                this.Controls.Add(cardPictureBoxes[i]);
            }

            cardInfoTextBox = new TextBox();
            cardInfoTextBox.ReadOnly = true;
            cardInfoTextBox.Location = new Point(50, 220);
            cardInfoTextBox.Size = new Size(500, 50);
            this.Controls.Add(cardInfoTextBox);
        }

        private void CardPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null)
            {
                int cardIndex = Array.IndexOf(cardPictureBoxes, clickedPictureBox);
                string cardName = Path.GetFileNameWithoutExtension(cardImageFiles[cardIndex]);
                cardInfoTextBox.Text = cardName.Replace('_', ' ');
            }
        }

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}