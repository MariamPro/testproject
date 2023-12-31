import { AsyncPipe } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { product } from '../../types/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-view-product',
  standalone: true,
  imports: [AsyncPipe ],
  templateUrl: './view-product.component.html',
  styleUrl: './view-product.component.css'
})
export class ViewProductComponent implements OnInit {
  products$! :Observable<product[]>
  proService = inject(ProductService);
  ngOnInit(): void {

    this.products$ = this.proService.getProduct();
  }

}
