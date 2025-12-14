using MauiContactsApp.Data;
using MauiContactsApp.Views;

namespace MauiContactsApp
{
    public partial class App : Application
    {
        public static DatabaseService Database { get; private set; } = null!;

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "contacts.db3");
            Database = new DatabaseService(dbPath);

            MainPage = new NavigationPage(new Views.ContactListPage());
        }
    }
}
