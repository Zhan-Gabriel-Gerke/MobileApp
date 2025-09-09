using System.Threading.Tasks;

namespace AnExample;

public partial class TimerPage : ContentPage
{
	public TimerPage()
	{
        InitializeComponent();
	}
    bool isRunning = true;
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (isRunning)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
            Show_Time();
        }
    }
    private async void Show_Time()
    {
        while (isRunning)
        {
            label.Text = DateTime.Now.ToString("hh:mm:ss");
            await Task.Delay(1000);
        }
    }

}