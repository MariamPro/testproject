import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { user } from '../types/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
 apiUrl = "https://localhost:7048/api/User"
  constructor( private http:HttpClient) {
  }
  getUsers = ():Observable<user[]> => this.http.get<user[]>(this.apiUrl)
  addUser = (data:user)=>this.http.post<user[]>(this.apiUrl , data)
  getOneUser = (id: number):Observable<user>=>this.http.get<user>(this.apiUrl+'/'+ id)
  UpdateUser =(data:user , id:string)=>this.http.put<user[]>(this.apiUrl +'/'+id, data)
  deleteUser = (id: number)=>this.http.delete(this.apiUrl+'/'+ id)
}
