import { JsonPipe } from '@angular/common';
import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CategoryService } from '../../services/category.service';
import { Subscriber, Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { HomeComponent } from '../../home/home.component';
// import {ToastrService} from 'ngx-toastr'

@Component({
  selector: 'app-category-form',
  standalone: true,
  imports: [ReactiveFormsModule, JsonPipe , HomeComponent],
  templateUrl: './category-form.component.html',
  styleUrl: './category-form.component.css'
})
export class CategoryFormComponent implements OnInit , OnDestroy {
  form!:FormGroup
  categoryService = inject(CategoryService);
  categorySubscription! : Subscription
  paramSubscription! : Subscription
  isEdit! : Boolean
  id!: string
 constructor( private fb : FormBuilder , private activateRouter : ActivatedRoute ){

 }
  ngOnDestroy(): void {
   if(this.categorySubscription){
      this.categorySubscription.unsubscribe();
   }
   if(this.paramSubscription){
    this.paramSubscription.unsubscribe();
   }
  }
 onSubmit(){

  if(this.isEdit == false){
    this.categorySubscription =  this.categoryService.addCategory(this.form.value).subscribe({
      next:(res)=>{
        console.log(res)
        // this.toastrservice.success('تم الاضافة بنجاح');

      },
      error : (err)=>{
        console.log(err)
      }
    })

  }else{
    console.log(this.form.value);

    this.categorySubscription= this.categoryService.UpdateCategory(this.form.value ,this.id ).subscribe({
    next:(res)=>{
    },
    error:(error)=>{

    }
  })
}
 }

  ngOnInit(): void {
   this.paramSubscription =  this.activateRouter.params.subscribe({
      next:(response)=>{
        this.id =response['id'];
        if(this.id == 'form'){
          console.log("mMmM")
          return ;
        }
        console.log(response['id']);
        console.log("noo")
        this.categoryService.getOneCategory(response['id']).subscribe(
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
    this.form = this.fb.group({
      cateName :['', Validators.required],
      cateDescription:['', Validators.required]
    })
  }
}
