import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/_models/customer';
import { Device } from 'src/app/_models/device';
import { Order } from 'src/app/_models/order';
import { OrderStatus } from 'src/app/_models/orderStatus';
import { OrderType } from 'src/app/_models/orderType';
import { Refrigerant } from 'src/app/_models/refrigerant';
import { UseOfRefrigernat } from 'src/app/_models/useOfRefrigernat';
import { CustomersService } from 'src/app/_services/customers.service';
import { DevicesService } from 'src/app/_services/devices.service';
import { OrderStatusesService } from 'src/app/_services/order-statuses.service';
import { OrderTypesService } from 'src/app/_services/order-types.service';
import { OrdersService } from 'src/app/_services/orders.service';
import { RefrigerantsService } from 'src/app/_services/refrigerants.service';
import { UseOfRefrigerantsService } from 'src/app/_services/use-of-refrigerants.service';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.css']
})

export class OrderEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  order: Order;
  customers: Customer[];
  devices: Device[];
  orderStatuses: OrderStatus[];
  orderTypes: OrderType[];
  useOfRefrigerants: UseOfRefrigernat[];
  refrigerants: Refrigerant[];

  constructor(private orderService: OrdersService, private customerService: CustomersService, private toastr: ToastrService, private route: ActivatedRoute,
    private deviceService: DevicesService, private orderStatusService: OrderStatusesService, private ordertTypesService: OrderTypesService,
    private useOfRefrigerantService: UseOfRefrigerantsService, private refrigerantService: RefrigerantsService) { }

  ngOnInit(): void {
    this.loadOrder();
    this.getCustomers();
    this.getDevices();
    this.getOrderStatus();
    this.getOrderType();
    this.getUseOfRefrigerants();
    this.getRefrigerants();
  
  } 

  loadOrder(){ 
    this.orderService.getOrder(this.route.snapshot.paramMap.get('id')).
    subscribe(order => { this.order = order}) 
  }

  updateOrder(){
    this.orderService.updateOrder(this.order.id, this.order).subscribe(() => {
      this.toastr.success('Dane zosta??y zapisane');
      this.editForm.reset(this.order);
    })
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe(customers => {
      this.customers = customers;
    })
  }

  getDevices() {
    this.deviceService.getDevices().subscribe(devices => {
      this.devices = devices;
    })
  }

  getOrderStatus() {
    this.orderStatusService.getOrderStatuses().subscribe(orderStatuses => {
      this.orderStatuses = orderStatuses;
    })
  }

  getOrderType() {
    this.ordertTypesService.getOrderTypes().subscribe(orderTypes => {
      this.orderTypes = orderTypes;
    })
  }

  getUseOfRefrigerants() {
    this.useOfRefrigerantService.getUseOfRefrigernats().subscribe(useOfRefrigerants => {
      this.useOfRefrigerants = useOfRefrigerants;
    })
  }

  getRefrigerants() {
    this.refrigerantService.getRefrigerants().subscribe(refrigerants => {
      this.refrigerants = refrigerants;
    })
  }
 
}
 