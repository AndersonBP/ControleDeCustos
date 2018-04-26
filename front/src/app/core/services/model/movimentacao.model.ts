import { Model } from '@app/core/services/model/ModelBase';

export class Movimentacao extends Model {

    public nome: string;

    public static Create(input: any): Movimentacao {
        let obj = new Movimentacao();
        obj.codigo = input.codigo;
        obj.nome = input.nome;
       

        return obj;
    }
}