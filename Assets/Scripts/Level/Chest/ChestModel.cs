using UnityEngine;

public class ChestModel : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    private int health;

    public void Init(ChestProperties props)
    {
        body.detectCollisions = true;
        body.isKinematic = false;
        health = props.Health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void ReduceHealth()
    {
        health--;
        if (health == 0)
        {
            body.isKinematic = true;
            body.detectCollisions = false;
        }
    }
}