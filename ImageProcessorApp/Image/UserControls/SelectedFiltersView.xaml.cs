using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageProcessingApp.Image.UserControls
{
    /// <summary>
    /// Interaction logic for SelectedFiltersViewModelView.xaml
    /// </summary>
    public partial class SelectedFiltersView : UserControl, IViewFor<SelectedFiltersViewModel>
    {
        public SelectedFiltersView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.Filters, v => v.lstSelectedItems.ItemsSource);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(SelectedFiltersViewModel), typeof(SelectedFiltersView), new PropertyMetadata(null));

        public SelectedFiltersViewModel ViewModel
        {
            get { return (SelectedFiltersViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (SelectedFiltersViewModel)value; }
        }
    }
}
