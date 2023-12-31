import { Routes } from '@angular/router';
import { CategoryComponent } from './category/category.component';
import { CategoryFormComponent } from './category/category-form/category-form.component';
import { ProductComponent } from './product/product.component';
import { ProductFormComponent } from './product/product-form/product-form.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserComponent } from './user/user.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { AuthComponent } from './auth/auth.component';
import { authent2Guard } from './authent2.guard';
import { WebsiteComponent } from './website/website.component';
import { ViewProductComponent } from './website/view-product/view-product.component';

export const routes: Routes = [
  {
    component:CategoryComponent,
    path:'category',
    canActivate: [authent2Guard]
  },
  {
    component:CategoryFormComponent,
    path : 'category/:id',
    canActivate: [authent2Guard]
  },
  {
    component:CategoryFormComponent,
    path : 'category/form',
    canActivate: [authent2Guard]
  },
  {
    component:ProductComponent,
    path:'product',
    canActivate: [authent2Guard]
  },
  {
    component:ProductFormComponent,
    path : 'product/form',
    canActivate: [authent2Guard]
  },
  {
    component:ProductFormComponent,
    path : 'product/:id',
    canActivate: [authent2Guard]

  },
  {
    component:DashboardComponent,
    path : 'dashboard',
    canActivate: [authent2Guard]
  },
  {
    component:UserComponent,
    path:'user',
    canActivate: [authent2Guard]
  },
  {
    component:UserFormComponent,
    path : 'user/form',
    canActivate: [authent2Guard]
  },
  {
    component:UserFormComponent,
    path : 'user/:id',
    canActivate: [authent2Guard]
  },
  {
    component:AuthComponent,
    path : 'auth'
  },
  {
    component:WebsiteComponent,
    path : 'website'
  },
  {
    component:ViewProductComponent,
    path : 'view_product'
  },
];
