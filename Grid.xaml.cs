namespace AnExample;

public partial class GridPage : ContentPage
{
    Microsoft.Maui.Controls.Grid grid;
    BoxView boxView;
    public GridPage()
    {
        BackgroundColor = Color.FromRgb(120, 30, 50);
        grid = new Microsoft.Maui.Controls.Grid
        {
            BackgroundColor = Color.FromRgb(200, 200, 100),
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }
        };
        for (int rida = 0; rida < 3; rida++)
        {
            for (int veerg = 0; veerg < 3; veerg++)
            {
                boxView = new BoxView
                {
                    Color = Colors.AliceBlue, CornerRadius = 20, Margin = 5
                };
                grid.Add(boxView, veerg, rida);
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += Tap_Tapped;
                boxView.GestureRecognizers.Add(tap);
            }
        }
        Content = grid;
    }

    private void Tap_Tapped(object? sender, TappedEventArgs e)
    {
        var box = (BoxView)sender;
        var r = Microsoft.Maui.Controls.Grid.GetRow(box);
        var v = Microsoft.Maui.Controls.Grid.GetColumn(box);
        DisplayAlert("Info", $"Rida {r+1}, veerg {v+1}", "OK");
    }
}