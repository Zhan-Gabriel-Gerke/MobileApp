using MediaManager;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Media;
using static System.Net.Mime.MediaTypeNames;

namespace AnExample;

public partial class SnowMan : ContentPage
{
    private volatile uint speed = 2000;
    private float opacityForFrames = 1.0F;
    private string SelectedItem;
    private Picker picker;
    private Slider slider;
    private Stepper stepper;
    private AbsoluteLayout al;
    private Frame head, bucketBody, handle, firstRing, secondRing, eye1, eye2, carrot, handL, handR;
    private Label speedLabel;
    private Button action;
    private List<Frame> elements;
    private Random rnd;
    private bool isNight = false;
    private Switch isNightSwith;
    public SnowMan()
    {
        InitializeComponent();
        CrossMediaManager.Current.Init();
        rnd = new Random();
        handL = new Frame
        {
            BackgroundColor = Colors.Black,
            CornerRadius = 10,
            HasShadow = false,
            Padding = 0,
            Opacity = opacityForFrames
        };
        handR = new Frame
        {
            BackgroundColor = Colors.Black,
            CornerRadius = 10,
            HasShadow = false,
            Padding = 0,
            Opacity = opacityForFrames
        };

        carrot = new Frame
        {
            BackgroundColor = Colors.Orange,
            CornerRadius = 10,
            HasShadow = false,
            Padding = 20,
            Opacity = opacityForFrames
        };

        eye1 = new Frame
        {
            BackgroundColor = Colors.Green,
            CornerRadius = 100,
            HasShadow = false,
            Padding = 20,
            Opacity = opacityForFrames

        };

        eye2 = new Frame
        {
            BackgroundColor = Colors.Green,
            CornerRadius = 100,
            HasShadow = false,
            Padding = 20,
            Opacity = opacityForFrames

        };

        head = new Frame
        {
            BackgroundColor = Colors.LightGray,
            CornerRadius = 100,
            HasShadow = false,
            Padding = new Thickness(10, 5),
            Opacity = opacityForFrames
        };

        bucketBody = new Frame
        {
            BackgroundColor = Colors.Gray,
            BorderColor = Colors.Black,
            HasShadow = false,
            CornerRadius = 10,
            Padding = 0,
            Opacity = opacityForFrames
        };

        handle = new Frame
        {
            BackgroundColor = Colors.DarkGray,
            CornerRadius = 5,
            HasShadow = false,
            Padding = 0,
            Opacity = opacityForFrames
        };

        firstRing = new Frame
        {
            BackgroundColor = Colors.LightGray,
            CornerRadius = 100,
            HasShadow = false,
            Padding = new Thickness(10, 5),
            Opacity = opacityForFrames
        };


        secondRing = new Frame
        {
            BackgroundColor = Colors.LightGray,
            CornerRadius = 100,
            HasShadow = false,
            Padding = new Thickness(10, 5),
            Opacity = opacityForFrames
        };

        speedLabel = new Label
        {
            BackgroundColor = Colors.LightGray,
            Padding = new Thickness(10, 5),
            TextColor = Colors.Black,
            FontSize = 18,
            Text = speed.ToString()
        };

        isNightSwith = new Switch
        {
            IsToggled = false
        };

        isNightSwith.Toggled += (s, e) =>
        {
            bool isNight = e.Value; // true if switch is ON
            this.BackgroundImageSource = isNight ? "winter_street.jpg" : "winter_street_day";
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
            Value = 100,
            BackgroundColor = Color.FromRgb(100, 100, 100),
            ThumbColor = Colors.Gray,
            MinimumTrackColor = Colors.White,
            MaximumTrackColor = Colors.Black
        };

        slider.ValueChanged += (s, e) =>
        {
            opacityForFrames = (float)e.NewValue / 100;
            foreach (var el in elements)
            {
                el.Opacity = opacityForFrames;
            }
        };

        stepper = new Stepper
        {
            Minimum = 1000,
            Maximum = 10000,
            Increment = 1000,
            Value = 2000,
            BackgroundColor = Color.FromRgb(100, 100, 100),
            HorizontalOptions = LayoutOptions.Center
        };

        stepper.ValueChanged += (s, e) =>
        {
            speed = (uint)e.NewValue;
            speedLabel.Text = speed.ToString();
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

        //var shapeList = new View[]
        //{
        //    speedLabel, carrot, handR,
        //    handL, eye1, eye2,
        //    action, head, bucketBody,
        //    handle, firstRing, secondRing,
        //    picker, slider, stepper
        //};
        //var x = new double[]
        //{
        //    0.98, 0.52, 0.25, // speedLabel, carrot, handR
        //    0.75, 0.6, 0.45,  // handL, eye1, eye2
        //    0.9, 0.5, 0.5,    // action, head, bucketBody
        //    0.5, 0.5, 0.5,    // handle, firstRing, secondRing
        //    0.1, 0, 0.98      // picker, slider, stepper
        //};

        //var y = new double[]
        //{
        //    0.92, 0.48, 0.6, // speedLabel, carrot, handR
        //    0.6, 0.48, 0.48, // handL, eye1, eye2
        //    0.05, 0.48, 0.40, // action, head, bucketBody
        //    0.45, 0.65, 0.9,  // handle, firstRing, secondRing
        //    0.05, 1, 1        // picker, slider, stepper
        //};

        //var scale = new int[]
        //{
        //    75, 5, 65,   // speedLabel, carrot, handR
        //    65, 10, 10,  // handL, eye1, eye2
        //    100, 100, 100, // action, head, bucketBody
        //    60, 150, 200, // handle, firstRing, secondRing
        //    200, 300, 100 // picker, slider, stepper
        //};

        //var scaleX = new int[]
        //{
        //    40, 40, 8,// speedLabel, carrot, handR
        //    8, 10, 10,// handL, eye1, eye2
        //    50, 100, 80,// action, head, bucketBody
        //    10, 150, 200,// handle, firstRing, secondRing
        //    50, 50,  50//picker, slider, stepper
        //};

        //for (int i = 0; i < shapeList.Length - 1; i++)
        //{
        //    AbsoluteLayout.SetLayoutBounds(shapeList[i], new Rect(x[i], y[i], scale[i], scaleX[i]));
        //    AbsoluteLayout.SetLayoutFlags(shapeList[i], AbsoluteLayoutFlags.PositionProportional);
        //    Console.WriteLine(i);
        //}

        AbsoluteLayout.SetLayoutBounds(isNightSwith, new Rect(0.05, 0.92, 40, 40));
        AbsoluteLayout.SetLayoutFlags(isNightSwith, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(speedLabel, new Rect(0.98, 0.92, 75, 40));
        AbsoluteLayout.SetLayoutFlags(speedLabel, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(carrot, new Rect(0.52, 0.48, 5, 40));
        AbsoluteLayout.SetLayoutFlags(carrot, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(handR, new Rect(0.25, 0.6, 65, 8));
        AbsoluteLayout.SetLayoutFlags(handR, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(handL, new Rect(0.75, 0.6, 65, 8));
        AbsoluteLayout.SetLayoutFlags(handL, AbsoluteLayoutFlags.PositionProportional);

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

        AbsoluteLayout.SetLayoutBounds(stepper, new Rect(0.98, 1, 100, 50));
        AbsoluteLayout.SetLayoutFlags(stepper, AbsoluteLayoutFlags.PositionProportional);

        elements = new List<Frame> { head, firstRing, secondRing, bucketBody,
                                     handle, eye2, eye1, handL, handR, carrot };

        al = new AbsoluteLayout
        {
            Children =
            {
                head, firstRing, secondRing, bucketBody, handle, picker, isNightSwith,
                slider, stepper, action, carrot, eye1, eye2, handL, handR, speedLabel
            }
        };
        Content = al;
    }

    private async void Btn_Clicked_Melt()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].ScaleTo(0.1, speed);
            elements[i].FadeTo(0, speed);
        }
    }
    
    private async void Btn_Clicked_Dance()
    {
        await CrossMediaManager.Current.Play("https://ia800404.us.archive.org/32/items/careless-whisper_202306/CarelessWhisper.mp3");

        List<Task> moveLTasks = new List<Task>();
        for (int i = 0; i < elements.Count; i++)
        {
            var cords = AbsoluteLayout.GetLayoutBounds(elements[i]);
            moveLTasks.Add(elements[i].LayoutTo(new Rect(cords.X - 0.3, cords.Y, cords.Width, cords.Height), 3000));
        }
        
        await Task.WhenAll(moveLTasks);

        List<Task> moveRTasks = new List<Task>();

        for (int i = 0; i < elements.Count; i++)
        {
            var cords = AbsoluteLayout.GetLayoutBounds(elements[i]);
            moveRTasks.Add(elements[i].LayoutTo(new Rect(cords.X + 0.4, cords.Y, cords.Width, cords.Height), 3000));
        }

        await Task.WhenAll(moveRTasks);

        List<Task> tasks = new List<Task>();
        for (int i = 0; i < elements.Count; i++)
        {
            tasks.Add(elements[i].RotateTo(360, 1000));
        }

        await Task.WhenAll(tasks);

        foreach (var el in elements)
        {
            el.Rotation = 0;
        }
    }

    private async void Btn_Clicked(object? sender, EventArgs e)
    {
        Button butn = (Button)sender;
        sound();
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
                Btn_Clicked_Melt();
                break;
            case "Dance":
                Btn_Clicked_Dance();
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
    public async void sound()
    {
        IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();
        SpeechOptions optionsTextToSpeech = new SpeechOptions()
        {
            Pitch = 1.5f,   // 0.0 - 2.0
            Volume = 0.75f, // 0.0 - 1.0
            Locale = locales.FirstOrDefault(l => l.Language == "et-EE")
        };

        try
        {
            await TextToSpeech.SpeakAsync("Christmas is coming", optionsTextToSpeech);
        }
        catch (Exception ex)
        {
            await DisplayAlert("TTS viga", ex.Message, "OK");
        }
    }
}
