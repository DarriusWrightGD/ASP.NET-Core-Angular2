import {Component, OnInit} from 'angular2/core';
import {HeroService} from './../services/hero.service';
import {Router} from 'angular2/router';
import {Hero} from './../hero';

@Component({
  selector: 'dashboard',
  templateUrl: 'app/templates/dashboard.component.html',
  styleUrls: ['app/styles/dashboard.component.css']
})

export class DashboardComponent implements OnInit {
  private heroes: Hero[] = [];

  constructor(private _heroService: HeroService,
    private _router: Router) { }

  ngOnInit() {
    this._heroService.getHeroes()
    .subscribe(heroes => this.heroes = heroes);
  }

  gotoDetail(hero: Hero) {
	   let link = ['HeroDetail', { id: hero.id }];
    this._router.navigate(link);
  }
}