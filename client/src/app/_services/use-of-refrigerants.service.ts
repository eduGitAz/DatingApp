import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UseOfRefrigernat } from '../_models/useOfRefrigernat';

@Injectable({
  providedIn: 'root'
})
export class UseOfRefrigerantsService {
  baseUrl = environment.apiUrl;
  useOfRefrigerant: UseOfRefrigernat
  constructor(private http: HttpClient) { }

  getUseOfRefrigernats(){
    return this.http.get<UseOfRefrigernat[]>(this.baseUrl + 'useofrefrigernat');
  }
  
}
