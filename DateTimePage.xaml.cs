using Microsoft.Maui.Layouts;

namespace AnExample;

public partial class DateTimePage : ContentPage
{
	Label mis_on_valitud;
	DatePicker datePicker;
	TimePicker timePicker;
	AbsoluteLayout al;
	Picker picker;
	Slider slider;
	Stepper stepper;
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
		picker = new Picker
		{
			Title = "Vali midagi",
			FontSize = 20,
			BackgroundColor = Color.FromRgb(200, 200, 100),
			TextColor = Colors.Black,
		};
		picker.ItemsSource = new List<string> { "Teade", "Jah / Ei teade", "Valik", "Vaba vastus" };


        //foreach (var option in options)
        //{
        //    picker.Items.Add(option);
        //}
		picker.SelectedIndexChanged += (s, e) =>
		{
			if (picker.SelectedIndex != -1)
			{
				mis_on_valitud.Text = $"Valitud: {picker.Items[picker.SelectedIndex]}";
				if (picker.SelectedIndex ==0)
				{
					DisplayAlert("Teade", "Mis ole hea uudis", "Selge");
                }
				else if (picker.SelectedIndex == 1)
				{
					DisplayAlert("Kusimus", "Kas soovite jätkata?", "Jah", "Ei");
                }
				else if (picker.SelectedIndex == 2)
				{
					var valik = new string[] { "Võimalus 1", "Võimalus 2", "Võimalus 3" };
					var tulemus = DisplayActionSheet("Vali võimal", "Katkesta", null, valik);
                }
				else if (picker.SelectedIndex == 3)
				{
					var tulemus = DisplayPromptAsync("Küsimus", "Kirjuta oma vastus", "OK", "Katkesta", "Siia tuleb vastus", 20, Keyboard.Text, "Vaikimisi vastus");
                }

            }
		};
		slider = new Slider
		{
			Minimum = 0,
			Maximum = 100,
			Value = 50,
			BackgroundColor = Color.FromRgb(100, 200, 100),
			ThumbColor = Colors.Red,
			MinimumTrackColor = Colors.Green,
			MaximumTrackColor = Colors.Blue
        };
		slider.ValueChanged += (s, e) =>
		{
			mis_on_valitud.FontSize = e.NewValue;
			mis_on_valitud.Rotation = e.NewValue;
		};
		stepper = new Stepper
		{
			Minimum = 0,
			Maximum = 100,
			Increment = 1,
			Value = 20,
			BackgroundColor = Color.FromRgb(200, 200, 100),
			HorizontalOptions = LayoutOptions.Center
		};
		stepper.ValueChanged += (s, e) =>
		{
			mis_on_valitud.Text = $"Stepper value: {e:NewValue}";
		};
        al = new AbsoluteLayout
		{
			Children = { 				
				mis_on_valitud,
				datePicker,
                timePicker,
				picker,
				slider,
				stepper
            }
        };
        /*AbsoluteLayout.SetLayoutBounds(mis_on_valitud, new Rect(0.5, 0.0, 300, 50));
        AbsoluteLayout.SetLayoutFlags(mis_on_valitud, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(datePicker, new Rect(0.5, 0.2, 0.9, 0.2));
		AbsoluteLayout.SetLayoutFlags(datePicker, AbsoluteLayoutFlags.All);
        AbsoluteLayout.SetLayoutBounds(timePicker, new Rect(0.5, 0.4, 0.9, 0.2));
        AbsoluteLayout.SetLayoutFlags(timePicker, AbsoluteLayoutFlags.All);
		AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.5, 0.6, 0.9, 0.2));
		AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.All);
		AbsoluteLayout.SetLayoutBounds(slider, new Rect(0.5, 0.8, 0.9, 0.2));
		AbsoluteLayout.SetLayoutFlags(slider, AbsoluteLayoutFlags.All);
		AbsoluteLayout.SetLayoutBounds(stepper, new Rect(0.5, 1, 0.9, 0.2));
		AbsoluteLayout.SetLayoutFlags(stepper, AbsoluteLayoutFlags.All);*/

		var elementid = new View[]
		{
            mis_on_valitud,
            datePicker,
            timePicker,
            picker,
            slider,
            stepper
        };
		for (int i = 0; i < elementid.Length; i++)
		{
			AbsoluteLayout.SetLayoutBounds(elementid[i], new Rect(0.5, 0.1 + i * 0.15, 0.9, 0.13));
            AbsoluteLayout.SetLayoutFlags(elementid[i], AbsoluteLayoutFlags.All);
        }
		Content = al;
        //X, Y, Width, Height
        //X - padding from left side, Y - padding from top side

    }

    private void DatePicker_DateSelected(object? sender, DateChangedEventArgs e)
    {
		mis_on_valitud.Text = $"Valitud kuupäev: {e.NewDate:D}";
    }
}