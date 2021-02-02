import { AdminService } from './../admin.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

// export const toMd5 = (input: string): string => Md5.hashStr(input).toString();

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 
  username=''
  password=''
  message='';

  constructor(
    private router:Router,
    private adminService:AdminService,
    private toastr:ToastrService
    ) {
   
   }

  ngOnInit(): void {}

  onLogin(){
    //let isUserValid=true;
    if(this.username.length==0){
      this.toastr.error('Please enter Username!')
    }else if(this.password.length==0){
      this.toastr.error('Please enter Password!')
    }else{
     console.log(this.username,this.password)
      this.adminService
    .login(this.username,this.password).subscribe((response)=>
    {
      //if(response['status']=='success')
     // {
       console.log(response)
         //const data=response['data']
        sessionStorage['role']=response['role']
        //console.log(data)
         //go to dashboard
          if(response['role']=='admin')
          {
            this.toastr.success('Welcome To Online Book Store ')
              window.sessionStorage.setItem("isActive", "1");
              sessionStorage.setItem("user",JSON.stringify(response));
              this.router.navigate(['/dashboard'])
             
          }else if( response['role']=='user'){
           
              sessionStorage['user_id']=response['user_id']
              this.toastr.success('Welcome To Online Book Store ')
              window.sessionStorage.setItem("isActive", "2");
              sessionStorage.setItem("user",JSON.stringify(response));
              this.router.navigate(['/gallery'])
              }else{
                this.toastr.error('Please check your credentials!')
              }
     // }//else{
       // this.toastr.error('please check ur credentials')
        //this.router.navigate(['/login']);
      //}
      
    })
   
  }    
     
  }

}
