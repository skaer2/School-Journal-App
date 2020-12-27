using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class SubjectItem
    {
        private readonly int id;
        public int Id { get { return id; } }
        private readonly string title;
        public string Title { get { return title; } }
        private readonly DateTime date;
        public DateTime Date { get { return date; } }
        private readonly string comment;
        public string Comment { get { return comment; } }
        private readonly int maxMark;
        public int MaxMark { get { return maxMark; } }
        private readonly int subjectId;
        public int SubjectId { get { return subjectId; } }

        public SubjectItem(int _id, string _title, string _comment, int _maxMark, int _subjectId)
        {
            id = _id;
            title = _title;
            comment = _comment;
            maxMark = _maxMark;
            subjectId = _subjectId;
        }
    }
}
