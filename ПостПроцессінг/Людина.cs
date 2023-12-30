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

/*
public class ЛюдинаЯкБиВиПисалиСами : INotifyPropertyChanged
{
	public string ПовнеІмя => $"{Імя} {Прізвище}";
	public string Імя
	{
		get => імя;
		set
		{
			імя = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Імя)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ПовнеІмя)));
		}
	}
	public string Прізвище
	{
		get => прізвище;
		set
		{
			прізвище = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Прізвище)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ПовнеІмя)));
		}
	}

	private string імя;
	private string прізвище;

	/// <inheritdoc />
	public event PropertyChangedEventHandler? PropertyChanged;

}
*/
