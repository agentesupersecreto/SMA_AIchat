using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003E4 RID: 996
	public abstract class ViendoA<T_Estimulante, T_Estimulado> : ViendoOSiendoVisto<T_Estimulante, T_Estimulado>, IViendoA where T_Estimulante : Component where T_Estimulado : MonoBehaviour, IViendoOSiendoVistoUser
	{
		// Token: 0x0600159D RID: 5533 RVA: 0x0005B319 File Offset: 0x00059519
		protected ViendoA(HistorialDeCollidersEnRadius historial, T_Estimulado estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, LayerMask checkMask)
			: base(historial, estimulado, PrioridadesDeObjetoEstimulado, checkMask)
		{
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x0005B328 File Offset: 0x00059528
		protected sealed override void PoblarEstimuloDeEstimulante(T_Estimulante estimulante, EstimuloVisual emptyEstimulo)
		{
			emptyEstimulo.tipoDeEstimulo = TipoDeEstimulo.visual;
			Collider collider = this.m_ColliderDeEstimulante[estimulante];
			Transform transform = this.ObtenerTransformEstimulanteDeCollider(estimulante, collider);
			emptyEstimulo.DefinirReferencias(base.estimulado, base.prioridadesDeObjetoEstimulado, estimulante, transform, null);
			emptyEstimulo.side = Side.none;
			if (base.estimulado.camara)
			{
				emptyEstimulo.DefinirTransformEstimuladoYVectoresDeEstimuloVisual(base.estimulado.cabeza, emptyEstimulo.transformEstimulante, -this.m_pedido.direccionVisual, collider.ClosestPointOnBounds(this.m_pedido.puntoVisual), this.m_pedido.puntoVisual, base.estimulado.camara, null);
			}
			else
			{
				emptyEstimulo.DefinirTransformEstimuladoYVectoresDeEstimuloVisual(base.estimulado.ojoIzqierdo, emptyEstimulo.transformEstimulante, -this.m_pedido.direccionVisual, collider.ClosestPointOnBounds(this.m_pedido.puntoVisual), this.m_pedido.puntoVisual, base.estimulado.ojoDerecho, null);
			}
			emptyEstimulo.tipo = this.ObtenerTipoDeEstimulo(estimulante, emptyEstimulo);
			emptyEstimulo.AddParteEstimulada(this.ObtenerPartesPrincipalAEstimulo(estimulante, emptyEstimulo));
			this.CargarPartesAEstimulo(estimulante, emptyEstimulo);
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x0005B468 File Offset: 0x00059668
		protected virtual Transform ObtenerTransformEstimulanteDeCollider(T_Estimulante estimulante, Collider collider)
		{
			return collider.transform;
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override DireccionDeEstimulo ObtenerTipoDeEstimulo(T_Estimulante estimulante, EstimuloVisual estimulo)
		{
			return DireccionDeEstimulo.dada;
		}

		// Token: 0x060015A1 RID: 5537
		protected abstract ParteQuePuedeEstimular GetParteEstimulante(ICharacter estimulante, EstimuloVisual estimulo);

		// Token: 0x060015A2 RID: 5538 RVA: 0x0005B470 File Offset: 0x00059670
		protected sealed override void FinallyUpdated()
		{
			base.FinallyUpdated();
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x0005B478 File Offset: 0x00059678
		public bool ContieneEstimuloVisual<T_estimulo>(ICharacter estimulante, out T_estimulo estimulo, out ParteQuePuedeEstimular estimulanteParte) where T_estimulo : EstimuloVisual
		{
			if (!base.ContieneEstimuloV3<T_estimulo>(estimulante, out estimulo))
			{
				estimulanteParte = ParteQuePuedeEstimular.None;
				return false;
			}
			estimulanteParte = this.GetParteEstimulante(estimulante, estimulo);
			return true;
		}
	}
}
