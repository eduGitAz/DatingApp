import { Customer } from "./customer";
import { Device } from "./device";
import { OrderStatus } from "./orderStatus";
import { OrderType } from "./orderType";

export interface Order {
    id: number;
    customerId: number;
    appCustomer: Customer;
    deviceId: number;
    appDevice: Device;
    scheduledDate: Date; 
    orderStatusId: number;
    appOrderStatus: OrderStatus;
    orderTypeId: number;
    appOrderType: OrderType;
} 