using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examanswer
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Body}");
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine($"- {answer.AnswerText}");
                }
                Console.WriteLine($"Correct Answer: {question.AnswerList[question.RightAnswerId - 1].AnswerText}");
            }
        }
    }
}
