import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { HomeComponent } from '../home/home.component';
import { RouterLink } from '@angular/router';
import { AsyncPipe, JsonPipe } from '@angular/common';
import { UserService } from '../services/user.service';
import { Observable } from 'rxjs';
import { user } from '../types/user';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [HomeComponent , RouterLink , AsyncPipe , JsonPipe ],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit , OnDestroy {
  userService =  inject(UserService);
  users$! : Observable<user[]>
  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.users$ = this.userService.getUsers();
  }
  DeleteUser(id: number){
    this.userService.deleteUser(id).subscribe({
      next:(res)=>{
      this.users$ = this.userService.getUsers();
      },
      error : (err)=>{
        console.log(err)
      }
    })

  }


}
