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
    class RegistrationViewModel : NotifyPropertyChanged
    {
        private RelayCommand _closeWindowCommand;
        private RelayCommand _registrationCommand;
        private string _name;
        private string _surname;
        private string _mail;
        private string _phone;
        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string SurName 
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged("SurName");
            }
        }
        public string Mail 
        {
            get => _mail;
            set
            {
                _mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public string Phone 
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged("phone");
            }
        }
        public RegistrationViewModel()
        {

        }

        public new RelayCommand CloseWindowCommand => _closeWindowCommand ??
                  (_closeWindowCommand = new RelayCommand(obj =>
                  {
                      Window window = (Window)obj;
                      Authorization authorization  = new Authorization();
                      authorization.Show();
                      window.Close();
                  }));
        public RelayCommand RegistrationCommand => _registrationCommand ??
                  (_registrationCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          var values = (object[])obj;
                          if (_name == "" || _surname == "" || _mail == "" || _phone == "" ||
                          _name == null || _surname == null || _mail == null || _phone == null)
                              throw new Exception("Заполните пустые поля");
                          else
                              using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                              {
                                  if (unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Name == _name) != null)
                                  {
                                      //обработка ошибки --- не найдено имя
                                      throw new Exception("Такой логин \nуже существует");
                                  }
                                  PasswordBox password = (PasswordBox)values[1];
                                  PasswordBox repeatPassword = (PasswordBox)values[2];
                                  if(password.Password.Length != 8) 
                                      throw new Exception("слишком короткий пароль\nдопустимая длина пароля 8!");
                                  if (password.Password != repeatPassword.Password)
                                          throw new Exception("пароли не совпадают");
                                  MD5 md5 = new MD5CryptoServiceProvider();
                                  byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(password.Password));
                                  string pass = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                                  String patternMail = @"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}";
                                  String patternPhone = @"\+\d{3}\(\d{2,4}\)\d{3}\-\d{2}\-\d{2}$";
                                  if (!Regex.IsMatch(_mail, patternMail, RegexOptions.IgnoreCase))
                                      throw new Exception("Неверный формат почты");
                                  if (!Regex.IsMatch(_phone, patternPhone, RegexOptions.IgnoreCase))
                                      throw new Exception("Неверный формат номера\nпример:+375(44)123-45-67");
                                  User user = new User(_name, _surname, pass, _mail, _phone);
                                  unitOfWork.UserRepository.Create(user);
                                  unitOfWork.Save();
                                  Window window = (Window)values[0];
                                  Authorization authorization = new Authorization();
                                  authorization.Show();
                                  window.Close();
                              }
                      }
                      catch (Exception ex)
                      {
                          Message message = new Message(ex.Message);
                          message.Show();
                      }
                  }));

    }
}
