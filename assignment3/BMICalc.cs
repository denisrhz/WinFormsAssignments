using System;
using System.Drawing;
using System.Windows.Forms;

namespace BMICalculator
{
    public class MainForm : Form
    {
        private Label weightLabel = new Label
        {
            Text = "Weight (pounds):",
            Location = new Point(20, 20),
            AutoSize = true
        };

        private Label heightLabel = new Label
        {
            Text = "Height (inches):",
            Location = new Point(20, 60),
            AutoSize = true
        };

        private TextBox weightTextBox = new TextBox
        {
            Location = new Point(150, 20),
            Size = new Size(100, 20)
        };

        private TextBox heightTextBox = new TextBox
        {
            Location = new Point(150, 60),
            Size = new Size(100, 20)
        };

        private Button calculateButton = new Button
        {
            Text = "Calculate BMI",
            Location = new Point(20, 100),
            Size = new Size(120, 30)
        };

        private Label resultLabel = new Label
        {
            Text = "BMI: ",
            Location = new Point(20, 150),
            AutoSize = true
        };

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            calculateButton.Click += CalculateButton_Click;

            Controls.Add(weightLabel);
            Controls.Add(heightLabel);
            Controls.Add(weightTextBox);
            Controls.Add(heightTextBox);
            Controls.Add(calculateButton);
            Controls.Add(resultLabel);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(weightTextBox.Text, out double weight) &&
                double.TryParse(heightTextBox.Text, out double height))
            {
                double bmi = CalculateBMI(weight, height);
                resultLabel.Text = $"BMI: {bmi:F2}";

                if (bmi < 18.5)
                    resultLabel.Text += " (Underweight)";
                else if (bmi >= 18.5 && bmi <= 25)
                    resultLabel.Text += " (Optimal Weight)";
                else
                    resultLabel.Text += " (Overweight)";
            }
            else
            {
                resultLabel.Text = "Invalid input. Please enter valid numbers.";
            }
        }

        private double CalculateBMI(double weight, double height)
        {
            return (weight / (height * height)) * 703;
        }


        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
