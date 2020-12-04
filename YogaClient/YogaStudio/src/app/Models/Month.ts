import { Week } from './Week';
import { ClassParticipated } from './ClassParticipated';
export class Month{
    id:number|null;
    monthName:string;
    year:string;
    classesInMonth: ClassParticipated[];
    weeks: Week[];
}