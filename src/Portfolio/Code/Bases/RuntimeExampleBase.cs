using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Portfolio.Services;

namespace Portfolio.Code.Bases;

public abstract class RuntimeExampleBase : ComponentBase
{
    private string? inputBuffer;
    private RuntimeExampleProgramBase? program;
    private bool programRunning;
    [Inject] private IJSRuntime JS { get; set; } = null!;
    [Inject] private ProgramCompletionService CompletionService { get; set; } = null!;

    protected ElementReference TerminalDiv { get; set; }
    protected List<string> OutputLines { get; set; } = [];
    protected string CurrentInput { get; private set; } = String.Empty;

    protected abstract RuntimeExampleProgramBase CreateProgram(
        Action<string, bool> output,
        Func<string> input,
        Action callback
    );

    protected async Task SetupProgram()
    {
        await Task.Delay(50);
        await TerminalDiv.FocusAsync();

        program = CreateProgram(
            (text, newline) => InvokeAsync(async () =>
            {
                // Replace trailing spaces with &nbsp; entities
                string escaped = text.Replace(" ", "&nbsp;");

                if (OutputLines.Count == 0)
                    OutputLines.Add(escaped);
                else
                    OutputLines[^1] += escaped;

                if (newline) OutputLines.Add(String.Empty);

                StateHasChanged();
            }),
            () =>
            {
                // Wait until user types input
                while (String.IsNullOrEmpty(inputBuffer))
                    Task.Delay(10).Wait();

                string result = inputBuffer!;
                inputBuffer = null;
                return result;
            },
            () => InvokeAsync(() =>
            {
                programRunning = false;
                OnProgramComplete();
                StateHasChanged();
            }));

        programRunning = true;
        _ = Task.Run(() => program!.Execute());
    }

    protected virtual void OnProgramComplete()
    {
        // Notify the completion service to show the modal
        CompletionService.NotifyProgramCompleted();
    }

    protected async Task HandleKeyDown(KeyboardEventArgs e)
    {
        if (!programRunning) return;

        if (e.Key.Equals("Enter", StringComparison.OrdinalIgnoreCase))
        {
            string submitted = CurrentInput;
            CurrentInput = String.Empty;

            // Echo the input to the terminal (append to prompt line)
            if (OutputLines.Count > 0 && !OutputLines[^1].EndsWith(Environment.NewLine))
                OutputLines[^1] += submitted;
            else
                OutputLines.Add(submitted);

            // Add empty line after the input to move to next line
            OutputLines.Add(String.Empty);

            // Now make it available to the program
            inputBuffer = submitted;

            // Keep terminal focused after hitting Enter
            await TerminalDiv.FocusAsync();
            StateHasChanged();
        }
        else if (e.Key.Equals("Backspace", StringComparison.OrdinalIgnoreCase) && CurrentInput.Length > 0)
        {
            CurrentInput = CurrentInput[..^1];
            StateHasChanged();
        }
        else if (e.Key.Length == 1)
        {
            CurrentInput += e.Key;
            StateHasChanged();
        }
    }
}