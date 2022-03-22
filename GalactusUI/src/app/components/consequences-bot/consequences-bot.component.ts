import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConsequenceService } from 'src/app/services/consequence/consequence.service';
import { IConsequence } from 'src/models/IConsequence';

@Component({
  selector: 'consequences-bot',
  templateUrl: './consequences-bot.component.html',
  styleUrls: ['./consequences-bot.component.css']
})
export class ConsequencesBotComponent implements OnInit {
  public consequence$: Observable<IConsequence>;

  constructor(private consequenceService: ConsequenceService) {}

  ngOnInit(): void {
    this.consequence$ = this.consequenceService.consequence$;
  }
}
