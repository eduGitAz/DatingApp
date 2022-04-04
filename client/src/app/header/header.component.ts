import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  registerMode = false;
  model: any = {}
  constructor(public accountService: AccountService, private router:Router) { }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
     this.router.navigateByUrl('/');
    }
    )
   }
 
   logout(){
     this.accountService.logout();
     this.router.navigateByUrl('/')
   }

}
