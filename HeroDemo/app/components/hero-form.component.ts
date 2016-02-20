import {Component} from 'angular2/core';
import {HeroService} from './../services/hero.service';
import {Router} from 'angular2/router';
import {HeroViewModel} from './../hero-view-model';

@Component({
  selector:'hero-form',
  templateUrl : 'app/templates/hero-form.component.html',
  styleUrls : ['app/styles/hero-form.component.css'],
  inputs : ['hero','formText', 'submit']
})

export class HeroFormComponent{
  public formText = "Add Hero";
  public hero = {name:""};
  public submit = this.addHero;
  constructor(private _heroService:HeroService, private _rotuer: Router){}
  
  addHero(hero){
    this._heroService.post(hero);
  }
}