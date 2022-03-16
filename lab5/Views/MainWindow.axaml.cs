using Avalonia.Controls;
using lab5.ViewModels;
using Avalonia.Interactivity;

namespace lab5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("openFile").Click += async delegate
            {
                string[]? path = await new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                var context = this.DataContext as MainWindowViewModel;
                if (path == null) context.Path = "";
                else context.Path = string.Join("\\", path);
            };
            this.FindControl<Button>("saveFile").Click += async delegate
            {
                string? path = await new SaveFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                var context = this.DataContext as MainWindowViewModel;
                if (path == null) context.Savepath = "";
                else context.Savepath = path;
            };
            this.FindControl<Button>("setRegex").Click += async delegate
            {
                var window = new SetRegex();
                var context = this.DataContext as MainWindowViewModel;
                window.FindControl<TextBox>("regex").Text = context.Pattern;
                string? str = await window.ShowDialog<string?>((Window)this.VisualRoot);
                context.Pattern = str ?? "";
            };
        }
    }
}
