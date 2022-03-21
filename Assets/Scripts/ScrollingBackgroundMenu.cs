using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollingBackgroundMenu : MonoBehaviour
{
    private RawImage _img;
    [SerializeField] float _x = .1f,_y = .1f;
    // Start is called before the first frame update
    void Start()
    {
        _img = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x,_y)*Time.deltaTime,_img.uvRect.size);
    }
}
