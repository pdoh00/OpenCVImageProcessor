using ReactiveUI;
using System.Windows;
using System.Windows.Controls;

namespace ImageProcessingApp.Image.UserControls
{
    /// <summary>
    /// Interaction logic for ImageFilterSelectionTileView.xaml
    /// </summary>
    public partial class SelectedFilterTileView : UserControl, IViewFor<SelectedFilterTileViewModel>
    {
        public SelectedFilterTileView()
        {
            InitializeComponent();
            this.OneWayBind(ViewModel, vm => vm.Name, v => v.txtFilterName.Text);
            this.OneWayBind(ViewModel, vm => vm.Parameters, v => v.lstFilterParameters.ItemsSource);
            this.BindCommand(ViewModel, vm => vm.Remove, v => v.btnDelete);
            this.BindCommand(ViewModel, vm => vm.MoveDown, v => v.btnMoveUp);
            this.BindCommand(ViewModel, vm => vm.MoveUp, v => v.btnMoveDown);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(SelectedFilterTileViewModel), typeof(SelectedFilterTileView), new PropertyMetadata(null));

        public SelectedFilterTileViewModel ViewModel
        {
            get { return (SelectedFilterTileViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (SelectedFilterTileViewModel)value; }
        }
    }
}
