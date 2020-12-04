import { ClassParticipated } from "./ClassParticipated";

export class Person{
    id :number | null;
    name: string;
    phone:string;
    level: number;
    isActive:boolean;
    birthday: string;
    totalPaid:number;
    debt:number;
    studentClasses: ClassParticipated[];
}