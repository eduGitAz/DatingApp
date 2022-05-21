import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Device } from 'src/app/_models/device';
import { DevicesService } from 'src/app/_services/devices.service';

@Component({
  selector: 'app-device-edit',
  templateUrl: './device-edit.component.html',
  styleUrls: ['./device-edit.component.css']
})
export class DeviceEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  device: Device;
  constructor(private deviceService: DevicesService, private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadDevice();
  }

  loadDevice(){ 
    this.deviceService.getDevice(this.route.snapshot.paramMap.get('id')).
    subscribe(device => { this.device = device}) 
  }

  updateDevice(){
    this.deviceService.updateDevice(this.device.id, this.device).subscribe(() => {
      this.toastr.success('Dane zostały zapisane');
      this.editForm.reset(this.device);
    })

}

}
