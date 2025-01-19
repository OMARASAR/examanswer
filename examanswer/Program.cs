using examanswer;
using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Subject Name: ");
        string subjectName = Console.ReadLine();
        Console.Write("Enter Subject ID: ");
        int subjectId = int.Parse(Console.ReadLine());

        Subject subject = new Subject(subjectId, subjectName);

        Console.Write("Enter Exam Type (Final/Practical): ");
        string examType = Console.ReadLine();
        Exam exam;

        int examTime;
        do
        {
            Console.Write("Enter Exam Timer (between 30 and 120 minutes): ");
            examTime = int.Parse(Console.ReadLine());
            if (examTime < 30 || examTime > 120)
            {
                Console.WriteLine("Invalid input. Please enter a value between 30 and 120.");
            }
        } while (examTime < 30 || examTime > 120);

        if (examType.ToLower() == "final")
        {
            exam = new FinalExam(examTime, 0); 
        }
        else
        {
            exam = new PracticalExam(examTime, 0);
        }

        Console.Write("Enter Number of Questions: ");
        int numberOfQuestions = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.WriteLine($"\nEnter details for Question {i + 1}:");
            Console.Write("Enter Question Type (MCQ/TrueOrFalse): ");
            string questionType = Console.ReadLine();

            Console.Write("Enter Header: ");
            string header = Console.ReadLine();
            Console.Write("Enter Body: ");
            string body = Console.ReadLine();
            Console.Write("Enter Mark: ");
            int mark = int.Parse(Console.ReadLine());

            if (questionType.ToLower() == "mcq")
            {
                MCQ mcq = new MCQ(header, body, mark);

                Console.WriteLine("Enter 3 Choices:");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Choice {j + 1}: ");
                    mcq.AnswerList.Add(new Answer(j + 1, Console.ReadLine()));
                }

                Console.Write("Enter the index of the correct answer (1, 2, or 3): ");
                mcq.RightAnswerId = int.Parse(Console.ReadLine());

                exam.Questions.Add(mcq);
            }
            else if (questionType.ToLower() == "trueorfalse")
            {
                TrueOrFalse tf = new TrueOrFalse(header, body, mark);

                tf.AnswerList.Add(new Answer(1, "True"));
                tf.AnswerList.Add(new Answer(2, "False"));

                Console.Write("Enter the correct answer (1 for True, 2 for False): ");
                tf.RightAnswerId = int.Parse(Console.ReadLine());

                exam.Questions.Add(tf);
            }
        }

        // تعيين الامتحان للمادة
        subject.CreateExam(exam);

        Console.WriteLine($"\nStarting Exam for Subject: {subject.SubjectName}");
        int score = 0;

        foreach (var question in exam.Questions)
        {
            Console.WriteLine($"\n{question.Header}: {question.Body}");

            for (int i = 0; i < question.AnswerList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.AnswerList[i].AnswerText}");
            }

            Console.Write("Enter your answer: ");
            int userAnswer = int.Parse(Console.ReadLine());

            if (userAnswer == question.RightAnswerId)
            {
                Console.WriteLine("Correct!");
                score += question.Mark;
            }
            else
            {
                Console.WriteLine("Wrong!");
            }
        }

        Console.WriteLine($"\nExam Finished! Your Total Score: {score}/{exam.Questions.Count * 5}");
    }
}
