using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Cutscene", order = 1)]

public class Cutscene : ScriptableObject
{
    public int day;
    public VideoClip clip;
}
