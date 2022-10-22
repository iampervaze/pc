import { Component, Input, OnInit } from '@angular/core';
import { Premium } from '../models';

@Component({
  selector: 'app-premium-details',
  templateUrl: './premium-details.component.html',
  styleUrls: ['./premium-details.component.css']
})
export class PremiumDetailsComponent implements OnInit {
  @Input() premium: Premium  | null = null;
  constructor() { }

  ngOnInit(): void {
  }
}
