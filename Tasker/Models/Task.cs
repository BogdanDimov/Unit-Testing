using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Models.Contracts;

namespace Tasker.Models
{
    public class Task : ITask
    {
        private int id;
        private string description;

        public Task(string description)
        {
            this.Description = description;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if(value < 0)
                {
                    throw new ArgumentException();
                }

                this.id = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.description = value;
            }
        }

    }
}
