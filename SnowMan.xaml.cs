using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace AnExample;

public partial class SnowMan : ContentPage
{
    string SelectedItem;
    Picker picker;
    Slider slider;
    Stepper stepper;
    AbsoluteLayout al;
    Frame head, bucketBody, handle, firstRing, secondRing, eye1, eye2, carrot;
    Button action;
    List<Frame> elements;
    Random rnd;
    public SnowMan()
    {
        InitializeComponent();

        rnd = new Random();

        carrot = new Frame
        {
            BackgroundColor = Colors.Orange,
            CornerRadius = 10,
            HasShadow = false,
            Padding = 20
        };

        eye1 = new Frame
        {
            BackgroundColor = Colors.Green,
            CornerRadius = 100,
            HasShadow = false,
            Padding = 20

        };

        eye2 = new Frame
        {
            BackgroundColor = Colors.Green,
            CornerRadius = 100,
            HasShadow = false,
            Padding = 20

        };

        head = new Frame
        {
            BackgroundColor = Colors.LightGray,
            CornerRadius = 100,
            HasShadow = false,
            Padding = new Thickness(10, 5)
        };

        bucketBody = new Frame
        {
            BackgroundColor = Colors.Gray,
            BorderColor = Colors.Black,
            HasShadow = false,
            CornerRadius = 10,
            Padding = 0
        };

        handle = new Frame
        {
            BackgroundColor = Colors.DarkGray,
            CornerRadius = 5,
            HasShadow = false,
            Padding = 0
        };

        firstRing = new Frame
        {
            BackgroundColor = Colors.LightGray,
            CornerRadius = 100,
            HasShadow = false,
            Padding = new Thickness(10, 5)
        };


        secondRing = new Frame
        {
            BackgroundColor = Colors.LightGray,
            CornerRadius = 100,
            HasShadow = false,
            Padding = new Thickness(10, 5)
        };

        picker = new Picker
        {
            Title = "Choose something",
            FontSize = 20,
            BackgroundColor = Color.FromRgb(100, 100, 100),
            TextColor = Colors.Black
        };
        var options = new List<string> { "Hide", "Show", "Change the color", "Melt", "Dance", "The regular color"};
        foreach (var option in options)
            picker.Items.Add(option);

        picker.SelectedIndexChanged += (s, e) =>
        {
            if (picker.SelectedIndex != -1)
            {
                SelectedItem = picker.Items[picker.SelectedIndex];
            }
        };

        slider = new Slider
        {
            Minimum = 0,
            Maximum = 100,
            Value = 50,
            BackgroundColor = Color.FromRgb(100, 100, 100),
            ThumbColor = Colors.Gray,
            MinimumTrackColor = Colors.White,
            MaximumTrackColor = Colors.Black
        };

        stepper = new Stepper
        {
            Minimum = 0,
            Maximum = 100,
            Increment = 1,
            Value = 20,
            BackgroundColor = Color.FromRgb(100, 100, 100),
            HorizontalOptions = LayoutOptions.Center
        };

        action = new Button
        {
            Text = "Do action",
            FontSize = 12,
            BackgroundColor = Color.FromRgb(100, 100, 100),
            TextColor = Colors.Black,
            FontFamily = "Lucida-400"
        };
        action.Clicked += Btn_Clicked;

        AbsoluteLayout.SetLayoutBounds(carrot, new Rect(0.52, 0.48, 5, 40));
        AbsoluteLayout.SetLayoutFlags(carrot, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(eye1, new Rect(0.6, 0.48, 10, 10));
        AbsoluteLayout.SetLayoutFlags(eye1, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(eye2, new Rect(0.45, 0.48, 10, 10));
        AbsoluteLayout.SetLayoutFlags(eye2, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(action, new Rect(0.9, 0.05, 100, 50));
        AbsoluteLayout.SetLayoutFlags(action, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(head, new Rect(0.5, 0.48, 100, 100));
        AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(bucketBody, new Rect(0.5, 0.40, 100, 80));
        AbsoluteLayout.SetLayoutFlags(bucketBody, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(handle, new Rect(0.5, 0.45, 60, 10));
        AbsoluteLayout.SetLayoutFlags(handle, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(firstRing, new Rect(0.5, 0.65, 150, 150));
        AbsoluteLayout.SetLayoutFlags(firstRing, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(secondRing, new Rect(0.5, 0.9, 200, 200));
        AbsoluteLayout.SetLayoutFlags(secondRing, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.1, 0.05, 200, 50));
        AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(slider, new Rect(0, 1, 300, 50));
        AbsoluteLayout.SetLayoutFlags(slider, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(stepper, new Rect(0.98, 1 ,100, 50));
        AbsoluteLayout.SetLayoutFlags(stepper, AbsoluteLayoutFlags.PositionProportional);

        elements = new List<Frame> { head, firstRing, secondRing, bucketBody, handle, eye2, eye1 };

        al = new AbsoluteLayout
        {
            Children =
            {
                head, firstRing, secondRing, bucketBody, handle, picker, slider, stepper, action, carrot, eye1, eye2
            }
        };
        Content = al;
    }

    private async void Btn_Clicked(object? sender, EventArgs e)
    {
        Button butn = (Button)sender;
        switch (SelectedItem)
        {
            case "Hide":
                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].IsVisible = false;
                }
                break;
            case "Show":
                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].IsVisible = true;
                }
                break;
            case "Change the color":
                var randomColor = Color.FromRgb(
                rnd.Next(256),
                rnd.Next(256),
                rnd.Next(256));
                head.BackgroundColor = randomColor;
                firstRing.BackgroundColor = randomColor;
                secondRing.BackgroundColor = randomColor;
                break;
            case "Melt":

                break;
            case "Dance":

                break;
            case "The regular color":
                head.BackgroundColor = Colors.LightGray;
                firstRing.BackgroundColor = Colors.LightGray;
                secondRing.BackgroundColor = Colors.LightGray;
                break;
            default:
                action.Text = "Chose";
                break;
        }
    }
}
