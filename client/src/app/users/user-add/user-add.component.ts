import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {
  
  model: any = {};
  constructor(private membersService: MembersService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addMember(){
    this.membersService.addMember(this.model).subscribe(response => {
      console.log(response);
      this.toastr.success("Poprawnie dodano pracownika"); 
    }, error => {
      console.log(error);
      this.toastr.error(error.error); 
    });
  }

}
