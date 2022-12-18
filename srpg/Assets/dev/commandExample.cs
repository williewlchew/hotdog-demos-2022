using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace commandExample {
    public class commandExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ExampleProgram exe = new ExampleProgram(); 
            Debug.Log(exe.Run());
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

    // https://www.dofactory.com/net/command-design-pattern

    /// <summary>
    /// Command Design Pattern
    /// </summary>

    public class ExampleProgram
    {
        public string Run()
        {
            // Create user and let her compute
            User user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(4);

            // Redo 3 commands
            user.Redo(3);

            return user.GetLogs();
        }
    }

    /// <summary>
    /// The 'Command' abstract class
    /// </summary>

    public abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>

    public class CalculatorCommand : Command
    {
        char @operator;
        int operand;
        Calculator calculator;

        // Constructor

        public CalculatorCommand(Calculator calculator,
            char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }

        // Gets operator

        public char Operator
        {
            set { @operator = value; }
        }

        // Get operand

        public int Operand
        {
            set { operand = value; }
        }

        // Execute new command

        public override void Execute()
        {
            calculator.Operation(@operator, operand);
        }

        // Unexecute last command

        public override void UnExecute()
        {
            calculator.Operation(Undo(@operator), operand);
        }

        // Returns opposite operator for given operator

        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new
                ArgumentException("@operator");
            }
        }
    }

    /// <summary>
    /// The 'Receiver' class
    /// </summary>

    public class Calculator
    {
        int curr = 0;
        public string log = "";

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': curr += operand; break;
                case '-': curr -= operand; break;
                case '*': curr *= operand; break;
                case '/': curr /= operand; break;
            }
            log += "Current value = " + curr + " (" + @operator + " " + operand + ")\n";
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>

    public class User
    {
        // Initializers
        Calculator calculator = new Calculator();
        List<Command> commands = new List<Command>();
        int current = 0;
        public string log = "";

        public void Redo(int levels)
        {
            log += "---- Redo " + levels + " levels \n";
            // Perform redo operations
            for (int i = 0; i < levels; i++)
            {
                if (current < commands.Count - 1)
                {
                    Command command = commands[current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            log += "---- Undo " + levels + " levels \n";
            
            // Perform undo operations

            for (int i = 0; i < levels; i++)
            {
                if (current > 0)
                {
                    Command command = commands[--current] as Command;
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            log += "---- " + @operator + " " + operand + "\n";
            Command command = new CalculatorCommand(calculator, @operator, operand);
            command.Execute();

            // Add command to undo list

            commands.Add(command);
            current++;
        }

        public string GetLogs()
        {
            string ret = "User Logs: \n" + log;
            ret += "Calculator Logs: \n" + calculator.log;
            return ret;
        }
    }
}