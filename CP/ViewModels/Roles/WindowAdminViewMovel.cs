using CP.Command;
using CP.Other;
using CP.Views;
using CP.Views.Pages;
using System.Windows.Controls;

namespace CP.ViewModels
{
    class WindowAdminViewMovel : NotifyPropertyChanged
    {
        private Page _accountPage;
        private Page _plainsPage;
        private Page _usersPage;
        private Page _reservationsPage;
        private Page _airFlightsPage;
        private Page _aboutProgramPage;
        private Page _currentPage;
        private User _user;
        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private RelayCommand _openAccountPageCommand;
        private RelayCommand _openPlainsPageCommand;
        private RelayCommand _openUsersPageCommand;
        private RelayCommand _openReservPageCommand;
        private RelayCommand _openAirFlightPageCommand;
        private RelayCommand _openAboutProrgamCommand;


        public WindowAdminViewMovel(int id)
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                _user = unitOfWork.UserRepository.Get(id);
            }
            _accountPage = new AccountPage(_user);
            _plainsPage = new PlainsPage();
            _usersPage = new UsersPage();
            _reservationsPage = new ReservationsPage();
            _airFlightsPage = new AirFlightsPage();
            _aboutProgramPage = new AboutProgramPage();
            CurrentPage = _accountPage;
        }

        public RelayCommand OpenAccountPageCommand => _openAccountPageCommand ??
                  (_openAccountPageCommand = new RelayCommand(obj =>
                  {
                      CurrentPage = _accountPage;
                  }));
        public RelayCommand OpenPlainsPageCommand => _openPlainsPageCommand ??
                  (_openPlainsPageCommand = new RelayCommand(obj =>
                  {
                      CurrentPage = _plainsPage;
                  }));
        public RelayCommand OpenUsersPageCommand => _openUsersPageCommand ??
                  (_openUsersPageCommand = new RelayCommand(obj =>
                  {
                      CurrentPage = _usersPage;
                  }));
        public RelayCommand OpenReservPageCommand => _openReservPageCommand ??
                  (_openReservPageCommand = new RelayCommand(obj =>
                  {
                      CurrentPage = _reservationsPage;
                  }));
        public RelayCommand OpenAirFlightPageCommand => _openAirFlightPageCommand ??
                  (_openAirFlightPageCommand = new RelayCommand(obj =>
                  {
                      CurrentPage = _airFlightsPage;
                  }));
        public RelayCommand OpenAboutProgramPageCommand => _openAboutProrgamCommand ??
                  (_openAboutProrgamCommand = new RelayCommand(obj =>
                  {
                      CurrentPage = _aboutProgramPage;
                  }));



    }
}
