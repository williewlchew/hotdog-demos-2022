using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 'Command' abstract class
/// </summary>
public abstract class Command
{
    protected Receiver receiver;
    // Constructor
    public Command(Receiver receiver)
    {
        this.receiver = receiver;
    }
    public abstract void Execute();
}
/// <summary>
/// The 'ConcreteCommand' class
/// </summary>
public class ConcreteCommand : Command
{
    // Constructor
    public ConcreteCommand(Receiver receiver) :
        base(receiver)
    {
    }
    public override void Execute()
    {
        receiver.Action();
    }
}
/// <summary>
/// The 'Receiver' class
/// </summary>
public class Receiver
{
    public void Action()
    {
        Debug.Log("Called Receiver.Action()");
    }
}
/// <summary>
/// The 'Invoker' class
/// </summary>
public class Invoker
{
    Command command;
    public void SetCommand(Command command)
    {
        this.command = command;
    }
    public void ExecuteCommand()
    {
        command.Execute();
    }
}

public class commandTemplate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create receiver, command, and invoker
        Receiver receiver = new Receiver();
        Command command = new ConcreteCommand(receiver);
        Invoker invoker = new Invoker();
        // Set and execute command
        invoker.SetCommand(command);
        invoker.ExecuteCommand();
        invoker.ExecuteCommand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
