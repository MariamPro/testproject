import { Component } from '@angular/core';
import { ViewProductComponent } from './view-product/view-product.component';

@Component({
  selector: 'app-website',
  standalone: true,
  imports: [ViewProductComponent],
  templateUrl: './website.component.html',
  styleUrl: './website.component.css'
})
export class WebsiteComponent {

}
