import { Component, OnInit } from '@angular/core';
import { ListAbstract } from '@app/pages/abstract/list.abstract';
import { Movimentacao } from '@app/core/services/model/Movimentacao.model';
import { MovimentacaoSeletor } from '@app/core/services/seletores/Movimentacao.seletor';
import { MovimentacaoService } from '@app/core/services/Movimentacao.service';
import { HttpService } from '@app/core';
import { IOption } from "ng-select";
import { FuncionarioService } from '@app/core/services/funcionario.service';
import { FuncionarioSeletor } from '@app/core/services/seletores/Funcionario.seletor';
import { Funcionario } from '@app/core/services/model/funcionario.model';

@Component({
  selector: 'app-movimentacao',
  templateUrl: './movimentacao.component.html',
  styleUrls: ['./movimentacao.component.scss']
})
export class MovimentacaoComponent extends ListAbstract<Movimentacao, MovimentacaoSeletor, MovimentacaoService> implements OnInit {
  private funcSelecionado: any;
  private listFuncionario: Funcionario[] = [];
  private funcionarioOpcoes: IOption[] = [];
  seletor: MovimentacaoSeletor;


  constructor(private service: MovimentacaoService, private _funtionarioService: FuncionarioService) {
    super(service, new MovimentacaoSeletor());
    this.seletor = new MovimentacaoSeletor();
    this.carregarFuncionarios();
  }

  ngOnInit() {
    this.query();
  }

  filtrar() {
    this.seletor.funcionarioCodigo = this.funcSelecionado ? this.funcSelecionado as number : 0;
    this.service.list(this.seletor).subscribe(res => {
      this._list = res.Data;
    })
  }

  carregarFuncionarios() {
    let sel = new FuncionarioSeletor();
    this._funtionarioService.list(sel).subscribe(res => {
      this.listFuncionario = res.Data;
      this.funcionarioOpcoes = this.listFuncionario.map(func => {
        return { label: func.nome, value: func.codigo.toString() } as IOption;
      });
    });
  }

}
