import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';



@Injectable({
  providedIn: 'root'
})
export class AdminService implements CanActivate{

 
  constructor( private router:Router,
    private httpclient:HttpClient,
    private toastr:ToastrService) { }
 

login(username:string,password:string)
{
     var url='http://localhost:58338/api/Userlogin'
     
     const body=
     {
       username:username,
       password:password
      }
      console.log(username,password)
      return this.httpclient.post(url,body)
    
  }

    

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
     // sessionStorage['name']
      if(sessionStorage['role']=='admin'){
          //user is logged in
         //launch the componnent
        return true
      }
       console.log("User has not logged in");
       //force user to login
      this.router.navigate(['/login'])
      //stop launching the component

      return false
    }
    

    

}
