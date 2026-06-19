using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Testing.PhyscisAnus
{
	// Token: 0x02000016 RID: 22
	[SelectionBase]
	public class GizmoBone : MonoBehaviour
	{
		// Token: 0x06000085 RID: 133 RVA: 0x00003FB0 File Offset: 0x000021B0
		private void OnDrawGizmos()
		{
			Vector3 position = base.transform.position;
			bool flag = base.name.Contains("DEF");
			bool flag2 = base.name.Contains("STRETCH");
			if (flag)
			{
				DebugExtension.DrawArrow(position, base.transform.forward * 0.001f, Color.cyan);
				return;
			}
			if (flag2)
			{
				DebugExtension.DrawArrow(position, base.transform.forward * 0.007f, Color.yellow);
				return;
			}
			DebugExtension.DrawArrow(position, base.transform.forward * 0.005f, Color.magenta);
		}
	}
}
