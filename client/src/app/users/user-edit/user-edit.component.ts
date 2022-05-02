import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  @ViewChild('editForm') editForm: NgForm;
  member: Member;

  constructor(private memberService: MembersService, private toastr: ToastrService, private route: ActivatedRoute) { 
    
   }

  ngOnInit(): void {
    this.loadMember();
  } 


  loadMember(){ 
    this.memberService.getMember(this.route.snapshot.paramMap.get('id')).
    subscribe(member => { this.member = member}) 
  }

  updateMember(){
    this.memberService.updateMember(this.member.id, this.member).subscribe(() => {
      this.toastr.success('Dane zostały zapisane');
      this.editForm.reset(this.member);
    })
  
  }

}
