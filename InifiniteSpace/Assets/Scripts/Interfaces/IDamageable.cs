using UnityEngine;
using System.Collections;

public interface IDamageable<T> 
{

	void TakeDamage(T damage);

}
