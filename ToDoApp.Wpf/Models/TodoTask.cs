using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Wpf.Models
{
    [System.Serializable]
    class TodoTask
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        public System.DateTime LastSaved { get; set; }

        public string Content { get; set; }


        public TodoTask()
        {
            Content = string.Empty;
            LastSaved = System.DateTime.Now;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content">Content for instance</param>
        public TodoTask(string content)
        {
            Content = content;
            LastSaved = System.DateTime.Now;
        }

    }
}
