import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { ItemDetails } from '../dependencies/models/itemDetails';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Orders } from '../dependencies/models/orders';
import { AccountService } from '../dependencies/services/account.service';
import { Customers } from '../dependencies/models/customers';

@Component({
  selector: 'app-order-details-modal',
  templateUrl: './order-details-modal.component.html',
  styleUrls: ['./order-details-modal.component.css']
})
export class OrderDetailsModalComponent implements OnInit {
  displayedColumns: string[] = ['name', 'quantity', 'unitCost'];
  dataSource: MatTableDataSource<ItemDetails>;
  ordersDeatils: ItemDetails[] = [];
  order: Orders;
  customer: Customers;

  value: string = '';

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(@Inject(MAT_DIALOG_DATA) public data: Orders, private accountService: AccountService) {
    this.getOrderDetails();
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

  //Get OrderDetails method.
  getOrderDetails(){
    this.customer = {
      id: this.data.customer.id,
      name: this.data.customer.name,
      phone: this.data.customer.phone,
      email: this.data.customer.email,
      address: this.data.customer.address,
      userName: this.data.customer.userName,
      password: this.data.customer.password,
      loginStatus: this.data.customer.loginStatus,
      registerDate: this.data.customer.registerDate
    };

    this.order = {
      id: this.data.id,
      dateCreated: this.data.dateCreated,
      totalAmount: this.data.totalAmount,
      customer: this.customer
    }

    this.accountService.getOrderDetails(this.order).subscribe(res => {
      this.ordersDeatils = res;
      this.dataSource = new MatTableDataSource(this.ordersDeatils);

      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  //Clear the search field.
  clear(){
    this.value='';
    this.getOrderDetails();
  }

}
