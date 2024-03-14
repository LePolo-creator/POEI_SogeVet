import { Component, OnInit } from '@angular/core';
import { User } from '../model/user';
import { Subscription } from 'rxjs';
import { UserService } from '../user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styleUrls: ['./user-account.component.css']
})
export class UserAccountComponent implements OnInit{
  user?: User ;
  userSubscription?: Subscription;


  constructor(private userService: UserService,
    private activatedRoute: ActivatedRoute,
  private router : Router) { }
  

    ngOnInit(): void {
      const id = 3;

      this.userService.getUserbyId(id).subscribe(u => {
        this.user = u;
        console.log(this.user);
      });
      
    }

}
