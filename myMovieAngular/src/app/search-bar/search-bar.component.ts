import { Component, OnInit } from '@angular/core';
import MyMovieService from 'src/api/my-movie.service';
import PagedData from 'src/models/pagedData';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {

  constructor(private myMovieService: MyMovieService) { }

  ngOnInit() {
  }
}
