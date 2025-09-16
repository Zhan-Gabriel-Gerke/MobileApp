using System.Threading.Tasks;

namespace AnExample;

public partial class TraficLight : ContentPage
{
    private bool isDay = true;
    private bool isRunning = false;
    public TraficLight()
	{
        InitializeComponent();
    }
    //Start button
    private void Button_Clicked(object sender, EventArgs e)
    {
        isRunning = true;
        Change_Status_Label();
        Start_Trafic_Light();
    }
    //Day/Night
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (isDay == true)
        {
            isDay = false;
        }
        else
        {
            isDay = true;
        }
        Change_Type_Lable();
        
    }
    //End button
    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        isRunning = false;
        Change_Status_Label();
        frameGreen.BackgroundColor = Colors.DarkGray;
        frameOrange.BackgroundColor = Colors.DarkGray;
        frameRed.BackgroundColor = Colors.DarkGray;
    }

    private void Change_Status_Label()
    {
        if (isRunning)
        {
            statusLabel.Text = "Status: The trafick light is working";
        }
        else
        {
            statusLabel.Text = "Status: The trafick light isn't working";
        }
        
    }

    private void Change_Type_Lable()
    {
        if (isDay)
        {
            statusDayNightLabel.Text = "Type: Day type";
        }
        else
        {
            statusDayNightLabel.Text = "Type: Night type";
        }
    }
    private async void Start_Trafic_Light()
    {
        while (isRunning)
        {
            if (isDay)
            {
                //Day type
                frameRed.BackgroundColor = Colors.Red;
                await Task.Delay(5000);
                if (!isRunning) break;
                frameRed.BackgroundColor = Colors.DarkGray;
                frameOrange.BackgroundColor = Colors.Orange;
                await Task.Delay(2000);
                if (!isRunning) break;
                frameOrange.BackgroundColor = Colors.DarkGray;
                frameGreen.BackgroundColor = Colors.Green;
                await Task.Delay(5000);
                if (!isRunning) break;
                frameGreen.BackgroundColor = Colors.DarkGray;
            }
            else
            {
                //Night type
                frameOrange.BackgroundColor = Colors.Orange;
                await Task.Delay(1000);
                if (!isRunning) break;
                frameOrange.BackgroundColor = Colors.Gray;
                await Task.Delay(1000);
                if (!isRunning) break;
            }
        }
    }

    //Orange
    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        if (isRunning)
        {
        labelOrange.Text = "Wait!!!";
        labelOrange.TextColor = Colors.Black ;
        labelOrange.FontSize = 35;
        await Task.Delay(2000);
        labelOrange.Text = "Orange";
        labelOrange.TextColor = Colors.White;
        labelOrange.FontSize = 20;
        }

    }
    //Green
    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        if (isRunning) 
        { 
        labelGreen.Text = "Go";
        labelGreen.TextColor = Colors.Black;
        labelGreen.FontSize = 35;
        await Task.Delay(2000);
        labelGreen.Text = "Green";
        labelGreen.TextColor = Colors.White;
        labelGreen.FontSize = 20;
        }
    }
    //Red
    private async void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {
        if (isRunning) 
        { 
        labelRed.Text = "STOP!!!";
        labelRed.TextColor = Colors.Black;
        labelRed.FontSize = 32;
        await Task.Delay(2000);
        labelRed.Text = "Red";
        labelRed.TextColor = Colors.White;
        labelRed.FontSize = 20;
        }
    }
}