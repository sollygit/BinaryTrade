import { Component, OnInit } from '@angular/core';
import { BinaryTrade } from '../models/binaryTrade.type';
import { TradeService } from '../services/trade.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html'
})
export class ReportsComponent implements OnInit {
  readonly assetList = this.tradeService.AssetList;
  trades: BinaryTrade[];
  mostUsedReport = true;
  mostUsedAssets = [];

  constructor(private tradeService: TradeService) { }

  ngOnInit() {
    this.getMostUsedAssets();
  }

  getMostUsedAssets() {
    this.tradeService.getAll()
      .subscribe(trades => {
        this.trades = trades;
        for (let i = 0; i < this.assetList.length; i++) {
          const assetName = this.assetList[i].name;
          const used = this.trades.filter(t => t.asset.name === assetName).map(o => o).length;
          this.mostUsedAssets.push({ asset: assetName, used: used });
        }
        this.mostUsedAssets.sort((a, b) => (a.used > b.used ? -1 : 1));
      },
        error => {
          console.log(error);
          this.trades = null;
        });
  }

  showMostUsed(show: boolean): void {
    this.mostUsedReport = show;
  }

  public get TotalCount() { return this.tradeService.TotalCount; }

  public get MostUsedAssets() { return this.mostUsedAssets; }

}
