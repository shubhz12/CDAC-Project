import { ToastrService } from 'ngx-toastr';
import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  FirstName:''
  contact_no:''
  Username:''
  Address:''




  constructor(private service:DataService,
    private toastr:ToastrService,
    private router:Router) { }

  ngOnInit(): void {
  }

}
