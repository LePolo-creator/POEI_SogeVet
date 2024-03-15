import { OrderItems } from "./order-items";

export interface IOrderToDisplay {
  id: number,
  status: string,
  address: string,
  orderItems: Array<OrderItems>,
  totalPrice: number,
  totalQuantity: number
}
