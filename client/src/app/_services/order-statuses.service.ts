import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { OrderStatus } from '../_models/orderStatus';

@Injectable({
  providedIn: 'root'
})
export class OrderStatusesService {
  baseUrl = environment.apiUrl;
  orderStatus: OrderStatus;
  constructor(private http: HttpClient) { }

  getOrderStatuses(){
    return this.http.get<OrderStatus[]>(this.baseUrl + 'orderstatuses');
  }
}
