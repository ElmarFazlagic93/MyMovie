import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

  getTopMovies() {
    return this.http.get(this.mymovies_api + "Movies/GetTop10Movies");
  }

  getTopTvShows() {
    return this.http.get(this.mymovies_api + "Movies/GetTop10TvShows");
  }

  getAllMovies() {
    return this.http.get(this.mymovies_api + "movies/");
  }

  searchMovies(searchText: string, pageNumber: number) {
    return this.http.get(this.mymovies_api + "movies/SearchMovies/" + searchText + "/" + pageNumber + "/" + 10);
  }

  rateMovie(rating: Rating) {
    return this.http.post<Rating>(this.mymovies_api + "Ratings", rating);
  }

  getAverageRating(movieId: number) {
    return this.http.get(this.mymovies_api + "movies/GetAverageRating/" + movieId);
  }
}