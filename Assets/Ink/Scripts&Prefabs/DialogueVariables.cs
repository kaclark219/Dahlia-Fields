using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables : MonoBehaviour 
{
    public Dictionary<string, string> variables { get; private set; }
    [SerializeField] private TextAsset LoadGlobalsJSON;

    private Story GlobalStory;
    private Story currStory;
    private const string saveVariablesKey = "INK_VARIABLES";

    private void Awake()
    {
        GlobalStory = new Story(LoadGlobalsJSON.text);
        variables = new Dictionary<string, string>();

        foreach (string name in GlobalStory.variablesState)
        {
            string value = GlobalStory.variablesState.GetVariableWithName(name).ToString();
            variables[name] = value;

            // Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        currStory = story;
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        currStory = null;
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    // Used as listener
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value.ToString());
            Debug.Log("Variable Updated: " + name + " = " + value);
        }
    }

    // Functions that change variables outside of Ink and updates the stories
    public void ChangeVariable(string name, string value)
    {
        if (variables.ContainsKey(name))
        {
            variables[name] = value;
            if (currStory)
            {
                currStory.variablesState.SetGlobal(name, new Ink.Runtime.StringValue(value));
            }
            Debug.Log("Variable Updated: " + name + " = " + value);
        }
    }

    public void AddTrust(string name, int value)
    {
        if (variables.ContainsKey(name))
        {
            int current = int.Parse(variables[name]); 
            current += value; 
            variables[name] = current.ToString();

            if (currStory)
            {
                currStory.variablesState.SetGlobal(name, new Ink.Runtime.IntValue(value));
            }

            Debug.Log($"Variable Updated: {name} = {current}");
        }
        else
        {
            Debug.LogWarning($"Variable '{name}' not found or is not an integer.");
        }
    }

    // Updates all variable changes to the dictionary to the Ink Story
    private void VariablesToStory(Story story)
    {
        if (variables != null)
        {
            foreach (KeyValuePair<string, string> var in variables)
            {
                story.variablesState.SetGlobal(var.Key, new Ink.Runtime.StringValue(var.Value));
            }
        }
    }

    public int GetVariableState(string name)
    {
        if (variables.ContainsKey (name))
        {
            return int.Parse(variables[name]);
        }
        else
        {
            Debug.Log($"Variable '{name}' was not found or is not an integer");
            return -1;
        }
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        if (GlobalStory != null)
        {
            VariablesToStory(GlobalStory);  // Load current state of all variables
            PlayerPrefs.SetString(saveVariablesKey, GlobalStory.state.ToJson());  // saves data
        }
    }

    public void LoadData()
    {
        if (GlobalStory == null)
        {
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
        variables.Clear();
        foreach (KeyValuePair<string, string> var in variables)
        {
            variables.Add(var.Key, "0");
            VariablesToStory(GlobalStory);
        }
    }
    #endregion
}

