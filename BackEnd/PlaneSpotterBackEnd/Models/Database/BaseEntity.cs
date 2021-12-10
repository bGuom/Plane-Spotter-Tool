namespace PlaneSpotterBackEnd.Models.Database
{
   /*
    * Holds common attributes for all DB entities. 
    */
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            IsDeleted = false;
        }
        public bool IsDeleted { get; set; }
    }
}
