import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';
import { User } from '../_models/user';


@Injectable({
  providedIn: 'root'
})
export class MembersService {
baseUrl = environment.apiUrl;
 
  member: Member;
  constructor(private http: HttpClient) { }

  getMembers(){
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }

  getMember(username: string){
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }


  updateMember(id: Number, member: Member){
    return this.http.put(this.baseUrl + 'users/'+ id, member)
  }

  getUsersWithRoles() {
    return this.http.get<Partial<User[]>>(this.baseUrl + 'users/users-with-roles');
  }

  updateUserRoles(username: string, roles: string[]) {
    return this.http.post(this.baseUrl + 'users/edit-roles/' + username + '?roles=' + roles, {});
  }

  addMember(model:any){
    return this.http.post(this.baseUrl + "users/add", model);
  }
}
