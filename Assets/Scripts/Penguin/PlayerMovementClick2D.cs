using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovementClick2D : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingDistance = 1.2f;
    public Sprite[] moving_down;
    public Sprite[] moving_up;
    public Sprite[] moving_x;
    public Sprite[] moving_xy_up;
    public Sprite[] moving_xy_down;
    public Sprite standSprite;
    public float frameDelay = 0.05f;

    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isNoInteractive = false;
    private int index = 0;
    private Coroutine animationCoroutine;
    private char direction;
    private Vector3 clickOffset;
    private SpriteRenderer mySpriteRenderer;
    private Transform targetObject;


    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Debug.Log("entro a la condicion");
            Vector3 selectPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(selectPosition);

            if (hit == null)
            {
                isNoInteractive = false;
            }   
        }

        if (Input.GetMouseButtonDown(0) && !isNoInteractive)
        {
            UnityEngine.Debug.Log("me muevo");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickOffset = mousePos - transform.position;            
            targetPosition = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            isMoving = true;

            if (animationCoroutine == null)
            {
                animationCoroutine = StartCoroutine(WalkCoroutine());
            }

            
        }

        if (isMoving)
        {            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
                StopWalkingAnimation();
            }
            
            
        }
        else
        {
            stopMoving();
        }
    }

    IEnumerator WalkCoroutine()
    {
        while (isMoving)
        {
            if (clickOffset.y > 0.8 && clickOffset.x > 0.8)
            {
                UnityEngine.Debug.Log("Se activo diagonal superior derecha x: " + +clickOffset.x + " y: " + clickOffset.y);
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.sprite = moving_xy_up[index];
                direction = 'e';
            }
            else if (clickOffset.y > 0.8 && clickOffset.x < -0.8)
            {
                UnityEngine.Debug.Log("Se activo diagonal superior izquierda x: " + clickOffset.x + " y: " + clickOffset.y);
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_xy_up[index];
                direction = 'q';
            }
            else if (clickOffset.y < -0.8 && clickOffset.x > 0.8)
            {
                UnityEngine.Debug.Log("Se activo diagonal inferior derecha x: " + clickOffset.x + " y: " + clickOffset.y);
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.sprite = moving_xy_down[index];
                direction = 'c';
            }
            else if (clickOffset.y < -0.8 && clickOffset.x < -0.8)
            {
                UnityEngine.Debug.Log("Se activo diagonal inferior izquierda x: " + clickOffset.x + " y: " + clickOffset.y);
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_xy_down[index];
                direction = 'z';
            }
            else if (clickOffset.x > 0 && (clickOffset.y > -0.79 && clickOffset.y < 0.79))
            {
                UnityEngine.Debug.Log("Se activo derecha x: " + clickOffset.x + " y: " + clickOffset.y);
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.sprite = moving_x[index];
                direction = 'd';
            }
            else if (clickOffset.x < 0 && (clickOffset.y > -0.79 && clickOffset.y < 0.79))
            {
                UnityEngine.Debug.Log("Se activo izquierda x: " + clickOffset.x + " y: " + clickOffset.y);
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_x[index];
                direction = 'a';
            }
            else if (clickOffset.y > 0)
            {
                UnityEngine.Debug.Log("Se activo arriba x: " + clickOffset.x + " y: " + clickOffset.y);
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_up[index];
                direction = 'w';
            }
            else if (clickOffset.y < 0)
            {
                UnityEngine.Debug.Log("Se activo abajo x: " + clickOffset.x + " y: " + clickOffset.y);
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_down[index];
                direction = 's';
            }
            else
            {

                mySpriteRenderer.sprite = moving_down[index];
            }
            index++;
            if (index == 8)
            {
                index = 0;
            }
            yield return new WaitForSeconds(frameDelay);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MoveCloser"))
        {
            isNoInteractive = true;
            isMoving = false;
            targetPosition = transform.position;
            StopWalkingAnimation();
            UnityEngine.Debug.Log("Se detuvo por colisión con: " + collision.collider.name);
        }
    }
    /*void onCollisionExit2D(Collision2D collision)
    {
        isNoInteractive = true;
        isMoving = false;
    }*/
    void OnCollisionExit2D(Collision2D collision)
    {
        isNoInteractive = false;
        isMoving = true;

    }   


    void StopWalkingAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }

        stopMoving();

        UnityEngine.Debug.Log("DIRECTION " + direction + moving_down.Length);
        index = 0;
    }

    void stopMoving()
    {
        switch (this.direction)
        {
            case 'q':
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_xy_up[moving_down.Length - 1];
                break;
            case 'w':
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_up[moving_down.Length - 1];
                break;
            case 'e':
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.sprite = moving_xy_up[moving_down.Length - 1];
                break;
            case 'a':
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_x[moving_down.Length - 1];
                break;
            case 'd':
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.sprite = moving_x[moving_down.Length - 1];
                break;
            case 'z':
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_xy_down[moving_down.Length - 1];
                break;
            case 'x':
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = moving_down[moving_down.Length - 1];
                break;
            case 'c':
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.sprite = moving_xy_down[moving_down.Length - 1];
                break;
        }
    }
}