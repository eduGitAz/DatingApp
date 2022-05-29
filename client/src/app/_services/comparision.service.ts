import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Comparision } from '../_models/comparision';

@Injectable({
  providedIn: 'root'
})
export class ComparisionService {
  baseUrl = environment.apiUrl;
  comparision: Comparision;
  constructor(private http: HttpClient) { }

  getComparision(){
    return this.http.get<Comparision[]>(this.baseUrl + 'comparision');
  }
}
