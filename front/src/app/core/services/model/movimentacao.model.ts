import { Model } from '@app/core/services/model/ModelBase';

export class Movimentacao extends Model {

    public descricao: string;
    public funcionarioCodigo: number;
    public valor: number;

    public static Create(input: any): Movimentacao {
        let obj = new Movimentacao();
        obj.codigo = input.codigo;
        obj.descricao = input.descricao;
        obj.funcionarioCodigo = input.funcionarioCodigo;
        obj.valor = input.valor;
       
        return obj;
    }
}