import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PremiumDetailsComponent } from './premium-details.component';

describe('PremiumDetailsComponent', () => {
  let component: PremiumDetailsComponent;
  let fixture: ComponentFixture<PremiumDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PremiumDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PremiumDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
