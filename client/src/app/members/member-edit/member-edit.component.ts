import { ThrowStmt } from '@angular/compiler';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  member: Member;

  constructor(private memberService: MembersService, private toastr: ToastrService, private route: ActivatedRoute) { 
    this.member = this.memberService.getData();
   }

  ngOnInit(): void {
    this.loadMember();
  }


  loadMember(){ 
    this.memberService.getMember(this.member.username).subscribe(member => {this.member = member})
  }

  updateMember(){
    this.memberService.updateMember(this.member.username, this.member).subscribe(() => {
      this.toastr.success('Dane zostały zapisane');
      this.editForm.reset(this.member);
    })
  
  }

}
 