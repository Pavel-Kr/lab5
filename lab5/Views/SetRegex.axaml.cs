using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using lab5.ViewModels;
using ReactiveUI;

namespace lab5.Views
{
    public partial class SetRegex : Window
    {
        public SetRegex()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("okButton").Click += async delegate
            {
                Close(this.FindControl<TextBox>("regex").Text);
            };
            this.FindControl<Button>("cancelButton").Click += async delegate
            {
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
