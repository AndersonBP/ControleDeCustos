import { NgModule } from '@angular/core';
import { HttpService } from '@app/core';
import { FuncionarioService } from '@app/core/services/funcionario.service';
import { HttpClient } from '@app/core/http/http-client';
import { DepartamentoService } from '@app/core/services/departamento.service';

@NgModule({
  imports: [

  ],
  declarations: [
  ],
  providers: [
    HttpClient,
    FuncionarioService,
    DepartamentoService
  ]
})
export class ServicesModule { }
