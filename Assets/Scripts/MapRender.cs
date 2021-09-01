using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRender : MonoBehaviour
{
    
    public TextAsset textAsset;
    public SpriteParts spriteParts;
    // Start is called before the first frame update
    public void Serilizationjson()
    {
        spriteParts = JsonUtility.FromJson<SpriteParts>(textAsset.text);
    }

    [System.Serializable]
    public class List
    {
        public string Id;
        public string Type;

        public float X;
        public float Y;

        public float Width;
        public float Height;
    }
    [System.Serializable]
    public class SpriteParts
    {
        public List[] List;
    }
}


