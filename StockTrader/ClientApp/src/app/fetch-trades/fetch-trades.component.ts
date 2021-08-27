import { Component, OnInit } from '@angular/core';
import { BinaryTrade } from '../models/binary-trade.type';
import { TradeService } from '../services/trade.service';

@Component({
  selector: 'app-fetch-trades',
  templateUrl: './fetch-trades.component.html'
})
export class FetchTradesComponent implements OnInit {
  loading = false;
  public trades: BinaryTrade[];

  constructor(private tradeService: TradeService) { }

  ngOnInit() {
    this.getTrades();
  }

  getTrades() {
    this.tradeService.getAll()
      .subscribe(trades => {
        trades.map(m => m.id = m.id.toUpperCase());
        this.trades = trades;
      },
        error => {
          console.log(error);
          this.trades = null;
        });
  }

  deleteTrade(id: string) {
    this.tradeService.delete(id)
      .subscribe(() => {
        this.getTrades();
      });
  }

  autoTrade() {
    this.tradeService.generate()
      .subscribe(() => {
        this.getTrades();
      });
  }

}


