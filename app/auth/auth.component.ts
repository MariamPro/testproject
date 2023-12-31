import { JsonPipe } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { HomeComponent } from '../home/home.component';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [ JsonPipe , HomeComponent , ReactiveFormsModule],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent implements OnInit {
  form! :FormGroup;
  authService = inject(AuthService);
  AuthSubscription! : Subscription
  constructor( private pd : FormBuilder , private routerActive : ActivatedRoute ,private router: Router){

  }
  ngOnInit(): void {

    this.form = this.pd.group({
      username:['', Validators.required],
     password:['', Validators.required],
    })
  }


  onSubmit(){
     console.log(this.form.value);
     this.AuthSubscription = this.authService.login(this.form.value).subscribe({
     next:(res)=>{
      this.authService.storeToken(res.token)
      this.router.navigate(['dashboard'])
     },
     error:(error)=>{

     }
   });

     }
}
