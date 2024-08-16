using System.Windows.Input;

public class RelayCommand: ICommand
{
    private Action<object> _execute { get; set; }
    private Predicate<object> _canExecute { get; set; }

    public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
    {
        _execute = executeMethod;
        _canExecute = canExecuteMethod;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }
    public void Execute(object? parameter)
    {
        _execute(parameter);
    }
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}