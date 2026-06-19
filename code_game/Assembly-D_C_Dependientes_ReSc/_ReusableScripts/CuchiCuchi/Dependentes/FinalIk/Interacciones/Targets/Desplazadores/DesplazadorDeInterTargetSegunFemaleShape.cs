using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics.Shapes;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets.Desplazadores
{
	// Token: 0x02000180 RID: 384
	public class DesplazadorDeInterTargetSegunFemaleShape : DesplazadorSegunFemaleShape
	{
		// Token: 0x06000847 RID: 2119 RVA: 0x0002B8C8 File Offset: 0x00029AC8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_interaccion = base.GetComponentInParent<Interaccion>();
			if (this.m_interaccion == null)
			{
				throw new ArgumentNullException("m_interaccion", "m_interaccion null reference.");
			}
			this.m_interaccion.comenzada += this.M_interaccion_comenzada;
			this.m_interaccion.terminada += this.M_interaccion_terminada;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0002B933 File Offset: 0x00029B33
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.enabled = false;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0002B944 File Offset: 0x00029B44
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_interaccion != null)
			{
				this.m_interaccion.comenzada -= this.M_interaccion_comenzada;
				this.m_interaccion.terminada -= this.M_interaccion_terminada;
			}
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0002B994 File Offset: 0x00029B94
		private void M_interaccion_comenzada(Interaccion obj)
		{
			this.m_defaultLocalPosition = this.target.localPosition;
			base.enabled = true;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0002B9AE File Offset: 0x00029BAE
		private void M_interaccion_terminada(Interaccion obj)
		{
			base.enabled = false;
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0002B9B7 File Offset: 0x00029BB7
		public override void OnUpdateEvent1()
		{
			if (this.m_interaccion.ejecutandose)
			{
				base.OnUpdateEvent1();
			}
		}

		// Token: 0x040006A2 RID: 1698
		private Interaccion m_interaccion;
	}
}
