using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core;
using Tasker.Models.Contracts;

namespace Tasker.Tests.Core.TaskManagerTests.Fakes
{
    public class TaskManagerFake : TaskManager
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
