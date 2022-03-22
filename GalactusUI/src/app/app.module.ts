import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ReactionBotComponent } from './components/reaction-bot/reaction-bot.component';
import { ConsequencesBotComponent } from './components/consequences-bot/consequences-bot.component';

@NgModule({
  declarations: [
    AppComponent,
    ReactionBotComponent,
    ConsequencesBotComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
