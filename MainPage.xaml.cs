namespace AnExample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"AsalaMaleikum {count}";
            else
                CounterBtn.Text = $"AsalaMaleikum {count}";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
