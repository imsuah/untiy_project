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

        if (collision.gameObject.CompareTag("��ֹ�"))
        {
            SceneManager.LoadScene(0); // ������ �����
        }
    }

    // ��� ������ Ʈ���� �浹ü�� ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� Collider2D�� ���ӿ�����Ʈ �̸��� "������ ���ǵ�" ���
        if (collision.gameObject.name.Equals("������ ���ǵ�")) 
        {
            // ���� ��ü ����
            Destroy(collision.gameObject);

            // �̵��ӵ� 20 ����
            moveSpeed += 20f;
        }
        // �浹�� Collider2D�� ���ӿ�����Ʈ �̸��� "������ ���ǵ�" ���
        else if (collision.gameObject.name.Equals("������ ������"))
        {
            // ���� ��ü ����
            Destroy(collision.gameObject);

            // ������ 200 ����
            jumpSpeed += 200f;
        }
        else if (collision.gameObject.name.Equals("��Ż"))
        {
            SceneManager.LoadScene(1);
        }
    }

}
