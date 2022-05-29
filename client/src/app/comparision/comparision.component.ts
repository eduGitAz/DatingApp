import { Component, OnInit } from '@angular/core';
import { Comparision } from '../_models/comparision';
import { Order } from '../_models/order';
import { ComparisionService } from '../_services/comparision.service';
import { OrdersService } from '../_services/orders.service';

@Component({
  selector: 'app-comparision',
  templateUrl: './comparision.component.html',
  styleUrls: ['./comparision.component.css']
})
export class ComparisionComponent implements OnInit {
  comparisons: Comparision[];

 
  constructor(private comparisionService: ComparisionService) {  }

  ngOnInit(): void {
    this.getComparison();
  
  }

  getComparison() {
    this.comparisionService.getComparision().subscribe(comparision => {
      this.comparisons = comparision;
    })
  }

}
