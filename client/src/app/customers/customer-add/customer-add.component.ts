import { Component, OnInit } from '@angular/core';
import { MembersService } from 'src/app/_services/members.service';
import { ToastrService } from 'ngx-toastr';
import { CustomersService } from 'src/app/_services/customers.service';
@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomerAddComponent implements OnInit {
  model: any = {};
  constructor(private customersService: CustomersService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addCustomer(){ 
    this.customersService.addCustomer(this.model).subscribe(response => { 
      console.log(response);
      this.toastr.success("Poprawnie dodano klienta"); 
    }, error => {
      console.log(error);
      this.toastr.error(error.error); 
    });
  }

}
