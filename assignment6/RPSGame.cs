using System;
using System.Windows.Forms;
using System.Drawing;

public class RPSGame : Form
{
    private Button rockButton = new Button { Text = "Rock", Location = new Point(10, 10) };
    private Button paperButton = new Button { Text = "Paper", Location = new Point(100, 10) };
    private Button scissorsButton = new Button { Text = "Scissors", Location = new Point(190, 10) };
    private Label computerChoiceLabel = new Label { Text = "Computer's choice: ", Location = new Point(10, 30), AutoSize = true };
    private Label resultLabel = new Label { Text = "Result: ", Location = new Point(10, 70), AutoSize = true };
    private Random random = new Random();

    public RPSGame()
    {
        this.Text = "Rock, Paper, Scissors Game";
        this.Size = new Size(300, 200);

        rockButton.Click += OnUserChoice;
        paperButton.Click += OnUserChoice;
        scissorsButton.Click += OnUserChoice;

        this.Controls.AddRange(new Control[] { rockButton, paperButton, scissorsButton, computerChoiceLabel, resultLabel });
    }

    private void OnUserChoice(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        string userChoice = clickedButton.Text;
        string computerChoice = GetComputerChoice();
        string result = DetermineWinner(userChoice, computerChoice);
        computerChoiceLabel.Text = $"Computer's choice: {computerChoice}";
        resultLabel.Text = $"Result: {result}";
    }

    private string GetComputerChoice()
    {
        int choice = random.Next(1, 4);
        switch (choice)
        {
            case 1: return "Rock";
            case 2: return "Paper";
            case 3: return "Scissors";
            default: return "Rock";
        }
    }

    private string DetermineWinner(string userChoice, string computerChoice)
    {
        if (userChoice == computerChoice)
            return "It's a tie!";

        if ((userChoice == "Rock" && computerChoice == "Scissors") ||
            (userChoice == "Scissors" && computerChoice == "Paper") ||
            (userChoice == "Paper" && computerChoice == "Rock"))
        {
            return "You win!";
        }
        else
        {
            return "You lose!";
        }
    }

    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new RPSGame());
    }
}
