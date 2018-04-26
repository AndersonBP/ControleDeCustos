import { ActivatedRoute, Params, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { Model } from  '../../core/services/model/ModelBase';
import { ServiceBase } from '../../core//services/SeviceBase';
import { Seletor } from '../../core//services/seletores/SeletorBase';



export abstract class FormAbstract<T extends Model, X extends ServiceBase<Seletor, T>>  {

    private _service: X;
    private _totalItems: number;
    private _router: Router;
    private _activeRoute: ActivatedRoute;

    private _object: T;
    private _id: number;

    constructor(service: X, activeRoute: ActivatedRoute, router: Router) {
        this._service = service;
        this._activeRoute = activeRoute;
        this._router = router;
    }

    get Id(): number {
        return this._id;
    }

    get Service(): X {
        return this._service;
    }

    get Object(): T {
        return this._object;
    }

    get Router(): Router {
        return this._router;
    }

    get ActiveRoute(): ActivatedRoute {
        return this._activeRoute;
    }

    set Object(object: T) {
        this._object = object;
    }

    // Metodo usado para preencher os formularios ap editar um item
    query() {
        this._activeRoute.params.subscribe((params: Params) => {
            let id = params['id'];

            if (id == undefined) {
                this._id = null;
                this.Object = ({} as T);
            } else {
                this._id = id;
                this.Service.get(this._id).subscribe(data => {
                    this.Object = data.Data;
                });
            }
        });
    }

    // Metodo usado para inicilizar as listas dos formularios
    querySupport() {
        this._activeRoute.params.subscribe((params: Params) => {
                this._id = null;
                this.Object = ({} as T);
        });
    }

    save() {
        debugger;
        this.Service.save(this.Id, this.Object).subscribe(res => {
            this._router.navigate(['../'], { relativeTo: this._activeRoute });
        });
    }
}