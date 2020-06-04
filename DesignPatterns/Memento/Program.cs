using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Author = "Sabahattin Ali", Isbn = "SA-32545", Title = "Kürk Mantolu Madonna" };
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();
            Thread.Sleep(2000);
            book.Author = "Victor Hugo";
            book.Isbn = "VH-3254";
            book.Title = "Sefiller";
            book.ShowBook();
            book.RestoreFromUndo(history.Memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }
    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetLastEdited();
            }
        }
        public string Author { get => _author; set { _author = value; SetLastEdited(); } }
        public string Isbn { get => _isbn; set { _isbn = value; SetLastEdited(); } }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_title, _author, _isbn, _lastEdited);
        }
        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook()
        {
            Console.WriteLine("Title: {0}, Author: {1}, Isbn: {2}, LastEdited: {3}", Title, Author, Isbn, _lastEdited);
        }
    }
    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }
        public Memento(string title, string author, string isbn, DateTime lastEdited)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            LastEdited = lastEdited;
        }
    }
    class CareTaker
    {
        public Memento Memento { get; set; }

    }
}
