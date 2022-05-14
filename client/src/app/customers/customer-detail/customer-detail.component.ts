import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/_models/customer';
import { CustomersService } from 'src/app/_services/customers.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
  customer: Customer;
  constructor(private customerService: CustomersService, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember(){
    this.customerService.getCustomer(this.route.snapshot.paramMap.get('id')).
    subscribe(customer => { this.customer = customer})
  }

  deleteCustomer(){ 
    if(confirm('Czy na pewno chcesz usunąc Klienta "'+ this.customer.name + '"?')){
    this.customerService.deleteCustomer(this.customer.id).subscribe(() => {
      this.toastr.success('Klient został usunięty');
    })}
  } 
}
