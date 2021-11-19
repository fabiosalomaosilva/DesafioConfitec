import { UsuarioService } from './../../../services/usuario.service';
import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Usuario } from 'src/app/models/usuario';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  listaUsuarios: Usuario[] | undefined;
  constructor(private service: UsuarioService, private router: Router) {}

  ngOnInit() {
    this.getAll();
  }

  async getAll() {
    this.listaUsuarios = await lastValueFrom(this.service.get());
    console.log(this.listaUsuarios);
  }

  add() {
    this.router.navigate(['/add']);
  }

  edit(obj: Usuario) {
    this.router.navigate([`/edit/${obj.id}`]);
  }

  async delete(obj: Usuario) {
    try {
      const confirm = window.confirm(`Deseja excluir o usuário: ${obj.nome}`);
      if (confirm) {
        await lastValueFrom(this.service.delete(obj.id as number));
      }
      await this.getAll();
    } catch {
      await this.getAll();
    }
  }
}
