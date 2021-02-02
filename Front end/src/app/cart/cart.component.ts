import { ToastrService } from 'ngx-toastr';
import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  
  title:" "
  price:0
  quantity:0
  totalAmount :0
  items :any;

  constructor(private dataService:DataService,
    private toastr:ToastrService,
    private router:Router,
    private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.loadCartItems()
  }

  loadCartItems() {
    const request=this.dataService.getCartItems()
      .subscribe(response => {
       // if(response[status]=='error'){
          console.log('Cart list fetching failed')
         
      // }else{
          /* console.log(response['error']) */
          this.items=response;
          
          
         /*  console.log(this.books);
          console.log('inside if'); */
      // }
        console.log('Cart loaded');


      })
  }

  onDelete(item){
    this.dataService
      .deleteItem(item['cart_id'])
      .subscribe(response => { 
        console.log('in delete cart item')
       // if (response['status'] == 'success') {
          let item = response
          console.log(item)
          this.toastr.success("Cart item deleted successfully!")
          //this.toastr.success(response['data'])
          this.router.navigate['/cart']
          
         // }
         this.loadCartItems() ;
        
      })

  }

  onEdit(item){
    this.router.navigate(['/cart-update'],{queryParams:{id:item['cart_id']}})
  }


}
