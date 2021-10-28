using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList3.Annotations;
using Xamarin.Forms;

namespace ToDoList3
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            AddCommand = new Command(AddList);
            DeleteCommand = new Command(DeleteList);
            TaskList = new ObservableCollection<Task>(); //кошелек
        }

        public ObservableCollection<Task> TaskList { get; } // список("массив") из задач    карман

        private void AddList(object obj) // положить деньги в кошелек
        {
            var s = obj.ToString();
            TaskList.Add(new Task(s)); // конвертнули деньги в рубли
            OnPropertyChanged(); //обновить внешний вид
        }

        private void DeleteList(object obj) // убрать деньги из кошелька
        {
            if (obj is Task task)  //если типа таск
            {
                TaskList.Remove(task);  //удали его
            }

            OnPropertyChanged(); //обновить внешний вид
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Task : BindableObject
    {
        public Task(string name)   
        {
            Name = name;
            IsComplete = false;
        }

        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}