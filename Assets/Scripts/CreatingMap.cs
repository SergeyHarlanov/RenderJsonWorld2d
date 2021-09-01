using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingMap : MapRender
{
    public List<Texture2D> sprite;

    public float offsetScale;
    public Vector2 offsetPos;

    public float limitXleft;
    public float limitXright;
    public float limitYup;
    public float limitYdown;

    void Start()
    {
        Serilizationjson();

        foreach (var item in spriteParts.List)
        {
            sprite.Add((Texture2D)Resources.Load(item.Id));
        }
        for (int i =0 ; i < sprite.Count; i++)
        {
            GameObject gb = new GameObject();

            Sprite mySprite = Sprite.Create(sprite[i], new Rect(0.0f, 0.0f, sprite[i].width, sprite[i].height), new Vector2(0.5f, 0.5f), 100.0f);
            gb.AddComponent<SpriteRenderer>().sprite = mySprite;
            gb.AddComponent<BoxCollider2D>();
            gb.transform.position = new Vector2(spriteParts.List[i].X + offsetPos.x, spriteParts.List[i].Y + offsetPos.y);
            gb.transform.localScale = new Vector2(spriteParts.List[i].Width * offsetScale, spriteParts.List[i].Height * offsetScale);
            gb.transform.SetParent(transform);
            gb.name = (spriteParts.List[i]).Id;

            Vector2 pos = new Vector2(spriteParts.List[i].X + offsetPos.x, spriteParts.List[i].Y + offsetPos.y);

            //limit
            FindLimitSide(pos);
        }
    }
    public void FindLimitSide(Vector3 pos)
    {
        if (limitXleft > pos.x) limitXleft = pos.x;
        if (limitXright * Mathf.Sign(limitXright) < pos.x * Mathf.Sign(pos.x)) limitXright = pos.x;
        if (limitYup > pos.y) limitYup = pos.y;
        if (limitYdown < pos.y) limitYdown = pos.y;
    }
 
}
