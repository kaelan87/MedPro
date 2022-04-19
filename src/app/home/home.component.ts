import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']

})
export class HomeComponent implements OnInit {
  img1:string = "../../assets/images/img1.png";
  img2:string = "../../assets/images/img2.png";
  

  constructor() { }

  ngOnInit(): void {
  }

}
