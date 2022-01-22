# Projekt-ASP to strona do dzielenia się osiągnieciami w grach. Post o swoim dokonaniu należy stworzyć w odpowiednim achievement, który musi być już wcześniej stworzony,
dodatkowo posty można komentować.
Każdy z 3 obiektów można usuwać po zalogowaniu.
Edytować można posty oraz achievementy.

Konfiguracja przed uruchomieniem:
Ustawić własny "ConnectionString" dla achievementsTable w pliku appsettings.json oraz zmienić nazwę bazy danych albo upewnić się że nie ma takiej na serwrze SQL
W konsoli nugget wpisać "update-database -verbose --context ApplicationDbContext" oraz "update-database -verbose --context AppIdentityDbContext"
(Opcjonalnie) uruchomić testy, aby upewnić się, że wszystko działa tak jak należy
Uruchomić stronę
