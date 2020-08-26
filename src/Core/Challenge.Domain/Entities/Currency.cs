using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Entities
{
    public sealed class Currency :
        ICurrency
    {
        public Currency(
            string code, 
            string name, 
            string symbol) 
        {
            this.Code = code;
            this.Name = name;
            this.Symbol = symbol;
        }

        public string Code { get; private set; }

        public string Name { get; private set; }

        public string Symbol { get; private set; }
    }
}
