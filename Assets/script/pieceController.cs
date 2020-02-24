using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceController : MonoBehaviour
{
    // マウスをクリックしたときにどのコマかわかるようにする
    // マウスをクリックされたコマが以降の処理に従う
    // マウスをクリックした状態のとき、マウスの位置をコマが追従する
    // マウスが離されたらコマは追従をやめる

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        Debug.Log("MouseDown");
        // このオブジェクトの位置(transform.position)をスクリーン座標に変換。
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // ワールド座標上の、マウスカーソルと、対象の位置の差分。
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Debug.Log("Drag");
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }

    // [SerializeField, Range(0f, 1f)] private float followStrength;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        // var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // targetPos.z = 0f;

        // // クリックした座標に何かあるかみて、pieceだったら、つかみ処理が出るようにする。
        // // ここで書いてはだめだと思う。
        // if(Input.GetMouseButton(0)){
        //     transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);
        // }
    }
}
