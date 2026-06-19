using System;
using System.Collections.Generic;
using Assets.Base.Tiempo.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Semens;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Particulas.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Sonidos;
using Assets._ReusableScripts.Sonidos.Singletones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen
{
	// Token: 0x02000047 RID: 71
	[RequireComponent(typeof(EmisorDeSemenChain))]
	public class EmisorDeSemenChainSetAsWater : CustomMonobehaviour
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x0000BBF8 File Offset: 0x00009DF8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_emisor = base.GetComponent<EmisorDeSemenChain>();
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000BC0C File Offset: 0x00009E0C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_emisor.onChainCreated += this.M_emisor_onChainCreated;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000BC2B File Offset: 0x00009E2B
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_emisor != null)
			{
				this.m_emisor.onChainCreated -= this.M_emisor_onChainCreated;
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000BC5C File Offset: 0x00009E5C
		private void M_emisor_onChainCreated(SemenChain arg1, EmisorDeSemenChain arg2)
		{
			for (int i = 0; i < arg1.semenPuntos.Count; i++)
			{
				SemenPunto semenPunto = arg1.semenPuntos[i];
				SonidoProductor sonidoProductor = semenPunto.gameObject.AddComponent<SonidoProductor>();
				semenPunto.gameObject.AddComponent<DestroyGameObjectAfterTiempoDeJuego>().duration = 3600f;
				sonidoProductor.textura = TexturaDeObjetoSonoro.liquido;
				sonidoProductor.forma = FormaDeObjetoSonoro.circular;
				semenPunto.SetTipo(TipoDeSemen.water);
				semenPunto.onBinding += EmisorDeSemenChainSetAsWater.OnBindingHandler;
				semenPunto.reduceScaleByLifeTime = true;
				if (this.m_reducirLifeTimeRandom && Random.value > 0.5f)
				{
					semenPunto.duracionModificador.ObtenerModificadorNotNull(this).valor.valor = Random.value.InPow(3f);
				}
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000BD1C File Offset: 0x00009F1C
		private static void OnBindingHandler(Collision collision, Collider other, SemenPunto.OnBindingEventArgs args, SemenPunto sender)
		{
			args.AbortV2(false, true, 1f);
			float magnitude = collision.relativeVelocity.magnitude;
			ReproductorDeSonidosUnaVezGenerico reproductor = Singleton<ReproductorDeSonidosDeWaterDrops>.instance.reproductor;
			if (reproductor.EnRangoMinimo(magnitude) && collision.contactCount > 0)
			{
				SonidoProductor component = sender.GetComponent<SonidoProductor>();
				reproductor.RegistrarPedido(component, collision.GetContact(0).point, magnitude);
			}
			if (Random.value > 0.95f)
			{
				HitSkinBasica hitSkinBasica = HitSkinBasica.ObtenerSkinDeCollider(other);
				if (hitSkinBasica != null)
				{
					Vector3 metrosPorSegundo = sender.stepVelocity.metrosPorSegundo;
					if (metrosPorSegundo.sqrMagnitude > 0.0001f)
					{
						Vector3 position = sender.body.transform.position;
						try
						{
							RaycastHit raycastHit;
							if (hitSkinBasica.TryCalcularPartesImpactadasDeCollision(collision, other, out raycastHit, EmisorDeSemenChainSetAsWater.m_impactadasTEmp, new Vector3?(metrosPorSegundo), new Vector3?(position), false) && EmisorDeSemenChainSetAsWater.m_impactadasTEmp.Count > 0)
							{
								SkinSensibleASemen component2 = hitSkinBasica.GetComponent<SkinSensibleASemen>();
								if (component2 != null && sender.ownerPene != null)
								{
									component2.RegistrarContacto(sender.ownerPene, TipoDeSemen.water, position, -metrosPorSegundo, metrosPorSegundo, EmisorDeSemenChainSetAsWater.m_impactadasTEmp);
								}
								CharAi componentEnRoot = hitSkinBasica.GetComponentEnRoot(false);
								if (componentEnRoot != null)
								{
									int num = Mathf.CeilToInt(20f / (float)EmisorDeSemenChainSetAsWater.m_impactadasTEmp.Count);
									for (int i = 0; i < EmisorDeSemenChainSetAsWater.m_impactadasTEmp.Count; i++)
									{
										BodyPartEnum bodyPartEnum = EmisorDeSemenChainSetAsWater.m_impactadasTEmp[i];
										Side side = hitSkinBasica.side;
										Side side2 = ((side != Side.none) ? side : bodyPartEnum.ParseASide());
										ParteDelCuerpoHumano parteDelCuerpoHumano = bodyPartEnum.ParseAParteHumana();
										componentEnRoot.RegistrarSemenSobreTemporal(parteDelCuerpoHumano, TipoDeSemen.semen, side2, num);
									}
								}
							}
						}
						finally
						{
							EmisorDeSemenChainSetAsWater.m_impactadasTEmp.Clear();
						}
					}
				}
			}
		}

		// Token: 0x04000187 RID: 391
		[SerializeField]
		private bool m_reducirLifeTimeRandom;

		// Token: 0x04000188 RID: 392
		private EmisorDeSemenChain m_emisor;

		// Token: 0x04000189 RID: 393
		private static List<BodyPartEnum> m_impactadasTEmp = new List<BodyPartEnum>();
	}
}
