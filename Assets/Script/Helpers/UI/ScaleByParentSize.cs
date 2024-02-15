﻿using UnityEngine;

namespace YARG.Helpers.UI
{
    /// <summary>
    /// Resizes a RectTransform to fit a specified aspect ratio.
    /// </summary>
    [ExecuteAlways]
    [DisallowMultipleComponent]
    public class ScaleByParentSize : MonoBehaviour
    {
        private RectTransform _parentRectTransform = null!;
        private RectTransform ParentRectTransform
        {
            get
            {
                if (_parentRectTransform == null)
                {
                    _parentRectTransform = transform.parent.gameObject.GetComponent<RectTransform>();
                }

                return _parentRectTransform;
            }
        }

        [SerializeField]
        private Vector2 _initialSize = Vector2.one;

        private void Update()
        {
            UpdateScale();
        }

        private void UpdateScale()
        {
            var size = ParentRectTransform.rect.size;
            float xRatio = size.x / _initialSize.x;
            float yRatio = size.y / _initialSize.y;

            transform.localScale = new Vector3(xRatio, yRatio, 1f);
        }
    }
}
