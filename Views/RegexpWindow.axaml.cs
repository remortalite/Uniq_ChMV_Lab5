using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using tutorial.ViewModels;

namespace tutorial.Views
{
    public partial class RegexpWindow : Window
    {
        public RegexpWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

	    this.FindControl<Button>("ButtonOK").Click += delegate
	    {
		var context = this.DataContext as MainWindowViewModel;
		context!.Pattern = context.PatternStream;
		Close();
	    };

	    this.FindControl<Button>("ButtonCancel").Click += delegate
	    {
		var context = this.DataContext as MainWindowViewModel;
		context!.PatternStream = context.Pattern;
		Close();
	    };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
