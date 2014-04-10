using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TalkShow.Common;
using TalkShow.Models;

namespace TalkShow.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IMessageService msg;

        private string input;
        public string Input
        {
            get { return input; }
            set
            {
                input = value;
                NotifyChange("Input");
            }
        }

        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                NotifyChange("Items");
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get { return addCommand; }
        }

        public MainViewModel(IMessageService msgSrvc)
        {
            msg = msgSrvc;
            addCommand = new RelayCommand(Add) { IsEnabled = true };
        }

        private void Add()
        {
            if (Items == null)
                Items = new ObservableCollection<Item>();

            Items.Add(new Item() { Name = Input });

            msg.Show("Vai ser adicionado depois que apertar ok motherfucker!");
        }

        private void NotifyChange(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
