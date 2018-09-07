using MyToDoList.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyToDoList
{
	public partial class MainPage : ContentPage
	{
        ObservableCollection<ToDoItem> toDoItems = new ObservableCollection<ToDoItem>() { };
		public MainPage()
		{
			InitializeComponent();
            MyListView.ItemsSource = GetToDoItems();
        }

        private ObservableCollection<ToDoItem> GetToDoItems()
        {
            toDoItems =  new ObservableCollection<ToDoItem> {
                new ToDoItem { toDoId = 0, toDoTitle = "Test To Do 1", toDoStatus = false },
                new ToDoItem { toDoId = 1, toDoTitle = "Test To Do 2", toDoStatus = true },
                new ToDoItem { toDoId = 2, toDoTitle = "Test To Do 3", toDoStatus = true },
                new ToDoItem { toDoId = 3, toDoTitle = "Test To Do 4", toDoStatus = false }
            };
            return toDoItems;
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedItem = e.SelectedItem as ToDoItem;
            await DisplayAlert(selectedItem.toDoTitle, "ID is : " + selectedItem.toDoId, selectedItem.toDoStatus.ToString());
            MyListView.SelectedItem = null;
        }

        private void MyListView_Refreshing(object sender, EventArgs e)
        {
            MyListView.ItemsSource = GetToDoItems();
            MyListView.EndRefresh();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var toDoItem = menuItem.CommandParameter as ToDoItem;
            toDoItems.Remove(toDoItem);
        }
    }
}
