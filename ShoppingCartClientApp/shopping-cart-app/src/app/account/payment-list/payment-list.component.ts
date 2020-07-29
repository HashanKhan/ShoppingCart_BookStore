import { Component, OnInit, ViewChild } from '@angular/core';
import { Payments } from '../dependencies/models/payments';
import { MatTableDataSource } from '@angular/material/table';
import { UserCredentials } from '../dependencies/models/userCredentials';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { AuthenticationService } from '../dependencies/services/authentication.service';
import { AccountService } from '../dependencies/services/account.service';

@Component({
  selector: 'app-payment-list',
  templateUrl: './payment-list.component.html',
  styleUrls: ['./payment-list.component.css']
})
export class PaymentListComponent implements OnInit {
  displayedColumns: string[] = ['paymentMethod', 'paymentAmount', 'paymentDate'];
  dataSource: MatTableDataSource<Payments>;
  payments: Payments[] = [];

  userCredentials: UserCredentials;
  value: string = '';

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private authenticationService: AuthenticationService, private accountService: AccountService) { 
    this.getPayments();
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

  //Get payments method.
  getPayments(){
    let userName = this.authenticationService.getUserName();
    let password = this.authenticationService.getPassword();

    this.userCredentials = {
      userName: userName,
      password: password
    }

    this.accountService.getPayments(this.userCredentials).subscribe(res => {
      this.payments = res;
      this.dataSource = new MatTableDataSource(this.payments);

      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  //Clear the search field.
  clear(){
    this.value='';
    this.getPayments();
  }

}
