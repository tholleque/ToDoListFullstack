// To parse this data:
//
//   import { Convert, Employee } from "./file";
//
//   const employee = Convert.toEmployee(json);

import { ToDo } from "./to-do";

export interface Employee {
    id:    number;
    name:  string;
    hours: number;
    title: string;
    toDos: ToDo[];
}

// Converts JSON strings to/from your types
export class Convert {
    public static toEmployee(json: string): Employee {
        return JSON.parse(json);
    }

    public static employeeToJson(value: Employee): string {
        return JSON.stringify(value);
    }
}
