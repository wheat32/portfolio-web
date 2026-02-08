namespace Portfolio.Code.Bases;

public abstract class RuntimeExampleProgramBase
{
    protected readonly Func<string> readInput;
    protected readonly Action<string, bool> writeOutput;
    private readonly Action? onComplete;

    protected RuntimeExampleProgramBase(Action<string, bool> output, Func<string> input, Action callback)
    {
        writeOutput = output;
        readInput = input;
        onComplete = callback;
    }

    public void Execute()
    {
        try
        {
            Run();
        }
        finally
        {
            onComplete?.Invoke();
        }
    }

    protected abstract void Run();

    // ─────────────────────────────
    // Printing helpers
    // ─────────────────────────────
    protected void Print(string text)
    {
        writeOutput(text, false);
    }

    protected void PrintLine(string text)
    {
        writeOutput(text, true);
    }
}