import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from './model/book';

@Injectable()
export class BookService {

  // Criar serviço de API para os livros

  private url = 'https://localhost:5001/api/bookstore';
  httOptions = {
    Headers: new HttpHeaders({ 'content-type': 'appiclation/json' })
  }
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
  getBook(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url);
  }
}