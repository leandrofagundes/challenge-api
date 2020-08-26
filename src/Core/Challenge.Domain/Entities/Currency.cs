using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Entities
{
    public abstract class Currency :
        ICurrency
    {
        public string Code { get; protected set; }
        public string Name { get; protected set; }
        public string Symbol { get; protected set; }

        protected Currency(
            string code,
            string name,
            string symbol)
        {
            this.Code = code;
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}