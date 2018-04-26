import { Component, OnInit } from '@angular/core';
import { ListAbstract } from '@app/pages/abstract/list.abstract';
import { Movimentacao } from '@app/core/services/model/Movimentacao.model';
import { MovimentacaoSeletor } from '@app/core/services/seletores/Movimentacao.seletor';
import { MovimentacaoService } from '@app/core/services/Movimentacao.service';
import { HttpService } from '@app/core';

@Component({
  selector: 'app-movimentacao',
  templateUrl: './movimentacao.component.html',
  styleUrls: ['./movimentacao.component.scss']
})
export class MovimentacaoComponent extends ListAbstract<Movimentacao, MovimentacaoSeletor, MovimentacaoService> implements OnInit {

  constructor(private service: MovimentacaoService) {
    super(service, new MovimentacaoSeletor());
  }

  ngOnInit() {
    this.query();
  }

}
