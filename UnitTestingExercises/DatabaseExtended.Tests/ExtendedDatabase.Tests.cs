
using NUnit.Framework;
using System;

namespace ExtendedDatabase.Test
{
    public class ExtendedDatabaseTests
    {
        [Test]
        [TestCase(16, "Ivan")]
        [TestCase(10, "Stoqn")]
        [TestCase(5, "Borislav")]
        public void ConstructorShouldAddCollectionOfPersonBelowOrEqualTo16(int count, string name)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < count; i++)
            {
                Person newPerson = new Person(i, name + $"{i}");
                people[i] = newPerson;
            }

            ExtendedDatabase database = new ExtendedDatabase(people);
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        [TestCase(17, "Ivan")]
        [TestCase(25, "Stoqn")]
        public void ConstructorShouldntAddMoreThan16Persons(int count, string name)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < count; i++)
            {
                Person newPerson = new Person(i, name + $"{i}");
                people[i] = newPerson;
            }

            Assert.Throws<ArgumentException>(() =>  new ExtendedDatabase(people));
        }

        [Test]
        [TestCase(16, "Ivan")]
        [TestCase(5, "Stoqn")]
        public void ConstructorShouldThrowOperationExceptionDueToRepeatingName(int count, string name)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < count; i++)
            {
                Person newPerson = new Person(i, name );
                people[i] = newPerson;
            }

            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase(people));
        }

        [Test]
        [TestCase(16, "Ivan")]
        [TestCase(5, "Stoqn")]
        public void ConstructorShouldThrowOperationExceptionDueToRepeatingId(int count, string name)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < count; i++)
            {
                Person newPerson = new Person(12, name + $"{i}");
                people[i] = newPerson;
            }

            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase(people));
        }

        [Test]
        [TestCase(16, "Ivan")]
        [TestCase(5, "Stoqn")]
        public void AddShouldAddPeopleUpTo16(int count, string name)
        {
            ExtendedDatabase database = new ExtendedDatabase();
            for (int i = 0; i < count; i++)
            {
                Person newPerson = new Person(i, name + $"{i}");
                database.Add(newPerson);
            }
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void AddShouldThrowOperationExceptionDueToRepeatingName()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person1 = new Person(23, "Borislav");
            database.Add(person1);
            Person person2 = new Person(24, "Borislav");
            Assert.Throws<InvalidOperationException>(() => database.Add(person2));
        }

        [Test]
        [TestCase(16, "Ivan")]
        [TestCase(16, "Stoqn")]
        public void AddShouldThrowOperationExceptionForAddingMoreThan16People(int count, string name)
        {
            ExtendedDatabase database = new ExtendedDatabase();
            for (int i = 0; i < count; i++)
            {
                Person newPerson = new Person(i, name + $"{i}");
                database.Add(newPerson);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(45, "Dimitar")));
        }

        [Test]
        public void AddShouldThrowOperationExceptionDueToRepeatingId()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person1 = new Person(34, "Ivo");
            database.Add(person1);
            Person person2 = new Person(34, "Kiril");
            Assert.Throws<InvalidOperationException>(() => database.Add(person2));
        }

        [Test]
        [TestCase(16, "Ivan", 14)]
        [TestCase(5, "Stoqn", 3)]
        public void RemoveShouldSuccessfullyRemovePeople(int toAdd, string name, int count)
        {
            ExtendedDatabase database = new ExtendedDatabase();
            for (int i = 0; i < toAdd; i++)
            {
                Person newPerson = new Person(i, name + $"{i}");
                database.Add(newPerson);
            }
            database.Remove();
            database.Remove();
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void RemoveShouldThrowOperationExceptionDueToEmptyCollection()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByNameShouldReturnPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person1 = new Person(54, "Ivan");
            database.Add(person1);
            Person newPerson = database.FindByUsername("Ivan");
            Assert.AreEqual(person1.UserName, newPerson.UserName);
        }

        [Test]
        public void FindByNameShouldThrowOperationExceptionDueToNotExistingName()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person1 = new Person(54, "Ivan");
            database.Add(person1);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Kiril"));
            
        }

        [Test]
        public void FindByNameShouldThrowOperationExceptionDueToNullInput()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person1 = new Person(54, "Ivan");
            database.Add(person1);
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));

        }

        [Test]
        public void FindByIdShouldReturnPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person1 = new Person(54, "Ivan");
            database.Add(person1);
            Person newPerson = database.FindById(54);
            Assert.AreEqual(person1.Id, newPerson.Id);
        }

        [Test]
        public void FindByIdShouldThrowOperationExceptionDueToNonExistingId()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person1 = new Person(54, "Ivan");
            database.Add(person1);
            Assert.Throws<InvalidOperationException>(() => database.FindById(43));
        }

        [Test]
        public void FindByIdShouldThrowInvalidArgumentDueToNegativeNumber()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person1 = new Person(54, "Ivan");
            database.Add(person1);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-4));
        }
    }
}