using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores
{
	// Token: 0x02000538 RID: 1336
	public class GenericEmocionPorOrgasmo : EmocionPorEmocionMax
	{
		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x060020F3 RID: 8435 RVA: 0x0007B383 File Offset: 0x00079583
		protected override Emocion atMax
		{
			get
			{
				return this.m_placer;
			}
		}

		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x060020F4 RID: 8436 RVA: 0x0007B38B File Offset: 0x0007958B
		protected override Emocion target
		{
			get
			{
				return this.emocionTarget;
			}
		}

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x060020F5 RID: 8437 RVA: 0x0007B393 File Offset: 0x00079593
		protected override float aumentoMod
		{
			get
			{
				return this.aumentoModificador;
			}
		}

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x060020F6 RID: 8438 RVA: 0x0007B39B File Offset: 0x0007959B
		protected override float aumentoTemporalMod
		{
			get
			{
				return this.aumentoTemporalModificador;
			}
		}

		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x060020F7 RID: 8439 RVA: 0x0007B3A3 File Offset: 0x000795A3
		protected override float tiempoParaReducirAumentoTemporalAproxMod
		{
			get
			{
				return this.tiempoParaReducirAumentoTemporalAproxModificador;
			}
		}

		// Token: 0x060020F8 RID: 8440 RVA: 0x0007B3AB File Offset: 0x000795AB
		protected override void AwakeUnityEvent()
		{
			if (this.emocionTarget == null)
			{
				throw new ArgumentNullException("emocionTarget", "emocionTarget null reference.");
			}
			base.AwakeUnityEvent();
		}

		// Token: 0x060020F9 RID: 8441 RVA: 0x0007B3D1 File Offset: 0x000795D1
		protected override void StartUnityEvent()
		{
			this.m_placer = this.emocionTarget.owner.placer;
			base.StartUnityEvent();
		}

		// Token: 0x0400156D RID: 5485
		public Emocion emocionTarget;

		// Token: 0x0400156E RID: 5486
		public float aumentoModificador = 1f;

		// Token: 0x0400156F RID: 5487
		public float aumentoTemporalModificador = 1f;

		// Token: 0x04001570 RID: 5488
		public float tiempoParaReducirAumentoTemporalAproxModificador = 1f;

		// Token: 0x04001571 RID: 5489
		private PlacerBase m_placer;
	}
}
