import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/_models/customer';
import { Order } from 'src/app/_models/order';
import { CustomersService } from 'src/app/_services/customers.service';
import { OrdersService } from 'src/app/_services/orders.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders: Partial<Order[]>;
  searchText;
  customer: Customer;
  customers: Customer[];
  constructor(private orderService: OrdersService, private customerService: CustomersService) { 
 
  }

  ngOnInit(): void {
    this.getOrders();
    
   
  }

  getOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders;
    })
  }


}
