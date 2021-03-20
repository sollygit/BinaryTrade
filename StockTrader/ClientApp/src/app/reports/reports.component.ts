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
  shortLongAssets = [];
  totalUsed = 0;
  totalShort = 0;
  totalLong = 0;

  constructor(private tradeService: TradeService) { }

  ngOnInit() {
    this.getMostUsedAssets();
    this.getLongShort();
  }

  getMostUsedAssets() {
    this.tradeService.getAll()
      .subscribe(trades => {
        this.trades = trades;
        for (let i = 0; i < this.assetList.length; i++) {
          const assetName = this.assetList[i].name;
          const used = this.trades.filter(t => t.asset.name === assetName).map(o => o).length;
          this.mostUsedAssets.push({ asset: assetName, used: used });
          this.totalUsed += used;
        }
        this.mostUsedAssets.sort((a, b) => (a.used > b.used ? -1 : 1));
      },
        error => {
          console.log(error);
          this.trades = null;
        });
  }

  getLongShort() {
    this.tradeService.getAll()
      .subscribe(trades => {
        this.trades = trades;
        for (let i = 0; i < this.assetList.length; i++) {
          const assetName = this.assetList[i].name;
          const short = this.trades.filter(t => t.asset.name === assetName && t.direction === 0).map(o => o).length;
          const long = this.trades.filter(t => t.asset.name === assetName && t.direction === 1).map(o => o).length;
          this.shortLongAssets.push({ asset: assetName, short: short, long: long });
          this.totalShort += short;
          this.totalLong += long;
        }
      },
        error => {
          console.log(error);
          this.trades = null;
        });
  }

  showMostUsed(show: boolean): void {
    this.mostUsedReport = show;
  }

  public get TotalUsed() { return this.totalUsed; }

  public get MostUsedAssets() { return this.mostUsedAssets; }

  public get ShortLongAssets() { return this.shortLongAssets; }

  public get TotalShort() { return this.totalShort; }

  public get TotalLong() { return this.totalLong; }

}
