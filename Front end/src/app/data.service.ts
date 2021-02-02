import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { identifierModuleUrl, Identifiers } from '@angular/compiler';
import { isBoolean } from 'util';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  httpClient:HttpClient
 

   url='http://localhost:58338/api/Cart';
  
 

  constructor(httpClient:HttpClient) {
    this.httpClient=httpClient
   }



  getBooks(){
    const url='http://localhost:58338/api/Books'
    const request=this.httpClient.get(url)
    return request
  }

  getCartItems(){
   
    const url='http://localhost:58338/api/Cart'
    const request=this.httpClient.get(url)
    return request
  }

  getCartitemsbyid(cart_id:number){
    const url='http://localhost:58338/api/Cart'
    const request=this.httpClient.get(url+"/"+cart_id)
    return request
  }
  getUserDetails(user_id:number){
    const url='http://localhost:58338/api/Users/details/'
    const request=this.httpClient.get(url+user_id)
    return request
  }
  

  
// this.service.addCartItems(book['Book_id'],book['Price'],1,book['Title'],this.user.user_id)
  
  addCartItems(Book_id:number,Price:number,Quantity:number,Title:string,user_id:number){
    console.log('service method')
    console.log(user_id)
    
    const body={
      Book_id:Book_id,
      Price:Price,
      Quantity:Quantity,
      user_id:user_id,
      Title:Title,

   
    }
    sessionStorage['cartItem']=body.Title;
    console.log(body)
    
    return this.httpClient.post(this.url + "/add", body)
  }

  getBooksDetails(Book_id:number){
    const url='http://localhost:58338/api/Books'
    const request=this.httpClient.get(url+"/"+Book_id)
    return request
  }

  deleteItem(cart_id:number){
    const delurl='http://localhost:58338/api/Cart';
    // this.router.navigate(['/view'],{queryParams:{id: book['Book_id']}})
   return this.httpClient.delete(delurl+"?cart_id="+cart_id )
  }

  AddUserData(user)
  {
    console.log(user);
    return this.httpClient.post("http://localhost:58338/api/User",user);
  }

  updateCart(cart_id:number,Title:string,Price:number,Quantity:number) {
      
    const body={
        
      cart_id:cart_id,
      Title:Title,
      Price:Price,
      Quantity:Quantity,
     
      
      } 
       
      const url='http://localhost:58338/api/Cart'
    const request=this.httpClient.put(url+"/"+cart_id,body)
    return request


  }

}
