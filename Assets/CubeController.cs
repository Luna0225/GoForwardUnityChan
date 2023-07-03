using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //�L���[�u�̈ړ����x
    private float speed = -12;

    //���ňʒu
    private float deadLine = -10;


    //se���Ăяo���p
    public AudioClip audioClip;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSource���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʊO�ɏo������ł�����
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�L���[�u�܂��͒n�ʂɓ����������Ɍ��ʉ����o�� �ڐG����
        if (collision.gameObject.CompareTag("CubeTag") || collision.gameObject.CompareTag("GroundTag"))
        {
            //se��炷
            audioSource.PlayOneShot(audioClip);
            //���O�̕\��
            Debug.Log("�ڐG");
        }
        else
        {
            //���O�̕\��
            Debug.Log("�ʂ̃I�u�W�F�N�g�ɐڐG");
        }
    }
}
