import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  
  public showMenuFooter = true;
  constructor(private http: HttpClient, router: Router) {
    router.events.forEach((event) => {
      if (event instanceof NavigationStart) {
        /*this.showMenuFooter = event.url !== "/login";*/
        this.showMenuFooter != event.url.startsWith("/login");
      }
    });
  }



  title = 'sogevet.client';
}
