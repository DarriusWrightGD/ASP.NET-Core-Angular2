import {Injectable} from 'angular2/core';
import {Hero} from './../hero';
import {Http, Response} from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/Rx';



@Injectable()
export class HeroService {


  private _url = '/api/hero';

  constructor(private _http: Http) { }

  getHeroes(): Observable<Hero[]> {
    return this._http.get(this._url)
      .map(res=> <Hero[]>res.json())
      .catch(this.handleError);
  }

  getHero(id: string): Observable<Hero> {
    console.log(id)
    return this._http.get(`${this._url}/${id}`)
      .map(res=> <Hero>res.json())
      .catch(this.handleError);
  }

  private handleError(error: Response) {
    var errorMessage = 'Server Error';

    if (error.json && error.json().error) {
      errorMessage = error.json().error;
    }

    return Observable.throw(errorMessage);
  }
}