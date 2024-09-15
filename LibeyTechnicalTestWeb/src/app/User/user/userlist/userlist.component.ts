import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {

  libeyUsers: LibeyUser[] = [];

  constructor(private libeyUserService: LibeyUserService,) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers() {
    this.libeyUserService.GetAll().subscribe({
      next: (users) => {
        this.libeyUsers = users;
        console.log('libeyUsers:' + this.libeyUsers)
      },
    });
  }

  onDeleteUser(document: string) {

    this.libeyUserService.deleteUser(document)
      .subscribe(user => {
        this.getAllUsers()
      });
  }

}
