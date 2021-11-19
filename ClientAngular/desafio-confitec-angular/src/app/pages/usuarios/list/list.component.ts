import { UsuarioService } from './../../../services/usuario.service';
import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Usuario } from 'src/app/models/usuario';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  listaUsuarios: Usuario[] | undefined;
  constructor(private service: UsuarioService) {}

  ngOnInit() {
    this.getAll();
  }

  async getAll() {
    this.listaUsuarios = await lastValueFrom(this.service.get());
    console.log(this.listaUsuarios);
  }
}
