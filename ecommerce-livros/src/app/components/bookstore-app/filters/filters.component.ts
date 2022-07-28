import { Component, OnInit } from '@angular/core';
import { Book } from '../product-list/model/book';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})

export class FiltersComponent implements OnInit {
  valores: Array<number> = [];
  valorInicial = '';
  valorFinal = '';
  constructor() {
  }
  ngOnInit(): void {
  }
  filter(vInicial: string, vFinal: string): void {
    this.valores = [0, 0];
    if (vInicial) {
      this.valores[0] = Number(vInicial);

    }
    if (vFinal) {
      this.valores[1] = Number(vFinal);
    }
  }
}
