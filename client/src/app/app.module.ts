import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from './_modules/shared.module';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { NotloggedinComponent } from './notloggedin/notloggedin.component';
import { HeaderComponent } from './header/header.component';
import { LeftmenuComponent } from './leftmenu/leftmenu.component';
import { HasRoleDirective } from './_directives/has-role.directive';
import { UserManagementComponent } from './users/user-management/user-management.component';
import { RolesModalComponent } from './modals/roles-modal/roles-modal.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserAddComponent } from './users/user-add/user-add.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { HomeComponent } from './home/home.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { CustomerEditComponent } from './customers/customer-edit/customer-edit.component';
import { CustomerAddComponent } from './customers/customer-add/customer-add.component';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { OrderDetailComponent } from './orders/order-detail/order-detail.component';
import { OrderAddComponent } from './orders/order-add/order-add.component';
import { OrderEditComponent } from './orders/order-edit/order-edit.component';
import { CompanyEditComponent } from './company/company-edit/company-edit.component';
import { CompanyDetailComponent } from './company/company-detail/company-detail.component';
import { DeviceAddComponent } from './devices/device-add/device-add.component';
import { DeviceListComponent } from './devices/device-list/device-list.component';
import { DeviceEditComponent } from './devices/device-edit/device-edit.component';
import { DeviceDetailComponent } from './devices/device-detail/device-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    MemberListComponent,
    MemberDetailComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    NotloggedinComponent,
    HeaderComponent,
    LeftmenuComponent,
    HasRoleDirective,
    UserManagementComponent,
    RolesModalComponent,
    UserDetailComponent,
    UserEditComponent,
    UserAddComponent,
    HomeComponent,
    CustomerListComponent,
    CustomerDetailComponent,
    CustomerEditComponent,
    CustomerAddComponent,
    OrderListComponent,
    OrderDetailComponent,
    OrderAddComponent,
    OrderEditComponent,
    CompanyEditComponent,
    CompanyDetailComponent,
    DeviceAddComponent,
    DeviceListComponent,
    DeviceEditComponent,
    DeviceDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    Ng2SearchPipeModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
