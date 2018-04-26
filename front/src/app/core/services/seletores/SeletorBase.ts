export abstract class Seletor {

    public Codigo: number;

    public Pagina: number = 1;
    public RegistroPorPagina: number = 10;
    public OrderBy: string;
    public OrderByOrder: string;

    abstract Create(input: any): any;
}