using Microsoft.Maui.Layouts;

namespace AnExample;

public partial class DateTimePage : ContentPage
{
	Label mis_on_valitud;
	DatePicker datePicker;
	TimePicker timePicker;
	AbsoluteLayout al;
    public DateTimePage()
	{
		//InitializeComponent();
		mis_on_valitud = new Label
		{
			Text = "Mis on valitud",
			FontSize = 20,
			TextColor = Colors.Black,
		};
		datePicker = new DatePicker
		{
			FontSize = 20,
			Date = DateTime.Now,
			MinimumDate = DateTime.Now.AddDays(-7),//Min date 7 days ago
            //MinimumDate = new DateTime(2020, 1, 1),
            MaximumDate = new DateTime(2030, 12, 31),
			TextColor = Colors.Blue,
			Format = "D"//Full date
        };
        datePicker.DateSelected += DatePicker_DateSelected;

		timePicker = new TimePicker
		{
			FontSize = 20,
			Time = new TimeSpan(12, 0, 0),//12:00 PM
			//MinimumTime = new TimeSpan(8, 0, 0),//8:00 AM
			//MaximumTime = new TimeSpan(18, 0, 0),//6:00 PM
			TextColor = Colors.Green,
			Format = ""// t - short time, T - long time
        };
		timePicker.PropertyChanged += (s, e) =>
		{

			if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
			{
				mis_on_valitud.Text = $"Valitud aeg: {timePicker.Time}";
            }
        };

        al = new AbsoluteLayout
		{
			Children = { 				
				mis_on_valitud,
				datePicker,
                timePicker
            }
        };
		AbsoluteLayout.SetLayoutBounds(mis_on_valitud, new Rect(0.5, 0.1, 300, 50));
		AbsoluteLayout.SetLayoutFlags(mis_on_valitud, AbsoluteLayoutFlags.All);
		AbsoluteLayout.SetLayoutBounds(datePicker, new Rect(0.5, 0.5, 0.9, 0.2));
		AbsoluteLayout.SetLayoutFlags(datePicker, AbsoluteLayoutFlags.All);
        AbsoluteLayout.SetLayoutBounds(timePicker, new Rect(0.5, 0.8, 0.9, 0.2));
        AbsoluteLayout.SetLayoutFlags(timePicker, AbsoluteLayoutFlags.All);
        Content = al;
        //X, Y, Width, Height
        //X - padding from left side, Y - padding from top side

    }

    private void DatePicker_DateSelected(object? sender, DateChangedEventArgs e)
    {
		mis_on_valitud.Text = $"Valitud kuupäev: {e.NewDate:D}";
    }
}