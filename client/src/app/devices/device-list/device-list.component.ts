import { Component, OnInit } from '@angular/core';
import { Device } from 'src/app/_models/device';
import { DevicesService } from 'src/app/_services/devices.service';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {
  devices: Partial<Device[]>;
  searchText;
  constructor(private deviceService: DevicesService) { }

  ngOnInit(): void {
    this.getDevices();
  }
  getDevices() {
    this.deviceService.getDevices().subscribe(devices => {
      this.devices = devices;
    })
  }
}
