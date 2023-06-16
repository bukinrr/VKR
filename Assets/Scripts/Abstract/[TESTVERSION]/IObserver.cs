using System;
using UnityEngine;

public interface IObserver
{
    void Update(object sender, EventArgs args);
}
