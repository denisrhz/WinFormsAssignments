using System;
using System.Windows.Forms;

public class GuessGameForm : Form
{
    private int randomNumber;
    private int guessCount;
    private TextBox guessInput = new TextBox
    {
        Size = new System.Drawing.Size(200, 23),
        Location = new System.Drawing.Point(10, 10)
    };

    private Button guessButton = new Button
    {
        Text = "Guess",
        Size = new System.Drawing.Size(100, 23),
        Location = new System.Drawing.Point(220, 10)
    };

    private Label messageLabel = new Label
    {
        Size = new System.Drawing.Size(320, 23),
        Location = new System.Drawing.Point(10, 40)
    };

    public GuessGameForm()
    {
        this.randomNumber = new Random().Next(1, 101);
        this.guessCount = 0;
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.guessButton.Click += new EventHandler(GuessButton_Click);

        this.Controls.AddRange(new Control[] { this.guessInput, this.guessButton, this.messageLabel });

        this.Text = "Random Number Guessing Game";
        this.Size = new System.Drawing.Size(350, 120);
    }

    private void GuessButton_Click(object sender, EventArgs e)
    {
        guessCount++;
        int userGuess;
        bool isNumeric = int.TryParse(this.guessInput.Text, out userGuess);

        if (!isNumeric)
        {
            MessageBox.Show("Please enter a valid number.");
            return;
        }

        if (userGuess > randomNumber)
        {
            this.messageLabel.Text = "Too high, try again.";
        }
        else if (userGuess < randomNumber)
        {
            this.messageLabel.Text = "Too low, try again.";
        }
        else
        {
            this.messageLabel.Text = $"Congratulations! You guessed the number in {guessCount} attempts.";
            this.randomNumber = new Random().Next(1, 101);
            this.guessCount = 0;
        }

        this.guessInput.Text = "";
    }

    static void Main()
    {
        Application.Run(new GuessGameForm());
    }
}
