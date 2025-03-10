using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnboardingTipButton
{
   public class RelayCommand : ICommand
   {
      #region Fields

      internal readonly Action _execute;
      internal readonly Func<bool> _canExecute;

      #endregion // Fields

      #region Constructors

      /// <summary>
      /// Creates a new command that can always execute.
      /// </summary>
      /// <param name="execute">The execution logic.</param>
      public RelayCommand( Action execute )
         : this( execute, DefaultCanExecute )
      {
      }

      /// <summary>
      /// Creates a new command.
      /// </summary>
      /// <param name="execute">The execution logic.</param>
      /// <param name="canExecute">The execution status logic.</param>
      /// <exception cref="ArgumentNullException"><c>execute</c> is null.</exception>
      public RelayCommand( Action execute, Func<bool> canExecute )
      {
         _execute = execute ?? throw new ArgumentNullException( nameof( execute ) );
         _canExecute = canExecute ?? DefaultCanExecute;
      }

      private static bool DefaultCanExecute() => true;

      #endregion // Constructors

      #region ICommand Members

      [DebuggerStepThrough]
      public bool CanExecute( object parameter ) => _canExecute();

      public event EventHandler CanExecuteChanged
      {
         add => CommandManager.RequerySuggested += value;
         remove => CommandManager.RequerySuggested -= value;
      }

      public void Execute( object parameter ) => _execute();

      #endregion // ICommand Members
   }
}
