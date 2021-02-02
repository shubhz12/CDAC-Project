import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class CustomerService implements CanActivate{

  url='http://localhost:58338/api/User'

  constructor(
    private httpClient:HttpClient,
    private router:Router) { }

    getUsers(){
      console.log('in get user');
      return this.httpClient.get(this.url)
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
      // sessionStorage['name']
       if(sessionStorage['role']=='user'){
           //user is logged in
          //launch the componnent
         return true
        }
        this.router.navigate(['/login'])
 
       return false
     }
 
     DeleteBook(Book_id:number) {
      const url='http://localhost:58338/api/User'
      return this.httpClient.delete(url+"?book_id="+Book_id)
    }

}
