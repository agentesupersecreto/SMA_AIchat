using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Interacciones
{
	// Token: 0x02000313 RID: 787
	public abstract class ReacctorDeInteraccionesPartesPrivadasConRopa<TCalculo> : ReacctorDeInteraccionesPartesPrivadasConPersonalidad<TCalculo> where TCalculo : class, ICalculoDeInteracionEstimulante
	{
		// Token: 0x060013E2 RID: 5090 RVA: 0x0005D045 File Offset: 0x0005B245
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ropa = this.GetComponentEnRoot(false);
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x0005D05C File Offset: 0x0005B25C
		private bool CubirendoConRopaParteEstimulada(ICalculoDeInteracionEstimulante calculo, out int cantidadCubriendo)
		{
			cantidadCubriendo = -1;
			ParteDelCuerpoHumano parteDelCuerpoHumano = ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			RopaCubre ropaCubre;
			if (!parteDelCuerpoHumano.TryParce(out ropaCubre))
			{
				throw new NotSupportedException("no se pudo convertir parte estimulada a parte siendo cubierta: " + parteDelCuerpoHumano.ToString());
			}
			bool flag = this.m_ropa.Cubriendo(ropaCubre);
			if (flag)
			{
				cantidadCubriendo = this.m_ropa.CantidadPiezasCubriendo(ropaCubre, true, null);
			}
			return flag;
		}

		// Token: 0x060013E4 RID: 5092
		protected abstract float ModDeRequerimientoPorVestidura(int cantidadDePiezasCubriendo);

		// Token: 0x060013E5 RID: 5093
		protected abstract float ModDePudorPorVestidura(int cantidadDePiezasCubriendo);

		// Token: 0x060013E6 RID: 5094 RVA: 0x0005D0BC File Offset: 0x0005B2BC
		protected override void OnCalculoEnEnPartePrivada(TCalculo calculo)
		{
			this.m_currentParteEstimuladaEstaCubierta = this.CubirendoConRopaParteEstimulada(calculo, out this.m_currentCantidadDePiezasCubriendo);
			if (this.m_currentParteEstimuladaEstaCubierta && this.m_currentCantidadDePiezasCubriendo <= 0)
			{
				throw new InvalidOperationException();
			}
			if (this.m_currentParteEstimuladaEstaCubierta)
			{
				this.m_currentModDeRequerimientoPorVestidura = this.ModDeRequerimientoPorVestidura(this.m_currentCantidadDePiezasCubriendo);
				this.m_currentModDePudorPorVestidura = this.ModDePudorPorVestidura(this.m_currentCantidadDePiezasCubriendo);
				this.m_currentModDePudorPorVestiduraInvertido = 1f / this.m_currentModDePudorPorVestidura;
				return;
			}
			this.m_currentModDeRequerimientoPorVestidura = 1f;
			this.m_currentModDePudorPorVestidura = 1f;
			this.m_currentModDePudorPorVestiduraInvertido = 1f;
		}

		// Token: 0x04000E5E RID: 3678
		[Header("Con Ropa Config")]
		[ReadOnlyUI]
		[SerializeField]
		protected bool m_currentParteEstimuladaEstaCubierta;

		// Token: 0x04000E5F RID: 3679
		[ReadOnlyUI]
		[SerializeField]
		protected int m_currentCantidadDePiezasCubriendo;

		// Token: 0x04000E60 RID: 3680
		[ReadOnlyUI]
		[SerializeField]
		protected float m_currentModDeRequerimientoPorVestidura;

		// Token: 0x04000E61 RID: 3681
		[ReadOnlyUI]
		[SerializeField]
		protected float m_currentModDePudorPorVestidura;

		// Token: 0x04000E62 RID: 3682
		[ReadOnlyUI]
		[SerializeField]
		protected float m_currentModDePudorPorVestiduraInvertido;

		// Token: 0x04000E63 RID: 3683
		private IRopaManager m_ropa;
	}
}
