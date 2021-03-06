﻿using System;


namespace ExceptionHandling
{
    public class SimpleMathExam : Exam
    {
        public int ProblemsSolved { get; private set; }

        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                problemsSolved = 0;
            }
            if (problemsSolved > 10)
            {
                problemsSolved = 10;
            }

            this.ProblemsSolved = problemsSolved;
        }

        public override ExamResult Check()
        {
            switch (ProblemsSolved)
            {
                case 0:
                    return new ExamResult(2, 2, 6, "Bad result: nothing done.");
                case 1:
                    return new ExamResult(4, 2, 6, "Average result: something done.");
                case 2:
                    return new ExamResult(6, 2, 6, "Excellent result: everything done.");
                default:
                    return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
            }
        }
    }
}
