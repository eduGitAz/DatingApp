import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/_models/customer';
import { CustomersService } from 'src/app/_services/customers.service';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  customer: Customer;

  constructor(private customerService: CustomersService, private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember(){ 
    this.customerService.getCustomer(this.route.snapshot.paramMap.get('id')).
    subscribe(customer => { this.customer = customer}) 
  }

  updateCustomer(){
    this.customerService.updateCustomer(this.customer.id, this.customer).subscribe(() => {
      this.toastr.success('Dane zostały zapisane');
      this.editForm.reset(this.customer);
    })

}
}