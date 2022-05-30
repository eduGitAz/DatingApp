import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Company } from '../_models/company';
import { Customer } from '../_models/customer';
import { CompaniesService } from '../_services/companies.service';
import { CustomersService } from '../_services/customers.service';
import { DevicesService } from '../_services/devices.service';
import { OrdersService } from '../_services/orders.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  company: Company;
  amountCustomer: Subscription;
  amountDevices: Subscription;
  amountOrders: Subscription;

  constructor(private companyService: CompaniesService, private route: ActivatedRoute, private toastr: ToastrService,
    private customerService: CustomersService, private deviceService: DevicesService, private orderService: OrdersService) { }

  ngOnInit(): void {
    this.loadCompany();
    this.countCustomer();
    this.counOrders();
    this.countDevices();
  }

  loadCompany(){
    this.companyService.getCompany().
    subscribe(company => { this.company = company})
  }

  countCustomer(){
    this.customerService.countCustomers().
    subscribe(amountCustomer => {this.amountCustomer = amountCustomer});
  }

  counOrders(){
    this.orderService.countOrders().
    subscribe(amountOrders => {this.amountOrders = amountOrders});
  }

  countDevices(){
    this.deviceService.countDevices().
    subscribe(amountDevices => {this.amountDevices = amountDevices});
  }

}
