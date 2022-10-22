import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { debounceTime, Observable } from 'rxjs';
import { Occupation, Customer } from '../models';
import { OccupationService } from '../services/occupation.service';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {
  form: FormGroup;
  occupations$: Observable<Occupation[]>;
  @Output() customerDetailsSubmitted: EventEmitter<Customer> = new EventEmitter<Customer>();

  constructor(fb: FormBuilder, occupationService: OccupationService) {
    this.occupations$ = occupationService.getOccupations();
    this.form = fb.group({
      name: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      occupationId: ['', Validators.required],
      sumInsured: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.form.valueChanges.pipe(debounceTime(500)).subscribe(result => {
      if (this.form.valid) {
        this.customerDetailsSubmitted.next(this.form.value);
      }
    })
  }

  submit() {
    if(this.form.invalid){
      return;
    }

    this.customerDetailsSubmitted.next(this.form.value);
  }
}
