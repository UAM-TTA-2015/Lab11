﻿using System.Linq;
using NUnit.Framework;
using UamTTA.Model;
using UamTTA.Storage;

namespace UamTTA.Tests.Storage
{
    [TestFixture]
    public class InMemoryRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            _sut = new InMemoryRepository<TestModel>();
        }

        private InMemoryRepository<TestModel> _sut;

        private class TestModel : ModelBase
        {
            public int SomeIntAttribute { get; set; }

            public string SomeStringAttribute { get; set; }
        }

        [Test]
        public void FindById_Should_Return_NUll_When_Object_Og_Given_Id_Was_Not_Found()
        {
            var actual = _sut.FindById(4475438);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void GetAll_Returns_All_Items()
        {
            var model1 = new TestModel {Id = null, SomeIntAttribute = 10, SomeStringAttribute = "Bla"};
            var model2 = new TestModel {Id = null, SomeIntAttribute = 12, SomeStringAttribute = "BlaBla"};

            _sut.Persist(model1);
            _sut.Persist(model2);
            var result = _sut.GetAll();

            Assert.That(result.Count(), Is.EqualTo(2));
            CollectionAssert.AllItemsAreUnique(result);
        }

        [Test]
        public void GetAll_Returns_Empty_Collection_When_Repository_Is_Empty()
        {
            var result = _sut.GetAll();

            Assert.That(result.Any(), Is.False);
            //CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void Persist_Should_Return_Copy_Of_Persited_Object_With_Id_Same_Id_Assigned()
        {
            var somePersistedModel = new TestModel {Id = 100, SomeIntAttribute = 10, SomeStringAttribute = "Bla"};

            var result = _sut.Persist(somePersistedModel);

            Assert.That(result, Is.Not.Null);

            Assert.That(result, Is.Not.SameAs(somePersistedModel));
            Assert.That(result.SomeIntAttribute, Is.EqualTo(somePersistedModel.SomeIntAttribute));
            Assert.That(result.SomeStringAttribute, Is.EqualTo(somePersistedModel.SomeStringAttribute));
            Assert.That(result.Id, Is.EqualTo(somePersistedModel.Id));
        }

        [Test]
        public void Persist_Should_Return_Copy_Of_Transient_Object_With_Id_Assigned()
        {
            var someTransientModel = new TestModel {Id = null, SomeIntAttribute = 10, SomeStringAttribute = "Bla"};

            var result = _sut.Persist(someTransientModel);

            Assert.That(result, Is.Not.Null);

            Assert.That(result, Is.Not.SameAs(someTransientModel));
            Assert.That(result.SomeIntAttribute, Is.EqualTo(someTransientModel.SomeIntAttribute));
            Assert.That(result.SomeStringAttribute, Is.EqualTo(someTransientModel.SomeStringAttribute));
            Assert.That(result.Id.HasValue);
        }

        [Test]
        public void Persisted_Data_Should_Be_Accesible_By_Id_Via_FindById()
        {
            var someTransientModel = new TestModel {Id = null, SomeIntAttribute = 10, SomeStringAttribute = "Bla"};

            var persisted = _sut.Persist(someTransientModel);
            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual.Id, Is.EqualTo(persisted.Id));
            Assert.That(actual.SomeIntAttribute, Is.EqualTo(persisted.SomeIntAttribute));
            Assert.That(actual.SomeStringAttribute, Is.EqualTo(persisted.SomeStringAttribute));
        }

        [Test]
        public void Persisted_Object_With_Already_Existing_Id_Should_Evict_Previus_Data()
        {
            var someTransientModel = new TestModel {Id = null, SomeIntAttribute = 10, SomeStringAttribute = "Bla"};

            var persisted = _sut.Persist(someTransientModel);
            var anotherWithSameId = new TestModel
            {
                Id = persisted.Id,
                SomeIntAttribute = 1121210,
                SomeStringAttribute = "xd^grrr"
            };
            _sut.Persist(anotherWithSameId);
            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual.Id, Is.EqualTo(persisted.Id));
            Assert.That(actual.SomeIntAttribute, Is.EqualTo(anotherWithSameId.SomeIntAttribute));
            Assert.That(actual.SomeStringAttribute, Is.EqualTo(anotherWithSameId.SomeStringAttribute));
        }

        [Test]
        public void Remove_Should_Remove_Item_Of_Same_Id_From_Storage()
        {
            var someTransientModel = new TestModel {Id = null, SomeIntAttribute = 10, SomeStringAttribute = "Bla"};

            var persisted = _sut.Persist(someTransientModel);
            var anotherWithSameId = new TestModel {Id = persisted.Id};
            _sut.Remove(anotherWithSameId);

            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Subsequent_Persist_Calls_Objects_Should_Assign_Different_Id()
        {
            var someTransientModel = new TestModel {Id = null, SomeIntAttribute = 10, SomeStringAttribute = "Bla"};

            var result1 = _sut.Persist(someTransientModel);
            var result2 = _sut.Persist(someTransientModel);

            Assert.That(result1, Is.Not.Null);
            Assert.That(result2, Is.Not.Null);

            Assert.That(result1, Is.Not.SameAs(someTransientModel));
            Assert.That(result2, Is.Not.SameAs(someTransientModel));
            Assert.That(result1, Is.Not.SameAs(result2));
            Assert.That(result1.Id, Is.Not.Null);
            Assert.That(result2.Id, Is.Not.Null);
            Assert.That(result1.Id, Is.Not.EqualTo(result2.Id));
        }
    }
}