import { Model } from '@app/core/services/model/ModelBase';

export class Departamento extends Model {

    public nome: string;

    public static Create(input: any): Departamento {
        let obj = new Departamento();
        obj.codigo = input.codigo;
        obj.nome = input.nome;
       

        return obj;
    }
}