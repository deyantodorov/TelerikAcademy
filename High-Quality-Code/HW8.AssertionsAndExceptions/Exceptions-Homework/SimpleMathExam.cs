﻿namespace Exceptions_Homework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private int problemSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get { return this.problemSolved; }

            private set
            {
                if (value < 0)
                {
                    this.problemSolved = 0;
                }
                else if (value > 10)
                {
                    this.problemSolved = 10;
                }

                // I don't know which is correct implementation this or set value
                // else
                // {
                //    throw new ArgumentOutOfRangeException("ProblemSolved is out of range 0-10");
                // }
                this.problemSolved = value;
            }
        }

        public override ExamResult Check()
        {
            switch (this.ProblemsSolved)
            {
                case 0:
                    return new ExamResult(2, 2, 6, "Bad result: nothing done.");
                case 1:
                    return new ExamResult(4, 2, 6, "Average result: nothing done.");
                case 2:
                    return new ExamResult(6, 2, 6, "Average result: nothing done.");
                default:
                    throw new ArgumentOutOfRangeException("Invalid number of problems solved");
            }
        }
    }
}