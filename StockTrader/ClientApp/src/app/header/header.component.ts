import { Component } from '@angular/core';
import { TradeService } from '../services/trade.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  logo = require('../../assets/images/logo.png');
  constructor(private tradeService: TradeService) { }

  public get TotalAmount() { return this.tradeService.TotalAmount; }

}
