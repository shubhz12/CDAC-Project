import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-cart-update',
  templateUrl: './cart-update.component.html',
  styleUrls: ['./cart-update.component.css']
})
export class CartUpdateComponent implements OnInit {

  
  Title=''
  Price=0
 Quantity=0
  selectedFile: File = null;
  
  
  item:any;
 
  

  constructor(private router:Router,
    private activatedRoute:ActivatedRoute,
    private dataService:DataService) { }

  ngOnInit(): void {
    const id= this.activatedRoute.snapshot.queryParams['id']
   if(id){
     this.dataService.getCartitemsbyid(id).subscribe(response=>{
      // if(response['status']=='error'){

      // }else{
         console.log('get cart details')
       this.item=response
         console.log(this.item)
        /*  console.log('length'+books.length)
         if(books.length>0){
           const book=books[0]
           console.log(book)
         } */
        this.Title=this.item['Title']
        this.Price=this.item['Price']
        this.Quantity=this.item['Quantity']
        
      // }
     })
   }

    
  }

  onUpdate(){

    if(this.item){
      //update
      this.dataService.updateCart(this.item['cart_id'],this.Title,this.Price,this.Quantity).subscribe(response=>{
      // if(response[status]=='error'){
        console.log('update cart in cart component')
        
          this.router.navigate(['/cart'])
  
     // }
      })
  }

}
onFileChanged(file: File): void {
  this.selectedFile=file;

}

}
