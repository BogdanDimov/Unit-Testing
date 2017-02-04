using Tasker.Models.Contracts;

namespace Tasker.Tests.Core.Provider.Fake
{
    internal class IdProviderFake : IIdProvider
    {
        public int NextId()
        {
            return default(int);
        }
    }
}
