import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/_models/customer';
import { CustomersService } from 'src/app/_services/customers.service';
import { OrdersService } from 'src/app/_services/orders.service';

@Component({
  selector: 'app-order-add',
  templateUrl: './order-add.component.html',
  styleUrls: ['./order-add.component.css']
}) 
export class OrderAddComponent implements OnInit {
  model: any = {};
  customers: Customer[];
  constructor(private orderService: OrdersService, private customerService: CustomersService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getCustomers();
  }

  addOrder(){
    this.orderService.addOrder(this.model).subscribe(response => { 
      console.log(response);
      this.toastr.success("Poprawnie dodano zlecenie"); 
    }, error => {
      console.log(error);
      this.toastr.error(error.error); 
    });
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe(customers => {
      this.customers = customers;
    })
  }

}
