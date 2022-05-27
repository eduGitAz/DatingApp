import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Refrigerant } from '../_models/refrigerant';

@Injectable({
  providedIn: 'root'
})
export class RefrigerantsService {
  baseUrl = environment.apiUrl;
  refrigerant: Refrigerant;
  constructor(private http: HttpClient) { }

  getRefrigerants(){
    return this.http.get<Refrigerant[]>(this.baseUrl + 'refrigerant');
  }

}
