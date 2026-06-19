using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Semen
{
	// Token: 0x0200008C RID: 140
	[RequireComponent(typeof(Renderer))]
	public class TestDisableBatcher : CustomMonobehaviour
	{
		// Token: 0x06000371 RID: 881 RVA: 0x0000D697 File Offset: 0x0000B897
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000D6AC File Offset: 0x0000B8AC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			this.m_renderer.GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetColor("_BaseColor", Color.Lerp(Color.white, Color.yellow, 0.5f));
			this.m_renderer.SetPropertyBlock(materialPropertyBlock);
		}

		// Token: 0x0400026F RID: 623
		private Renderer m_renderer;
	}
}
