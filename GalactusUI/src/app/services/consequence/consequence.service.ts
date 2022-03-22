import { Injectable } from '@angular/core';
import { BehaviorSubject, shareReplay, tap } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Config } from 'src/config';
import { IConsequence } from 'src/models/IConsequence';

@Injectable({
  providedIn: 'root'
})
export class ConsequenceService {
  private endpointBaseUrl: string;
  private consequenceSubject = new BehaviorSubject<IConsequence>({id: -1, body: "Greetings. I am ConsequenceBot.", mood: {id: -1, name: ""}});
  consequence$ = this.consequenceSubject.asObservable();

  constructor(private http: HttpClient) {
    let config = new Config();
    this.endpointBaseUrl = config.consequenceEndpointBaseUrl;
   }

   getConsequence(reactionBotMood: number){
    return this.http.get<IConsequence>(this.endpointBaseUrl + reactionBotMood, {
      headers: new HttpHeaders({
      "Content-Type": "Application/json"
      })
    })
    .pipe(
      tap(consequence => {
        this.consequenceSubject.next(consequence);
      }),
      shareReplay()
    ).subscribe();
  }
}
