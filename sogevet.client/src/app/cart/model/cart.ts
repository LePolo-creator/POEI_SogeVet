import { CartItem } from "./cart-item";

export class Cart {
  public get cartItems(): Array<CartItem> {
      return this._cartItems;
  }
  public set cartItems(value: Array<CartItem>) {
      this._cartItems = value;
  }
  public get totalPrice(): number {
      return this._totalPrice;
  }
  public set totalPrice(value: number) {
      this._totalPrice = value;
  }
  constructor(
    //private _userId: number,
    private _cartItems: Array<CartItem>,
    private _totalPrice: number

  ) { }
}
