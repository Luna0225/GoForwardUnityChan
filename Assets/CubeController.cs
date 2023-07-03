using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;


    //seを呼び出す用
    public AudioClip audioClip;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら消滅させる
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //キューブまたは地面に当たった時に効果音を出す 接触判定
        if (collision.gameObject.CompareTag("CubeTag") || collision.gameObject.CompareTag("GroundTag"))
        {
            //seを鳴らす
            audioSource.PlayOneShot(audioClip);
            //ログの表示
            Debug.Log("接触");
        }
        else
        {
            //ログの表示
            Debug.Log("別のオブジェクトに接触");
        }
    }
}
