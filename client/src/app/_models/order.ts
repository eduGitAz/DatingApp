import { Customer } from "./customer";

export interface Order {
    id: number;
    customerId: number;
    appCustomer: Customer;
}