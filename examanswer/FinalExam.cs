using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examanswer
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Body}");
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine($"- {answer.AnswerText}");
                }
            }
        }

    }
}
