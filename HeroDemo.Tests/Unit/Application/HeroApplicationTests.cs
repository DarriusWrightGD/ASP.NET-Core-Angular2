using Moq;
using Xunit;
using HeroDemo.Repository;
using HeroDemo.Domain;
using HeroDemo.Application;
using MongoDB.Bson;
using System.Collections.Generic;

namespace HeroDemo.Tests.Application
{
    public class HeroApplicationTests
    {
        private HeroApplication _application;
        private Mock<IHeroRepository> _heroRepo = new Mock<IHeroRepository>();
        private readonly string _id = "507c7f79bcf86cd7994f6c0e";
        private readonly Hero _hero;
        public HeroApplicationTests()
        {
            _hero = new Hero {Id= new ObjectId(_id)};
            _heroRepo.Setup(x => x.Get(_id)).Returns(_hero);
            _heroRepo.Setup(x => x.Get()).Returns(new List<Hero>{_hero});
            _application = new HeroApplication(_heroRepo.Object);
        }

        [Fact]
        public void get_by_id_should_call_repository()
        {
            var result = _application.Get(_id);
            Assert.Equal(_id, result.Id);
            _heroRepo.Verify(x=>x.Get(It.Is<string>(id=>id.Equals(_id))),Times.AtMostOnce);
        }
        
        [Fact]
        public void get_should_call_repository()
        {
            var results = _application.Get();
            _heroRepo.Verify(x=>x.Get(),Times.AtMostOnce);
        } 
        
        public void add_should_call_add_on_repository()
        {
            _heroRepo.Verify(x=>x.Add(),Times.AtMostOnce);
        }
        
    }
}