import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { LoginConnectionComponent } from './login-connection/login-connection.component';
import { LoginRegisterComponent } from './login-register/login-register.component';


@NgModule({
  declarations: [
    LoginConnectionComponent,
    LoginRegisterComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule
  ]
})
export class LoginModule { }
