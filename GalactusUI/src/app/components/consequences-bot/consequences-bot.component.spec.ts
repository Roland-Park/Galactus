import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsequencesBotComponent } from './consequences-bot.component';

describe('ConsequencesBotComponent', () => {
  let component: ConsequencesBotComponent;
  let fixture: ComponentFixture<ConsequencesBotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsequencesBotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsequencesBotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
