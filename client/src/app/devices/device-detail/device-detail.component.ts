import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Device } from 'src/app/_models/device';
import { DevicesService } from 'src/app/_services/devices.service';

@Component({
  selector: 'app-device-detail',
  templateUrl: './device-detail.component.html',
  styleUrls: ['./device-detail.component.css']
})
export class DeviceDetailComponent implements OnInit {
  device: Device;
  constructor(private detailService: DevicesService, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadDevice();
  }

  loadDevice(){
    this.detailService.getDevice(this.route.snapshot.paramMap.get('id')).
    subscribe(device => { this.device = device})
  }

  deleteDevice(){ 
    if(confirm('Czy na pewno chcesz usunąc urządzenie "'+ this.device.name + '"?')){
    this.detailService.deleteDevice(this.device.id).subscribe(() => {
      this.toastr.success('urządzenie zostało usunięte');
    })}
  } 

}
