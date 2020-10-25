using UnityEngine;
public class respawn : MonoBehaviour
{
    Vector3 _InitialPos = new Vector3 (105, 38, 208); // Starting position of the player
    float _YOffset;
    void Start()
    {
        _InitialPos = transform.position;
        _YOffset = _InitialPos.y - 50;
    }

    void Update()
    {
        if (_InitialPos.y < _YOffset)
        {
            transform.position = _InitialPos;
        }
    }
}