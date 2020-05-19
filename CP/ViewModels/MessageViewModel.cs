using CP.Command;
using CP.Other;
using CP.Views;
using System.Windows;

namespace CP.ViewModels
{
    class MessageViewModel : NotifyPropertyChanged
    {
        private string _message;
        public string Message
        {
            get => _message;
            set 
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        public MessageViewModel(string message)
        {
            Message = message;
        }
        private RelayCommand _closeWindowCommand;
        public new RelayCommand CloseWindowCommand => _closeWindowCommand ??
                  (_closeWindowCommand = new RelayCommand(obj =>
                  {
                      Window window = (Window)obj;
                      window.Close();
                  }));
    }
}
