using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200003B RID: 59
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/die_on_take_damage.html")]
	[AddComponentMenu("Dialogue System/Actor/Die On TakeDamage")]
	public class DieOnTakeDamage : MonoBehaviour
	{
		// Token: 0x060001B2 RID: 434 RVA: 0x000093DC File Offset: 0x000075DC
		private void TakeDamage(float damage)
		{
			if (this.deadPrefab != null)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.deadPrefab, base.transform.position, base.transform.rotation);
				if (gameObject != null)
				{
					gameObject.transform.parent = base.transform.parent;
				}
			}
			Object.Destroy(base.gameObject);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00009443 File Offset: 0x00007643
		private void Damage(float damage)
		{
			this.TakeDamage(damage);
		}

		// Token: 0x04000143 RID: 323
		public GameObject deadPrefab;
	}
}
