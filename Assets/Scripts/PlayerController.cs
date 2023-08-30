using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpSpeed = 300f;
    public bool isJump = false;

    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W) && isJump == false)
        {
            isJump = true;
            rigidbody2D.AddForce(Vector2.up * jumpSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;

        if (collision.gameObject.CompareTag("장애물"))
        {
            SceneManager.LoadScene(0); // 게임을 재시작
        }
    }

    // 통과 가능한 트리거 충돌체와 닿으면
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 Collider2D의 게임오브젝트 이름이 "아이템 스피드" 라면
        if (collision.gameObject.name.Equals("아이템 스피드")) 
        {
            // 닿은 객체 삭제
            Destroy(collision.gameObject);

            // 이동속도 20 증가
            moveSpeed += 20f;
        }
        // 충돌한 Collider2D의 게임오브젝트 이름이 "아이템 스피드" 라면
        else if (collision.gameObject.name.Equals("아이템 점프력"))
        {
            // 닿은 객체 삭제
            Destroy(collision.gameObject);

            // 점프력 200 증가
            jumpSpeed += 200f;
        }
        else if (collision.gameObject.name.Equals("포탈"))
        {
            SceneManager.LoadScene(1);
        }
    }

}
