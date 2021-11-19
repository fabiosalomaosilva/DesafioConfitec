import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListComponent } from './pages/usuarios/list/list.component';
import { AddComponent } from './pages/usuarios/add/add.component';
import { EditComponent } from './pages/usuarios/edit/edit.component';
import { HttpClientModule } from '@angular/common/http';
import { EnumToArrayPipe } from './pipes/EnumToArrayPipe';

@NgModule({
  declarations: [
    AppComponent,
    EnumToArrayPipe,
    ListComponent,
    AddComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
