import { Product } from "../../product/model/product";

export interface ICartItem {
   _productId: number,
   _quantity: number,
   _unitPrice: number,
  _totalPrice: number,
  _product: Product
}
