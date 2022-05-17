import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/_models/company';
import { CompaniesService } from 'src/app/_services/companies.service';

@Component({
  selector: 'app-company-detail',
  templateUrl: './company-detail.component.html',
  styleUrls: ['./company-detail.component.css']
})
export class CompanyDetailComponent implements OnInit {
  company: Company;
  constructor(private companyService: CompaniesService, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadCompany();
  }

  loadCompany(){
    this.companyService.getCompany().
    subscribe(company => { this.company = company})
  }

}
