import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import { TabsComponent } from './tabs/tabs.component';
import { TopMoviesComponent } from './top-movies/top-movies.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule, MatTabsModule, MatIconModule, MatToolbarModule, MatSnackBarModule, MatSidenavModule, MatProgressBarModule, MatListModule, MatTooltipModule} from '@angular/material';
import { ToolbarComponent } from './toolbar/toolbar.component';
import {NgbModule, NgbRatingModule} from '@ng-bootstrap/ng-bootstrap';
import { RatingComponent } from './rating/rating.component';
import { MoviesListComponent } from './movies-list/movies-list.component';
import { NgMatSearchBarModule } from 'ng-mat-search-bar';

import { HttpClientModule } from '@angular/common/http';
import { SearchBarComponent } from './search-bar/search-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    TabsComponent,
    TopMoviesComponent,
    MovieDetailsComponent,
    ToolbarComponent,
    RatingComponent,
    MoviesListComponent,
    SearchBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatTabsModule,
    MatIconModule,
    MatToolbarModule,
    NgbModule,
    NgbRatingModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatProgressBarModule,
    MatListModule,
    MatTooltipModule,
    HttpClientModule,
    NgMatSearchBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
