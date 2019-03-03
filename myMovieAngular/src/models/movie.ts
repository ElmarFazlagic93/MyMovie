import Star from './star';
import Rating from './rating';
import { Type } from '@angular/compiler';
import ShowType from './showType';

export default class Movie {
    id: number;
    name: string;
    description: string;
    releaseDate: Date;
    stars: Array<Star>;
    rating: Array<Rating>;
    type: ShowType;
    image: string;
  }