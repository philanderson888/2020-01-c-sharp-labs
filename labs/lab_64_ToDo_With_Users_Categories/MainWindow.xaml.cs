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
using lab_63_ToDo_API_Users_Categories.Models;

namespace lab_64_ToDo_With_Users_Categories
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ToDo> todos = new List<ToDo>();
        List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }
        void Initialise()
        {
            using (var db = new ToDoDbContext())
            {
                todos = db.ToDos.ToList();
                users = db.Users.ToList();
            }
            ListViewToDos.ItemsSource = todos;
        }
    }
}
