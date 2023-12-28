export interface licenseInfo{
    id : string | null;
    contact : string | null;
    impactLevel : number | null
    startDate : string | null;
    expireDate : string | null;
    productName : string | null;
    departmentName : string | null;
    isActive : boolean | null;
    createdOn : string | null;
    numOfDevices : number | null;
    serialKey : string | null;
    impactDescription : string | null;
    timeType : number | null;
    priceInUSD : string | null;
    priceInLYD : string | null;
}

export interface licenseInfoResponse {
    content: licenseInfo;
    msg: string;
}