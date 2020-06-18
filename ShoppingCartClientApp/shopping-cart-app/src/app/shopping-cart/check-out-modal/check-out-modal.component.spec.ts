import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckOutModalComponent } from './check-out-modal.component';

describe('CheckOutModalComponent', () => {
  let component: CheckOutModalComponent;
  let fixture: ComponentFixture<CheckOutModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckOutModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckOutModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
