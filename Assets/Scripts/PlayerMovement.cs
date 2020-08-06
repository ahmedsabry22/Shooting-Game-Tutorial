using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public LayerMask interactableLayer;
    public bool isShooting = false;

    private Animator playerAnimator;
    private float verticalValue;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        verticalValue = Input.GetAxisRaw("Vertical");

        if (!isShooting)
            Move();

        Turn();
    }

    private void Move()
    {
        if (verticalValue > 0)
        {
            playerAnimator.SetBool("Running", true);
            playerAnimator.SetFloat("Direction", verticalValue);

            transform.position = transform.position + transform.forward * verticalValue * moveSpeed * Time.deltaTime;
        }
        else
        {
            playerAnimator.SetBool("Running", false);
        }
    }

    private void Turn()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundHit;

        if (Physics.Raycast(cameraRay, out groundHit, Mathf.Infinity, interactableLayer))
        {
            if (Vector3.Distance(transform.position, groundHit.point) < 2)
                return;

            Vector3 playerToMouse = groundHit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 10);
        }
    }
}