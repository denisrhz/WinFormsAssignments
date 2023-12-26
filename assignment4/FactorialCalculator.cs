using System;
using System.Numerics;
using System.Windows.Forms;

namespace FactorialCalculatorApp
{
    public class MainForm : Form
    {
        private Label resultLabel = new Label();
        private TextBox inputTextBox = new TextBox();
        private Button calculateButton = new Button();

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            resultLabel.Location = new System.Drawing.Point(10, 80);
            resultLabel.Size = new System.Drawing.Size(300, 30);

            inputTextBox.Location = new System.Drawing.Point(10, 10);
            inputTextBox.Size = new System.Drawing.Size(100, 20);

            calculateButton.Location = new System.Drawing.Point(120, 10);
            calculateButton.Size = new System.Drawing.Size(80, 20);
            calculateButton.Text = "Calculate";
            calculateButton.Click += CalculateButton_Click;

            Controls.AddRange(new Control[] { resultLabel, inputTextBox, calculateButton });

            Size = new System.Drawing.Size(300, 150);
            Text = "Factorial Calculator";
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(inputTextBox.Text, out BigInteger number) && number >= 0)
            {
                BigInteger factorial = CalculateFactorial(number);

                resultLabel.Text = $"Factorial of {number} is: {factorial}";
            }
            else
            {
                resultLabel.Text = "Invalid input. Please enter a non-negative integer.";
            }
        }

        private BigInteger CalculateFactorial(BigInteger n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            BigInteger result = 1;
            for (BigInteger i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
