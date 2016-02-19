import {Component} from 'angular2/core';
import {HeroService} from './../services/hero.service';
import {Router} from 'angular2/router';
import {Hero} from './../hero';

@Component({
  selector:'add-hero',
  templateUrl : 'app/templates/add-hero.component.html',
   
})

export class AddHero{
  private hero: Hero;
  constructor(private _heroService:HeroService, private _rotuer: Router){}
  
  addHero(){
    
  }
}