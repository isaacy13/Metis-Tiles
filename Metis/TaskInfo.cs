using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Metis
{
    public class TaskInfo
    {
        private String taskName;
        private DateTime? dueDate;
        private String notes;

        public String TaskName { get => taskName; set { taskName = value; } }
        public DateTime? DueDate { get => dueDate; set { dueDate = value; } }
        public String Notes { get => notes; set { notes = value; } }

        public TaskInfo()
        {
            this.TaskName = "";
            this.DueDate = null;
            this.Notes = "";
        }

        public TaskInfo(String taskName, DateTime? dueDate, String notes)
        {
            TaskName = taskName;
            DueDate = dueDate;
            Notes = notes;
        }
    }
}
