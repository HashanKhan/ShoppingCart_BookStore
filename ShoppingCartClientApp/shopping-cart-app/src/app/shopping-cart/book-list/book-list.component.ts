import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Books } from '../models/books';
import { ShoppingCartService } from '../services/shopping-cart.service';
import { CartItem } from '../models/CartItem';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'type', 'author', 'price', 'stock', 'image', 'add'];
  dataSource: MatTableDataSource<Books>;
  books: Books[] = [];

  cartState = this.shoppingCartService.state;

  value: string = '';

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private shoppingCartService: ShoppingCartService) {
    this.getAllBooks();
  }

  ngOnInit(): void {

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getAllBooks(){
    this.shoppingCartService.getBooks().subscribe((res: any[]) => {
      this.books = res;
      this.dataSource = new MatTableDataSource(this.books);

      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  //Add Items to Cart
  addItemToCart(item: CartItem) {
    this.shoppingCartService.addCartItem(item);
  }

  clear(){
    this.value='';
    this.getAllBooks();
  }
}
