A PROJEKT A MESTERBEN VAN A PRJEKTBRANCHBEN!!!!!!!!!!!



### MAUI Contacts App - Dokumentáció

**Projekt áttekintés**

* Projekt neve: `MauiContactsApp`
* Cél: .NET 9 MAUI alkalmazás SQLite adatbázissal, teljes CRUD támogatással.
* Fájlstruktúra:

```
MauiContactsApp/
├─ Models/
│   └─ Contact.cs
├─ Data/
│   └─ DatabaseService.cs
├─ Views/
│   ├─ ContactListPage.xaml
│   ├─ ContactListPage.xaml.cs
│   ├─ ContactEditPage.xaml
│   └─ ContactEditPage.xaml.cs
├─ App.xaml
├─ App.xaml.cs
├─ MauiProgram.cs
├─ Resources/
```

---

**Problémák / Hibák .NET 8-9 alatt**

* `Contact` ambiguous reference: `MauiContactsApp.Models.Contact` vs `Microsoft.Maui.ApplicationModel.Communication.Contact`
* `Views` namespace nem található
* Non-nullable property hibák: `Database`, `Name`, `Email`, `Phone`
* `Frame` elavult .NET 9 alatt
* `MainPage` elavult .NET 9 alatt
* Workload warning: net8.0-ios/net8.0-maccatalyst nem támogatott

---

**Megoldások**

* Alias a Contact osztályhoz:

```csharp
using ContactModel = MauiContactsApp.Models.Contact;
```

* Views mappa létrehozása és importálása minden .cs fájlban:

```csharp
using MauiContactsApp.Views;
```

* Non-nullable property inicializálása:

```csharp
public string Name { get; set; } = string.Empty;
public string Email { get; set; } = string.Empty;
public string Phone { get; set; } = string.Empty;
public static DatabaseService Database { get; private set; } = null!;
```

* Frame → Border csere a UI-ban
* MainPage → `CreateWindow()` override

---

**Views felépítés**

* `ContactListPage`:

  * CollectionView a kapcsolatok listázásához
  * Border item template a vizuális megjelenítéshez
  * Navigáció gombok az új kapcsolat felvételére és szerkesztésre
* `ContactEditPage`:

  * Entry mezők: Name, Email, Phone
  * Mentés és Törlés gombok megerősítéssel

---

**CRUD Funkcionalitás**

* **Create**: Új kapcsolat hozzáadása a SQLite adatbázishoz
* **Read**: Kapcsolatok listázása CollectionView-ben
* **Update**: Kapcsolat módosítása a szerkesztő oldalon
* **Delete**: Kapcsolat törlése megerősítés után

---

**.NET 9 specifikus változtatások**

* `GlobalXmlns.cs` az XAML namespace-ek kezelésére
* `Frame` helyett `Border` használata
* Alias a Contact osztályhoz (`ContactModel`)
* `CreateWindow()` override a MainPage helyett

---

**Összegzés / Tanulság**

* .NET 9 MAUI bevezetett új szabályokat: alias, GlobalXmlns, CreateWindow, Border
* Views mappa létfontosságú a namespace hibák elkerüléséhez
* SQLite CRUD teljesen működik
* A projekt könnyen bővíthető további nézetekkel és funkciókkal
