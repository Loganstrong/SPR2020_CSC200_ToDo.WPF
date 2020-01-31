using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.Wpf.Models;
namespace ToDoApp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel();
        }
        private void  OnTodoTaskButtonClick(object sender, RoutedEventArgs e)
        {
            TodoTask item = new TodoTask();
            item.Description = TodoTaskNameText.Text;
            TodoTaskListView.Items.Add(item);

        }
        private void OnRemoveTodoTaskButtonClick(object sender, RoutedEventArgs e)
        {
            //selected index to remove cannot be less than 0 or greater than item count
            int index = TodoTaskListView.SelectedIndex;
            if(index >= 0  && index < TodoTaskListView.Items.Count)
            TodoTaskListView.Items.RemoveAt(TodoTaskListView.SelectedIndex);
            

        }

        private void OnTodoTaskListViewSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            int index = TodoTaskListView.SelectedIndex;
            bool enabled = (index >= 0 && index < TodoTaskListView.Items.Count);
            RemoveTodoTaskButton.IsEnabled = enabled;
        }
        private bool CanRemoveTodoTask(int selectedIndex)
        {
            return (selectedIndex >= 0 && selectedIndex < TodoTaskListView.Items.Count);
        }
        
        
    }
}
