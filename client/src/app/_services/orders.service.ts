import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  baseUrl = environment.apiUrl;
  order: Order;
  constructor(private http: HttpClient) { }

  getOrders(){
    return this.http.get<Order[]>(this.baseUrl + 'orders');
  }
  getOrder(id: string){
    return this.http.get<Order>(this.baseUrl + 'orders/' + id);
  }

  countOrders(){
    return this.http.get<Subscription>(this.baseUrl + 'orders/count');
  }
  updateOrder(id: Number, order: Order){
    return this.http.put(this.baseUrl + 'orders/'+ id, order)
  }
  addOrder(model:any){
    return this.http.post(this.baseUrl + "orders/add", model);
  }
  deleteOrder(id: Number){
    return this.http.delete(this.baseUrl + "orders/delete/" + id);      
  }
}
 