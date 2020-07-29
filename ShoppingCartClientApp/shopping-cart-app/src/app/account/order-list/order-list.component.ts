import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Orders } from '../dependencies/models/orders';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { AuthenticationService } from '../dependencies/services/authentication.service';
import { UserCredentials } from '../dependencies/models/userCredentials';
import { AccountService } from '../dependencies/services/account.service';
import { MatDialog } from '@angular/material/dialog';
import { OrderDetailsModalComponent } from '../order-details-modal/order-details-modal.component';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  displayedColumns: string[] = ['dateCreated', 'totalAmount', 'status', 'details'];
  dataSource: MatTableDataSource<Orders>;
  orders: Orders[] = [];

  userCredentials: UserCredentials;
  value: string = '';

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;


  constructor(private authenticationService: AuthenticationService, private accountService: AccountService,
                public dialog: MatDialog) { 
    this.getOrders();
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

  //Get Orders method.
  getOrders(){
    let userName = this.authenticationService.getUserName();
    let password = this.authenticationService.getPassword();

    this.userCredentials = {
      userName: userName,
      password: password
    }

    this.accountService.getOrders(this.userCredentials).subscribe(res => {
      this.orders = res;
      this.dataSource = new MatTableDataSource(this.orders);

      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  //Open Modal method for open the OrderDetails component.
  openDetailsModal(rowObject: Orders){
    const dialogRef = this.dialog.open(OrderDetailsModalComponent, {
      width: '800px',
      height: '500px',
      disableClose: true,
      data: {id: rowObject.id, dateCreated: rowObject.dateCreated, totalAmount: rowObject.totalAmount, customer: rowObject.customer}
    });
  }

  //Clear the search field.
  clear(){
    this.value='';
    this.getOrders();
  }

}
