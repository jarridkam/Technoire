using System.Collections.Generic;
using UnityEngine.Events;

public static class DialogEvents
{
    // Delegates and events for updating the dialog UI
    public delegate void UpdateOptionsDelegate(List<DialogOption> options);
    public static event UpdateOptionsDelegate OnUpdateOptions;

    public delegate void UpdateResponseDelegate(string response);
    public static event UpdateResponseDelegate OnUpdateResponse;

    public delegate void OptionChosenDelegate(int optionIndex);
    public static event OptionChosenDelegate OnOptionChosen;

    // ... any other delegates and events you might have ...

    // Helper methods to invoke the events
    public static void UpdateOptions(List<DialogOption> options)
    {
        OnUpdateOptions?.Invoke(options);
    }

    public static void UpdateResponse(string response)
    {
        OnUpdateResponse?.Invoke(response);
    }

    public static void OptionChosen(int optionIndex)
    {
        OnOptionChosen?.Invoke(optionIndex);
    }



    // ... any other helper methods to invoke other events ...
}

