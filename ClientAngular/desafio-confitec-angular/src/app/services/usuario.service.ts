import { environment } from './../../environments/environment';
import { Usuario } from './../models/usuario';
import { HttpService } from './httpService.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService extends HttpService<Usuario> {

  constructor(protected override http: HttpClient) { 
    super(http, `${environment.desafioUri}usuarios`);
  }
}
