import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Order } from 'src/app/_models/order';
import { OrdersService } from 'src/app/_services/orders.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements OnInit {
  order: Order;
  constructor(private orderService: OrdersService, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadOrder();
  }

  loadOrder(){
    this.orderService.getOrder(this.route.snapshot.paramMap.get('id')).
    subscribe(order => { this.order = order})
  }

  deleteOrder(){ 
    if(confirm('Czy na pewno chcesz usunąc zamówienie nr: "'+ this.order.id + '"?')){
    
    this.orderService.deleteOrder(this.order.id).subscribe(() => {
      this.toastr.success('Zamówienie zostało usunięte');
    }, error => {
      console.log(error);
      this.toastr.error(error.error); 
    })
  }
  }
 
}
