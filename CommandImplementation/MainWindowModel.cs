using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CommandImplementation
{
    /// <summary>
    /// Class just to avoid have to implement the Notifypropert twice...
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class MainWindowModel : ViewModelBase
    {
        private string _ClickedText;

        private ICommand _clickMeCommand;

        private ObservableCollection<SomeItem> _itemList;

        public MainWindowModel()
        {
            ItemList = new ObservableCollection<SomeItem> {
                new SomeItem { AnimalId = 1, AnimalName="Cat" },
                new SomeItem { AnimalId = 2, AnimalName = "Dog" },
                new SomeItem { AnimalId = 3, AnimalName = "Bird" },
                new SomeItem { AnimalId = 4, AnimalName = "Duck" },
                new SomeItem { AnimalId = 5, AnimalName = "Another Cat" }
            };
        }

        public string ClickedText
        {
            get { return _ClickedText; }
            set
            {
                _ClickedText = value;
                NotifyPropertyChanged(nameof(ClickedText));
            }
        }

        public ICommand ClickMeCommand
        {
            get
            {
                if (_clickMeCommand == null)
                    _clickMeCommand = new RelayCommand<SomeItem>(DoSomething);
                return _clickMeCommand;
            }
        }

        public ObservableCollection<SomeItem> ItemList
        {
            get { return _itemList; }
            set
            {
                _itemList = value;
                NotifyPropertyChanged(nameof(ItemList));
            }
        }

        private void DoSomething(SomeItem obj)
        {
            //Note that here you can manipulate the "obj" any way you want.
            //This "obj" is excacly that one was clicked

            obj.ClickCount++;
            ClickedText = $"ID: [{obj.AnimalId}] - Animal: [{obj.AnimalName}] {Environment.NewLine} ClickCount:[{obj.ClickCount}]";
        }
    }

    public class SomeItem : ViewModelBase
    {
        private int _animalId;
        public int AnimalId
        {
            get { return _animalId; }
            set
            {
                _animalId = value;
                NotifyPropertyChanged(nameof(AnimalId));
            }
        }

        private int _clickCount;

        public int ClickCount
        {
            get { return _clickCount; }
            set
            {
                _clickCount = value;
                NotifyPropertyChanged(nameof(ClickCount));
            }
        }

        private string _animalName;
        public string AnimalName
        {
            get { return _animalName; }
            set
            {
                _animalName = value;
                NotifyPropertyChanged(nameof(AnimalName));
            }
        }
    }
}