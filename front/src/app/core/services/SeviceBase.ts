import { Observable } from 'rxjs';


import { Seletor } from './seletores/SeletorBase';
import { Model } from './model/ModelBase';
import { Response } from './model/Response';
import { HttpClient } from '@app/core/http/http-client';

export abstract class ServiceBase<S extends Seletor, M extends Model> {

    constructor(private endpoint: string, private http: HttpClient) { }

    abstract createEntity(input: any): M;

    get Http(): HttpClient {
        return this.http;
    }

    get EndPoint(): string {
        return this.endpoint;
    }

    get(id: number): Observable<Response<M>> {
        return this.http.get(this.endpoint + '/' + id)
            .map(res => {
                const response = new Response<M>();
                response.Data = this.createEntity(res.data) as M;
                console.log(response.Data);
                return response;
            });
    }

    list(seletor: S): Observable<Response<M[]>> {
        return this.http.post(this.endpoint + '/list', seletor)
            .map(res => {
                const response = new Response<M[]>();
                // TODO Remover ---.data.map
                response.Data = res.json().data.map((pp:any) => this.createEntity(pp) as M);
                response.TotalRows = +res.headers.get('x-total-rows');
                return response;
            });
    }

    save(id: number, object: M): Observable<Response<M>> {
        const observer = ((id:any) => {
            // Se for nulo deve ser criado
            if (id == null) {
                console.log(object);
                return this.http.post(this.endpoint + '/create', object)
            } else {
                return this.http.put(this.endpoint + '/' + id, object);
            }
        });

        return observer(id).map(res => {
            let response = new Response<M>();
            response.Data = this.createEntity(res.json()) as M;
            return response;
        });
    }
}