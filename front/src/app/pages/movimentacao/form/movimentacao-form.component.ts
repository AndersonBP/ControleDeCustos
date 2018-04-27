import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


import { FormAbstract } from '../../abstract/form.abstract';
import { Movimentacao } from '@app/core/services/model/Movimentacao.model';
import { MovimentacaoService } from '@app/core/services/Movimentacao.service';
import { IOption } from "ng-select";
import { FuncionarioService } from '@app/core/services/funcionario.service';
import { FuncionarioSeletor } from '@app/core/services/seletores/Funcionario.seletor';
import { Funcionario } from '@app/core/services/model/funcionario.model';

@Component({
    selector: 'app-movimentacao-form',
    templateUrl: './movimentacao-form.component.html',
    styleUrls: []
})
export class MovimentacaoFormComponent extends FormAbstract<Movimentacao, MovimentacaoService> implements OnInit {
    
    private funcSelecionado: any;
    private listFuncionario: Funcionario[]=[];
    private funcionarioOpcoes: IOption[] = [];
    
    constructor(
        service: MovimentacaoService,
        activeRoute: ActivatedRoute,
        router: Router,
        private _funtionarioService: FuncionarioService
    ) {
        super(service, activeRoute, router);
        this.carregarFuncionarios();
    }

    ngOnInit() {
        this.query();
    }
    salvar(){
        this.Object.funcionarioCodigo = this.funcSelecionado as number;
        this.save();
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
