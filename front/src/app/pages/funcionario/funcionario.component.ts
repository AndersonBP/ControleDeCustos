import { Component, OnInit } from '@angular/core';
import { ListAbstract } from '@app/pages/abstract/list.abstract';
import { Funcionario } from '@app/core/services/model/funcionario.model';
import { FuncionarioSeletor } from '@app/core/services/seletores/Funcionario.seletor';
import { FuncionarioService } from '@app/core/services/funcionario.service';
import { HttpService } from '@app/core';

@Component({
  selector: 'app-funcionario',
  templateUrl: './funcionario.component.html',
  styleUrls: ['./funcionario.component.scss']
})
export class FuncionarioComponent extends ListAbstract<Funcionario, FuncionarioSeletor, FuncionarioService> implements OnInit {

  constructor(private service: FuncionarioService) {
    super(service, new FuncionarioSeletor());
  }

  ngOnInit() {
    this.query();
  }

}
