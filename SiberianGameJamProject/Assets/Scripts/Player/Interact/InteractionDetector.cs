using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private Collider2D _currentCollider;//коллайдер зоны в которой ейчас находится игрок

    public IInteractable CurrentInteractable { get; private set; }//ссылка на объект реализующий интерфейс

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ЗАшёл в триггер");

        //есть ли компонент реализющий интерфеймс?
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable == null)
            return;

        _currentCollider = collision;
        CurrentInteractable = interactable;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            Debug.Log("вышел из триггера");

            if (collision != _currentCollider)
            return;

        _currentCollider = null;
        CurrentInteractable = null;
    }
}