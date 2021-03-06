import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/_models/customer';
import { Order } from 'src/app/_models/order';
import { CustomersService } from 'src/app/_services/customers.service';
import { OrdersService } from 'src/app/_services/orders.service';
import { map, catchError, filter } from 'rxjs/operators'



@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders: Partial<Order[]>;
  public searchOrder: String;
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
      this.orders = orders.filter(order => order.appOrderStatus.name === 'Nowe');
    })
  }
  getOnlyRealizedOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders.filter(order => order.appOrderStatus.name === 'Realizowane');
    })
  }
  getOnlyFinishOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders.filter(order => order.appOrderStatus.name === 'Zamknięte');
    })
  }

}
