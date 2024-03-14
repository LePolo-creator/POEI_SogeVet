javascript
import { Injectable } from '@angular/core';
import { LoginService } from 'src/app/login/services/login.service';
import { Profile } from '../model/profile';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  baseUrl = "https://localhost:7200/api/Users";
  user!: Profile;
  usersUpdated = new Subject<Profile[]>();

  constructor(private http: HttpClient) { }

  getUserById(userId: number): Observable<Profile> {
    return this.http.get<Profile>(this.baseUrl + "/" + userId);
  }

  editUser(user: Profile) {
    const id = user.id
    this.http.put<Profile>(this.baseUrl + "/" + id, user).subscribe(
      user => {
        this.user = user;
      }
    );
  }
}
