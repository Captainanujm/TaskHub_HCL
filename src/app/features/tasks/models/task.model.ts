import { TaskStatus } from "./task.enum";

export interface Task{
    id:number,
    title:string;
    description:string,
    status: TaskStatus,
}