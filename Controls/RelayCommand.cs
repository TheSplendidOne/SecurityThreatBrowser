﻿using System;
using System.Windows.Input;

namespace SecurityThreatBrowser
{
    public class RelayCommand : ICommand
    {
        private readonly Action<Object> _executingAction;
        private readonly Predicate<Object> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<Object> executingAction, Predicate<Object> canExecute = null)
        {
            _executingAction = executingAction;
            _canExecute = canExecute;
        }

        public Boolean CanExecute(Object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(Object parameter)
        {
            _executingAction(parameter);
        }
    }
}
