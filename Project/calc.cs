using System;
using System.Windows.Forms;

namespace FuelCalculatorApp
{
    public class FuelCalculatorForm : Form
    {
        private TextBox distanceTextBox;
        private TextBox fuelConsumptionTextBox;
        private TextBox fuelCostTextBox;
        private Label distanceLabel;
        private Label fuelConsumptionLabel;
        private Label fuelCostLabel;
        private GroupBox distanceGroup;
        private GroupBox consumptionGroup;
        private RadioButton kmRadioButton;
        private RadioButton milesRadioButton;
        private RadioButton litersRadioButton;
        private RadioButton gallonsRadioButton;
        private Button calculateButton;
        private Label travelCostLabel;

        public FuelCalculatorForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            distanceLabel = new Label();
            distanceLabel.Text = "Distance:";
            distanceLabel.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(distanceLabel);

            distanceTextBox = new TextBox();
            distanceTextBox.Location = new System.Drawing.Point(120, 20);
            this.Controls.Add(distanceTextBox);

            fuelConsumptionLabel = new Label();
            fuelConsumptionLabel.Text = "Fuel Consumption:";
            fuelConsumptionLabel.Location = new System.Drawing.Point(20, 60);
            this.Controls.Add(fuelConsumptionLabel);

            fuelConsumptionTextBox = new TextBox();
            fuelConsumptionTextBox.Location = new System.Drawing.Point(120, 60);
            this.Controls.Add(fuelConsumptionTextBox);

            fuelCostLabel = new Label();
            fuelCostLabel.Text = "Fuel Cost:";
            fuelCostLabel.Location = new System.Drawing.Point(20, 100);
            this.Controls.Add(fuelCostLabel);

            fuelCostTextBox = new TextBox();
            fuelCostTextBox.Location = new System.Drawing.Point(120, 100);
            this.Controls.Add(fuelCostTextBox);

            distanceGroup = new GroupBox();
            distanceGroup.Text = "Distance";
            distanceGroup.Location = new System.Drawing.Point(250, 10);
            distanceGroup.Size = new System.Drawing.Size(200, 60);
            this.Controls.Add(distanceGroup);

            kmRadioButton = new RadioButton();
            kmRadioButton.Text = "Kilometers";
            kmRadioButton.Location = new System.Drawing.Point(10, 20);
            distanceGroup.Controls.Add(kmRadioButton);

            milesRadioButton = new RadioButton();
            milesRadioButton.Text = "Miles";
            milesRadioButton.Location = new System.Drawing.Point(10, 40);
            distanceGroup.Controls.Add(milesRadioButton);

            consumptionGroup = new GroupBox();
            consumptionGroup.Text = "Fuel Consumption";
            consumptionGroup.Location = new System.Drawing.Point(250, 80);
            consumptionGroup.Size = new System.Drawing.Size(200, 60);
            this.Controls.Add(consumptionGroup);

            litersRadioButton = new RadioButton();
            litersRadioButton.Text = "Liters/100 km";
            litersRadioButton.Location = new System.Drawing.Point(10, 20);
            consumptionGroup.Controls.Add(litersRadioButton);

            gallonsRadioButton = new RadioButton();
            gallonsRadioButton.Text = "Liters/100 miles";
            gallonsRadioButton.Location = new System.Drawing.Point(10, 40);
            consumptionGroup.Controls.Add(gallonsRadioButton);

            calculateButton = new Button();
            calculateButton.Text = "Calculate";
            calculateButton.Location = new System.Drawing.Point(20, 140);
            calculateButton.Click += CalculateButton_Click;
            this.Controls.Add(calculateButton);

            travelCostLabel = new Label();
            travelCostLabel.Location = new System.Drawing.Point(20, 180);
            this.Controls.Add(travelCostLabel);

            this.Text = "Fuel Calculator";
            this.Size = new System.Drawing.Size(500, 300);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            double distance = Convert.ToDouble(distanceTextBox.Text);
            double fuelConsumption = Convert.ToDouble(fuelConsumptionTextBox.Text);
            double fuelCost = Convert.ToDouble(fuelCostTextBox.Text);

            double travelCost = 0;

            // Calculate travel cost based on selected options
            if (kmRadioButton.Checked && litersRadioButton.Checked)
            {
                // Calculation logic for kilometers and liters/100km
                travelCost = (distance / 100) * fuelConsumption * fuelCost;
            }
            else if (milesRadioButton.Checked && gallonsRadioButton.Checked)
            {
                // Calculation logic for miles and liters/100 miles
                travelCost = (distance / 100) * fuelConsumption * fuelCost * 0.621371; // Convert liters to gallons
            }
            else
            {
                // Handle if no options are selected
                MessageBox.Show("Please select distance and fuel consumption units.");
                return;
            }

            travelCostLabel.Text = $"Travel cost: {travelCost:F2} Euros";
        }

        public class Program
        {
            [STAThread]
            public static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                FuelCalculatorForm fuelCalculatorForm = new FuelCalculatorForm();
                Application.Run(fuelCalculatorForm);
            }
        }
    }
}
