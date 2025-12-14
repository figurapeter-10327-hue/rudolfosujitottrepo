using ContactModel = MauiContactsApp.Models.Contact;

namespace MauiContactsApp.Views;

public partial class ContactListPage : ContentPage
{
    public ContactListPage()
    {
        InitializeComponent();
        LoadContacts();
    }

    private async void LoadContacts()
    {
        ContactsCollectionView.ItemsSource = await App.Database.GetContactsAsync();
    }

    private async void OnAddContactClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ContactEditPage());
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is ContactModel selectedContact)
        {
            await Navigation.PushAsync(new ContactEditPage(selectedContact));
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts(); // Frissítés visszatéréskor
    }
}
