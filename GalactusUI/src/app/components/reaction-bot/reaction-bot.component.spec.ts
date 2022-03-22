import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactionBotComponent } from './reaction-bot.component';

describe('ReactionBotComponent', () => {
  let component: ReactionBotComponent;
  let fixture: ComponentFixture<ReactionBotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReactionBotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReactionBotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
