import {Component} from 'angular2/core';
import {HeroService} from './../services/hero.service';
import {Router} from 'angular2/router';
import {HeroViewModel} from './../hero-view-model';

@Component({
  selector:'add-hero',
  templateUrl : 'app/templates/hero-form.component.html',
  styleUrls : ['app/styles/hero-form.component.css']
})

export class HeroFormComponent{
  public buttonText = "Add Hero";
  private _hero: HeroViewModel = {name: ""};
  constructor(private _heroService:HeroService, private _rotuer: Router){}
  
  addHero(){
    this._heroService.post(this._hero);
  }
}