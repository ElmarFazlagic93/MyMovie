import { Component, OnInit, Input, NgZone, ViewChild } from '@angular/core';
import Movie from 'src/models/movie';
import Rating from 'src/models/rating';
import MyMovieService from 'src/api/my-movie.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

  @Input('rating') rating: number;
  @Input('starCount') starCount: number;
  @Input('color') color: string;
  @Input('movie') movie: Movie;
  @Input('ratingVisible') ratingVisible: boolean;

  constructor(private myMovieService: MyMovieService, private ngZone: NgZone, private sanitizer: DomSanitizer) {
  }

  averageRating: number;

  ngOnInit() {
    this.myMovieService.getAverageRating(this.movie.id).subscribe((data: any) => {
      this.averageRating = data;
    });
  }

  

  setMyStyles() {
    var prec = this.averageRating/5*100 + "%";
    let styles = {
      'width': prec
    };
    return styles;
  }

  onRatingChanged(rating) {
    this.rating = rating;
    var newRating: Rating = {
      rateNumber: rating,
      movieId: this.movie.id,
      movie: null,
      id: 0
    }


    this.myMovieService.rateMovie(newRating).subscribe(data => {
      console.log(data);
      if (data != null) {
        this.getAverage();
      }
    });
  }

  getAverage() {
    this.myMovieService.getAverageRating(this.movie.id).subscribe((data: any) => {
      this.averageRating = data;

      this.ngZone.run(() => {
        this.averageRating = data;
      });
    });
  }

}
