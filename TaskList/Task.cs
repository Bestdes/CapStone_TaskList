using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    class Task
    {
        private int _taskNumber;
        private string _teamMemberName;
        private string _description;
        private DateTime _dueDate;
        private bool _hasBeenCompleted;


        public int TaskNumber { get => _taskNumber; set => _taskNumber = value; }
        public string TeamMemberName { get => _teamMemberName; set => _teamMemberName = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime DueDate { get => _dueDate; set => _dueDate = value; }
        public bool HasBeenCompleted { get => _hasBeenCompleted; set => _hasBeenCompleted = value; }
        

        public Task(int taskNumber, string teamMemberName, string description, DateTime dueDate, bool hasBeenCompleted)
        {
            TaskNumber = taskNumber;
            TeamMemberName = teamMemberName;
            Description = description;
            DueDate = dueDate;
            HasBeenCompleted = hasBeenCompleted;
        }

        public Task()
        {

        }

        public void DispayTaskProperties()
        {
            Console.WriteLine($"Task Number: {TaskNumber}");
            Console.WriteLine($"Responsible Team Member: {TeamMemberName}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Due Date: {DueDate}");
            Console.WriteLine($"Task Completed: {HasBeenCompleted}\n\n");
        }
    }
}
