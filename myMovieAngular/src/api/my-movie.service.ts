import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import Rating from 'src/models/rating';
import PagedData from 'src/models/pagedData';

@Injectable({
  providedIn: 'root'
})
export default class MyMovieService {
  public API = 'http://localhost:8080/api';
  public mymovies_api = `${this.API}/`;

  constructor(private http: HttpClient) { }

  authorize(username: string, password: string) {
    return this.http.get(this.mymovies_api + "token?username=" + username + "&password=" + password);
  }

  getTopMovies() {
    var token = JSON.parse(localStorage.getItem('currentUser')).token;
    const  headers = new  HttpHeaders().set("Authorization", "Bearer " + token);
    return this.http.get(this.mymovies_api + "Movies/GetTop10Movies/", {headers});
  }

  getTopTvShows() {
    var token = JSON.parse(localStorage.getItem('currentUser')).token;
    const  headers = new  HttpHeaders().set("Authorization", "Bearer " + token);
    return this.http.get(this.mymovies_api + "Movies/GetTop10TvShows/", {headers});
  }

  getAllMovies() {
    var token = JSON.parse(localStorage.getItem('currentUser')).token;
    const  headers = new  HttpHeaders().set("Authorization", "Bearer " + token);
    return this.http.get(this.mymovies_api + "movies/", {headers});
  }

  searchMovies(searchText: string, pageNumber: number) {
    var token = JSON.parse(localStorage.getItem('currentUser')).token;
    const  headers = new  HttpHeaders().set("Authorization", "Bearer " + token);
    return this.http.get(this.mymovies_api + "movies/SearchMovies/" + searchText + "/" + pageNumber + "/" + 10, {headers});
  }

  rateMovie(rating: Rating) {
    var token = JSON.parse(localStorage.getItem('currentUser')).token;
    const  headers = new  HttpHeaders().set("Authorization", "Bearer " + token);
    return this.http.post<Rating>(this.mymovies_api + "Ratings/", rating, {headers});
  }

  getAverageRating(movieId: number) {
    var token = JSON.parse(localStorage.getItem('currentUser')).token;
    const  headers = new  HttpHeaders().set("Authorization", "Bearer " + token);
    return this.http.get(this.mymovies_api + "movies/GetAverageRating/" + movieId, {headers});
  }
}