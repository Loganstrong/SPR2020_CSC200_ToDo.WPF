using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Wpf.Models;

namespace ToDoApp.Wpf.ViewModels
{
    class TodoTaskViewModel
    {
        public TodoTaskViewModel(TodoTask todoTask)
        {
            this.TodoTask = todoTask;
        }

        public TodoTask TodoTask { get; }

        public ICommand AddCommand { get; }
    }
}
