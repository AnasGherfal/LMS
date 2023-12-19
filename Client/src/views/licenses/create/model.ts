export interface License{
    NumOfDevices : number | null;
    SerialKey : string | null;
    ImpactLevel : number | null
    ImpactDescription : string | null;
    StartDate : string | null;
    ExpireDate : string | null;
    ProductId : string | null;
    Contact : string | null;
    TimeType : number | null;
    PriceInUSD : string | null;
    PriceInLYD : string | null;
    DepartmentId : string | null;

}

// public int NumOfDevices { get; set; }
// public string? SerialKey { get; set; }
// public TimeType? TimeType { get; set; }
// public string? Contact { get; set; } 
// public ImpactLevel? ImpactLevel { get; set; }
// public string? StartDate { get; set; }
// public string? ExpireDate { get; set; }
// public string? ImpactDescription { get; set; }
// public decimal? PriceInUSD { get; set; }
// public decimal? PriceInLYD { get; set; }
// public EntityStatus? Status { get; set; }
// public string? DepartmentId { get; set; }
// public string? ProductId { get; set; }