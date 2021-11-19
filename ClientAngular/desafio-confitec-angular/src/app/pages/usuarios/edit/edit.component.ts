import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { Usuario } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss'],
  providers: [DatePipe]
})
export class EditComponent implements OnInit {
  public form!: FormGroup;
  private id: number = 0;
  private objUsuario!: Usuario;
  public submitted: boolean = false;

  constructor(
    private service: UsuarioService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute, 
    private datePipe: DatePipe
  ) {}

  async ngOnInit() {
    this.objUsuario = await lastValueFrom(
      this.service.getByID(this.activatedRoute.snapshot.params['id'])
    );
    this.form = this.fb.group({
      nome: [
        this.objUsuario.nome,
        [Validators.required, Validators.minLength(3)],
      ],
      sobrenome: [
        this.objUsuario.sobrenome,
        [Validators.required, Validators.minLength(3)],
      ],
      email: [
        this.objUsuario.email,
        [
          Validators.required,
          Validators.pattern(
            /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,63})$/
          ),
        ],
      ],
      dataNascimento: [
        this.datePipe.transform(this.objUsuario.dataNascimento, 'yyyy-MM-dd'),
        [Validators.required],
      ],
      escolaridade: [this.objUsuario.escolaridade, [Validators.required]],
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

    const aniversario = new Date(this.form.value.dataNascimento);
    const dataAtual = new Date();
    if (aniversario > dataAtual) {
      alert('Data de nascimento maior que a data atual');
      return;
    }

    const usuario: Usuario = {
      id: this.objUsuario.id,
      nome: this.form.value.nome,
      sobrenome: this.form.value.sobrenome,
      dataNascimento: this.form.value.dataNascimento,
      email: this.form.value.email,
      escolaridade: parseInt(this.form.value.escolaridade),
    };
    const data = await lastValueFrom(this.service.edit(usuario));
    this.router.navigate(['/']);
  }

  toData(date: Date) { 
    return `${date.getDate()}/${date.getMonth}/${date.getFullYear}`; 
  }
}
