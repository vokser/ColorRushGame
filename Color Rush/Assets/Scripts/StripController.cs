using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StripController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Material _neonMaterial;
    [SerializeField] private Color[] stripColors;
    
    private SpriteRenderer stripRenderer;


    private void Start()
    {
        stripRenderer = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void ChangeColor()
    {
        int randomIndex = Random.Range(0, stripColors.Length);
        _neonMaterial.SetColor("_EmissionColor", stripColors[randomIndex]);
        stripRenderer.color = stripColors[randomIndex];
    }

}
