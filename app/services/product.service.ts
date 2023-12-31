import { Injectable } from '@angular/core';
import { product } from '../types/product';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { category } from '../types/category';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  apiUrl = "https://localhost:7048/api/Products"
  constructor(private http:HttpClient) {
   }
   getCategory = ():Observable<category[]> => this.http.get<category[]>("https://localhost:7048/api/Category")
   getProduct = ():Observable<product[]> => this.http.get<product[]>(this.apiUrl)
   addProduct = (data:product )=>this.http.post<product[]>(this.apiUrl,data)
   getOneProduct = (id: number):Observable<product>=>this.http.get<product>(this.apiUrl+'/'+ id)
   UpdateProduct =(data:product , id:string)=>this.http.put<product[]>(this.apiUrl +'/'+id, data)
   deleteProduct = (id: number)=>this.http.delete(this.apiUrl+'/'+ id)
}
