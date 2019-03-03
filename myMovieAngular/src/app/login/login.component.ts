import { Component, OnInit } from '@angular/core';
import MyMovieService from 'src/api/my-movie.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private myMovieService: MyMovieService, private router: Router) { }

  ngOnInit() {
  }

  authorizeUser(){
    this.myMovieService.authorize("authTest", "test123!").subscribe((data: any) => {
        localStorage.setItem('currentUser', JSON.stringify({ token: data}));
        this.router.navigate(['/movies'])
    });
  }

}
