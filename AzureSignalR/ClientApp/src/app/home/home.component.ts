import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {
  }

  public message = '';

  public send() {
    if (this.message) {
      this._http.get<void>(this._baseUrl + 'home/SendMessage/' + this.message).subscribe(result => {
      }, error => console.error(error));
    }
  }
}
