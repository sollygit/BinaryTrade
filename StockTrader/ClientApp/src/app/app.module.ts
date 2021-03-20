import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { ConfigurationService } from './services/configuration.service';
import { TradeService } from './services/trade.service';
import { BooleanPipe } from './pipes/boolean.pipe';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { FetchTradesComponent } from './fetch-trades/fetch-trades.component';
import { TradeComponent } from './trade/trade.component';
import { ReportsComponent } from './reports/reports.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HeaderComponent,
    HomeComponent,
    FetchTradesComponent,
    TradeComponent,
    ReportsComponent,
    BooleanPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'trades', component: FetchTradesComponent },
      { path: "trades/new", component: TradeComponent },
      { path: "trades/:id", component: TradeComponent },
      { path: 'reports', component: ReportsComponent }
    ])
  ],
  providers: [
    ConfigurationService,
    TradeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
