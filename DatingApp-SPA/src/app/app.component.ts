import { Component, OnInit } from '@angular/core';
import {AuthService} from './_Services/auth.Service';
import {JwtHelperService} from '@auth0/angular-jwt';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  jwtHelper  = new JwtHelperService();

  /**
   *
   */
  constructor(private authService: AuthService) {
  }

  ngOnInit() {
   const token = localStorage.getItem('token');
   const user: User = JSON.parse(localStorage.getItem('usere'));
   if (token) {
     this.authService.decodedToken = this.jwtHelper.decodeToken(token);
   }
   if (user) {
     this.authService.currentUser = user;
     this.authService.changeMemberPhoto(user.photoUrl);
   }
  }
}
