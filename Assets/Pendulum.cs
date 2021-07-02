using UnityEngine;
using System.Collections;

public class Pendulum : MonoBehaviour
{
    #region Public Variables
    public Rigidbody2D body2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;
    public int damage = 20;
    #endregion 

    #region Main Methods
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
    }

    void Update()
    {
        Push();
    }
    #endregion 

    #region Utility Methods 
    public void Push()
    {
        if (transform.rotation.z > 0
            && transform.rotation.z < rightPushRange
            && (body2d.angularVelocity > 0)
            && body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0
            && transform.rotation.z > leftPushRange
            && (body2d.angularVelocity < 0)
            && body2d.angularVelocity > velocityThreshold * -1)
        {
            body2d.angularVelocity = velocityThreshold * -1;
        }

    }

    void OnCollisionEnter2D()
    {
        FindObjectOfType<PlayerCombat>().TakeDmg(damage);
    }
    #endregion 
}
