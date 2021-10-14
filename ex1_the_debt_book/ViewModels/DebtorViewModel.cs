using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ex1_the_debt_book.Models;
using ex1_the_debt_book.ViewModels;
using Prism.Commands;
using Prism.Mvvm;

namespace ex1_the_debt_book.ViewModels
{
    public class DebtorViewModel : BindableBase
    {
        
        public Debtor Debtor { get; set; }

        public DebtorViewModel(Debtor debtor)
        {
            Debtor = debtor;

        }


        private ICommand saveNewPersonCommand;

        public ICommand SaveNewPerCommand
        {
            get
            {
                return saveNewPersonCommand ??= new DelegateCommand(SaveNewPerCommandHandler);
            }
        }

        private void SaveNewPerCommandHandler()
        {
            
            
        }

        private ICommand closeWindowCommand;

        public ICommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand ??= new DelegateCommand(CloseWindowCommandHandler);
            }
        }

        private void CloseWindowCommandHandler()
        {
           
        }


    }
}