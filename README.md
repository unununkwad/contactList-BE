# contactList-BE
Recruitment task

1.	Kompilacja aplikacji - Poniżej przedstawiono kroki niezbędne do uruchomienia aplikacji:
  •	Skopiować projekt z repozytorium githuba. Poniżej link do repozytorium.
    https://github.com/unununkwad/contactList-BE
  •	Wprowadzić do pliku appsettings.json lokalizację swojego lokalnego serwera bazodanowego. Ewentualnie do serwera sieciowego, jednak wtedy trzeba również wprowadzić poświadczenia.
  •	W terminalu „Package manager console” wykonać polecenie update-database
  •	Zmienić sposób otwierania aplikacji na IIS Express i uruchomić
 
2.	Wykorzystane biblioteki
  •	Microsoft.AspNetCore.Authentication.JwtBearer
  •	BCrypt.NET-Next
  •	Microsoft.EntityFrameworkCore
  •	Microsoft.EntityFrameworkCore.SqlServer
  •	Microsoft.EntityFrameworkCore.Tools

3.	Opis poszczególnych klas i metod
  •	DbCon
    Klasa DbCon zawiera tabelę użytkowników, kontaktów oraz tabele słownikowe kategorii i podkategorii. Posiada również metodę OnModelCreating, która wprowadza do bazy przykładowe dane do bazy zaraz po jej stworzeniu. 
   
  •	AuthController
    Klasa AuthController zawiera metodę Login weryfikującą za pomocą BCrypt hasło wprowadzonego użytkownika oraz prywatną metodę GenerateJwtToken generującą za pomocą  JWT token dla zalogowanegu użytkownika. Token ważny jest przez 8 godzin.
   
  •	ContactController
    W klasie ContactController jedyna dostępna bez zalogowania metoda to GetContacts, która pobiera listę wszystkich kontaktów wraz z danymi z tabel słownikowych.
    Metody pobierające dane dostępne po otrzymaniu tokena to GetCategories, GetSubCategories oraz GetEmails. Pierwsze dwa potrzebne są do formularzy, natomiast ostatnia do sprawdzenia, czy wprowadzony email nie występuje już w bazie danych.
    Metody AddContact oraz EditContact sprawdzają najpierw czy trzeba wprowadzić nową podkategorię i zapisują jej identyfikator, a następnie zapisują kontakt.
    Metoda DeleteContact usuwa wybrany kontakt
