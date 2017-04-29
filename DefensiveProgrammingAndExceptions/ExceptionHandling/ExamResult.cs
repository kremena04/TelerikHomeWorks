using System;


namespace ExceptionHandling
{
    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private string comments;
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (maxGrade <= minGrade)
            {
                throw new ArgumentOutOfRangeException("Max grade must be bigger than Min grade!");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Grade must be greater than or equal to 0!");
                }

                this.grade = value;
            }
        }
        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Min grade must be greater than or equal to 0!");
                }

                this.minGrade = value;
            }
            }
        public string Comments
        {
            get
            {
                return this.comments;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Comments are missing!");
                }

                this.comments = value;
            }
        }

        public int MaxGrade { get; private set; }
    }
        
 }


