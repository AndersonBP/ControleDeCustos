import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { FuncionarioSeletor } from '@app/core/services/seletores/Funcionario.seletor';
import { Funcionario } from '@app/core/services/model/funcionario.model';
import { ServiceBase } from '@app/core/services/SeviceBase';
import { Response } from '../services/model/Response';
import { HttpClient } from '@app/core/http/http-client';

@Injectable()
export class FuncionarioService extends ServiceBase<FuncionarioSeletor, Funcionario> {

    constructor(http: HttpClient) {
        super('funcionario', http);
    }

    createEntity(input: any): Funcionario {
        return Funcionario.Create(input);
        
    }

}
