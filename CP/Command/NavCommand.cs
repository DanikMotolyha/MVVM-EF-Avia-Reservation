using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CP.Command
{
    class NavCommand
    {
        private RelayCommand _closeWindowCommand;
        private RelayCommand _borderDragCommand;
        public RelayCommand CloseWindowCommand => _closeWindowCommand ??
            (_closeWindowCommand = new RelayCommand(obj => ExexuteCloseWindowCommand(obj)));
     
        public RelayCommand BorderDragCommand => _borderDragCommand ??
            (_borderDragCommand = new RelayCommand(obj => ExexuteBorderDragCommand(obj)));
        private void ExexuteCloseWindowCommand(object obj)
        {
            Application.Current.Shutdown();
        }
        private void ExexuteBorderDragCommand(object obj)
        {
            Window window = (Window)obj;
            window.DragMove();
        }
    }
}
