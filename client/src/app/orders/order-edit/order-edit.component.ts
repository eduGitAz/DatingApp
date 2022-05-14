import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/_models/customer';
import { Order } from 'src/app/_models/order';
import { CustomersService } from 'src/app/_services/customers.service';
import { OrdersService } from 'src/app/_services/orders.service';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.css']
})

export class OrderEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  order: Order;
  defaultCustomer: Customer;
  customers: Customer[];
  constructor(private orderService: OrdersService, private customerService: CustomersService, private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadOrder();
    this.getCustomers();
  
  } 

  loadOrder(){ 
    this.orderService.getOrder(this.route.snapshot.paramMap.get('id')).
    subscribe(order => { this.order = order}) 
  }

  updateOrder(){
    this.orderService.updateOrder(this.order.id, this.order).subscribe(() => {
      this.toastr.success('Dane zostały zapisane');
      this.editForm.reset(this.order);
    })
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe(customers => {
      this.customers = customers;
    })
  }


 
}
 