using CP.Command;
using CP.Other;
using CP.Views;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace CP.ViewModels
{
    class AuthorizationViewModel : NotifyPropertyChanged
    {
        private RelayCommand _registrationCommand;
        private RelayCommand _authorizationCommand;
        private string _name;



        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        
        public RelayCommand RegistrationCommand => _registrationCommand ??
                  (_registrationCommand = new RelayCommand(obj => ExexuteRegistrationCommand(obj)));
        public RelayCommand AuthorizationCommand => _authorizationCommand ??
                  (_authorizationCommand = new RelayCommand(obj => ExexuteAuthorizationCommand(obj)));




        private void ExexuteRegistrationCommand(object obj)
        {
            Window window = (Window)obj;
            Registration registration = new Registration();
            registration.Show();
            window.Close();
        }
        private void ExexuteAuthorizationCommand(object obj)
        {
            try
            {
                var values = (object[])obj;
                PasswordBox password = (PasswordBox)values[1];
                if (_name != null && _name != "" && password.Password != "" && password.Password != "")
                    using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                    {

                        User user = unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Name == _name);
                        if (user == null)
                        {
                            //обработка ошибки --- не найдено имя
                            throw new Exception("Такого логина \nне существует");
                        }
                        MD5 md5 = new MD5CryptoServiceProvider();
                        byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(password.Password));
                        string pass = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                        if (user.Password != pass)
                        {
                            //ошибка 2 пасс не верный 
                            throw new Exception("Пароль неверный");
                        }
                        if (user.IdUser == 0)
                        {
                            WindowAdmin registration = new WindowAdmin(user.IdUser);
                            registration.Show();
                        }
                        else 
                        {
                            WindowUser registration = new WindowUser(user.IdUser);
                            registration.Show();
                        }
                        Window window = (Window)values[0];
                        window.Close();
                    }
                else
                {
                    //введите поля
                    throw new Exception("Не все поля заполнены");
                }
            }
            catch (Exception ex)
            {
                Message message = new Message(ex.Message);
                message.Show();
            }
        }
    }
}
