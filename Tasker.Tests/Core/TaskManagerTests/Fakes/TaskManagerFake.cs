using System.Collections.Generic;
using Tasker.Core;
using Tasker.Models.Contracts;

namespace Tasker.Tests.Core.TaskManagerTests.Fakes
{
    internal class TaskManagerFake : TaskManager
    {
        public TaskManagerFake(IIdProvider provider, ILogger logger) : base(provider, logger)
        {
        }

        public ICollection<ITask> ExposedTasks
        {
            get
            {
                return base.Tasks;
            }
        }
    }
}
