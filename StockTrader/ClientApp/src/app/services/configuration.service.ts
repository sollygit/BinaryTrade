import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class ConfigurationService {
  public static readonly appVersion: string = "1.0.1";
  public baseUrl = environment.baseUrl;

  private _dateFormat = 'dd-MM-yyyy';
  private _directions = [
    { value: 1, display: "UP" },
    { value: 2, display: "DOWN" }
  ];

  get dateFormat() {
    return this._dateFormat;
  }

  get directions() {
    return this._directions;
  }

}
