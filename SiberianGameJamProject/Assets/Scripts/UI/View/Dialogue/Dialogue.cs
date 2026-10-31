using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    private struct DialogueEntry
    {
        public DialogueId Id;

        [TextArea(2, 5)]
        public string Text;
    }

    [SerializeField] private DialogueEntry[] _entries;
    [SerializeField] private DialogueView _dialogueView;

    public void Show(DialogueId id)
    {
        foreach (var entry in _entries)
        {
            if (entry.Id != id)
                continue;

            _dialogueView.Show(entry.Text);
            return;
        }

        Debug.LogWarning($"Реплика {id} не найдена");
    }
}