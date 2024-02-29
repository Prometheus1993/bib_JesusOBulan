project opdracht voor Object Oriented Programming AP '24

# Book Library Application

## Overview

This C# console application simulates a library system where users can add, remove, search, and view books. The project leverages object-oriented programming principles, with the `Book` and `Library` classes as the core components of the application.

## Class: Book

### Properties

The `Book` class includes the following properties:

- ISBN Number (String): A unique identifier for the book.
- Title (String): The title of the book.
- Author (String): The name of the book's author.
- Genre (Enumeration): The genre of the book, defined by an enum with predefined values such as Fiction, Non-Fiction, Science, etc.
- Publication Year (Integer): The year the book was published.
- Page Count (Integer): The number of pages in the book.
- Language (String): The language in which the book is written.
- Publisher (String): The publisher of the book.

### Validations

The following validations are performed when assigning values to a book's properties:

- The book's title cannot be empty.
- The ISBN number must have a valid format.
- The publication year must be in the past.
- The page count must be positive.

### Constructor

The constructor requires the title, author, and a reference to a `Library` object.

### Methods

- `ShowInfo()`: Displays all the information of the book in a clear manner.
- `DeserializeFromCSV(string csvFile)`: Reads a list of books from a CSV file and adds them to the library.

## Class: Library

### Properties

- Name (String): The name of the library.
- Books (List<Book>): A list of all the books in the library.

### Constructor

Creates a new library with a specified name.

### Methods

- `AddBook(Book book)`: Adds a new book to the library.
- `RemoveBook(string ISBN)`: Removes a book based on the ISBN number.
- `SearchBookByTitleAuthor(string title, string author)`: Searches for a book based on title and author.
- `SearchBookByISBN(string ISBN)`: Searches for a book based on its ISBN number.
- `SearchBooksByAuthor(string author)`: Returns a list of books by a specific author.
- `SearchBooksByProperty()`: Searches for books that meet a specific property value.

## Menu

Upon starting the application, a new `Library` is created first. Then, a menu is displayed allowing the user to perform various actions:

1. Add a book to the library.
2. Add information to a book.
3. Show all information of a book.
4. Search for a book.
5. Remove a book from the library.
6. Show all books in the library.

The application remains in the menu until the user chooses to exit.

## CSV File Format

For deserializing books from a CSV file, the file should include the following columns: ISBN, Title, Author, Genre, Publication Year, Page Count, Language, Publisher.

---

## Developed by:

Jesus O'Bulan
