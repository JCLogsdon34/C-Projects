using JCL.BookShelf.Models;
using JCL.BookShelf.UI.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JCL.BookShelf.Tests
{
    [TestFixture]
    public class BookShelfTests
    {

        private const string _filePath = @"C:\Data\BookShelf\Books.txt";
        private const string _originalData = @"C:\Data\BookShelf\BooksTestSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_originalData, _filePath);
        }

        [Test]
        public void AddBook()
        {
            BookRepository repo = new BookRepository(_filePath);

            Book bookywook = new Book();
            bookywook.Title = "Orange Muscle: The Carrot Top Story";
            bookywook.Author = "Anon Ymus";
            bookywook.Publisher = "Carrot Top";
            bookywook.ReleaseDate = 09/31/2018;

            repo.Add(bookywook);

            List<Book> books = repo.List();

            Assert.AreEqual(5, books.Count());

            Book otherbook = books[4];

            Assert.AreEqual("Orange Muscle: The Carrot Top Story", otherbook.Title);
            Assert.AreEqual("Anon Ymus", otherbook.Author);
            Assert.AreEqual("Carrot Top", otherbook.Publisher);
            Assert.AreEqual(bookywook.ReleaseDate, otherbook.ReleaseDate);

        }

        [Test]
        public void ViewBook()
        {
            BookRepository repo = new BookRepository(_filePath);
            List<Book> alsobooks = repo.List();

            Assert.AreEqual(5, alsobooks.Count());

            Book otherbook = alsobooks[4];

            Assert.AreEqual("Orange Muscle: The Carrot Top Story", otherbook.Title);
            Assert.AreEqual("Anon Ymus", otherbook.Author);
            Assert.AreEqual("Carrot Top", otherbook.Publisher);
            Assert.AreEqual(09/31/2018, otherbook.ReleaseDate);
        }

        [Test]
        public void RemoveBook()
        {
            BookRepository repo = new BookRepository(_filePath);
            repo.Delete(0);
            List<Book> alsobooks = repo.List();

            Assert.AreEqual(3, alsobooks.Count());

            Book otherbook = alsobooks[0];

            Assert.AreEqual("Orange Muscle: The Carrot Top Story", otherbook.Title);
            Assert.AreEqual("Anon Ymus", otherbook.Author);
            Assert.AreEqual("Carrot Top", otherbook.Publisher);
            Assert.AreEqual(09 / 31 / 2018, otherbook.ReleaseDate);
        }

        [Test]
        public void EditBook()
        {
            BookRepository repo = new BookRepository(_filePath);
            List<Book> morebooks = repo.List();

            Book editbook = morebooks[0];
            editbook.Publisher = "His mom's basement";
            repo.Edit(editbook, 0);

            Assert.AreEqual(4, morebooks.Count());

            morebooks = repo.List();
            Book otherbook = morebooks[0];

            Assert.AreEqual("Orange Muscle: The Carrot Top Story", otherbook.Title);
            Assert.AreEqual("Anon Ymus", otherbook.Author);
            Assert.AreEqual("His mom's basement", otherbook.Publisher);
            Assert.AreEqual(09/ 31/2018, otherbook.ReleaseDate);
        }

        [Test]
        public void ListAllBooks()
        {
            BookRepository repo = new BookRepository(_filePath);
            List<Book> morebooks = repo.List();
            List<Book> booksgalore = repo.List();

            Assert.AreEqual(booksgalore.Count(), morebooks.Count());

            morebooks = repo.List();
            Book otherbook = morebooks[0];

            Assert.AreEqual(booksgalore[0].Title.Length, morebooks[0].Title.Length);
            Assert.AreEqual(booksgalore[2].ReleaseDate.ToString().Length, morebooks[2].ReleaseDate.ToString().Length);
            Assert.AreEqual(booksgalore[1].Publisher.Length, morebooks[1].Publisher.Length);
            Assert.AreEqual(booksgalore[4].Author.Length, morebooks[4].Author.Length);
        }

    }
}
