namespace BlunderYears.Data.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class EnumEntity<TEnum> : IdentityEntity<TEnum>
        where TEnum : struct, Enum
    {
        public new TEnum? Id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
