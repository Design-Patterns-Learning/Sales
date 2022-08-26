namespace Sales.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var group =
                new SalesUnitBuilder()
                    .WithGroup(u => u.GroupNamed("g")
                        .WithMember(m => m.MemberNamed("m1"))
                        .WithMember(m => m.MemberNamed("m2")))
                    .Build();

            group.PayCommission(5000);

            var agent =
                new SalesUnitBuilder()
                    .WithAgent(a => a.MemberNamed("m"))
                    .Build();

            agent.PayCommission(1000);
        }
    }
}