import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Book } from './model/book';
import { BookService } from './product-list.component.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnChanges {
  @Input() valores: Array<number> = []
  livros: Array<Book> = [];
  livrosFilter: Array<Book> = [];

  bookService: BookService;
  constructor(bookService: BookService) {
    this.bookService = bookService;
  }
  ngOnChanges() {
    this.getBook();


  }
  ngOnInit(): void {
    //this.getBook();
  }
  getBook(): void {
    this.bookService.getBook().subscribe(data => {
      let vInicial = this.valores[0];
      let vFinal = this.valores[1];
      if (vInicial > 0 && vFinal > 0) {
        this.livros = data.filter(livro => livro.price >= vInicial && livro.price <= vFinal).sort((a,b)=> a.price - b.price);
            
      } else if (vInicial > 0) {
        this.livros = data.filter(livro => livro.price >= vInicial).sort((a,b)=> a.price - b.price);
      } else if (vFinal > 0) {
        this.livros = data.filter(livro => livro.price <= vFinal).sort((a,b)=> a.price - b.price);
      } else {
        this.livros = data.sort((a,b)=> a.price - b.price);
      }
    });
  }
}
