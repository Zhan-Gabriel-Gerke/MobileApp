using Microsoft.Maui.Controls;


namespace AnExample;

public partial class PulsePage : ContentPage
{

	private const int Rows = 3;
	private const int Columns = 4;
	public Microsoft.Maui.Controls.Grid sourcegrid, targetgrid;
	Dictionary<string, Image> pieceImage = new ();
	Dictionary<(int row, int col), string> CorrectPositions = new ();
	Image image;


	public PulsePage()
	{
		Title = "Pusle leht";
		BackgroundColor = Color.FromRgb(120, 30, 50);
		var mainLayout = new VerticalStackLayout { Spacing = 20, Padding = new Thickness(10) };
		Button newGame = new Button
		{
			Text = "Uus mang"
		};
		newGame.Clicked += NewGame_Clicked;
		Button pickImage = new Button
		{
			Text = "Vali pilt"
		};
		pickImage.Clicked += async (s, e) => await pickImageAsync();
		image = new Image
		{
			Source = "dotnet_bot.png",
			WidthRequest = 200,
			HeightRequest = 200,
		};

        sourcegrid = new Microsoft.Maui.Controls.Grid { BackgroundColor = Colors.Beige };
        targetgrid = new Microsoft.Maui.Controls.Grid { BackgroundColor = Colors.LightGray };


        for (int r = 0; r < Rows; r++)
        {
            sourcegrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            targetgrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
        }

        // Add ColumnDefinitions dynamically
        for (int c = 0; c < Columns; c++)
        {
            sourcegrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            targetgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        mainLayout.Children.Add(new HorizontalStackLayout { Spacing = 40, Children = { newGame, pickImage, image } });

		Content = mainLayout;
	}

	private void InitializePieces()
	{
		pieceImage.Clear();
		CorrectPositions.Clear();
		sourcegrid.Children.Clear();
		targetgrid.Children.Clear();
		for (int r = 0; r < Rows; r++)
		{
			for (int c = 0; c < Columns; c++)
			{
				string id = $"piece_{r}_{c}";
				var img = new Image
				{
					Source = $"{id}.png",
					WidthRequest = 100,
					HeightRequest = 100,
				};
				pieceImage[id] = img; ;
				CorrectPositions[(r, c)]=id;
			}
		}
		for (int r = 0; r< Rows; r++)
		{
			for(int c=0; c< Columns; c++)
			{
				var target = new Border
				{
					BackgroundColor = Colors.White,
					Stroke = Colors.Black,
					StrokeThickness = 2,
					Margin = 5,
					WidthRequest = 100,
					HeightRequest = 100,
				};
			}
		}
	}
	
	private void AddPiedesGasteres(Image img, string id)
	{
		//Drag and drop
		img.GestureRecognizers.Add(new DragGestureRecognizer
		{
			CanDrag = true,
			DragStartingCommand = new Command<DragStartingEventArgs>(args =>
			{
				args.Data.Properties["id"] = id;
			})
		});
		//Tap
		img.GestureRecognizers.Add(new TapGestureRecognizer
		{
			Command = new Command(() =>
			{
				selectedPiece = img;
				img.Opacity = 0.5;
			})
		});
	}

    private void NewGame_Clicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async Task pickImageAsync()
    {
        throw new NotImplementedException();
    }
}