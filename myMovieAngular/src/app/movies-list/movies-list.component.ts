import { Component, OnInit, Input } from '@angular/core';
import Movie from 'src/models/movie';
import MyMovieService from 'src/api/my-movie.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.scss']
})
export class MoviesListComponent implements OnInit {

  movies: Object;

  constructor(private myMovieService: MyMovieService) { }

  @Input('isMovie') isMovie: boolean;
  @Input('isTop10') isTop10: boolean;
  @Input('searchResult') searchResult: Object;
  @Input('token') token: string;

  ngOnChanges() {
    console.log(this.searchResult)

    if (this.searchResult != null) {
      this.movies = this.searchResult;
      return;
    }
  }

  ngOnInit() {
    if (!this.isTop10) {
      this.myMovieService.getAllMovies().subscribe(data => {
        this.movies = data;
      });

      return;
    }

    if (this.isMovie) {
      this.myMovieService.getTopMovies().subscribe(data => {
        this.movies = data;
      });
    }
    else {
      this.myMovieService.getTopTvShows().subscribe(data => {
        this.movies = data;
      });
    }
  }

}
