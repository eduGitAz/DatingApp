import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from '../_models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  baseUrl = environment.apiUrl;
  customer: Customer;

  constructor(private http: HttpClient) { }

  getCustomers(){
    return this.http.get<Customer[]>(this.baseUrl + 'customers');
  }
  getCustomer(id: string){
    return this.http.get<Customer>(this.baseUrl + 'customers/' + id);
  }

  getCustomerN(id: Number){
    return this.http.get<Customer>(this.baseUrl + 'customers/' + id);
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
 