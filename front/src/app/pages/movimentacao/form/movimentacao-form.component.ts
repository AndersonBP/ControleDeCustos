import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


import { FormAbstract } from '../../abstract/form.abstract';
import { Movimentacao } from '@app/core/services/model/Movimentacao.model';
import { MovimentacaoService } from '@app/core/services/Movimentacao.service';
import { IOption } from "ng-select";

@Component({
    selector: 'app-movimentacao-form',
    templateUrl: './movimentacao-form.component.html',
    styleUrls: []
})
export class MovimentacaoFormComponent extends FormAbstract<Movimentacao, MovimentacaoService> implements OnInit {
    
    deptoSelecionado: any;
    
    constructor(
        service: MovimentacaoService,
        activeRoute: ActivatedRoute,
        router: Router
    ) {
        super(service, activeRoute, router);
    }

    ngOnInit() {
        this.query();
    }
}
