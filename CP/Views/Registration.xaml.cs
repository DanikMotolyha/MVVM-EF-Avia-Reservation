using CP.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CP.Views
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }
    }
}
