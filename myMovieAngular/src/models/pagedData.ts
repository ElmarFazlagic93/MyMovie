import Movie from './movie';

export default class PagedData {
    dataObject: Movie[];
    pageSize: number;
    currentPage: number;
    isEnd: boolean;
  }