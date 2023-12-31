import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { user } from '../types/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService  {
apiUrl = "https://localhost:7048/api/Auth/Login"
  constructor( private http: HttpClient) { }
  login = (data:user)=>this.http.post<user>(this.apiUrl , data)

storeToken(tokenValue : string){
localStorage.setItem("token" , tokenValue)
}
getToken(){
  return localStorage.getItem('token')
}

isLogin() :boolean{
  console.log( localStorage.getItem('token'))
  return !! localStorage.getItem('token')
}
removeToken(){
  localStorage.removeItem('token');
}
}
