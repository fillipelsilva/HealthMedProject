using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMed.Domain.Entities
{
    public abstract class EntityBase : IEquatable<Guid>
    {
        public Guid Id { get; private set; }
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        public virtual ValidationResult IsValid()
        {
            throw new NotImplementedException();
        }

        protected EntityBase()
            => Id = Guid.NewGuid();

        public bool Equals(Guid id)
            => Id == id;

        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
