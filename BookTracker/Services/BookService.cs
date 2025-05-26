using BookTracker.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace BookTracker.Services
{
    public class BookService
    {
        public ObservableCollection<Book> Books { get; private set; } = new();

        public void AddBook(Book book) 
        {
            if (book != null) Books.Add(book);
        }
        public void RemoveBook(Book book) 
        {
            if (Books.Contains(book)) Books.Remove(book);
        }
        public void MarkAsRead(Book book) 
        {
            if (book != null) book.IsRead = true;
        }

        public void SaveToFile(string path)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(Books.ToList(), options);

            File.WriteAllText("books.json", json);
        }
        public void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                List<Book>? loaded = JsonSerializer.Deserialize<List<Book>>(json);
                if (loaded != null)
                {
                    Books.Clear();
                    foreach (var book in loaded)
                    {
                        Books.Add(book);
                    }
                }
            }
        }
    }
}
