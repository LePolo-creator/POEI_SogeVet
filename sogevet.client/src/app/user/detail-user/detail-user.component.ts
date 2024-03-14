import { Component, OnInit } from '@angular/core';
import { Profile } from '../model/profile';
import { ProfileService } from '../services/profile.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-list-profile',
  templateUrl: './list-profile.component.html',
  styleUrls: ['./list-profile.component.css']
})
export class ListProfileComponent implements OnInit {
  constructor(private profileService: ProfileService) { }
  user!: user
  profilSubscription!: Subscription;
  userId: number = 0

  ngOnInit(): void {
    this.getUserDetails();
    this.userId = 3;
    //this.userId = Number(localStorage.getItem('userId').userId);


    this.profileService.getUserById(this.userId)
      .subscribe((user: Profile) => {
        this.user = user;

      })
  }




}
