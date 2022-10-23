import { Component, EventEmitter, Injectable, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter, NgbDateParserFormatter, NgbDateStruct, NgbInputDatepickerConfig } from '@ng-bootstrap/ng-bootstrap';
import { debounceTime, Observable } from 'rxjs';
import { Occupation, Customer } from '../models';
import { OccupationService } from '../services/occupation.service';

@Injectable()
export class CustomAdapter extends NgbDateAdapter<string> {
	readonly DELIMITER = '-';

	fromModel(value: string | null): NgbDateStruct | null {
		if (value) {
			const date = value.split(this.DELIMITER);
			return {
				day: parseInt(date[2], 10),
				month: parseInt(date[1], 10),
				year: parseInt(date[0], 10),
			};
		}
		return null;
	}

	toModel(date: NgbDateStruct | null): string | null {
		return date ? `${date.year}${this.DELIMITER}${date.month.toString().padStart(2, '0')}${this.DELIMITER}${date.day.toString().padStart(2, '0')}` : null;
	}
}

@Injectable()
export class CustomDateParserFormatter extends NgbDateParserFormatter {
	readonly DELIMITER = '-';

	parse(value: string): NgbDateStruct | null {
		if (value) {
			const date = value.split(this.DELIMITER);
			return {
				day: parseInt(date[2], 10),
				month: parseInt(date[1], 10),
				year: parseInt(date[0], 10),
			};
		}
		return null;
	}

	format(date: NgbDateStruct | null): string {
		return date ? `${date.year}${this.DELIMITER}${date.month.toString().padStart(2, '0')}${this.DELIMITER}${date.day.toString().padStart(2, '0')}` : '';
	}
}

@Component({
	selector: 'app-customer-details',
	templateUrl: './customer-details.component.html',
	styleUrls: ['./customer-details.component.css'],
	providers: [
		{ provide: NgbDateAdapter, useClass: CustomAdapter },
		{ provide: NgbDateParserFormatter, useClass: CustomDateParserFormatter },
	],
})
export class CustomerDetailsComponent implements OnInit {
	form: FormGroup;
	occupations$: Observable<Occupation[]>;
	@Output() customerDetailsSubmitted: EventEmitter<Customer> = new EventEmitter<Customer>();
	date: any = null;
	constructor(config: NgbInputDatepickerConfig, fb: FormBuilder, occupationService: OccupationService) {
		const currentDate = new Date();
		config.minDate = { year: 2005, month: 1, day: 1 };
		config.maxDate = { year: 2007, month: 12, day: 31 };
		// config.minDate = {day: 1, month: 1, year: 1920};
		// config.maxDate = {day: currentDate.getDate(), month: currentDate.getMonth() + 1, year: currentDate.getFullYear() - 1};
		console.log(config.maxDate);
		this.occupations$ = occupationService.getOccupations();
		this.form = fb.group({
			name: ['', Validators.required],
			dateOfBirth: ['', Validators.required],
			occupationId: ['', Validators.required],
			sumInsured: ['', Validators.required]
		});
	}

	ngOnInit(): void {
		this.form.valueChanges.pipe(debounceTime(500)).subscribe(result => {
			if (this.form.valid) {
				this.customerDetailsSubmitted.next(this.form.value);
			}
		})
	}

	submit = () => this.form.valid && this.customerDetailsSubmitted.next(this.form.value);
}