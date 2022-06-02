import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Device } from '../_models/device';

@Injectable({
  providedIn: 'root'
})
export class DevicesService {
  baseUrl = environment.apiUrl;
  device: Device;
  constructor(private http: HttpClient) { }

  getDevices(){
    return this.http.get<Device[]>(this.baseUrl + 'devices');
  }
  getDevice(id: string){
    return this.http.get<Device>(this.baseUrl + 'devices/' + id);
  }
  countDevices(){
    return this.http.get<number>(this.baseUrl + 'devices/count');
  }
  updateDevice(id: Number, device: Device){
    return this.http.put(this.baseUrl + 'devices/'+ id, device)
  }
  addDevice(model:any){
    return this.http.post(this.baseUrl + "devices/add", model);
  }
  deleteDevice(id: Number){
    return this.http.delete(this.baseUrl + "devices/delete/" + id);      
  }
}
