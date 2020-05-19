using CP.Command;
using CP.Other;
using CP.Views;
using CP.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CP.ViewModels
{
    class WindowUserViewModel : NotifyPropertyChanged
    {
        private Page _accountPage;
        private Page _searchPage;
        private Page _reservPage;
        private Page _currentPage;
        private Page _aboutProgramPage;
        public Page CurrentPage 
        { 
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }




        public WindowUserViewModel()
        {
            _accountPage = new AccountPage(_user);
            _searchPage = new SearchPage();
            _reservPage = new ReservedFlights();
            _aboutProgramPage = new AboutProgramPage();
            CurrentPage = _accountPage;
        }



        private User _user; 
        public WindowUserViewModel(int id)
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                _user = unitOfWork.UserRepository.Get(id);
            }
        }
    }

}
