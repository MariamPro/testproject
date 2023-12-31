import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { HomeComponent } from './home/home.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet , RouterLink , HomeComponent],
  templateUrl: 'app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'client';

}
