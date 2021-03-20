import { Component, OnInit } from '@angular/core';
import { BinaryTrade } from '../models/binaryTrade.type';
import { TradeService } from '../services/trade.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html'
})
export class ReportsComponent implements OnInit {
  trades: BinaryTrade[];
  mostUsedReport = true;
  mostUsedAssets = [];
  result = [];

  constructor(private tradeService: TradeService) { }

  ngOnInit() {
    this.getTrades();
  }

  getTrades() {
    this.tradeService.getAll()
      .subscribe(trades => {
        this.trades = trades;

        this.mostUsedAssets.push({ asset: 'EUR/USD', used: this.trades.filter(t => t.asset.id === 1).map(o => o).length });
        this.mostUsedAssets.push({ asset: 'JPY/USD', used: this.trades.filter(t => t.asset.id === 2).map(o => o).length });
        this.mostUsedAssets.push({ asset: 'GBP/USD', used: this.trades.filter(t => t.asset.id === 3).map(o => o).length });

        this.result = this.mostUsedAssets.reduce(function (r, a) {
          r[a.used] = r[a.used] || [];
          r[a.used].push(a);
          return r;
        }, Object.create(null));

      },
        error => {
          console.log(error);
          this.trades = null;
        });
  }

  getMostUsedAssets() {
    
  }

  showMostUsed(show: boolean): void {
    this.mostUsedReport = show;
  }

  public get TotalCount() { return this.tradeService.TotalCount; }

  public get MostUsedAssets() { return this.mostUsedAssets; }

}
