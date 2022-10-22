import { Customer } from "./customer.model";

export interface Premium {
    customer: Customer;
    insurancePremium: number;
}