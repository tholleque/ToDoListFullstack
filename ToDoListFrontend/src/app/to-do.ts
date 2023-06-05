// To parse this data:
//
//   import { Convert, ToDo } from "./file";
//
//   const toDo = Convert.toToDo(json);

export interface ToDo {
    id:                   number;
    name:                 string;
    description:          string;
    assignedTo:           number;
    hoursNeeded:          number;
    isCompleted:          boolean;
    assignedToNavigation: null;
}

// Converts JSON strings to/from your types
export class Convert {
    public static toToDo(json: string): ToDo {
        return JSON.parse(json);
    }

    public static toDoToJson(value: ToDo): string {
        return JSON.stringify(value);
    }
}
