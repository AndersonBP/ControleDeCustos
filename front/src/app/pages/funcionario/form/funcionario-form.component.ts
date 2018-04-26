import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


import { FormAbstract } from '../../abstract/form.abstract';
import { Funcionario } from '@app/core/services/model/funcionario.model';
import { FuncionarioService } from '@app/core/services/funcionario.service';
import { IOption } from "ng-select";

@Component({
    selector: 'app-funcionario-form',
    templateUrl: './funcionario-form.component.html',
    styleUrls: []
})
export class FuncionarioFormComponent extends FormAbstract<Funcionario, FuncionarioService> implements OnInit {
    
    deptoSelecionado: any;
    
    constructor(
        service: FuncionarioService,
        activeRoute: ActivatedRoute,
        router: Router
    ) {
        super(service, activeRoute, router);
    }

    ngOnInit() {
        this.query();
    }
}
