using ContactModel = MauiContactsApp.Models.Contact;

namespace MauiContactsApp.Views;

public partial class ContactEditPage : ContentPage
{
    private ContactModel _contact;

    public ContactEditPage(ContactModel? contact = null)
    {
        InitializeComponent();
        _contact = contact ?? new ContactModel();

        if (contact != null)
        {
            NameEntry.Text = contact.Name;
            EmailEntry.Text = contact.Email;
            PhoneEntry.Text = contact.Phone;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _contact.Name = NameEntry.Text;
        _contact.Email = EmailEntry.Text;
        _contact.Phone = PhoneEntry.Text;

        if (string.IsNullOrWhiteSpace(_contact.Name))
        {
            await DisplayAlert("Hiba", "A név mezõ nem lehet üres!", "OK");
            return;
        }

        if (_contact.Id == 0)
            await App.Database.AddContactAsync(_contact);
        else
            await App.Database.UpdateContactAsync(_contact);

        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_contact.Id == 0) return;

        bool confirm = await DisplayAlert("Törlés", "Biztosan törölni szeretné a kapcsolatot?", "Igen", "Mégse");
        if (confirm)
        {
            await App.Database.DeleteContactAsync(_contact);
            await Navigation.PopAsync();
        }
    }
}
