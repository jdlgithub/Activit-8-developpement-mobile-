namespace CampusShare.Frontend.Views.Components;

public partial class EtatErreurView : ContentView
{
    public static readonly BindableProperty MessageProperty =
        BindableProperty.Create(nameof(Message), typeof(string), typeof(EtatErreurView), string.Empty);

    public EtatErreurView()
    {
        InitializeComponent();
    }

    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }
}
