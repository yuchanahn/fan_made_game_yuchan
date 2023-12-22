using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBox : MonoBehaviour
{
    [SerializeField] private float spacing = 0.0f;
    [SerializeField] public RectTransform content = null;

    private void OnUpdate()
    {
        var height = 0.0f;
        foreach (Transform child in transform)
        {
            var rect = child.GetComponent<RectTransform>();
            if (height == 0.0f)
                height = rect.rect.height / 2;

            var tr = rect.transform;
            var pos = tr.localPosition;
            pos.y = -height;
            tr.localPosition = pos;
            height += child.GetComponent<RectTransform>().rect.height + spacing;
        }

        if (content)
        {
            content.sizeDelta = new Vector2(content.sizeDelta.x, height);
        }
    }

    private void Update()
    {
        OnUpdate();
    }
}