namespace Sales
{
    public interface ISalesUnitBuilder
    {
        public SalesUnit Build();
    }

    public interface ISalesMemberBuilder
    {
        public ISalesUnitBuilder WithGroup
            (Action<SalesGroupBuilder> groupBuilder);

        public ISalesUnitBuilder WithAgent
            (Action<SalesAgentBuilder> agentBuilder);
    }

    public class SalesUnitBuilder : 
        ISalesUnitBuilder, ISalesMemberBuilder
    {
        private SalesUnit _unit;

        public ISalesUnitBuilder WithGroup
            (Action<SalesGroupBuilder> groupBuilder)
        {
            var builder = new SalesGroupBuilder();
            groupBuilder.Invoke(builder);

            _unit = builder.Build();

            return this;
        }

        public ISalesUnitBuilder WithAgent
            (Action<SalesAgentBuilder> agentBuilder)
        {
            var builder = new SalesAgentBuilder();
            agentBuilder.Invoke(builder);

            _unit = builder.Build();

            return this;
        }

        public SalesUnit Build()
        {
            return _unit;
        }
    }

    public class SalesGroupBuilder
    {
        private IList<SalesUnit> _units = new List<SalesUnit>();
        private string _groupName;

        public SalesGroupBuilder GroupNamed(string groupName)
        {
            _groupName = groupName;
            return this;
        }

        public SalesGroupBuilder WithMember
            (Action<SalesAgentBuilder> agentBuilder)
        {
            var builder = new SalesAgentBuilder();
            agentBuilder.Invoke(builder);

            _units.Add(builder.Build());

            return this;
        }

        public SalesGroup Build()
        {
            return new SalesGroup(_groupName, _units);
        }
    }

    public class SalesAgentBuilder
    {
        private string _agentName;

        public SalesAgentBuilder MemberNamed(string agentName)
        {
            _agentName = agentName;
            return this;
        }

        public SalesAgent Build()
        {
            return new SalesAgent(_agentName);
        }
    }

}
