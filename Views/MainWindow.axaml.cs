using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using tutorial.ViewModels;

namespace tutorial.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("OpenFileButton").Click += async delegate
            {
                var taskPathIn = new OpenFileDialog() { Title = "Open file" }.ShowAsync(this.VisualRoot as Window);

                string[]? pathIn = await taskPathIn;
                var context = this.DataContext as MainWindowViewModel;
                if (pathIn != null)
                    context !.PathIn = string.Join(@"\", pathIn);
            };

            this.FindControl<Button>("SaveFileButton").Click += async delegate
            {
                var taskPathOut =
                    new SaveFileDialog() { Title = "Save file", InitialFileName = "output.txt" }.ShowAsync(
                        this.VisualRoot as Window);

                string? pathOut = await taskPathOut;
                var context = this.DataContext as MainWindowViewModel;
                if (pathOut != null)
                    context !.PathOut = string.Join(@"\", pathOut);
            };
        }

        private void SetRegexpButton_Click(object sender, RoutedEventArgs e)
        {
            var win = new RegexpWindow();
            win.DataContext = this.DataContext;
            win.ShowDialog(this.VisualRoot as Window);
        }
    }
}
