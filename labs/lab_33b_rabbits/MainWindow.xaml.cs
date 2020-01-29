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
using System.Windows.Shapes; // CALL LIBRARY

namespace lab_33b_rabbits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits = new List<Rabbit>();
        static Rabbit rabbit = new Rabbit();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            var db = new RabbitDatabaseEntities(); // potentially messy

            // CLEAN CODE WRAPPER - BETTER
            using (var db2 = new RabbitDatabaseEntities()) {
                rabbits = db2.Rabbits.ToList();
            }

            // DB2 NOT VALID HERE


        }

        private void ButtonShowRabbits_Click(object sender, RoutedEventArgs e)
        {
            // get list rabbits and show on screen
            // screen      bind to       list of rabbits
            ListBoxRabbits.ItemsSource = rabbits;  // bind listbox to list
            ListBoxRabbits.DisplayMemberPath = "RabbitName";

            //foreach (var rabbit in rabbits)
            //{
            //    ListBoxRabbits.Items.Add(rabbit.RabbitName);
            //}

            
            ListViewRabbits.ItemsSource = rabbits;

        }

        private void ListBoxRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewRabbits.SelectedItem != null)
            {
                // select rabbit by casting to Rabbit type the object select in ListView
                rabbit = (Rabbit)ListViewRabbits.SelectedItem;
                TextBoxRabbitId.Text = rabbit.RabbitId.ToString();
                TextBoxRabbitName.Text = rabbit.RabbitName;
                TextBoxRabbitAge.Text = rabbit.Age.ToString();
            }

        }

        private void ListViewRabbits_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            // must have selected a rabbit
            if (rabbit != null)
            {
                // only open database when needed
                using (var db = new RabbitDatabaseEntities())
                {
                    // find in the database the rabbit which has an ID the same as the selected rabbit
                    var rabbitToDelete = db.Rabbits.Find(rabbit.RabbitId);
                    var result = MessageBox.Show($"Delete Rabbit {rabbit.RabbitId}? Are you sure?",
                        "Rabbit Database",MessageBoxButton.OKCancel);
                    if(result == MessageBoxResult.OK)
                    {
                        db.Rabbits.Remove(rabbitToDelete);
                        db.SaveChanges();
                        ListViewRabbits.ItemsSource = null; // reset to zero
                        rabbits = db.Rabbits.ToList(); // refresh rabbits from database
                        ListViewRabbits.ItemsSource = rabbits; // refresh view
                    }
                }
            }
        }
    }
}
