import { StudentInClass } from "./StudentInClass";

export class YogaLessonDto{
    id: number|null;
    day: number;
    startingTime: any;
    endTime: any;
    classLevel: number;
    studentsIds: number[]=[];

    /**
     *
     */
    constructor(day,startingTime,endTime) {
        this.day=day;
        this.startingTime=startingTime;
        this.endTime=endTime;
      
        
    }
}