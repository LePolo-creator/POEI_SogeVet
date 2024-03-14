import { Order } from "src/app/user/model/order";

export class User {
  public get orders(): Array<Order> {
    return this._orders;
  }
  public set orders(value: Array<Order>) {
    this._orders = value;
  }
  public get firstName(): string {
    return this._firstName;
  }
  public set firstName(value: string) {
    this._firstName = value;
  }
  public get lastName(): string {
    return this._lastName;
  }
  public set lastName(value: string) {
    this._lastName = value;
  }
  public get email(): string {
    return this._email;
  }
  public set email(value: string) {
    this._email = value;
  }
  public get address(): string {
    return this._address;
  }
  public set address(value: string) {
    this._address = value;
  }


  public get id(): number {
    return this._id;
  }
  public set id(value: number) {
    this._id = value;
  }

  constructor(
    private _id: number,
    private _firstName: string,
    private _lastName: string,
    private _email: string,
    private _address: string,
    private _orders: Array<Order>

  ) { }
}
