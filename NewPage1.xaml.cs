using System.Threading.Tasks;

namespace AnExample;

public partial class NewPage1 : ContentPage
{
	public List<ContentPage> pagesE = new List<ContentPage>() { new TextPage(), new FigurePage(), new TimerPage(), new TraficLight() ,new SnowMan(), new DateTimePage(), new GridPage(), new PulsePage() };
	public List<string> textsE = new List<string>() { "Text Page !!!", "Figure Page !!!", "Timer Page !!!", "Trafic Light", "SnowMan", "DateTimePage", "Grid", "PulsePage" };
	ScrollView sv;
	VerticalStackLayout vsl;
	public NewPage1()
	{
		//InitializeComponent();
		Title = "Home page";
		vsl = new VerticalStackLayout { BackgroundColor = Color.FromRgb(120, 30, 50) };
		for (int i = 0; i < pagesE.Count; i++)
		{
			Button btn = new Button()
			{
				Text = textsE[i],
				FontSize = 20,
				BackgroundColor = Color.FromRgb(200, 200, 100),
				TextColor = Colors.Black,
				FontFamily = "Lucida-400",
				ZIndex = i
			};
			vsl.Add(btn);
            btn.Clicked += Btn_Clicked;
		}
        sv = new ScrollView{Content = vsl};
        Content = sv;

    }

    private async void Btn_Clicked(object? sender, EventArgs e)
    {
        Button butn = (Button)sender;
        await Navigation.PushAsync(pagesE[butn.ZIndex]);
    }
}