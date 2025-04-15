using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    [Space]
    [SerializeField] private GameObject UI;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private OnClickNextDialogue panel;
    [SerializeField] private VerticalLayoutGroup choiceButtonContainer;
    [SerializeField] private GameObject choiceButtonPrefab;
    [SerializeField] private Sprite killButtonSprite;
    [Space]
    [SerializeField] private DialogueVariables dialogueVariables;

    [Space]
    [SerializeField] public Slider speedSlider; 

    private NPCManager npcManager;
    private InteractableObj currInteractable;
    private Coroutine printCoroutine = null;
    private string text;
    private bool isStoryPaused = false;
    private bool storyPlaying = false;

    private float dialogSpeed = 0.05f;
    private SoundEffects effect; 

    private void Awake()
    {
        dialogueVariables = GetComponent<DialogueVariables>();
        npcDialogueManager = FindObjectOfType<NPCDialogueManager>();
        npcManager = FindAnyObjectByType<NPCManager>();
        effect = GameObject.Find("SoundEffectManager").GetComponent<SoundEffects>();
        UI.SetActive(false);
    }

    private void Update()
    {
        if (storyPlaying && Input.GetKeyDown(KeyCode.E)) {
            DisplayNextLine();
            storyPlaying = false;
            StartCoroutine(StoryIsPlaying());
        } 
    }

    // For testing
    private void StartStory()
    {
        story = new Story(inkJsonAsset.text);
        UI.SetActive(true);

        // Connects function calls in Ink file with function calls in Unity
        BindFunctions();

        DisplayNextLine();
        StartCoroutine(StoryIsPlaying());
    }

    // keeps track of InteractableObj to call EndInteract() at end of dialogue
    public Story StartStory(TextAsset newstory, InteractableObj obj)
    {
        currInteractable = obj; 
        inkJsonAsset = newstory;
        story = new Story(inkJsonAsset.text);
        UI.SetActive(true);

        // Connects function calls in Ink file with function calls in Unity
        BindFunctions();

        DisplayNextLine();
        StartCoroutine(StoryIsPlaying());

        return story;
    }

    // Used to create the story but not display the next line for other ExternalFunction bindings
    public Story CreateStory(TextAsset newstory, InteractableObj obj)
    {
        currInteractable = obj;
        inkJsonAsset = newstory;
        story = new Story(inkJsonAsset.text);
        UI.SetActive(true);

        // Connects function calls in Ink file with function calls in Unity
        BindFunctions();
        
        return story;
    }

    public void SetDialogueName(string name)
    {
        npcDialogueManager.SetName(name);
    }

    public void StartCreatedStory()
    {
        if (story)
        {
            DisplayNextLine();
            StartCoroutine(StoryIsPlaying());
        }
    }

    private void BindFunctions()
    {
        story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => npcDialogueManager.ShowCharacter(name, position, mood));
        story.BindExternalFunction("HideCharacter", (string name) => npcDialogueManager.HideCharacter(name));
        story.BindExternalFunction("ChangeMood", (string name, string mood) => npcDialogueManager.ChangeMood(name, mood));
        story.BindExternalFunction("KillNPC", (string name) => npcManager.KillNPC(name));
        dialogueVariables.StartListening(story);
    }

    public void EndStory()
    {
        // Reset Dialogue 
        story.ResetState();
        dialogueVariables.StopListening(story);
        UI.SetActive(false);
        story = null;

        // Clear all Portraits
        npcDialogueManager.ClearCharacters();

        // End Interaction for Player
        currInteractable.EndInteract();
        currInteractable = null;

        storyPlaying = false;
    }

    public void DisplayNextLine()
    {
        if (isStoryPaused)
        {
            return;
        }

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
            effect.PlayClose();
            EndStory();
        }

    }
    
    public void SetDialogSpeed(float i)
    {
        dialogSpeed = 0.1f - speedSlider.value;
    }

    // Coroutine to slowly print each character in a line.
    private IEnumerator PrintLine()
    {
        textBox.text = text;
        textBox.maxVisibleCharacters = 0;
        foreach (char c in text)
        {
            textBox.maxVisibleCharacters++;
            yield return new WaitForSeconds(dialogSpeed);
        }
        printCoroutine = null;
    }

    private IEnumerator StoryIsPlaying()
    {
        yield return new WaitForSeconds(.25f);
        storyPlaying = true;
    }

    // Styling Stuff:
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

    public void DisableUI()
    {
        UI.SetActive(false);
        isStoryPaused = true;
    }

    public void EnableUI()
    {
        UI.SetActive(true);
        isStoryPaused = false;

        if (story != null)
        {

            if (printCoroutine != null)
            {
                StopCoroutine(printCoroutine);
                printCoroutine = null;
            }

            DisplayNextLine();
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
            if (choice.tags != null && choice.tags.Contains("kill"))
            {
                button.GetComponentInChildren<Image>().sprite = killButtonSprite;
                button.GetComponentInChildren<TextMeshProUGUI>().color = new Color(148, 0, 0);
            }
            button.GetComponentsInChildren<Button>()[0].onClick.AddListener(() => OnClickChoiceButton(choice)); 
        }

        panel.enabled = false;
    }

    
    private void OnClickChoiceButton(Choice choice)
    {
        effect.PlayUIClick(); 
        story.ChooseChoiceIndex(choice.index);
        RefreshChoiceView();
        DisplayNextLine();
        panel.enabled = true;
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
