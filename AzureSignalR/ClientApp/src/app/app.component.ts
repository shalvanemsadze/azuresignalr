import { Component } from '@angular/core';
import * as signalR from '@microsoft/signalr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  public constructor() {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl('/notify').build();

    connection.on('broadcastmessage', data => {
      console.log(data);
      alert(data);
    });
    connection.start().catch(error => console.log(error));
    // connection.start()
    //   .then(() => connection.invoke('broadcastmessage', 'Hello').catch(error => console.log(error)));
  }
}


