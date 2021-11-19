import { ListComponent } from './pages/usuarios/list/list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddComponent } from './pages/usuarios/add/add.component';
import { EditComponent } from './pages/usuarios/edit/edit.component';

const routes: Routes = [
  {path: '', component: ListComponent},
  {path: 'add', component: AddComponent},
  {path: 'edit', component: EditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
