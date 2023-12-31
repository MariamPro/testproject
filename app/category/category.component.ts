import { Component, OnInit, inject } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { Observable } from 'rxjs';
import { category } from '../types/category';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { HomeComponent } from '../home/home.component';
@Component({
  selector: 'app-category',
  standalone: true,
  imports: [AsyncPipe , RouterLink , HomeComponent],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {
  categoryService = inject(CategoryService)
  categories$!:Observable<category[]>
  ngOnInit(): void {
   this.categories$ = this.categoryService.getCategory()
  }
  deleteCate(id : number){
    this.categoryService.deleteCategory(id).subscribe({
      next : (res)=>{
       this.categories$ =  this.categoryService.getCategory();
        console.log(res)
      },
      error : (er)=>[
        console.log(er)
      ]
    })
  }

}
