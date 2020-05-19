using CP.ViewModels.AdminRegistrations;
using System.Windows;

namespace CP.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AirFlightReg.xaml
    /// </summary>
    public partial class AirFlightReg : Window
    {
        public AirFlightReg(int idFlight)
        {
            InitializeComponent();
            DataContext = new AirFlightsRegViewModel(idFlight);
        }
    }
}
