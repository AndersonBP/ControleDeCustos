import { Component, OnInit } from '@angular/core';
import { ListAbstract } from '@app/pages/abstract/list.abstract';
import { Departamento } from '@app/core/services/model/departamento.model';
import { DepartamentoSeletor } from '@app/core/services/seletores/departamento.seletor';
import { DepartamentoService } from '@app/core/services/departamento.service';
import { HttpService } from '@app/core';

@Component({
  selector: 'app-departamento',
  templateUrl: './departamento.component.html',
  styleUrls: ['./departamento.component.scss']
})
export class DepartamentoComponent extends ListAbstract<Departamento, DepartamentoSeletor, DepartamentoService> implements OnInit {

  constructor(private service: DepartamentoService) {
    super(service, new DepartamentoSeletor());
  }

  ngOnInit() {
    this.query();
  }

}
