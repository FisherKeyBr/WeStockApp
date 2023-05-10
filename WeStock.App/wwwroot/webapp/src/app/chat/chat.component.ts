import { Component } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {

  messages: any[] = [
    {
      displayName: 'Gabriel',
      text: 'Hey how are you!'
    },
    {
      displayName: 'John',
      text: 'Im great!'
    }
  ];

  private _hubConnection!: HubConnection;
  private _connectionId!: string;

  constructor() {
    this.createConnection();

    this.startConnection();
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:7291/chat")
      .build();
  }

  private startConnection() {
    this._hubConnection.start().then(() => {
      console.log('CONECTEI!');

      this.registerOnServerEvents();
      this.setConnectionId();
    }).catch((err: any) => console.log('Error while establishing connection :('));

    this._hubConnection.onclose(() => {
      console.log('connection closed')
    });
  }

  private registerOnServerEvents() {
    this._hubConnection.on('SendMessage', (data) => {
      console.log(data);

      //add to list
    });
  }

  private setConnectionId() {
    this._hubConnection.invoke('GetConnectionId', (connectionId:any) => {
      this._connectionId = connectionId;
      console.log(connectionId);
    });
  }
}
