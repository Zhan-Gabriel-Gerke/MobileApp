namespace AnExample;

public partial class TraficLight : ContentPage
{
    HorizontalStackLayout hsl;
    VerticalStackLayout vsl, mainVsl;
    BoxView redCircle, greenCircle, orangeCircle;
    Button startButton, endButton;
	Random random = new Random();
    ScrollView sv;
    public TraficLight()
	{
        //InitializeComponent();
        redCircle = new BoxView
        {
            Color = Colors.Gray,
            WidthRequest = DeviceDisplay.MainDisplayInfo.Width / 10,
            HeightRequest = DeviceDisplay.MainDisplayInfo.Height / 22,
            CornerRadius = 150,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start,
            Background = Color.FromRgba(0, 0, 0, 0)
        };
        greenCircle = new BoxView
        {
            Color = Colors.Gray,
            WidthRequest = DeviceDisplay.MainDisplayInfo.Width / 10,
            HeightRequest = DeviceDisplay.MainDisplayInfo.Height / 22,
            CornerRadius = 150,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Background = Color.FromRgba(0, 0, 0, 0)
        };
        orangeCircle = new BoxView
        {
            Color = Colors.Gray,
            WidthRequest = DeviceDisplay.MainDisplayInfo.Width / 10,
            HeightRequest = DeviceDisplay.MainDisplayInfo.Height / 22,
            CornerRadius = 150,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.End,
            Background = Color.FromRgba(0, 0, 0, 0)
        };
        startButton = new Button
        {
            BackgroundColor = Colors.Gray,
            WidthRequest = 100, HeightRequest = 20,
            CornerRadius = 15,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.End,
            Text = "Start"
        };
        endButton = new Button
        {
            BackgroundColor = Colors.Gray,
            WidthRequest = 100,
            HeightRequest = 20,
            CornerRadius = 15,
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.End,
            Text = "End"
        };
        vsl = new VerticalStackLayout
        {
            Children = { redCircle, orangeCircle, greenCircle }
        };
        hsl = new HorizontalStackLayout
        {
            Children = {startButton, endButton},
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        mainVsl = new VerticalStackLayout
        {
            Children = {vsl, hsl}
        };
        sv = new ScrollView { Content = mainVsl };
        Content = mainVsl;
    }
}