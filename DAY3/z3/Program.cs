using System;
using System.Linq;
using System.Collections.Generic;


abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    protected Book(string title, string author, double price, int stockQuantity)
    {
        Title = title;
        Author = author;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public override string ToString()
    {
        return $"{Title} – {Author} ({Price:C}, {StockQuantity} шт.)";
    }
}


sealed class FictionBook : Book
{
    public FictionBook(string title, string author, double price, int stockQuantity)
        : base(title, author, price, stockQuantity) { }
}


sealed class NonFictionBook : Book
{
    public NonFictionBook(string title, string author, double price, int stockQuantity)
        : base(title, author, price, stockQuantity) { }
}


class Bookstore
{
    private Book[] books;

    public Bookstore(Book[] books)
    {
        this.books = books;
    }

    
    public Book GetCheapestBook()
    {
        return books.OrderBy(b => b.Price).FirstOrDefault();
    }

   
    public List<Book> GetBooksInStock()
    {
        return books.Where(b => b.StockQuantity > 0).ToList();
    }

    public void PrintAllBooks()
    {
        Console.WriteLine("Все книги в магазине:");
        foreach (var book in books)
            Console.WriteLine($"  {book}");
    }
}


class Program
{
    static void Main()
    {
      
        Book[] books = new Book[]
        {
            new FictionBook("Война и мир", "Лев Толстой", 15.99, 5),
            new FictionBook("Преступление и наказание", "Фёдор Достоевский", 12.50, 0),
            new NonFictionBook("Sapiens. Краткая история человечества", "Юваль Ной Харари", 18.75, 3),
            new NonFictionBook("Краткие ответы на большие вопросы", "Стивен Хокинг", 14.20, 0),
            new FictionBook("Мастер и Маргарита", "Михаил Булгаков", 10.99, 7)
        };

        var bookstore = new Bookstore(books);

        bookstore.PrintAllBooks();

       
        var cheapest = bookstore.GetCheapestBook();
        Console.WriteLine($"\nСамая дешёвая книга: {cheapest}");

      
        var inStock = bookstore.GetBooksInStock();
        Console.WriteLine($"\nКниги в наличии ({inStock.Count} шт.):");
        foreach (var book in inStock)
            Console.WriteLine($"  {book}");
    }
}