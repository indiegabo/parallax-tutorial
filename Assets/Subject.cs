using UnityEngine;

public class Subject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this._rb.velocity = new Vector2(8f, this._rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this._rb.velocity = new Vector2(-8f, this._rb.velocity.y);
        }
        else
        {
            this._rb.velocity = new Vector2(0, this._rb.velocity.y);
        }
    }
}
