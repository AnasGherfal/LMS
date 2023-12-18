namespace Common.Constants;

public enum EventType: short
{
    CategoryCreated = 1,
    CategoryUpdated = 2,
    CategoryLocked = 3,
    CategoryUnlocked = 4,
    CategoryDeleted = 5,
    
    ProductCreated = 101,
    ProductUpdated = 102,
    ProductLocked = 103,
    ProductUnlocked = 104,
    ProductDeleted = 105,
}