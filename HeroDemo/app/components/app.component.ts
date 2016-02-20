import {Component, OnInit} from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';
import {HTTP_PROVIDERS } from 'angular2/http';
import {HeroDetailComponent} from './hero-detail.component';
import {HeroesComponent} from './heroes.component';
import {DashboardComponent} from './dashboard.component';
import {HeroFormComponent} from './hero-form.component';
import {Hero} from './../hero';
import {HeroService} from './../services/hero.service';

@RouteConfig([
  {
    path: '/heroes',
    name: 'Heroes',
    component: HeroesComponent
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: DashboardComponent,
    useAsDefault: true
  },
  {
    path: '/hero-form',
    name: "HeroForm",
    component: HeroFormComponent
  },
  {
    path: 'detail/:id',
    name: 'HeroDetail',
    component: HeroDetailComponent
  }
])

@Component({
  selector: 'app',
  templateUrl: 'app/templates/app.component.html',
  styleUrls: ['app/styles/app.component.css'],
  directives: [ROUTER_DIRECTIVES],
  providers: [
    ROUTER_PROVIDERS,
    HTTP_PROVIDERS,
    HeroService
  ]
})

export class AppComponent {
  public title = 'Tour of Heroes';
}