using System;
using System.Collections;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Penes
{
	// Token: 0x0200009A RID: 154
	[RequireComponent(typeof(IPeneCresiente))]
	public class PeneSizeModificable : CustomMonobehaviour
	{
		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000ED70 File Offset: 0x0000CF70
		public ModificableDeFloat sizeModificable
		{
			get
			{
				return this.m_sizeModificable;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000ED78 File Offset: 0x0000CF78
		public ModificableDeFloat anchoModModificable
		{
			get
			{
				return this.m_anchoModModificable;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000ED80 File Offset: 0x0000CF80
		public float lastSize
		{
			get
			{
				return this.m_lastSize;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0000ED88 File Offset: 0x0000CF88
		public float lastAncho
		{
			get
			{
				return this.m_lastSize;
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0000ED90 File Offset: 0x0000CF90
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IPene = base.GetComponent<IPeneCresiente>();
			this.m_checker = new CoroutineCapsule(this.CheckRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0000EDC9 File Offset: 0x0000CFC9
		private IEnumerator CheckRutine()
		{
			yield return new WaitForSeconds(Random.value);
			WaitForSeconds w = new WaitForSeconds(1f);
			for (;;)
			{
				this.m_lastSize = this.m_sizeModificable.ModificarValor(this.size);
				this.m_lastAncho = this.m_lastSize * this.m_anchoModModificable.ModificarValor(this.anchoMod);
				this.m_IPene.largo = this.m_lastSize;
				this.m_IPene.ancho = this.m_lastAncho;
				yield return w;
			}
			yield break;
		}

		// Token: 0x040002B3 RID: 691
		public float size = 1f;

		// Token: 0x040002B4 RID: 692
		public float anchoMod = 1f;

		// Token: 0x040002B5 RID: 693
		[SerializeField]
		private ModificableDeFloat m_sizeModificable = new ModificableDeFloat(1f);

		// Token: 0x040002B6 RID: 694
		[SerializeField]
		private ModificableDeFloat m_anchoModModificable = new ModificableDeFloat(1f);

		// Token: 0x040002B7 RID: 695
		private CoroutineCapsule m_checker;

		// Token: 0x040002B8 RID: 696
		private IPeneCresiente m_IPene;

		// Token: 0x040002B9 RID: 697
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastSize = 1f;

		// Token: 0x040002BA RID: 698
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastAncho = 1f;
	}
}
