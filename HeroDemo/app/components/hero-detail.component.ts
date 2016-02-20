import {Component,OnInit} from 'angular2/core';
import {RouteParams} from 'angular2/router';
import {Hero} from './../hero';
import {HeroService} from './../services/hero.service';

@Component({
    selector: 'hero-detail',
    templateUrl:'app/templates/hero-detail.component.html',
    styleUrls:['app/styles/hero-detail.component.css'],
    inputs:['hero']
})

export class HeroDetailComponent implements OnInit{
    hero:Hero;
    constructor(private _heroService: HeroService,
    private _routeParams: RouteParams ){}
    
    ngOnInit(){
      let id = this._routeParams.get('id');
      this._heroService.getById(id)
        .subscribe(hero => this.hero = hero);
    }
    
    goBack(){
      window.history.back();
    }
}