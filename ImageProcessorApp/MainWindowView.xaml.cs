using ReactiveUI;
using System.Windows;

namespace ImageProcessingApp
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window, IViewFor<MainWindowViewModel>
    {
        public MainWindowView(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            this.OneWayBind(ViewModel, vm => vm.ImageViewModel, v => v.imagePanel.ViewModel);
            this.OneWayBind(ViewModel, vm => vm.ImageFilterMenuViewModel, v => v.imgFilterMenuPanel.ViewModel);
            this.OneWayBind(ViewModel, vm => vm.SelectedFiltersViewModel, v => v.imgFilterSelectedPanel.ViewModel);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(MainWindowViewModel), typeof(MainWindowView), new PropertyMetadata(null));

        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainWindowViewModel)value; }
        }
    }
}
