using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;

namespace tutorial.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

	private void SetRegexpButton_Click(object sender, RoutedEventArgs e)
	{
		var win = new RegexpWindow();
		win.DataContext = this.DataContext;
		win.ShowDialog(this.VisualRoot as Window);
	}
    }
}
