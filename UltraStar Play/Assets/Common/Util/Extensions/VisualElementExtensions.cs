﻿using System;
using UnityEngine;
using UnityEngine.UIElements;

public static class VisualElementExtensions
{
    public static void RegisterCallbackButtonTriggered(this Button button, Action callback)
    {
        button.RegisterCallback<ClickEvent>(_ => callback());
        button.RegisterCallback<KeyUpEvent>(e =>
        {
            if (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter)
            {
                callback();
            }
        });
    }
}
