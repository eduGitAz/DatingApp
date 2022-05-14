import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserManagementComponent } from './users/user-management/user-management.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { NavComponent } from './nav/nav.component';
import { NotloggedinComponent } from './notloggedin/notloggedin.component';
import { RegisterComponent } from './register/register.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserAddComponent } from './users/user-add/user-add.component';
import { HomeComponent } from './home/home.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { CustomerAddComponent } from './customers/customer-add/customer-add.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { CustomerEditComponent } from './customers/customer-edit/customer-edit.component';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { OrderDetailComponent } from './orders/order-detail/order-detail.component';
import { OrderEditComponent } from './orders/order-edit/order-edit.component';
import { OrderAddComponent } from './orders/order-add/order-add.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: '', component: HomeComponent},
      {path: 'users/users-roles', component: UserManagementComponent, canActivate: [AdminGuard]},
      {path: 'users/:id', component: UserDetailComponent},
      {path: 'user/edit/:id', component: UserEditComponent},
      {path: 'user/add', component: UserAddComponent},
     

      {path: 'members', component: MemberListComponent},
      {path: 'members/:id', component: MemberDetailComponent}, 

      {path: 'customers', component: CustomerListComponent},
      {path: 'customers/:id', component: CustomerDetailComponent},
      {path: 'customer/edit/:id', component: CustomerEditComponent},
      {path: 'customer/add', component: CustomerAddComponent},

      {path: 'orders', component: OrderListComponent},
      {path: 'orders/:id', component: OrderDetailComponent},
      {path: 'order/edit/:id', component: OrderEditComponent},
      {path: 'order/add', component: OrderAddComponent},
      
    ]
  },
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent}, 
  {path: '**', component: NotFoundComponent, pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
