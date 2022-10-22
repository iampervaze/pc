import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer, Premium } from '../models';
import { PremiumService } from '../services/premium.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  premium: Premium | null = null;
  constructor(private premiumService: PremiumService) {
  }

  customerDetailsSubmitted(customer: Customer) {
    console.log('Recieved', customer)
    this.premiumService.calculatePremium(customer).subscribe((premium: Premium) => {
      this.premium = premium;
    })
  }
}
