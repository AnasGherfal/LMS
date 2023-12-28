export interface License{
    numOfDevices : number | null;
    serialKey : string | null;
    impactLevel : number | null
    impactDescription : string | null;
    startDate : string | null;
    expireDate : string | null;
    productId : string | null;
    contact : string | null;
    timeType : number | null;
    priceInUSD : string | null;
    priceInLYD : string | null;
    departmentId : string | null;

}

export interface LicenseResponse {
    content: License;
    msg: string;
}