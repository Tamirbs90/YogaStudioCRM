import { ClassParticipated } from './ClassParticipated';
export class YogaLessonToReturn{
    id: number|null;
    day: number;
    startingTime: any;
    endTime: any;
    classLevel: number;
    studentsParticipated: ClassParticipated[];

    /**
     *
     */
    constructor(day,startingTime,endTime, studentsIds) {
        this.day=day;
        this.startingTime=startingTime;
        this.endTime=endTime;
        
    }
}