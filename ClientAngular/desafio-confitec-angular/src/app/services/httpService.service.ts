import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService<T> {

  constructor(
    protected http: HttpClient, 
    @Inject(String) protected baseUri:string
    ) { }

  get() {
    return this.http.get<T[]>(this.baseUri).pipe(take(1));
  }

  getByID(id: number) {
    return this.http.get<T>(this.baseUri + "/" + id).pipe(take(1));
  }

  add(obj: T) {
    return this.http.post(this.baseUri, obj).pipe(take(1));
  }

  edit(obj: T) {
    return this.http.put(this.baseUri, obj).pipe(take(1));
  }

  delete(id: number) {
    return this.http.delete(this.baseUri + "/" + id).pipe(take(1));
  }  
}
