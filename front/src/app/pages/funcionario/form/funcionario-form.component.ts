import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


import { FormAbstract } from '../../abstract/form.abstract';
import { Funcionario } from '@app/core/services/model/funcionario.model';
import { FuncionarioService } from '@app/core/services/funcionario.service';
import { IOption } from "ng-select";
import { DepartamentoService } from '@app/core/services/departamento.service';
import { DepartamentoSeletor } from '@app/core/services/seletores/departamento.seletor';
import { Departamento } from '@app/core/services/model/departamento.model';

@Component({
    selector: 'app-funcionario-form',
    templateUrl: './funcionario-form.component.html',
    styleUrls: []
})
export class FuncionarioFormComponent extends FormAbstract<Funcionario, FuncionarioService> implements OnInit {

    private deptoSelecionado: any;
    private listDepartamentos: Departamento[] = [];
    private departamentoOptions: IOption[] = [];


    constructor(
        service: FuncionarioService,
        activeRoute: ActivatedRoute,
        router: Router,
        private _departamentoService: DepartamentoService,
    ) {
        super(service, activeRoute, router);
        this.carregarDepartamentos();
    }

    ngOnInit() {
        this.query();
    }
    salvar(){
        this.Object.departamentoCodigo = this.deptoSelecionado as number;
        this.save();
    }

    carregarDepartamentos() {
        let sel = new DepartamentoSeletor();
        this._departamentoService.list(sel).subscribe(res => {
            this.listDepartamentos = res.Data;
            this.departamentoOptions = this.listDepartamentos.map(dept => {
                return { label: dept.nome, value: dept.codigo.toString() } as IOption;
            });
            this.deptoSelecionado = res.Data[0];
        });
    }
}
