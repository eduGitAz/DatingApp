import { Member } from "./member";


export interface Company {
    id: number;
    companyName: string;
    taxNumber: string;
    fgazNumber: string;
    streetNumber: string;
    city: string;
    postCode: string;
    users: Member[];
}
