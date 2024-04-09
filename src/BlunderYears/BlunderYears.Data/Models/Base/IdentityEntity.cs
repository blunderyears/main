namespace BlunderYears.Data.Models.Base
{
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class IdentityEntity<TId>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TId Id { get; set; }
    }
}
