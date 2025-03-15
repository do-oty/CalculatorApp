namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operationType = "";
        private bool isNewEntry = false;
        private bool isNewSolution = false;

        public void OnNumberClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (isNewEntry)
            {
                TextDisplay.Text = "";
                isNewEntry = false;
            }

            TextDisplay.Text += button.Text;

            if (isNewSolution)
            {
                SolutionDisplay.Text = button.Text;
                isNewSolution = false;
            }
            else
            {
                SolutionDisplay.Text += button.Text;
            }
        }

        public void OnOperatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (double.TryParse(TextDisplay.Text, out firstNumber))
            {
                operationType = button.Text;
                isNewEntry = true;

                if (!string.IsNullOrEmpty(SolutionDisplay.Text))
                {
                    SolutionDisplay.Text += " " + operationType + " ";
                }
            }
        }

        public void OnEqualsClick(object sender, EventArgs e)
        {
            if (double.TryParse(TextDisplay.Text, out secondNumber))
            {
                double result = 0;

                if (operationType == "+")
                {
                    result = firstNumber + secondNumber;
                }
                if (operationType == "-")
                {
                    result = firstNumber - secondNumber;
                }
                if (operationType == "x")
                {
                    result = firstNumber * secondNumber;
                }
                if (operationType == "/")
                {
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        TextDisplay.Text = "ERROR!";
                        return;
                    }
                }

                SolutionDisplay.Text += " = " + result.ToString();
                TextDisplay.Text = result.ToString();
                isNewEntry = true;
                isNewSolution = true;
            }
        }

        public void OnDeleteClick(object sender, EventArgs e)
        {
            if (double.TryParse(TextDisplay.Text, out double number))
            {
                number = Math.Floor(number / 10);
                TextDisplay.Text = number.ToString();
            }
        }

        public void OnClearClick(object sender, EventArgs e)
        {
            TextDisplay.Text = "";
            SolutionDisplay.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            operationType = "";
            isNewEntry = false;
        }
    }
}