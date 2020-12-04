import { Person } from './Person';

export class ClassParticipated{
    id: number|null;
    date:string;
    paid:number;
    debt:number;
    personId:number;
    person:Person;

    constructor(date:string,paid:number, debt:number) 
    {
       this.date=date;
       this.paid=paid;
       this.debt=debt;
    }
}