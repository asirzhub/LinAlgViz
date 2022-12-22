using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : MonoBehaviour
{
    private bool _dirty;

    public void MarkDirty()
    {
        _dirty = true;
    }

    public virtual void ApplyNewState()
    {

    }

    private void FixedUpdate()
    {
        if (_dirty)
        {
            _dirty = false;
            ApplyNewState();
        }
    }
}
