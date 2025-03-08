using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Choice = Ink.Runtime.Choice;
using Story = Ink.Runtime.Story;

public class InkManager : MonoBehaviour
{
    [SerializeField] private NPCDialogueManager npcDialogueManager;
    [SerializeField] private TextAsset inkJsonAsset;
    [SerializeField] private Story story;

    [SerializeField] private GameObject UI;
    [SerializeField] private TextMeshProUGUI textBox;

    [SerializeField] private VerticalLayoutGroup choiceButtonContainer;

    [SerializeField] private GameObject choiceButtonPrefab;

    [SerializeField] private DialogueVariables dialogueVariables;

    private InteractableObj currInteractable;
    private Coroutine printCoroutine = null;
    private string text;

    private void Awake()
    {
        dialogueVariables = GetComponent<DialogueVariables>();
        npcDialogueManager = FindObjectOfType<NPCDialogueManager>();
        UI.SetActive(false);
    }

    // For testing
    private void StartStory()
    {
        Debug.Log("Starting Dialogue");
        story = new Story(inkJsonAsset.text);
        UI.SetActive(true);

        // Connects function calls in Ink file with function calls in Unity
        story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => npcDialogueManager.ShowCharacter(name, position, mood));
        story.BindExternalFunction("HideCharacter", (string name) => npcDialogueManager.HideCharacter(name));
        story.BindExternalFunction("ChangeMood", (string name, string mood) => npcDialogueManager.ChangeMood(name, mood));
        dialogueVariables.StartListening(story);
        DisplayNextLine();
    }

    // keeps track of InteractableObj to call EndInteract() at end of dialogue
    public Story StartStory(TextAsset newstory, InteractableObj obj)
    {
        Debug.Log("Starting Dialogue");

        currInteractable = obj; 
        inkJsonAsset = newstory;
        story = new Story(inkJsonAsset.text);
        UI.SetActive(true);

        // Connects function calls in Ink file with function calls in Unity
        story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => npcDialogueManager.ShowCharacter(name, position, mood));
        story.BindExternalFunction("HideCharacter", (string name) => npcDialogueManager.HideCharacter(name));
        story.BindExternalFunction("ChangeMood", (string name, string mood) => npcDialogueManager.ChangeMood(name, mood));
        dialogueVariables.StartListening(story);
        DisplayNextLine();

        return story;
    }

    // Used to create the story but not display the next line for other ExternalFunction bindings
    public Story CreateStory(TextAsset newstory, InteractableObj obj)
    {
        Debug.Log("Starting Dialogue");

        currInteractable = obj;
        inkJsonAsset = newstory;
        story = new Story(inkJsonAsset.text);
        UI.SetActive(true);

        // Connects function calls in Ink file with function calls in Unity
        story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => npcDialogueManager.ShowCharacter(name, position, mood));
        story.BindExternalFunction("HideCharacter", (string name) => npcDialogueManager.HideCharacter(name));
        story.BindExternalFunction("ChangeMood", (string name, string mood) => npcDialogueManager.ChangeMood(name, mood));
        dialogueVariables.StartListening(story);

        return story;
    }

    private void EndStory()
    {
        Debug.Log("Exiting Dialogue");

        // Reset Dialogue 
        story.ResetState();
        dialogueVariables.StopListening(story);
        UI.SetActive(false);

        // Clear all Portraits
        npcDialogueManager.ClearCharacters();

        // End Interaction for Player
        currInteractable.EndInteract();
    }

    public void DisplayNextLine()
    {
        // Check if a line is being printed
        if (printCoroutine != null)
        {
            StopCoroutine(printCoroutine);
            textBox.maxVisibleCharacters = text.Length;
            printCoroutine = null;
            return;
        }

        if (story.canContinue)
        {
            text = story.Continue();
            text = text?.Trim();
            if (text == "")
            {
                DisplayNextLine();
            }
            else
            {
                ApplyStyling();

                printCoroutine = StartCoroutine(PrintLine());
            }
        }
        else if (story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else if (!story.canContinue)
        {
            EndStory();
        }

    }

    // Coroutine to slowly print each character in a line.
    private IEnumerator PrintLine()
    {
        textBox.text = text;
        textBox.maxVisibleCharacters = 0;
        foreach (char c in text)
        {
            textBox.maxVisibleCharacters++;
            yield return new WaitForSeconds(0.04f);
        }
        printCoroutine = null;
    }

    private void ApplyStyling()
    {
        if (story.currentTags.Contains("thought")) {
            textBox.fontStyle = FontStyles.Italic;
        }
        else
        {
            textBox.fontStyle= FontStyles.Normal;
        }
    }

    #region CHOICES_FUNCTIONS
    // Displays all choices for a dialogue 
    private void DisplayChoices()
    {
        if (choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) { return; }

        foreach (Choice choice in story.currentChoices)
        {
            GameObject button = CreateChoiceButton(choice.text);
            button.GetComponentsInChildren<Button>()[0].onClick.AddListener(() => OnClickChoiceButton(choice)); 
        }
    }

    
    private void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshChoiceView();
        DisplayNextLine();
    }

    // Removes all choices
    private void RefreshChoiceView()
    {
        if (choiceButtonContainer != null)
        {
            foreach (Transform button in choiceButtonContainer.transform)
            {
                Destroy(button.gameObject);
            }
        }
    }

    private GameObject CreateChoiceButton(string text)
    {
        GameObject buttonObj = Instantiate(choiceButtonPrefab);
        buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = text;
        buttonObj.transform.SetParent(choiceButtonContainer.transform, false);
        return buttonObj; ;
    }
    #endregion

}
