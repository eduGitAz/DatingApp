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
import { ViewChild } from '@angular/core';
import { BarControllerChartOptions, ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import DataLabelsPlugin from 'chartjs-plugin-datalabels';
import { NullVisitor } from '@angular/compiler/src/render3/r3_ast';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  company: Company;

  amountCustomers : number 
  amountDevices: number;
  amountOrders: number;
  amountNewOrderes: number;
  amountRealizedOrders: number;
  amountClosedOrders: number;
  percentOfServicesOrders: number;
  percentOfInstallationOrders: number;
 


  constructor(private companyService: CompaniesService, private route: ActivatedRoute, private toastr: ToastrService,
    private customerService: CustomersService, private deviceService: DevicesService, private orderService: OrdersService) 
    {   }

  ngOnInit(): void {
    this.loadCompany();
    this.countCustomer();
    this.counOrders();
    this.countDevices();
    this.countNewOrders();
    this.countRealizedOrders();
    this.countClosedOrders();
    this.countPercentOfServicesOrders();
    this.countPercentOfInstallationOrders();
   
  }

 

  loadCompany(){
    this.companyService.getCompany().
    subscribe(company => { this.company = company})
  }

  countCustomer(){
    this.customerService.countCustomers().
    subscribe(amountCustomer => {this.amountCustomers = amountCustomer});
  }

  counOrders(){
    this.orderService.countOrders().
    subscribe(amountOrders => {this.amountOrders = amountOrders});
  }

  countDevices(){
    this.deviceService.countDevices().
    subscribe(amountDevices => {this.amountDevices = amountDevices});
  }

  countNewOrders(){
    this.orderService.countNewOrders().
    subscribe(amountNewOrders => {this.amountNewOrderes = amountNewOrders});
  }

  countRealizedOrders(){
    this.orderService.countRealizedOrders().
    subscribe(amountRealizedOrders => {this.amountRealizedOrders = amountRealizedOrders});
  }

  countClosedOrders(){
    this.orderService.countClosedOrders().
    subscribe(amountClosedOrders => {this.amountClosedOrders = amountClosedOrders});
  }

  countPercentOfServicesOrders(){
    this.orderService.countPercentOfServicesOrders().
    subscribe(percentOfServicesOrders => {this.percentOfServicesOrders = percentOfServicesOrders});
  }
  
  countPercentOfInstallationOrders(){
    this.orderService.countPercentOfInstallationOrders().
    subscribe(percentOfInstallationOrders => {this.percentOfInstallationOrders = percentOfInstallationOrders});
  }



}
