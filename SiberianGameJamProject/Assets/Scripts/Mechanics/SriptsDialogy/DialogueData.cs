using UnityEngine;

// Этот атрибут позволяет создавать ассет этого типа через меню Create в Unity
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    // Массив из 3 строк (диалогов)
    [TextArea(2, 4)] // Делает поле многострочным в инспекторе
    public string[] dialogues = new string[3];
}