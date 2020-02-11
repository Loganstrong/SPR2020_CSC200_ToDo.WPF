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

        private const string DefaultFilePath = "text.txt";
        private void  OnTodoTaskButtonClick(object sender, RoutedEventArgs e)
        {
            string line =  TodoTaskNameText.Text;
            TodoTask item = new TodoTask();
            item.Description = line;
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string path = "task.txt";
            
            {
                
                    
                    System.IO.FileStream fileStream = System.IO.File.Open(
                    path,
                    System.IO.FileMode.Append,
                    System.IO.FileAccess.Write,
                    System.IO.FileShare.None);
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(fileStream);

                    foreach(var item in TodoTaskListView.Items)
                    {
                        TodoTask iTem = item as TodoTask;
                        writer.WriteLine(iTem.Description);
                    }

                    writer.Close();
                    fileStream.Close();
                
                
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            string path = "task.txt";

            if (System.IO.File.Exists(path))
            {
                
                
                    System.IO.FileStream fileStream = System.IO.File.Open(
                    path,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read,
                    System.IO.FileShare.None);
                    System.IO.StreamReader reader = new System.IO.StreamReader(fileStream);
                    

                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    TodoTask item = new TodoTask();
                    item.Description = line;
                    this.TodoTaskListView.Items.Add(item);
                    
                }

                

                fileStream.Close();
                    reader.Close();
            }
            else
            {
                Console.WriteLine("File not found!");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TodoTaskNameText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void OnMenuFileSaveMenuCLicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            bool? dialogResult = dialog.ShowDialog();
            if (dialogResult == true)
            {
                string filePath = dialog.FileName;

                if (System.IO.File.Exists(DefaultFilePath))
                {
                    MessageBoxResult userSelected;
                    userSelected = System.Windows.MessageBox.Show(
                        messageBoxText: "Overwrite file?",
                        caption: "Confirm", MessageBoxButton.YesNo);

                    if (userSelected == MessageBoxResult.Yes)
                    {
                        System.IO.File.Delete(DefaultFilePath);
                    }
                }
            }
        }



        private void OnMainHelpAboutMenuClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(messageBoxText: "Simple Notepad",
                caption: "About",
                MessageBoxButton.OK,
                icon: MessageBoxImage.Information);
        }
    }
}
