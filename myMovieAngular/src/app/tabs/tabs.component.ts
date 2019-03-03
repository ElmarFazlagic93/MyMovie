import { Component, OnInit } from '@angular/core';
import MyMovieService from 'src/api/my-movie.service';
import PagedData from 'src/models/pagedData';
import Movie from 'src/models/movie';

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.scss']
})
export class TabsComponent implements OnInit {

  isSearch: boolean;
  searchResult: Movie[];
  pagedData: PagedData;
  pageNumber: number = 1;
  isEnd: boolean = false;
  token: string;

  constructor(private myMovieService: MyMovieService) { }

  ngOnInit() {
  }
  filterItem(value: string) {
    if (value.length > 1) {
      this.pageNumber = 1;
      this.myMovieService.searchMovies(value, this.pageNumber).subscribe((data: any) => {
        this.pagedData = data;
        this.searchResult = this.pagedData.dataObject;
        this.isSearch = true;
        if (this.searchResult.length === 0) {
          this.isEnd = true;
          return;
        }
        else {
          this.isEnd = data.isEnd
        }
      });
    }
    else if (value.length === 0) {
      this.isSearch = false;
      this.isEnd = false;
      this.pageNumber = 1;
    }
  }

  loadMore(value: string) {
    if (this.pagedData.isEnd) {
      this.isEnd = true;
      return;
    }

    if (value.length > 1) {
      this.pageNumber = this.pageNumber + 1
      this.myMovieService.searchMovies(value, this.pageNumber).subscribe((data: any) => {
        this.pagedData = data;
        this.searchResult = this.searchResult.concat(this.pagedData.dataObject);
        this.isEnd = data.isEnd;
      });
    }
  }
}
