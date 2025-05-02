using UnityEngine;
using UnityEngine.UI;
public class BGMove : MonoBehaviour
{
    public RawImage _img;
    public float _x;
    public float _y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}
