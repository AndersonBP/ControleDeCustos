import { NgModule } from '@angular/core';
import { HttpService } from '@app/core';
import { FuncionarioService } from '@app/core/services/funcionario.service';
import { HttpClient } from '@app/core/http/http-client';
import { DepartamentoService } from '@app/core/services/departamento.service';
import { Movimentacao } from '@app/core/services/model/Movimentacao.model';
import { MovimentacaoService } from '@app/core/services/Movimentacao.service';

@NgModule({
  imports: [

  ],
  declarations: [
  ],
  providers: [
    HttpClient,
    FuncionarioService,
    DepartamentoService,
    MovimentacaoService
  ]
})
export class ServicesModule { }
