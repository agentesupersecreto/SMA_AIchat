using System;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Interacciones
{
	// Token: 0x02000312 RID: 786
	public abstract class ReacctorDeInteraccionesPartesPrivadasConPersonalidad<TCalculo> : ReacctorDeInteraccionesPartesPrivadas<TCalculo> where TCalculo : class, ICalculoDeInteracionEstimulante
	{
		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x060013DD RID: 5085 RVA: 0x0005CF93 File Offset: 0x0005B193
		public float pudorInvertMod
		{
			get
			{
				return MathfExtension.LerpConMedio(4f, 1f, 0.25f, this.m_Personalidad.timidez);
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x060013DE RID: 5086 RVA: 0x0005CFB4 File Offset: 0x0005B1B4
		public float pudorMod
		{
			get
			{
				return MathfExtension.LerpConMedio(0.25f, 1f, 4f, this.m_Personalidad.timidez);
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x060013DF RID: 5087 RVA: 0x0005CFD8 File Offset: 0x0005B1D8
		public float personalidadWeight
		{
			get
			{
				float timidez = this.m_Personalidad.timidez;
				float num = 1f - this.m_Personalidad.exhibicionismo;
				return (timidez + num) / 2f;
			}
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x0005D00A File Offset: 0x0005B20A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Personalidad = this.GetComponentEnCharacter(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
		}

		// Token: 0x04000E5D RID: 3677
		protected Personalidad m_Personalidad;
	}
}
