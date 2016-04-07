using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYard
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input infix equation
            Console.WriteLine("Enter Infix Expression: ");
            string input = Console.ReadLine();
            string[] tokens = input.Split(null);

            //Stack<string> operatorStack = new Stack<string>();
            Queue<string> outputQueue = new Queue<string>();

            outputQueue = getRPN(tokens);
            Console.WriteLine("Reverse Polish Notation Expression: ");
            foreach (string value in outputQueue)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Calculating Result...");
            Console.WriteLine(calculateRPN(outputQueue));
           
            Console.ReadLine();
        }

        static Queue<string> getRPN(string[] token)
        {
            Stack<string> operatorStack = new Stack<string>();
            Queue<string> outputQueue = new Queue<string>();
            //Shunting Yard Algorithm Meat
            for (int i = 0; i < token.Length; i++)
            {
                if (isANumber(token[i]))
                {
                    outputQueue.Enqueue(token[i]);
                }else if (token[i].Equals("^"))
                {
                    operatorStack.Push(token[i]);
                }
                else if (operatorPrecedence(token[i]) != -1)
                {
                    while(operatorStack.Count != 0 && operatorPrecedence(operatorStack.Peek()) >= operatorPrecedence(token[i])){
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token[i]);
                }
                else  if (token[i].Equals("("))
                {
                    operatorStack.Push(token[i]);
                }
                else if (token[i].Equals(")"))
                {
                    while (!operatorStack.Peek().Equals("("))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                }
            }
            while(operatorStack.Count != 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue;
        }

        static bool isANumber(string n)
        {
            double retNum;
            bool isNumeric = double.TryParse(n, out retNum);
            return isNumeric;
        }

        static int operatorPrecedence(string n)
        {
            int precedence = -1;
            char c = n[0];
            switch (c)
            {
                case '+':
                case '-':
                    precedence = 2;
                    break;
                case '*':
                case '/':
                    precedence = 3;
                    break;
                case '^':
                    precedence = 4;
                    break;
                    
                default:
                    precedence = -1;
                    break;
            }
            return precedence;
        }

        static double calculateRPN(Queue<string> inputQueue)
        {
            Stack<string> outputStack = new Stack<string>();
            
            while (inputQueue.Count != 0)
            {
                string s = inputQueue.Dequeue();
                if (isANumber(s))
                {
                    outputStack.Push(s);
                }
                else
                {
                    if (outputStack.Count < 2)
                    {
                        Console.WriteLine("error: insufficient values");
                        return -1.0;
                    }
                    else
                    {
                        string value1, value2;
                        value1 = outputStack.Pop();
                        value2 = outputStack.Pop();
                        double result = 0.0;
                        if (s.Equals("+")){
                            result = addValues(Convert.ToDouble(value1), Convert.ToDouble(value2));
                        }
                        else if (s.Equals("-"))
                        {
                            result = subtractValues(Convert.ToDouble(value1), Convert.ToDouble(value2));
                        }
                        else if (s.Equals("*"))
                        {
                            result = multiplyValues(Convert.ToDouble(value1), Convert.ToDouble(value2));
                        }
                        else if (s.Equals("/"))
                        {
                            result = divideValues(Convert.ToDouble(value1), Convert.ToDouble(value2));
                        }
                        else if (s.Equals("^"))
                        {
                            result = exponentValues(Convert.ToDouble(value1), Convert.ToDouble(value2));
                        }                        
                        string retVal = Convert.ToString(result);
                        outputStack.Push(retVal);

                    }

                }
            }

            if (outputStack.Count == 1)
            {
                double outcome = Convert.ToDouble(outputStack.Pop());
                return outcome;
            }
            else
            {
                Console.WriteLine("error in calculation");
                return -1.0;
            }
        }

        static double subtractValues(double a, double b)
        {
            double difference = b - a;
            return difference;
        }

        static double addValues(double a, double b)
        {
            double sum = a + b;
            return sum;
        }

        static double divideValues (double a, double b)
        {
            double quotient = b / a;
            return quotient;
        }

        static double multiplyValues (double a, double b)
        {
            double product = a * b;
            return product;
        }

        static double exponentValues( double a, double b)
        {
            double product = Math.Pow(b, a);
            return product;
        }
    }
}
