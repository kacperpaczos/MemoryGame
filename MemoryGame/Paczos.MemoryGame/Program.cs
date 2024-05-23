using Paczos.MemoryGame.DAO;
using Paczos.MemoryGame.DAO.DO;
using Paczos.MemoryGame.DAO.Entities;
using Paczos.MemoryGame.INTERFACES.Entities;

namespace Paczos.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           // Tworzenie kontekstu bazy danych
            using (var context = new DAOContext())
            {
                // Tworzenie repozytorium użytkowników
                var userRepository = new UserRepository(context);

                // Tworzenie nowego użytkownika
                User newUserEntity = new User
                {
                    Nick = "NewUser",
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    CreationDate = DateTime.Now
                };
                IUser newUser = (IUser)newUserEntity; // Jawne rzutowanie

                // Dodawanie użytkownika do bazy danych
                var createdUser = userRepository.Create(newUser);
                Console.WriteLine($"Utworzono użytkownika: {createdUser.Nick}");

                // Odczytywanie użytkownika z bazy danych
                var readUser = userRepository.Read(createdUser.Id);
                if (readUser != null)
                {
                    Console.WriteLine($"Odczytano użytkownika: {readUser.Nick}");
                }

                // Aktualizacja danych użytkownika
                readUser.Nick = "UpdatedUser";
                var updatedUser = userRepository.Update(readUser);
                if (updatedUser != null)
                {
                    Console.WriteLine($"Zaktualizowano użytkownika: {updatedUser.Nick}");
                }

                // Usuwanie użytkownika z bazy danych
                bool isDeleted = userRepository.Delete(updatedUser.Id);
                if (isDeleted)
                {
                    Console.WriteLine("Usunięto użytkownika.");
                }

                // Odczytywanie wszystkich użytkowników
                var users = userRepository.ReadAll();
                foreach (var user in users)
                {
                    Console.WriteLine($"Użytkownik: {user.Nick}");
                }

                userRepository.TestUsers();
                // Uruchomienie ReadData na contextcie z UserRepository
                ReadData(userRepository);
            }
        }

        static void ReadData(UserRepository userRepository)
        {
            var users = userRepository.ReadAll();
            foreach (var user in users)
            {
                Console.WriteLine($"Nick: {user.Nick}, Imię: {user.FirstName}, Nazwisko: {user.LastName}, Data utworzenia: {user.CreationDate}");
            }
        }
    }
}
