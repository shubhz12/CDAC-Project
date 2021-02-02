import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  userCount:number
  bookCount:number
  cartCount:number

  constructor(private service:AdminService) { }

  ngOnInit(): void {

    
  }

  
    
  


}
