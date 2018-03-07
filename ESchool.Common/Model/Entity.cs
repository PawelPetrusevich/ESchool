using System;

namespace ESchool.Common.Model
{
    /// <summary>
    /// The basic model
    /// </summary>
    public abstract class Entity
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatersDate { get; set; }
        public int? ModifierId { get; set; }
        public DateTime? ModifierDate { get; set; }
    }
}
