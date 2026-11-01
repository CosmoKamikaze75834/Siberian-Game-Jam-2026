using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Zenject;

public class ButtonExit : MonoBehaviour
{
    [Header("Настройка диалогов")]
    [SerializeField] public DialogueData[] _dialogueData;
    [SerializeField] public DialogyMeneger _dialogyMeneger;
    private int currentDialogueIndex = 0;
    [SerializeField] public GameObject _dialogeWin;

    // Start is called before the first frame update
    public void ButtonExitCliks()
    {
        if (currentDialogueIndex < _dialogueData[0].dialogues.Length)
        {
            _dialogeWin.SetActive(true);
            string currentText = _dialogueData[0].dialogues[currentDialogueIndex];
            _dialogyMeneger.ShowDialogy(currentText);

          
            currentDialogueIndex++;
        }
        else
        {
            _dialogeWin.SetActive(false);
            currentDialogueIndex = 0;
            _dialogyMeneger.ClainerDialogy();
        
        }

    }

   


    public void ButtonTwoCliks()
    {

        if (currentDialogueIndex < _dialogueData[1].dialogues.Length)
        {
            _dialogeWin.SetActive(true);

            string currentText = _dialogueData[1].dialogues[currentDialogueIndex];
            _dialogyMeneger.ShowDialogy(currentText);


            currentDialogueIndex++;
        }
        else
        {
            _dialogeWin.SetActive(false);
            currentDialogueIndex = 0;
            _dialogyMeneger.ClainerDialogy();
           
        }

    }
}
