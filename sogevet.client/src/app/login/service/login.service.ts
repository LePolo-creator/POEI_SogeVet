import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../user/user.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  baseUrl = "https://localhost:7265/api/login";
  

  constructor(private http: HttpClient, private router: Router, userService : UserService
  ) { }

  login(username: string, password: string) {
    const body = JSON.stringify({
      UserName: username,
      Password: password
    })

    const options = {
      headers: new HttpHeaders(
        {
          "content-type": "application/json"
        }
      )
    }


    //console.log(body);
    this.http.post(this.baseUrl, body, options).subscribe(
      {
        next: (response: any) => {
          
          //Récupérer le token renvoyé par l'API serveur
          const authToken = (<any>response);
          //Enregistrer le token dans localstorage
          localStorage.setItem("authSogevet", JSON.stringify(authToken));

          //une fois que l'utilisateur est connecté, je le redirige vers la liste des produits
          this.router.navigate(["/"]);
        },
        error: error => console.log(error),
        complete: () => {
          console.log("Complete");
        }
      }
    )
  }


  register(firstname:string,lastname:string,email:string,password:string,address:string) {
    const body = JSON.stringify({
      FirstName: firstname,
      LastName: lastname,
      Email: email,
      Password: password,
      Address: address,
      IsAdmin: false,
      IsActive:true
    })
    console.log("body de register :" + body)


    const options = {
      headers: new HttpHeaders(
        {
          "content-type": "application/json"
        }
      )
    }

    this.http.post("https://localhost:7265/api/users", body, options).subscribe(
      {
        next: (response: any) => {

          //Récupérer le token renvoyé par l'API serveur
          //const authToken = (<any>response);
          //Enregistrer le token dans localstorage
          //localStorage.setItem("authSogevet", JSON.stringify(authToken));

          //une fois que l'utilisateur est connecté, je le redirige vers la liste des produits
          this.router.navigate(["/"]);
        },
        error: error => console.log(error),
        complete: () => {
          console.log("Complete");
        }
      }
    )

  }


  isAuthenticated(): boolean {
    if (localStorage.getItem("authSogevet") == null) {
      console.log("dans null")
      return false;
    }
    console.log("hors null")
    var tokenAuth = JSON.parse(localStorage.getItem("authSogevet")!).token
    if (tokenAuth == undefined
    )
      return false;
    return true;
  }
}
