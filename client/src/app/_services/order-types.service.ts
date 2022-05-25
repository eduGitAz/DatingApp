import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { OrderType } from '../_models/orderType';

@Injectable({
  providedIn: 'root'
})
export class OrderTypesService {
  baseUrl = environment.apiUrl;
  orderType: OrderType;
  constructor(private http: HttpClient) { }

  getOrderTypes(){
    return this.http.get<OrderType[]>(this.baseUrl + 'ordertypes');
  }
}
