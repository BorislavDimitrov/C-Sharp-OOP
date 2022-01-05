using Database;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Database.Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 4)]
        [TestCase(1, 16)]
        [TestCase(1, 15)]
        [TestCase(1, 10)]
        public void ConstructorShouldAddRightAmountOfIntegers(int start, int count)
        {
            int[] numbers = Enumerable.Range(start, count).ToArray();
            Database database = new Database(numbers);
            Assert.AreEqual(count, database.Count);
        }
        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 100)]
        [TestCase(1, 1000)]

        public void MoreThan16IntegersInConstructorShouldThrowOperationExceptionInDatabase(int start, int count)
        {
            int[] numbers = Enumerable.Range(start, count).ToArray();
            Assert.That(() => { Database database = new Database(numbers); } , Throws.InvalidOperationException
                , "Database cannot get more than 16 integers");
        }

        [Test]
        public void TryToAddNewElementIfElementsCountIs16ShouldThrowOperationException()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database databases = new Database(numbers);
            Assert.That(() => { databases.Add(17); }
            ,Throws.InvalidOperationException, "Database cannot add more than 16 integers");
        }

        [Test]
        public void TryToRemoveElementFromEmptyDatabaseShouldThrowOperationException()
        {
            Database databases = new Database();
            Assert.That(() => { databases.Remove(); }
            , Throws.InvalidOperationException, "Cannot remove element from an empty collection");
        }

        [Test]
        public void FetchMethodShouldReturnSameCollectionWithCollectionSetFromConstructor()
        {
            int[] inputArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8);
            int[] result = database.Fetch();
            Assert.That(inputArray, Is.EqualTo(result));
        }

        [Test]
        [TestCase(1, 10)]
        [TestCase(1,3)]
        [TestCase(1,11)]
        public void FetchMethodShouldReturnSameCollectionAfterRemoveMethod(int start , int count)
        {
            int[] numbers = Enumerable.Range(start, count).ToArray();
            Database database = new Database(numbers);
            numbers = numbers.SkipLast(1).ToArray();
            database.Remove();
            CollectionAssert.AreEqual(numbers, database.Fetch());
        }

        [Test]
        [TestCase(1, 11)]
        [TestCase(1, 5)]
        [TestCase(1, 14)]
        public void FetchMethodShouldReturnRightCollectionAfterAddMethod(int start, int count)
        {
            int[] numbers = Enumerable.Range(start, count).ToArray();
            Database database = new Database(numbers);
            database.Add(1);
            database.Add(122);
            List<int> result = new List<int>();
            result = numbers.ToList();
            result.Add(1);
            result.Add(122);
            CollectionAssert.AreEqual(result.ToArray(), database.Fetch());
        }

        [Test]
        [TestCase(1, 11)]
        [TestCase(1, 5)]
        [TestCase(1, 14)]
        public void CountShouldReturnTheRightNumber(int start, int count)
        {
            int[] numbers = Enumerable.Range(start, count).ToArray();
            Database database = new Database(numbers);
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(15)]
        public void AddMethodShouldAddAllGivenNumbers(int repeat)
        {
            Database database = new Database();
            for (int i = 0; i < repeat; i++)
            {
                database.Add(i);
            }
            Assert.AreEqual(repeat, database.Count);
        }
    }
}