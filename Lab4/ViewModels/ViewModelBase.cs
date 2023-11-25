using System.ComponentModel;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Метод, который упрощает установку значения свойства и вызов события PropertyChanged
    // Пример использования: SetProperty(ref _myProperty, value, nameof(MyProperty));
    protected bool SetProperty<T>(ref T storage, T value, string propertyName)
    {
        if (object.Equals(storage, value)) return false;

        storage = value;
        OnPropertyChanged(propertyName);

        return true;
    }
}
