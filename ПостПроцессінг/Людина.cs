using System.ComponentModel;

namespace ПостПроцессінг;

public class Людина : INotifyPropertyChanged
{
    /// <inheritdoc />
    public event PropertyChangedEventHandler? PropertyChanged;

    public string Імя { get; set; }
    public string Прізвище { get; set; }
    public string ПовнеІмя => $"{Імя} {Прізвище}";
}
