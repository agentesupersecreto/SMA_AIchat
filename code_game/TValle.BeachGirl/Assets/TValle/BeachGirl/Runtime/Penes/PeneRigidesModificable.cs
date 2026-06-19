using System;
using System.Collections;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Penes
{
	// Token: 0x02000099 RID: 153
	public class PeneRigidesModificable : CustomMonobehaviour
	{
		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x0000ECFD File Offset: 0x0000CEFD
		public ModificableDeFloat modificable
		{
			get
			{
				return this.m_modificable;
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0000ED05 File Offset: 0x0000CF05
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IPene = base.GetComponent<IPeneRigido>();
			this.m_checker = new CoroutineCapsule(this.CheckRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000ED3E File Offset: 0x0000CF3E
		private IEnumerator CheckRutine()
		{
			yield return new WaitForSeconds(Random.value);
			WaitForSeconds w = new WaitForSeconds(1f);
			for (;;)
			{
				float num = Mathf.Lerp(this.peneSizeModificable.lastSize * 1.3333334f, 1f, 0.5f);
				this.m_IPene.rigidez = this.m_modificable.ModificarValor(this.massMod * num);
				yield return w;
			}
			yield break;
		}

		// Token: 0x040002AE RID: 686
		public float massMod = 1f;

		// Token: 0x040002AF RID: 687
		public PeneSizeModificable peneSizeModificable;

		// Token: 0x040002B0 RID: 688
		[SerializeField]
		private ModificableDeFloat m_modificable = new ModificableDeFloat(1f);

		// Token: 0x040002B1 RID: 689
		private CoroutineCapsule m_checker;

		// Token: 0x040002B2 RID: 690
		private IPeneRigido m_IPene;
	}
}
