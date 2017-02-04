using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Models.Contracts;

namespace Tasker.Core
{
    public class TaskManager
    {
        private readonly IIdProvider idProvider;
        private readonly ILogger logger;
        private ICollection<ITask> tasks;

        public TaskManager(IIdProvider provider, ILogger logger)
        {
            if (provider == null)
            {
                throw new ArgumentNullException();
            }

            if (logger == null)
            {
                throw new ArgumentNullException();
            }

            this.idProvider = provider;
            this.logger = logger;
            this.tasks = new List<ITask>();
        }

        protected ICollection<ITask> Tasks { get; private set; }
        public void Add(ITask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException();
            }

            this.tasks.Add(task);
            this.logger.Log("Task logged successfully");
        }
    }
}
