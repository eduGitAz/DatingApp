import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  registerMode = false;
  model: any = {}
  constructor(public accountService: AccountService, private router:Router,  private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
    this.toastr.success("Logowanie powiodło się"); 
     this.router.navigateByUrl('/');
    }, error => {
      console.log(error);
      this.toastr.error(error.error);  
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }
}
   
 
 
  


