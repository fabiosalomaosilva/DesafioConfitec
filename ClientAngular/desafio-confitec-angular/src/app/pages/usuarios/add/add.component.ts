import { UsuarioService } from './../../../services/usuario.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { Usuario } from 'src/app/models/usuario';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss'],
})
export class AddComponent implements OnInit {
  public form!: FormGroup;
  public submitted: boolean = false;
  constructor(private service: UsuarioService, private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3)]],
      sobrenome: ['', [Validators.required, Validators.minLength(3)]],
      email: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,63})$/
          ),
        ],
      ],
      dataNascimento: ['', [Validators.required]],
      escolaridade: ['', [Validators.required]],
    });
  }

  get f() {
    return this.form.controls;
  }

  async onSubmit() {
    this.submitted = true;
    console.log(this.form.controls);
    if (this.form.invalid) {
      return;
    }
    const usuario: Usuario = {
      nome: this.form.value.nome,
      sobrenome: this.form.value.sobrenome,
      dataNascimento: this.form.value.dataNascimento,
      email: this.form.value.email,
      escolaridade: parseInt(this.form.value.escolaridade),
    }
    const data = await lastValueFrom(this.service.add(usuario));
    this.router.navigate(['/']);
  }
}
