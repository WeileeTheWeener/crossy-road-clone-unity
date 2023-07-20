using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathComponent : MonoBehaviour
{
    public bool isAlive;
    [SerializeField] UnityEvent onPlayerDeath;

    private void OnEnable()
    {
        isAlive = true;
    }

    public void HandleDeath()
    {
        if(isAlive)
        {
            onPlayerDeath.Invoke();
        }
    }
}
