import { Asset } from "./asset.type";

export class BinaryTrade {
  id: string;
  asset: Asset;
  expiration: number;
  amount: number;
  direction: number;
  payout: number;

  public constructor(
    fields?: {
      id?: number;
      asset?: Asset;
      expiration: number;
      amount: number;
      direction: number;
      payout: number;
    }) {
    if (fields) {
      Object.assign(this, fields);
    }
  }
}
