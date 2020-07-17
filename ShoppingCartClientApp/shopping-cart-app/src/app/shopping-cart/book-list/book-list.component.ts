import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Books } from '../dependencies/models/books';
import { ShoppingCartService } from '../dependencies/services/shopping-cart.service';
import { CartItem } from '../dependencies/models/CartItem';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'type', 'author', 'price', 'image', 'add'];
  dataSource: MatTableDataSource<Books>;
  books: Books[] = [];

  cartState = this.shoppingCartService.state;

  value: string = '';

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private shoppingCartService: ShoppingCartService) {
    // Load book products initially.
    this.getAllBooks();
  }

  ngOnInit(): void {

  }

  //Filter class for the search field.
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  // Get all books method.
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

  // Clear the search field.
  clear(){
    this.value='';
    this.getAllBooks();
  }
}
