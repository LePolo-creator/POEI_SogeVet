import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { CartComponent } from './cart/cart.component';
import { AdminComponent } from './admin/admin.component';
import { AppRoutingModule } from './app-routing.module';
import { DetailUserComponent } from './user/detail-user/detail-user.component';
import { CommandUserComponent } from './user/command-user/command-user.component';




@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    CartComponent,
    AdminComponent,
    DetailUserComponent,
    CommandUserComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
