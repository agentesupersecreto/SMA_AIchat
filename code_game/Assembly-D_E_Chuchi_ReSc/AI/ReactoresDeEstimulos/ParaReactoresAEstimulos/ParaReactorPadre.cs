using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.ParaReactoresAEstimulos
{
	// Token: 0x020003CB RID: 971
	public class ParaReactorPadre : ReactorPadreDummy
	{
		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060014EF RID: 5359 RVA: 0x00059589 File Offset: 0x00057789
		public string paraReactor
		{
			get
			{
				return this.m_paraReactor;
			}
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x00058C08 File Offset: 0x00056E08
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = false;
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x00058C1C File Offset: 0x00056E1C
		protected override void OnValidateUnityEvent()
		{
			base.OnValidateUnityEvent();
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = false;
		}

		// Token: 0x060014F2 RID: 5362 RVA: 0x00058C30 File Offset: 0x00056E30
		protected override bool ArgumentoEsValido(object arg)
		{
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = false;
			return true;
		}

		// Token: 0x040010FE RID: 4350
		[SerializeField]
		[StringSelector(typeof(ParaReactoresTags), "valoresEditor")]
		private string m_paraReactor;
	}
}
