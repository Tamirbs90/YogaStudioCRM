import { Person } from './Person';
export class StudentInClass{
    id:number|null;
    student:Person;
    participated:boolean;
    
    constructor(student) {
       this.student=student;
       this.participated=true;
        
    }
}