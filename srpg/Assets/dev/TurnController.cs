using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICommand
{
    void Execute();
}

interface TurnAgent
{
    
}


class LoopCommandController
{
    private List<ICommand> commands;
    private int currentPoint;

    public int CurrentPoint{get = currentPoint;}

    public CommandController()
    {
        commands = new List<ICommand>();
        currentPoint = 0;
    }
 
    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }
 
    public void Execute()
    {
        commands[currentPoint].Execute();
        currentPoint++;
        if(currentPoint >= commands.Count){
            
            currentPoint = 0;
        }

    }
}

class TurnCommand : ICommand
{
    private TurnAgent agent;

    public TurnCommand(TurnAgent _agent)
    {
        agent = _agent;
    }

    public void Execute()
    {
        
    }
}

/*
    list that iterates from 0 to n until stopped by flag
*/
public class TurnController : MonoBehaviour
{
    
    void FixedUpdate()
    {
        // execute an agent's turn
        // 
    }
}
