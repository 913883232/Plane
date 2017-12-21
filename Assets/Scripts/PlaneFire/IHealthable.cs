using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthable
{
	int Health { get; }
    void Damage(int val);
}
