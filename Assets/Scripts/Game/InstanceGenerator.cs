using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceGenerator : MonoBehaviour
{
    struct GeneratedItem
    {
        public GameObject obj;
        public Vector3 pos;
        public Quaternion rot;

        public GeneratedItem(GameObject obj, Vector3 pos, Quaternion rot)
        {
            this.obj = obj;
            this.pos = pos;
            this.rot = rot;
        }
    }

    private List<GeneratedItem> _toInstantiate;

    private void Start()
    {
        _toInstantiate = new List<GeneratedItem>();
    }

    private void Update()
    {
        foreach (var item in _toInstantiate)
        {
            var newInstance = Instantiate(item.obj, item.pos, item.rot);
            newInstance.transform.SetParent(null);
        }
        _toInstantiate.Clear();
    }

    public void MakeInstance(GameObject obj, Vector3 pos, Quaternion rot)
    {
        _toInstantiate.Add(new GeneratedItem(obj, pos, rot));
    }
}
