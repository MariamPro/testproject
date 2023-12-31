import { AsyncPipe, JsonPipe, formatDate } from '@angular/common';
import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { Observable, Subscription } from 'rxjs';
import { category } from '../../types/category';
import { CategoryService } from '../../services/category.service';
import { HomeComponent } from '../../home/home.component';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [ReactiveFormsModule , JsonPipe , AsyncPipe , HomeComponent],
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.css'
})
export class ProductFormComponent implements OnInit , OnDestroy{
  form! :FormGroup;
  isEdit! : Boolean
  productService = inject(ProductService)
  productSubscription! : Subscription
  paramSubscription! : Subscription
  categoryService = inject(CategoryService)
  categories$! : Observable<category[]>
  id! : string
  selectedFile: File | null = null;
  constructor( private pd : FormBuilder , private routerActive : ActivatedRoute){

  }
  ngOnDestroy(): void {
    if(this.productSubscription){
      this.productSubscription.unsubscribe();
    }
  }
  ngOnInit(): void {
    this.isEdit = false
    this.categories$ = this.categoryService.getCategory();
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
        this.productService.getOneProduct(response['id']).subscribe(
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
      proName :['', Validators.required],
      proDescription:['', Validators.required],
      price:[''],
      CateID:['']
    })
  }

  onSubmit(){
 if(this.isEdit == false){
  console.log(this.form.value);
  this.productSubscription = this.productService.addProduct(this.form.value).subscribe({
  next:(res)=>{
    console.log(this.form.value)
  },
  error:(error)=>{

  }
});
 }else{
  console.log(this.form.value);

  this.productSubscription = this.productService.UpdateProduct(this.form.value ,this.id ).subscribe({
  next:(res)=>{
  },
  error:(error)=>{

  }
});
 }

  }


}
