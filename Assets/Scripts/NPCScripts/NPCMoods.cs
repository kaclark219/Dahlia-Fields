using UnityEngine;

public class NPCMoods : MonoBehaviour
{
    public NPCName Name;
    public Sprite Normal;
    public Sprite Suspicious;
    public Sprite Happy;
    public Sprite Special;

    public Sprite GetMoodSprite(NPCMood mood)
    {

        switch (mood)
        {
            case NPCMood.Normal:
                return Normal;
            case NPCMood.Suspicious:
                return Suspicious;
            case NPCMood.Happy:
                return Happy;
            case NPCMood.Special:
                return Special;
            default:
                Debug.Log($"Didn't find Sprite for character: {Name}, mood: {mood}");
                return Normal;
        }
    }
}
