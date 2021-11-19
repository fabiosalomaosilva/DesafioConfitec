import { Pipe, PipeTransform } from "@angular/core";
import Escolaridade from "../models/Escolaridade";

@Pipe({
    name: 'enumToArray'
  })
  export class EnumToArrayPipe implements PipeTransform {
    transform(data: number) {
      return Escolaridade[data];
    }
  }