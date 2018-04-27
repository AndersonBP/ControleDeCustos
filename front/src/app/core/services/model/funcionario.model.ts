import { Model } from '@app/core/services/model/ModelBase';

export class Funcionario extends Model {

    public nome: string;
    public departamentoCodigo: number;

    public static Create(input: any): Funcionario {
        let obj = new Funcionario();
        obj.codigo = input.codigo;
        obj.nome = input.nome;
        obj.departamentoCodigo = input.departamentoCodigo;

        return obj;
    }
}