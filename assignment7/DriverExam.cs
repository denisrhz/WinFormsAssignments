using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace DriverExam
{
    public class MainForm : Form
    {
        private const int TotalQuestions = 20;
        private const int PassingScore = 15;
        private readonly char[] correctAnswers = { 'B', 'D', 'A', 'A', 'C', 'A', 'B', 'A', 'C', 'D', 'B', 'C', 'D', 'A', 'D', 'C', 'C', 'B', 'D', 'A' };

        private Button gradeButton = new Button
        {
            Text = "Grade Exam",
            Location = new Point(20, 20)
        };

        private Label resultLabel = new Label
        {
            Location = new Point(20, 60)
        };

        private DataGridView dataGridView1 = new DataGridView
        {
            Location = new Point(20, 180),
            Size = new Size(550, 150),
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToOrderColumns = true,
            ReadOnly = true
        };

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Driver's License Exam Grader";
            this.Size = new Size(600, 400);

            gradeButton.Click += GradeButton_Click;

            DataGridViewTextBoxColumn questionNumberColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Question Number",
                Name = "QuestionNumber"
            };
            DataGridViewTextBoxColumn correctAnswerColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Correct Answer",
                Name = "CorrectAnswer"
            };
            DataGridViewTextBoxColumn studentAnswerColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Student Answer",
                Name = "StudentAnswer"
            };

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { questionNumberColumn, correctAnswerColumn, studentAnswerColumn });

            this.Controls.AddRange(new Control[] { gradeButton, resultLabel, dataGridView1 });
        }

        private void GradeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.txt"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string[] studentAnswers = File.ReadAllLines(filePath);

                if (studentAnswers.Length != TotalQuestions)
                {
                    MessageBox.Show("The file should contain answers for all 20 questions.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int correctCount = 0;
                dataGridView1.Rows.Clear();

                for (int i = 0; i < TotalQuestions; i++)
                {
                    char correctAnswer = correctAnswers[i];
                    char studentAnswer = studentAnswers[i].ToUpper()[0];

                    if (correctAnswer == studentAnswer)
                    {
                        correctCount++;
                    }
                    else
                    {
                        dataGridView1.Rows.Add(i + 1, correctAnswer, studentAnswer);
                    }
                }

                resultLabel.Text = correctCount >= PassingScore ? "Pass" : "Fail";
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}