import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Company } from '../_models/company';

@Injectable({
  providedIn: 'root'
})
export class CompaniesService {
  baseUrl = environment.apiUrl;
  company: Company;

  constructor(private http: HttpClient) { }
  
  getCompany(){
    return this.http.get<Company>(this.baseUrl + 'companies');
  }

  updateCompany(id: Number, company: Company){
    return this.http.put(this.baseUrl + 'companies/'+ id, company)
  }
}
