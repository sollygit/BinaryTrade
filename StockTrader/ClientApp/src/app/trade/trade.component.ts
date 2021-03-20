import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Asset } from '../models/asset.type';
import { BinaryTrade } from '../models/binaryTrade.type';
import { TradeService } from '../services/trade.service';

@Component({
  selector: 'app-trade',
  templateUrl: './trade.component.html'
})
export class TradeComponent implements OnInit {
  public asset: Asset = new Asset({ id: 1, name: "EUR/USD" });
  public binaryTrade: BinaryTrade = new BinaryTrade({
    asset: this.asset,
    expiration: null,
    amount: null,
    direction: null,
    payout: null
  });
  
  assetList: Asset[];
  tradeAsset = new FormControl();
  selectedAsset = 1;
  isNew = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private tradeService: TradeService) {
  }

  ngOnInit() {
    const tradeId = this.activatedRoute.snapshot.params['id'] as string;
    if (!tradeId) {
      this.isNew = true;
      this.getAssetList();
    }
    else {
      this.getTrade(tradeId);
    }
  }

  getTrade(id: string) {
    this.tradeService.get(id)
      .subscribe(trade => {
        this.binaryTrade = trade;
        this.getAssetList();
      });
  }

  getAssetList() {
    this.tradeService.getAssets()
      .subscribe(assetList => {
        this.assetList = assetList;
        this.selectedAsset = this.binaryTrade.asset && this.binaryTrade.asset.id;
        this.tradeAsset.setValue(this.getSelectedAsset());
      });
  }

  getSelectedAsset() {
    const assets: Asset[] = [];
    if (!this.selectedAsset) return assets;

    this.assetList.map(t => {
      if (this.selectedAsset !== -1) {
        assets.push(t);
      }
    });
    return assets;
  }

  addTrade() {
    this.tradeService.add(this.binaryTrade)
      .subscribe(() => {
        this.router.navigate(["trades"]);
      });
  }

  updateTrade() {
    this.tradeService.update(this.binaryTrade)
      .subscribe(() => {
        this.router.navigate(["trades"]);
      });
  }

  deleteTrade() {
    this.tradeService.delete(this.binaryTrade.id)
      .subscribe(() => {
        this.router.navigate(["trades"]);
      });
  }


}
