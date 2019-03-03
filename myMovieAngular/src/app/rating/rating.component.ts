import { Component, OnInit, Input, Output, EventEmitter, ViewEncapsulation } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styles: [],
  encapsulation: ViewEncapsulation.Emulated
})
export class RatingComponent implements OnInit {

  currentRate = 0;
  @Input('rating') private rating: number;
  @Input('starCount') private starCount: number = 5;
  @Input('color') private color: string = "#ccc500";
  @Output() private ratingUpdated = new EventEmitter();
  private snackBarDuration: number = 2000;
  private ratingArr = [];

  constructor(private snackBar: MatSnackBar) {

  }

  ngOnInit() {
    for (let index = 0; index < this.starCount; index++) {
      this.ratingArr.push(index);
    }
  }

  onClick(rating: number) {
    this.snackBar.open('You rated ' + rating + ' / ' + this.starCount, '', {
      duration: this.snackBarDuration
    });
    this.ratingUpdated.emit(rating);
    return false;
  }

  showIcon(index: number) {
    if (this.rating >= index + 1) {
      return 'star_rate';
    } else {
      return 'star_border';
    }
  }

  onRatingChanged(rating) {
    this.rating = rating;
  }

}
export enum StarRatingColor {
  primary = "primary",
  accent = "accent",
  warn = "warn"
}
