using System.Collections.Generic;
using HeroDemo.Domain;
using HeroDemo.ViewModel;

namespace HeroDemo.Application
{
    public interface IHeroApplication
    {
       HeroViewModel Get(string id);
       IEnumerable<HeroViewModel> Get();
    }
}