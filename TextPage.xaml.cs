using UIKit;

namespace AnExample;

public partial class TextPage : ContentPage
{
	Label lblTekstl;
	Editor editorTeskst;
	HorizontalStackLayout hsl;
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
		hsl = new HorizontalStackLayout
		{
			Background = Color.FromRgb(120, 30, 50),
			Children = { lblTekstl, editorTeskst },
			HorizontalOptions = LayoutOptions.Center

		};
		Content = hsl;
	}
}