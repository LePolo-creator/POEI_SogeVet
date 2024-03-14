import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListProfileComponent } from './detail-user/detail-user.component';
import { CommandUserComponent } from './command-user/command-user.component';



const routes: Routes = [
  { path: "", component: ListProfileComponent, pathMatch: "full" },
  { path: "/orders", component: CommandUserComponent, pathMatch: "full" }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
