using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTaskList
{
    class Task
    {
        public Task() {
        }

        public Task(string Description, string TeamMember, DateTime DueDate )
        {
            this.Description = Description;
            this.TeamMember = TeamMember;
            this.DueDate = DueDate;
            this.Completed = false;
        }
        public string TeamMember { set; get; }

        public string Description { set; get; }

        public bool Completed { set; get; }

        public DateTime DueDate { set; get; }
    }
}
