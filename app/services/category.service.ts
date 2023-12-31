import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { category } from '../types/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  apiUrl = "https://localhost:7048/api/Category"
  constructor(private http:HttpClient) { }
  getCategory = ():Observable<category[]> => this.http.get<category[]>(this.apiUrl)
  addCategory = (data:category)=>this.http.post<category[]>(this.apiUrl , data)
  UpdateCategory = (data:category , id:string)=>this.http.put<category[]>(this.apiUrl +'/'+id , data)
  getOneCategory = (id: number):Observable<category>=>this.http.get<category>(this.apiUrl+'/'+ id)
  deleteCategory = (id: number)=>this.http.delete(this.apiUrl+'/'+ id)
}
