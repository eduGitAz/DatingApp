import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/_models/customer';
import { Order } from 'src/app/_models/order';
import { CustomersService } from 'src/app/_services/customers.service';
import { OrdersService } from 'src/app/_services/orders.service';
import { map, catchError, filter } from 'rxjs/operators'
import { MatSliderModule } from '@angular/material/slider';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders: Partial<Order[]>;
  searchOrder;
  orderStatus: string;
  constructor(private orderService: OrdersService) { 
 
  }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders;
    })
  }

  getOnlyNewOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders.filter(order => order.appOrderStatus.name === 'NOWE');
    })
  }
  getOnlyRealizedOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders.filter(order => order.appOrderStatus.name === 'REALIZOWANE');
    })
  }
  getOnlyFinishOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders.filter(order => order.appOrderStatus.name === 'ZAMKNIĘTE');
    })
  }








}
