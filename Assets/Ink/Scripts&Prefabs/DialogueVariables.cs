using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables : MonoBehaviour 
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }
    [SerializeField] private TextAsset LoadGlobalsJSON;

    private Story GlobalStory;
    private const string saveVariablesKey = "INK_VARIABLES";

    private void Start()
    {
        GlobalStory = new Story(LoadGlobalsJSON.text);
        variables = new Dictionary<string, Ink.Runtime.Object>();

        foreach (string name in GlobalStory.variablesState)
        {
            Ink.Runtime.Object value = GlobalStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            // Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }

    public void SaveData()
    {
        if (GlobalStory != null) {
            VariablesToStory(GlobalStory);  // Load current state of all variables
            PlayerPrefs.SetString(saveVariablesKey, GlobalStory.state.ToJson());  // saves data
        }
    }

    public void LoadData()
    {
        if (GlobalStory == null) {
            GlobalStory = new Story(LoadGlobalsJSON.text);
        }
        if (PlayerPrefs.HasKey(saveVariablesKey))   // check if there is saved data, load it
        {
            string state = PlayerPrefs.GetString(saveVariablesKey);
            GlobalStory.state.LoadJson(state);
        }
    }
    public void ResetData()
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> var in variables)
        {
            variables.Remove(var.Key);
            variables.Add(var.Key, null);
            VariablesToStory(GlobalStory);
        }
    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
            Debug.Log("Variable Updated: " + name + " = " + value);
        }
    }

    // Updates all variable changes to the dictionary to the Ink Story
    private void VariablesToStory(Story story)
    {
        if (variables != null)
        {
            foreach (KeyValuePair<string, Ink.Runtime.Object> var in variables)
            {
                story.variablesState.SetGlobal(var.Key, var.Value);
            }
        }
    }

    public Ink.Runtime.Object GetVariableState(string name)
    {
        Ink.Runtime.Object variableValue = null;
        variables.TryGetValue(name, out variableValue);
        if (variableValue != null)
        {
            Debug.Log("Ink variable was found to be null: " + name);
        }
        return variableValue;
    }
}

