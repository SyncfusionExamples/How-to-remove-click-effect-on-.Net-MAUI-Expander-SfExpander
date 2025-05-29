using Syncfusion.Maui.Expander;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GettingStarted
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _isExpanded;

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleExpanderCommand { get; }

        public MainViewModel()
        {
            ToggleExpanderCommand = new Command(() =>
            {
                IsExpanded = !IsExpanded;
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
