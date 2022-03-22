import { Injectable } from '@angular/core';
import { BehaviorSubject, shareReplay, tap } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Config } from 'src/config';

@Injectable({
  providedIn: 'root'
})
export class MoodService {
  private endpointBaseUrl: string;
  private moodSubject = new BehaviorSubject<string[]>([])
  moods$ = this.moodSubject.asObservable();

  constructor(private http: HttpClient) {
    let config = new Config();
    this.endpointBaseUrl = config.moodEndpointBaseUrl;
   }

   loadMoods(){
    return this.http.get<string[]>(this.endpointBaseUrl, {
      headers: new HttpHeaders({
      "Content-Type": "Application/json"
      })
    })
    .pipe(
      tap(moods => {
        this.moodSubject.next(moods);
      }),
      shareReplay()
    ).subscribe();
  }
}
