namespace Sales
{
    public class SalesGroup : SalesUnit
    {
        public SalesGroup(string name, IList<SalesUnit> units)
        {
            Units = units;
            Name = name;
        }

        public string Name { get; private set; }

        public IList<SalesUnit> Units { set; private get; }

        public override void PayCommission(long amount)
        {
            var shareAmount = amount / Units.Count;

            foreach (var salesUnit in Units)
            {
                salesUnit.PayCommission(shareAmount);
            }
        }
    }
}