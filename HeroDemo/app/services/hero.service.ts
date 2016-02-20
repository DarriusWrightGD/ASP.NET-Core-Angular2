import {Injectable} from 'angular2/core';
import {Hero} from './../hero';
import {Http, Response, Headers, RequestOptions} from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/Rx';
import {Router} from 'angular2/router';


@Injectable()
export class HeroService {


  private _url = 'http://localhost:5000/api/hero';

  constructor(private _http: Http, private _router: Router) { }

  get(): Observable<Hero[]> {
    return this._http.get(this._url)
      .map(res=> <Hero[]>res.json())
      .catch(this.handleError);
  }

  getById(id: string): Observable<Hero> {
    return this._http.get(`${this._url}/${id}`)
      .map(res=> <Hero>res.json())
      .catch(this.handleError);
  }
  
  post(hero){
    let headers = new Headers({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin' : '*' });
    let options = new RequestOptions({ headers: headers });
    this._http.post(this._url, JSON.stringify(hero), options)
    .subscribe(res=>{this._router.navigate(['Dashboard'])});
  }

  private handleError(error: Response) {
    var errorMessage = 'Server Error';

    if (error.json && error.json().error) {
      errorMessage = error.json().error;
    }

    return Observable.throw(errorMessage);
  }
}