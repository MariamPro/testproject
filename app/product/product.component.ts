import { Component, OnInit, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Observable } from 'rxjs';
import { product } from '../types/product';
import { AsyncPipe } from '@angular/common';
import { HomeComponent } from '../home/home.component';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [
    RouterLink,
    AsyncPipe,
    HomeComponent
  ],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit{
  productService = inject(ProductService)
  products$!: Observable<product[]>
  ngOnInit(): void {
    this.products$ = this.productService.getProduct();
  }

  DeleteProduct(id: number){
    this.productService.deleteProduct(id).subscribe({
      next:(res)=>{
      this.products$ = this.productService.getProduct();
      },
      error : (err)=>{
        console.log(err)
      }
    })

  }

}
