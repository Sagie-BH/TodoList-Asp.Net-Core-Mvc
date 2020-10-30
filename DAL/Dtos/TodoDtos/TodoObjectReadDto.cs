using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoList.Dtos.TodoDtos
{
    public class TodoObjectReadDto
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime SubmitTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
