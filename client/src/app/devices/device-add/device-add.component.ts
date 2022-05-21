import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { DevicesService } from 'src/app/_services/devices.service';

@Component({
  selector: 'app-device-add',
  templateUrl: './device-add.component.html',
  styleUrls: ['./device-add.component.css']
})
export class DeviceAddComponent implements OnInit {
  model: any = {};
  constructor(private devicesService: DevicesService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addDevice(){ 
    this.devicesService.addDevice(this.model).subscribe(response => { 
      console.log(response);
      this.toastr.success("Poprawnie dodano urządzenie"); 
    }, error => {
      console.log(error);
      this.toastr.error(error.error); 
    });
  }

}
