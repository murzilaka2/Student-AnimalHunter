namespace AnimalHunter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TextBox previousSelectedTextBox;
        private List<string> animals;
        private int counter;
        private void Form1_Load(object sender, EventArgs e)
        {
            animals = new List<string>()
            {
                "🙈","🙈","🙉","🙉",
                "🐕","🐕","💥","💥",
                "🐺","🐺","🦍","🦍",
                "🐴","🐴","🐂","🐂"
            };
            StartGame();
        }
        private void StartGame()
        {
            this.counter = animals.Count;
            MixList(animals);
            Random r = new Random();
            int counter = 0;
            foreach (TextBox textbox in tableLayoutPanel1.Controls.OfType<TextBox>())
            {
                textbox.Text = animals[counter++];
                textbox.ForeColor = Color.FromArgb(r.Next(255),r.Next(255),r.Next(255));
            }
        }
        private void MixList(List<string> list)
        {
            Random rand = new Random();
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox selectedTextBox = sender as TextBox;
            if (selectedTextBox is not null)
            {
                if (previousSelectedTextBox is not null)
                {
                    if (previousSelectedTextBox.Text.Equals(selectedTextBox.Text))
                    {
                        previousSelectedTextBox.Text = "";
                        selectedTextBox.Text = "";
                        previousSelectedTextBox.BackColor = SystemColors.Control;
                        previousSelectedTextBox = null;
                        counter -= 2;
                    }
                }
                else
                {
                    previousSelectedTextBox = selectedTextBox;
                    previousSelectedTextBox.BackColor = Color.Firebrick;
                }
                if (counter <= 0)
                {
                    MessageBox.Show("Вы прошли игру!");
                    StartGame();
                }
            }
        }

        private void ExutButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}