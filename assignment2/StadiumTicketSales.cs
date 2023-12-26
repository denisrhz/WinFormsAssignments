using System;
using System.Windows.Forms;

namespace StadiumTicketSalesApp
{
    public class TicketSalesForm : Form
    {
        private Label classALabel;
        private Label classBLabel;
        private Label classCLabel;

        private TextBox classATextBox;
        private TextBox classBTextBox;
        private TextBox classCTextBox;

        private Button calculateButton;
        private Button clearButton;
        private Button exitButton;

        private TextBox classATextBoxOutput;
        private TextBox classBTextBoxOutput;
        private TextBox classCTextBoxOutput;
        private TextBox totalTextBoxOutput;

        public TicketSalesForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            classALabel = new Label();
            classALabel.Text = "Class A Seats ($15 each):";
            classALabel.Location = new System.Drawing.Point(20, 20);

            classBLabel = new Label();
            classBLabel.Text = "Class B Seats ($12 each):";
            classBLabel.Location = new System.Drawing.Point(20, 50);

            classCLabel = new Label();
            classCLabel.Text = "Class C Seats ($9 each):";
            classCLabel.Location = new System.Drawing.Point(20, 80);

            classATextBox = new TextBox();
            classATextBox.Location = new System.Drawing.Point(160, 20);

            classBTextBox = new TextBox();
            classBTextBox.Location = new System.Drawing.Point(160, 50);

            classCTextBox = new TextBox();
            classCTextBox.Location = new System.Drawing.Point(160, 80);

            calculateButton = new Button();
            calculateButton.Text = "Calculate";
            calculateButton.Location = new System.Drawing.Point(100, 120);
            calculateButton.Click += CalculateButton_Click;

            clearButton = new Button();
            clearButton.Text = "Clear";
            clearButton.Location = new System.Drawing.Point(180, 120);
            clearButton.Click += ClearButton_Click;

            exitButton = new Button();
            exitButton.Text = "Exit";
            exitButton.Location = new System.Drawing.Point(260, 120);
            exitButton.Click += ExitButton_Click;

            classATextBoxOutput = new TextBox();
            classATextBoxOutput.ReadOnly = true;
            classATextBoxOutput.Location = new System.Drawing.Point(400, 20);
            classATextBoxOutput.Size = new System.Drawing.Size(100, 20);

            classBTextBoxOutput = new TextBox();
            classBTextBoxOutput.ReadOnly = true;
            classBTextBoxOutput.Location = new System.Drawing.Point(400, 50);
            classBTextBoxOutput.Size = new System.Drawing.Size(100, 20);

            classCTextBoxOutput = new TextBox();
            classCTextBoxOutput.ReadOnly = true;
            classCTextBoxOutput.Location = new System.Drawing.Point(400, 80);
            classCTextBoxOutput.Size = new System.Drawing.Size(100, 20);

            totalTextBoxOutput = new TextBox();
            totalTextBoxOutput.ReadOnly = true;
            totalTextBoxOutput.Location = new System.Drawing.Point(400, 110);
            totalTextBoxOutput.Size = new System.Drawing.Size(100, 20);

            Controls.Add(classALabel);
            Controls.Add(classBLabel);
            Controls.Add(classCLabel);
            Controls.Add(classATextBox);
            Controls.Add(classBTextBox);
            Controls.Add(classCTextBox);
            Controls.Add(calculateButton);
            Controls.Add(clearButton);
            Controls.Add(exitButton);
            Controls.Add(classATextBoxOutput);
            Controls.Add(classBTextBoxOutput);
            Controls.Add(classCTextBoxOutput);
            Controls.Add(totalTextBoxOutput);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int classA = int.TryParse(classATextBox.Text, out int classATickets) ? classATickets : 0;
            int classB = int.TryParse(classBTextBox.Text, out int classBTickets) ? classBTickets : 0;
            int classC = int.TryParse(classCTextBox.Text, out int classCTickets) ? classCTickets : 0;

            double revenueClassA = classA * 15;
            double revenueClassB = classB * 12;
            double revenueClassC = classC * 9;

            double totalRevenue = revenueClassA + revenueClassB + revenueClassC;

            classATextBoxOutput.Text = revenueClassA.ToString();
            classBTextBoxOutput.Text = revenueClassB.ToString();
            classCTextBoxOutput.Text = revenueClassC.ToString();
            totalTextBoxOutput.Text = totalRevenue.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            classATextBox.Clear();
            classBTextBox.Clear();
            classCTextBox.Clear();
            classATextBoxOutput.Clear();
            classBTextBoxOutput.Clear();
            classCTextBoxOutput.Clear();
            totalTextBoxOutput.Clear();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {            // Clear all input and output textboxes

            Application.Exit();
        }
    }

    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TicketSalesForm());
        }
    }
}