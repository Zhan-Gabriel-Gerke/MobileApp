using System.Runtime.CompilerServices;

namespace AnExample;

public partial class TextPage : ContentPage
{
    Button btn;
    Label lblTekstl;
	Editor editorTeskst;
	HorizontalStackLayout hsl;
	private async void Btn_Clicked(object sender, EventArgs e)
	{
        IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();

        SpeechOptions options = new SpeechOptions()
        {
            Pitch = 1.5f,   // 0.0 - 2.0
            Volume = 0.75f, // 0.0 - 1.0
            Locale = locales.FirstOrDefault(l => l.Language == "et-EE")
        };
        var text = editorTeskst.Text;
        if (string.IsNullOrWhiteSpace(text))
        {
            await DisplayAlert("Viga", "Palun sisesta tekst", "OK");
            return;
        }
        try
        {
            await TextToSpeech.SpeakAsync(text, options);
        }
        catch (Exception ex)
        {
            await DisplayAlert("TTS viga", ex.Message, "OK");
        }
    }
    public TextPage()
	{
		lblTekstl = new Label()
		{
			Text = "SomeText: ",
			FontSize = 20,
			TextColor = Colors.Black,
			FontFamily = "Lucinda-400"
		};
		editorTeskst = new Editor()
		{
			FontSize = 20,
			Background = new SolidColorBrush(Colors.White),
			TextColor = Colors.Black,
			FontFamily = "Lucinda-400",
			AutoSize = EditorAutoSizeOption.TextChanges,
			Placeholder = "Here is the text",
			PlaceholderColor = Colors.Gray,
			FontAttributes = FontAttributes.Italic
		};
        editorTeskst.TextChanged += EditorTeskst_TextChanged;
        btn = new Button
        {
            Text = "Loe tekst"
        };
        btn.Clicked += Btn_Clicked;
        hsl = new HorizontalStackLayout
		{
			Background = Color.FromRgb(120, 30, 50),
			Children = { lblTekstl, editorTeskst, btn },
			HorizontalOptions = LayoutOptions.Center

		};
		Content = hsl;
	}

    private void EditorTeskst_TextChanged(object? sender, TextChangedEventArgs e)
    {
        lblTekstl.Text = editorTeskst.Text;
    }
}