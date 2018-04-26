
import { Model } from  '../../core/services/model/ModelBase';
import { ServiceBase } from '../../core//services/SeviceBase';
import { Seletor } from '../../core//services/seletores/SeletorBase';

export abstract class ListAbstract<E extends Model, T extends Seletor, S extends ServiceBase<T, E>>  {

    private _service: S;
    private _seletor: T;
    private _totalItems: number;

    private _list: E[];

    constructor(service: S, seletor: T){
        this.Seletor = seletor;
        this._service = service;
        this._totalItems = 0;
    }

    get Seletor(): T {
        return this._seletor;
    }

    set Seletor(seletor: T) {
        this._seletor = seletor;
    }

    get Service(): S {
        return this._service;
    }

    get TotalItens(): number{
        return this._totalItems;
    }

    get List(): E[]{        
        return this._list;
    }

    public query() {
        this.Service.list(this.Seletor).subscribe(data => {
            this._totalItems = data.TotalRows;
            this._list = data.Data;
        });
    }

    setOrder(field: string) {
        this.Seletor.OrderBy = field;
        this.Seletor.OrderByOrder = this.Seletor.OrderByOrder == "ASC" ? "DESC" : "ASC"
        this.query();
    }

    changePage(e: any) {
        this.Seletor.Pagina = e.page;
        this.query();
    }
}