export interface LibeyUser{
    documentNumber:string;
    documentTypeId:number;
    documentTypeDescription: string
    name:string;
    fathersLastName :string;
    mothersLastName :string;
    address :string;
    regionCode :string;
    provinceCode :string;       
    ubigeoCode :string;
    phone :string;
    email :string;
    password :string;
    active :boolean;
}