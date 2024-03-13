import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginConnectionComponent } from './login-connection/login-connection.component';
import { LoginRegisterComponent } from './login-register/login-register.component';

const routes: Routes = [
  { path: "", component: LoginConnectionComponent, pathMatch: "full" },
  { path: "register", component: LoginRegisterComponent, pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
