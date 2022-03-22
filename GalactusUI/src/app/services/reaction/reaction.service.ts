import { Injectable } from '@angular/core';
import { BehaviorSubject, shareReplay, tap } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Config } from 'src/config';
import { IReaction } from 'src/models/IReaction';

@Injectable({
  providedIn: 'root'
})
export class ReactionService {
  private endpointBaseUrl: string;
  private unsuspectingBotGreeting: IReaction = {id: -1, body: "And I'm ReactionBot! Let's be friends!"}
  private reactionSubject = new BehaviorSubject<IReaction>(this.unsuspectingBotGreeting);
  reaction$ = this.reactionSubject.asObservable();

  constructor(private http: HttpClient) {
    let config = new Config();
    this.endpointBaseUrl = config.reactionEndpointBaseUrl;
   }

   getReaction(){
    return this.http.get<IReaction>(this.endpointBaseUrl, {
      headers: new HttpHeaders({
      "Content-Type": "Application/json"
      })
    })
    .pipe(
      tap(reaction => {
        this.reactionSubject.next(reaction);
      }),
      shareReplay()
    ).subscribe();
  }
}
