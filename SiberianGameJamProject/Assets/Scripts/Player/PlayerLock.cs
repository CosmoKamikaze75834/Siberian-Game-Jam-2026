using UnityEngine;

public class PlayerLock : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Lock()
    {
        _player.gameObject.SetActive(false);
    }

    public void Unlock()
    {
        _player.gameObject.SetActive(true);
    }
}