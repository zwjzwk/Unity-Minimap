using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public Collider minimapBoundingBox;

    public Image minimap;

    public Image arrow;

    public GameObject dir;

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        this.InitMap();
    }

    void InitMap()
    {
        this.minimap.SetNativeSize();
        this.minimap.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float realWidth = minimapBoundingBox.bounds.size.x;
        float realHeight = minimapBoundingBox.bounds.size.z;

        float relaX = playerTransform.position.x - minimapBoundingBox.bounds.min.x;
        float relaY = playerTransform.position.z - minimapBoundingBox.bounds.min.z;

        float pivotX = relaX / realWidth;
        float pivotY = relaY / realHeight;

        this.minimap.rectTransform.pivot = new Vector2(pivotX, pivotY);
        this.minimap.rectTransform.localPosition = Vector2.zero;
        this.arrow.transform.eulerAngles = new Vector3(0, 0, -playerTransform.eulerAngles.y);
        this.dir.transform.eulerAngles = new Vector3(0, 0, -Camera.main.transform.eulerAngles.y);
    }

    public void OnClickAdd()
    {
        minimap.transform.localScale += minimap.transform.localScale * 0.2f;
    }

    public void OnClickReduce()
    {
        minimap.transform.localScale -= minimap.transform.localScale * 0.2f;
    }
}
