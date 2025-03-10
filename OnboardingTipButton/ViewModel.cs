using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnboardingTipButton
{
   public class ViewModel : INotifyPropertyChanged
   {
      public ViewModel()
      {
         ToggleOnboardingToolTipsCommand = new RelayCommand( () => IsChecked = !IsChecked );
      }

      private bool _isChecked = false;
      public bool IsChecked
      {
         get => _isChecked;
         set
         {
            if (value != _isChecked)
            {
               _isChecked = value;
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs( nameof( IsChecked)));
            }
         }
      }

      public ICommand ToggleOnboardingToolTipsCommand { get; }

      public event PropertyChangedEventHandler PropertyChanged;
   }
}
