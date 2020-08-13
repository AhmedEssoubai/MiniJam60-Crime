using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void Dead()
    {
        movement.IsFreeze = true;
        UIManager.Manager.ShowGameOver();
    }
}
