namespace PlaneSpotterBackEnd.Models.Database
{
   /*
    * Holds common attributes for all DB entities. 
    */
    public abstract class BaseEntity
    {
        public bool IsDeleted { get; set; }
    }
}
