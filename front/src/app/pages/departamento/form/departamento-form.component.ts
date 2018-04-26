import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


import { FormAbstract } from '../../abstract/form.abstract';
import { Departamento } from '@app/core/services/model/departamento.model';
import { DepartamentoService } from '@app/core/services/departamento.service';
import { IOption } from "ng-select";

@Component({
    selector: 'app-departamento-form',
    templateUrl: './departamento-form.component.html',
    styleUrls: []
})
export class DepartamentoFormComponent extends FormAbstract<Departamento, DepartamentoService> implements OnInit {
    
    deptoSelecionado: any;
    
    constructor(
        service: DepartamentoService,
        activeRoute: ActivatedRoute,
        router: Router
    ) {
        super(service, activeRoute, router);
    }

    ngOnInit() {
        this.query();
    }
}
