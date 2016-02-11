import {Component, OnInit} from 'angular2/core';
import {Hero} from './../hero';
import {HeroService} from './../services/hero.service';
import {HeroDetailComponent} from './hero-detail.component';
import {Router} from 'angular2/router';
import 'rxjs/Rx';

@Component({
    selector:'heroes',
    templateUrl:'app/templates/heroes.component.html',
    inputs:['heroes'], 
    styleUrls: ['app/styles/heroes.component.css'], 
})

export class HeroesComponent implements OnInit{
    heroes:Hero[];
    private selectedHero: Hero;
    private errorMessage: string;
    constructor(private _heroService: HeroService, private _router: Router){}
    
    onSelect(hero: Hero) {this.selectedHero = hero; }

    ngOnInit() {
      this._heroService.getHeroes()
      .subscribe(heroes=> this.heroes= heroes);
    }
    
    gotoDetails() { 
      let link = ['HeroDetail', {id: this.selectedHero.id}];
      this._router.navigate(link);
    }
}