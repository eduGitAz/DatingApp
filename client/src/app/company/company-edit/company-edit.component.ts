import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/_models/company';
import { CompaniesService } from 'src/app/_services/companies.service';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.css']
})
export class CompanyEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  company: Company;
  
  constructor(private companyService: CompaniesService, private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadCompany();
  }

  loadCompany(){ 
    this.companyService.getCompany().
    subscribe(company => { this.company = company}) 
  }
  
  updateCompany(){
    this.companyService.updateCompany(this.company.id, this.company).subscribe(() => {
      this.toastr.success('Dane zostały zapisane');
      this.editForm.reset(this.company);
    })

}


}
