import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ReactionService } from 'src/app/services/reaction/reaction.service';
import { IReaction } from 'src/models/IReaction';

@Component({
  selector: 'reaction-bot',
  templateUrl: './reaction-bot.component.html',
  styleUrls: ['./reaction-bot.component.css']
})
export class ReactionBotComponent implements OnInit {
  public reaction$: Observable<IReaction>;

  constructor(private reactionService: ReactionService) { }

  ngOnInit(): void {
    this.reaction$ = this.reactionService.reaction$;
  }

  getReaction(){
    this.reactionService.getReaction();
  }
}
