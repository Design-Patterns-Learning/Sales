namespace Sales
{
    public class SalesAgent : SalesUnit
    {
        private long _credits;

        public SalesAgent(string agentName)
        {
            AgentName = agentName;
        }

        public string AgentName { get; private set; }

        public override void PayCommission(long amount)
        {
            _credits += amount;
        }
    }
}