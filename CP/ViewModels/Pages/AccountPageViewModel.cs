using CP.Command;
using CP.Other;
using System;
using CP.Views;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace CP.ViewModels
{
    class AccountPageViewModel : NotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _mail;
        private string _phone;
        private int id;
        private RelayCommand _updateAccountCommand;

        public RelayCommand UpdateAccountCommand => _updateAccountCommand ??
                  (_updateAccountCommand = new RelayCommand(obj => ExexuteUpdateCommand(obj)));
        private void ExexuteUpdateCommand(object obj)
        {
            try
            {
                var values = (object[])obj;
                if (_name != "" || _surname != "" || _mail != "" || Phone != "")
                    using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                    {
                        User user = unitOfWork.UserRepository.Get(id);
                        PasswordBox password = (PasswordBox)values[0];
                        PasswordBox repeatPassword = (PasswordBox)values[1];
                        if (password.Password != "")
                        {
                            MD5 md5 = new MD5CryptoServiceProvider();
                            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(password.Password));
                            string pass = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                            if(pass != user.Password) throw new Exception("Неверный пароль!!!");
                            if (repeatPassword == null) throw new Exception("Новый пароль не указан!!!");
                            if (repeatPassword.Password.Length != 8) throw new Exception("Новый пароль\nнедопустимой длины!!!");
                            checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(repeatPassword.Password));
                            pass = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                            user.Password = pass;
                        }
                        if (unitOfWork.UserRepository.GetAll().Where(a => a.Name == Name).Count() == 1
                            && user.Name != Name)
                            throw new Exception("Такой ник уже существует");
                        user.Name = Name;
                        user.Surname = Surname;
                        user.Mail = Mail;
                        user.Phone_number = Phone;
                        unitOfWork.Save();
                        throw new Exception("Сохранено успешно");
                    }
                else
                {
                    throw new Exception("Поля не могут быть пустыми");
                }
            }
            catch (Exception a)
            {
                Message message = new Message(a.Message);
                message.Show();
            }
        }
        public AccountPageViewModel(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Mail = user.Mail;
            Phone = user.Phone_number;
            id = user.IdUser;
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
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
                OnPropertyChanged("Phone");
            }
        }
    }
}
