import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../_models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  baseUrl = environment.apiUrl;
  customer: Customer;
  serviceCount: number;
  constructor(private http: HttpClient) { }

  getCustomers(){
    return this.http.get<Customer[]>(this.baseUrl + 'customers');
  }
  getCustomer(id: string){
    return this.http.get<Customer>(this.baseUrl + 'customers/' + id);
  }

  countCustomers(){
    return this.http.get<number>(this.baseUrl + 'customers/count');
  }
  updateCustomer(id: Number, customer: Customer){
    return this.http.put(this.baseUrl + 'customers/'+ id, customer)
  }
  addCustomer(model:any){
    return this.http.post(this.baseUrl + "customers/add", model);
  }
  deleteCustomer(id: Number){
    return this.http.delete(this.baseUrl + "customers/delete/" + id);      
  }

  
}
 