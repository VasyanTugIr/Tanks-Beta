using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveColision : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("hello");
        var isGround = collision.gameObject.layer == LayerMask.NameToLayer("ground");
        if (isGround)
        {
            _playerMovement.setIsOnGround(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        var isGround = collision.gameObject.layer == LayerMask.NameToLayer("ground");
        if (isGround)
        {
            _playerMovement.setIsOnGround(false);


        }
    }
}
