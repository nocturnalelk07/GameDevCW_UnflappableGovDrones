using Unity.VisualScripting;
using UnityEngine;

public class menuMovement : MonoBehaviour
{
    [Header("background movement")]
    [SerializeField] private bool backgroundMovement = false;
    [SerializeField] private bool moveRight;
    [SerializeField] private float targetSpeed = 0.1f;

    [Header("tweening settings")]
    [SerializeField] private LeanTweenType easeTypeMove = LeanTweenType.linear;
    [SerializeField] private LeanTweenType easeTypeScale = LeanTweenType.linear;
    [SerializeField] private Vector2 moveTarget;
    [SerializeField] private Vector2 startingPoint;
    [SerializeField] private float duration = 1;
    [SerializeField] private float delay;
    [SerializeField] private Vector2 scale = Vector2.one;

    private void Update()
    {
        if (backgroundMovement) { moveBackground(); }

    }

    private void moveBackground()
    {
        if (moveRight)
        {
            transform.position = transform.position + Vector3.right * targetSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position - Vector3.right * targetSpeed * Time.deltaTime;
        } 
    }

    //move the selected gameobject
    public void tweenMove()
    {
        LeanTween.move(gameObject, moveTarget, duration).setEase(easeTypeMove);
    }

    public void tweenScale()
    {
        gameObject.transform.localScale = Vector2.zero;
        LeanTween.scale(gameObject, scale, duration).setEase(easeTypeScale);
    }
}
