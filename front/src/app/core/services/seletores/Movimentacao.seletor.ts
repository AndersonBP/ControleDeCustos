import { Seletor } from "@app/core/services/seletores/SeletorBase";

export class MovimentacaoSeletor extends Seletor {
    Create(input: any) {
        throw new Error("Method not implemented.");
    }
    public descricao: string;
    public funcionarioCodigo: number;
   
}