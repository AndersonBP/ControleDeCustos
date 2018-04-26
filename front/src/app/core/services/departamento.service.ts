import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { DepartamentoSeletor } from '@app/core/services/seletores/departamento.seletor';
import { Departamento } from '@app/core/services/model/departamento.model';
import { ServiceBase } from '@app/core/services/SeviceBase';
import { Response } from '../services/model/Response';
import { HttpClient } from '@app/core/http/http-client';

@Injectable()
export class DepartamentoService extends ServiceBase<DepartamentoSeletor, Departamento> {

    constructor(http: HttpClient) {
        super('departamento', http);
    }

    createEntity(input: any): Departamento {
        return Departamento.Create(input);
        
    }

}
