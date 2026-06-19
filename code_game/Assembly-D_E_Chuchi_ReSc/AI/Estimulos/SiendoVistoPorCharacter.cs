using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003E2 RID: 994
	public abstract class SiendoVistoPorCharacter<T_EstimulanteCharacter, T_Estimulado> : ViendoOSiendoVisto<T_EstimulanteCharacter, T_Estimulado> where T_EstimulanteCharacter : AnimatorCharacter where T_Estimulado : MonoBehaviour, IViendoOSiendoVistoUser
	{
		// Token: 0x06001595 RID: 5525 RVA: 0x0005AFE8 File Offset: 0x000591E8
		protected SiendoVistoPorCharacter(HistorialDeCollidersEnRadius historial, T_Estimulado estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, LayerMask checkMask, float precision)
			: base(historial, estimulado, PrioridadesDeObjetoEstimulado, checkMask)
		{
			this.m_precision = precision;
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x0005B04C File Offset: 0x0005924C
		protected sealed override bool EstimulanteEsValido(T_EstimulanteCharacter estimulante)
		{
			Vector3 vector;
			Vector3 vector2;
			if (!BodyPartEnumHelpler.ViendoParametros(estimulante, out vector, out vector2))
			{
				return false;
			}
			int num = BodyPartEnumHelpler.ViendoSkinLayer();
			RaycastHit raycastHit;
			HitSkinBasica hitSkinBasica = BodyPartEnumHelpler.ViendoSkin(vector, vector2, out raycastHit, this.m_pedido.radius, num, base.estimulado.scala, this.m_precision);
			if (hitSkinBasica == null)
			{
				return false;
			}
			if (hitSkinBasica.requiereBodyPartEnumCalculo != null)
			{
				this.m_parteDeCharacter.Add(estimulante, (int)hitSkinBasica.requiereBodyPartEnumCalculo.Value.ParseAParteHumana());
				this.m_sideDeCharacter.Add(estimulante, (int)hitSkinBasica.side);
				this.m_puntoVisualDeCharacter.Add(estimulante, vector);
				this.m_direccionVisualDeCharacter.Add(estimulante, vector2);
				this.m_HitDeCharacter.Add(estimulante, raycastHit);
				this.m_SkinVistaDeCharacter.Add(estimulante, hitSkinBasica);
				return true;
			}
			HitSkin hitSkin = hitSkinBasica as HitSkin;
			if (hitSkin == null)
			{
				return false;
			}
			BodyPartEnum bodyPartEnum;
			if (!Singleton<FemaleHeroBodyPartHitCalculador>.instance.CalcularParteImpactada(hitSkin.hitParte, raycastHit, out bodyPartEnum))
			{
				return false;
			}
			this.m_parteDeCharacter.Add(estimulante, (int)bodyPartEnum.ParseAParteHumana());
			this.m_sideDeCharacter.Add(estimulante, (int)hitSkinBasica.side);
			this.m_puntoVisualDeCharacter.Add(estimulante, vector);
			this.m_direccionVisualDeCharacter.Add(estimulante, vector2);
			this.m_HitDeCharacter.Add(estimulante, raycastHit);
			this.m_SkinVistaDeCharacter.Add(estimulante, hitSkin);
			return true;
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0005B1B4 File Offset: 0x000593B4
		protected sealed override void PoblarEstimuloDeEstimulante(T_EstimulanteCharacter estimulante, EstimuloVisual emptyEstimulo)
		{
			bool flag = true;
			Vector3 vector;
			Vector3 vector2;
			if (BodyPartEnumHelpler.ViendoParametros(estimulante, out vector, out vector2))
			{
				flag = vector.EnCono(this.m_pedido.puntoVisual, this.m_pedido.direccionVisual, this.m_pedido.maxAngleDeVision, this.m_pedido.radius) || vector.EnRadius(this.m_pedido.puntoVisual, this.m_pedido.radiusIgnorandoCono);
			}
			RaycastHit raycastHit = this.m_HitDeCharacter[estimulante];
			EstimuloVisual.PoblarEstimuloDeObservador(emptyEstimulo, base.prioridadesDeObjetoEstimulado, flag, estimulante, null, base.estimulado, this.m_SkinVistaDeCharacter[estimulante].boneTarget, this.m_puntoVisualDeCharacter[estimulante], this.m_direccionVisualDeCharacter[estimulante], new Vector3?(raycastHit.normal), raycastHit.point, this.ObtenerPartesPrincipalAEstimulo(estimulante, emptyEstimulo), (Side)this.m_sideDeCharacter[estimulante], this.ObtenerTipoDeEstimulo(estimulante, emptyEstimulo));
			emptyEstimulo.SetTipoDeEstimuloVisual(TipoDeEstimuloVisual.normal);
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x00004252 File Offset: 0x00002452
		protected sealed override DireccionDeEstimulo ObtenerTipoDeEstimulo(T_EstimulanteCharacter estimulante, EstimuloVisual estimulo)
		{
			return DireccionDeEstimulo.recibida;
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0005B2B3 File Offset: 0x000594B3
		protected sealed override ParteDelCuerpoHumano ObtenerPartesPrincipalAEstimulo(T_EstimulanteCharacter estimulante, EstimuloVisual estimulo)
		{
			return (ParteDelCuerpoHumano)this.m_parteDeCharacter[estimulante];
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void CargarPartesAEstimulo(T_EstimulanteCharacter estimulante, EstimuloVisual estimulo)
		{
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x0005B2C4 File Offset: 0x000594C4
		protected sealed override void FinallyUpdated()
		{
			base.FinallyUpdated();
			this.m_parteDeCharacter.Clear();
			this.m_sideDeCharacter.Clear();
			this.m_puntoVisualDeCharacter.Clear();
			this.m_direccionVisualDeCharacter.Clear();
			this.m_HitDeCharacter.Clear();
			this.m_SkinVistaDeCharacter.Clear();
		}

		// Token: 0x0400114E RID: 4430
		private Dictionary<T_EstimulanteCharacter, int> m_parteDeCharacter = new Dictionary<T_EstimulanteCharacter, int>();

		// Token: 0x0400114F RID: 4431
		private Dictionary<T_EstimulanteCharacter, int> m_sideDeCharacter = new Dictionary<T_EstimulanteCharacter, int>();

		// Token: 0x04001150 RID: 4432
		private Dictionary<T_EstimulanteCharacter, Vector3> m_puntoVisualDeCharacter = new Dictionary<T_EstimulanteCharacter, Vector3>();

		// Token: 0x04001151 RID: 4433
		private Dictionary<T_EstimulanteCharacter, Vector3> m_direccionVisualDeCharacter = new Dictionary<T_EstimulanteCharacter, Vector3>();

		// Token: 0x04001152 RID: 4434
		private Dictionary<T_EstimulanteCharacter, RaycastHit> m_HitDeCharacter = new Dictionary<T_EstimulanteCharacter, RaycastHit>();

		// Token: 0x04001153 RID: 4435
		private Dictionary<T_EstimulanteCharacter, HitSkinBasica> m_SkinVistaDeCharacter = new Dictionary<T_EstimulanteCharacter, HitSkinBasica>();

		// Token: 0x04001154 RID: 4436
		[SerializeField]
		private float m_precision;
	}
}
