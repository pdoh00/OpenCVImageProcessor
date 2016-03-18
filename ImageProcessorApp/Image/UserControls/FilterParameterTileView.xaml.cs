using ReactiveUI;
using System.Windows;
using System.Windows.Controls;

namespace ImageProcessingApp.Image.UserControls
{
    /// <summary>
    /// Interaction logic for FilterParameterTileView.xaml
    /// </summary>
    public partial class FilterParameterTileView : UserControl, IViewFor<FilterParameterTileViewModel>
    {
        public FilterParameterTileView()
        {
            InitializeComponent();
            this.OneWayBind(ViewModel, vm => vm.Name, v => v.txtName.Text);
            this.OneWayBind(ViewModel, vm => vm.Value, v => v.txtValue.Text);
            this.BindCommand(ViewModel, vm => vm.Increase, v => v.btnIncrease);
            this.BindCommand(ViewModel, vm => vm.Decrease, v => v.btnDecrease);
            //this.OneWayBind(ViewModel, vm => vm.Min, v => v.sliderParamValue.Minimum);
            //this.OneWayBind(ViewModel, vm => vm.Max, v => v.sliderParamValue.Maximum);
            //this.OneWayBind(ViewModel, vm => vm.Step, v => v.sliderParamValue.SmallChange);
            //this.OneWayBind(ViewModel, vm => vm.Step, v => v.sliderParamValue.LargeChange);

            //this.Bind(ViewModel, vm => vm.Value, v => v.sliderParamValue.Value);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(FilterParameterTileViewModel), typeof(FilterParameterTileView), new PropertyMetadata(null));

        public FilterParameterTileViewModel ViewModel
        {
            get { return (FilterParameterTileViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (FilterParameterTileViewModel)value; }
        }
    }
}
