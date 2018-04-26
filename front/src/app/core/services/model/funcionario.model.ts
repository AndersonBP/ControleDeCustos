import { Model } from '@app/core/services/model/ModelBase';

export class Funcionario extends Model {

    public nome: string;

    public static Create(input: any): Funcionario {
        let obj = new Funcionario();
        obj.codigo = input.codigo;
        obj.nome = input.nome;
       

        return obj;
    }
}