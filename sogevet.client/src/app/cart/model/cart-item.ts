import { Product } from "../../product/model/product";

export class CartItem {
  public get product(): Product {
      return this._product;
  }
  public set product(value: Product) {
      this._product = value;
  }
  public get unitPrice(): number {
      return this._unitPrice;
  }
  public set unitPrice(value: number) {
      this._unitPrice = value;
  }
  public get totalPrice(): number {
    return this._totalPrice;
  }
  public set totalPrice(value: number) {
    this._totalPrice = value;
  }

  public get productId(): number {
    return this._productId;
  }
  public set productId(value: number) {
    this._productId = value;
  }

  public get quantity(): number {
    return this._quantity;
  }
  public set quantity(value: number) {
    this._quantity = value;
  }
  constructor(
    private _productId: number,
    private _quantity: number,
    private _unitPrice: number,
    private _totalPrice: number,
    private _product: Product

  ) { }

}
