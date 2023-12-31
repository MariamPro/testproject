import { JsonPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { HomeComponent } from '../../home/home.component';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { UserService } from '../../services/user.service';
import { Observable, Subscription } from 'rxjs';
import { user } from '../../types/user';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [JsonPipe , HomeComponent ,ReactiveFormsModule],
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.css'
})
export class UserFormComponent {
  form! :FormGroup;
  isEdit! : Boolean
  userService = inject(UserService)
  userSubscription! : Subscription
  paramSubscription! : Subscription
  users$! : Observable<user[]>
  id! : string
  constructor( private pd : FormBuilder , private routerActive : ActivatedRoute){

  }
  ngOnDestroy(): void {
    if(this.userSubscription){
      this.userSubscription.unsubscribe();
    }
  }
  ngOnInit(): void {
    this.isEdit = false
    this.paramSubscription =  this.routerActive.params.subscribe({
      next:(response)=>{
         this.id =response['id'];
        console.log(this.id)
        if(this.id == 'form'){
          console.log("mMmM")
          return ;
        }
        console.log(response['id']);
        console.log("noo")
        this.userService.getOneUser(response['id']).subscribe(
          {
            next:(res)=>{
              this.form.patchValue(res)
              this.isEdit = true
              console.log(res)
            },
            error : (err)=>{
              console.log(err)
            }
          }
        )
      },
      error:(error)=>{
        console.log(error)
      }
    })
    this.form = this.pd.group({
      username :['', Validators.required],
      password:['', Validators.required],
      email:['', Validators.required],
      role:['']
    })
  }
  onSubmit(){
 if(this.isEdit == false){
  console.log(this.form.value);
  this.userSubscription = this.userService.addUser(this.form.value).subscribe({
  next:(res)=>{
  },
  error:(error)=>{

  }
});
 }else{
  console.log(this.form.value);

  this.userSubscription = this.userService.UpdateUser(this.form.value ,this.id ).subscribe({
  next:(res)=>{
  },
  error:(error)=>{
  }
});
 }

  }
}
