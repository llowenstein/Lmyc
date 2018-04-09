import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  items: string[];

  constructor(){
    this.items = [];
    this.items.push("item1");
    this.items.push("item2");
    console.log(this.items);
  }
}
