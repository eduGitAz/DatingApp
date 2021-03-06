import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserManagementComponent } from './users/user-management/user-management.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
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
import { CompanyDetailComponent } from './company/company-detail/company-detail.component';
import { CompanyEditComponent } from './company/company-edit/company-edit.component';
import { DeviceListComponent } from './devices/device-list/device-list.component';
import { DeviceDetailComponent } from './devices/device-detail/device-detail.component';
import { DeviceEditComponent } from './devices/device-edit/device-edit.component';
import { DeviceAddComponent } from './devices/device-add/device-add.component';
import { ComparisionComponent } from './comparision/comparision.component';


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

      {path: 'customers', component: CustomerListComponent},
      {path: 'customers/:id', component: CustomerDetailComponent},
      {path: 'customer/edit/:id', component: CustomerEditComponent},
      {path: 'customer/add', component: CustomerAddComponent},

      {path: 'orders', component: OrderListComponent},
      {path: 'orders/:id', component: OrderDetailComponent},
      {path: 'order/edit/:id', component: OrderEditComponent},
      {path: 'order/add', component: OrderAddComponent},

      {path: 'companies', component: CompanyDetailComponent},
      {path: 'companies/edit/:id', component: CompanyEditComponent},

      {path: 'devices', component: DeviceListComponent},
      {path: 'devices/:id', component: DeviceDetailComponent},
      {path: 'device/edit/:id', component: DeviceEditComponent},
      {path: 'device/add', component: DeviceAddComponent},

      {path: 'comparision', component: ComparisionComponent},
      
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
