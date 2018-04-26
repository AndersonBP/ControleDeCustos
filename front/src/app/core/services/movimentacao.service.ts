import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { MovimentacaoSeletor } from '@app/core/services/seletores/Movimentacao.seletor';
import { Movimentacao } from '@app/core/services/model/Movimentacao.model';
import { ServiceBase } from '@app/core/services/SeviceBase';
import { Response } from '../services/model/Response';
import { HttpClient } from '@app/core/http/http-client';

@Injectable()
export class MovimentacaoService extends ServiceBase<MovimentacaoSeletor, Movimentacao> {

    constructor(http: HttpClient) {
        super('Movimentacao', http);
    }

    createEntity(input: any): Movimentacao {
        return Movimentacao.Create(input);
        
    }

}
