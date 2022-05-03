import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  member: Member;
  constructor(private memberService: MembersService, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void { 
    this.loadMember();
  }

  loadMember(){
    this.memberService.getMember(this.route.snapshot.paramMap.get('id')).
    subscribe(member => { this.member = member})
  }


  
  deleteMember(){
    if(confirm('Czy na pewno chcesz usunąc użytkownika "'+ this.member.name + '"?')){
    this.memberService.deleteMember(this.member.id).subscribe(() => {
      this.toastr.success('Pracownik został usunięty');
    })}
  }




}

 