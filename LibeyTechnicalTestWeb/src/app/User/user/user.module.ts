import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from "@ng-select/ng-select";
import { RouterModule } from '@angular/router';

import { UserlistComponent } from './userlist/userlist.component';
import { UsercardsComponent } from './usercards/usercards.component';
import { UsermaintenanceComponent } from './usermaintenance/usermaintenance.component';

@NgModule({
  declarations: [   
    UsercardsComponent,
    UsermaintenanceComponent,
    UserlistComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule    ,
    RouterModule
  ]
})
export class UserModule { }