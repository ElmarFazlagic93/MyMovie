import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MoviesComponent } from './movies/movies.component';
import { TopMoviesComponent } from './top-movies/top-movies.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';

const routes: Routes = [
  {
    path: '',
    component: TopMoviesComponent
  },
  {
    path: 'movies',
    component: MoviesComponent
  },
  {
    path: 'movies/:id',
    component: MovieDetailsComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
