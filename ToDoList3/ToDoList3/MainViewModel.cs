using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoList3
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //    public MainViewModel()
        //    {
        //        AddCommand = new Command(AddList);
        //        TaskList = new ObservableCollection<Task>(); //кошелек
        //    }

        //    public ObservableCollection<Task> TaskList { get; } // список("массив") из задач    карман

        //    private void AddList(object obj) // положить деньги в кошелек
        //    {
        //        var s = obj.ToString();
        //        TaskList.Add(new Task(s)); // конвертнули деньги в рубли
        //        OnPropertyChanged(); //обновить внешний вид
        //    }


        //    public ICommand AddCommand { get; }
        //    public event PropertyChangedEventHandler PropertyChanged;

        //    [NotifyPropertyChangedInvocator]
        //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Task> TaskList { get; }

        public MainViewModel()
        {
            TaskList = new ObservableCollection<Task>();

            CreateTaskCommand = new Command(CreateTask);
            DeleteTaskCommand = new Command(DeleteTask);
        }

        public ICommand CreateTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreateTask(object name)
        {
            
            TaskList.Add(new Task(name.ToString()));

            OnPropertyChanged();
        }

        private void DeleteTask(object taskObj)
        {
            if (taskObj is Task task)
            {
                TaskList.Remove(task);
            }

            OnPropertyChanged();
        }
    }

    public class Task : BindableObject
    {
        public Task(string name)
        {
            Name = name;
            IsComplite = false;
        }

        public string Name { get; set; }
        public bool IsComplite { get; set; }
    }
}