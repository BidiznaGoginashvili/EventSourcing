using EventSourcing.Domain.Models;

namespace EventSourcing.Domain.Core
{
    public class ValueObject
    {
        public decimal Amount { get; }
        public Currency Currency { get; }
    }
}
