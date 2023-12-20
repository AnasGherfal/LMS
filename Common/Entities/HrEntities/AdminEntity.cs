namespace Common.Entities.HrEntities;
public   class AdminEntity
{
     public short EntityId { get; set; }
    public string EntityName { get; set; }
    public short EntityTypeId { get; set; }
    public short? AdministrationId { get; set; }
    public string PhoneNo { get; set; }
    public string LanNo { get; set; }
    public string Email { get; set; }
    public short? ParentId { get; set; }
    public string Note { get; set; }
    public short Status { get; set; }
 }
 
