using System;
using System.Collections;
using UnityEngine;

namespace Assets.Base.Plugins.Runtime
{
	// Token: 0x0200017E RID: 382
	public class ShadersWarmUpDialog : MonoBehaviour
	{
		// Token: 0x06000B60 RID: 2912 RVA: 0x00025E98 File Offset: 0x00024098
		private void Start()
		{
			if (this.misShaders == null)
			{
				throw new ArgumentNullException("misShaders", "misShaders null reference.");
			}
			if (this.canvas == null)
			{
				throw new ArgumentNullException("canvas", "canvas null reference.");
			}
			base.StartCoroutine(this.IniciarProcesoCarga());
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x00025EEE File Offset: 0x000240EE
		private IEnumerator IniciarProcesoCarga()
		{
			this.canvas.gameObject.SetActive(true);
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			if (this.misShaders != null && !this.misShaders.isWarmedUp)
			{
				this.misShaders.WarmUp();
				yield return null;
			}
			yield return new WaitForEndOfFrame();
			this.canvas.gameObject.SetActive(false);
			yield break;
		}

		// Token: 0x0400038A RID: 906
		public Canvas canvas;

		// Token: 0x0400038B RID: 907
		public ShaderVariantCollection misShaders;
	}
}
