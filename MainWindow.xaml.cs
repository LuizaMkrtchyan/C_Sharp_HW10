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

namespace Wpf_homework
{
    public partial class MainWindow : Window
    {
        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        Person[] people = new Person[20];
        int count = 0;     

        public MainWindow()
        {
            InitializeComponent();
        }


        private void UpdateListBox()
        {
            PersonListBox.Items.Clear();
            foreach (var person in people.Take(count))
            {
                PersonListBox.Items.Add($"{person.Id}: {person.Name}, {person.Age}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (count < 20)
            {
                int id = int.Parse(IdTextBox.Text);
                string name = NameTextBox.Text;
                int age = int.Parse(AgeTextBox.Text);

                people[count] = new Person { Id = id, Name = name, Age = age };
                count++;

                UpdateListBox();
                IdTextBox.Text = "";
                NameTextBox.Text = "";
                AgeTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Storage is full!");
            }
        }

        private void Display(object sender, RoutedEventArgs e)
        {
            PersonListBox.Visibility = Visibility.Visible;
        }

        private void SearchByNameButton_Click(object sender, RoutedEventArgs e)
        {
            string searchName = SearchNameTextBox.Text;
            bool t = false;
            for (int i = 0; i < count; i++)
            {
                if (people[i].Name == searchName)
                {
                    MessageBox.Show($"Found: {people[i].Id}: {people[i].Name}, {people[i].Age}");
                    t = true;
                }
            }
            if (!t)
            {
                MessageBox.Show("Not found!");
            }
        }

        private void SearchByAgeButton_Click(object sender, RoutedEventArgs e)
        {
            int searchAge = int.Parse(SearchAgeTextBox.Text);
            bool t = false;
            for (int i = 0; i < count; i++)
            {
                if (people[i].Age == searchAge)
                {
                    MessageBox.Show($"Found: {people[i].Id}: {people[i].Name}, {people[i].Age}");
                    t = true;
                }
            }
            if (!t)
            {
                MessageBox.Show("Not found!");
            }
        }
        private void SortByNameButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    if (people[j].Name.CompareTo(people[j + 1].Name) > 0)
                    {
                        Person ob = people[j];
                        people[j] = people[j + 1];
                        people[j + 1] = ob;
                    }
                }
            }
            UpdateListBox();
        }

        private void SortByAgeButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    if (people[j].Age.CompareTo(people[j + 1].Age) > 0)
                    {
                        Person ob = people[j];
                        people[j] = people[j + 1];
                        people[j + 1] = ob;
                    }
                }
            }
            UpdateListBox();
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            int idToRemove = int.Parse(RemoveIdTextBox.Text);
            for (int i = 0; i < count; i++)
            {
                if (people[i].Id == idToRemove)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        people[j] = people[j + 1];
                    }
                    count--;
                    UpdateListBox();
                    return;
                }
            }
            MessageBox.Show("Record with given ID not found!");
        }

    }
}
