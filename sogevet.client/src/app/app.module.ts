import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { CartComponent } from './cart/cart.component';
import { AdminComponent } from './admin/admin.component';




@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    CartComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
