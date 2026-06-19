using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Particulas.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas.Skins
{
	// Token: 0x0200015B RID: 347
	[RequireComponent(typeof(HitSkinBasica))]
	public class SkinSensibleASemen : CustomUpdatedMonobehaviourBase, ISemenRegistrable
	{
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x0001A9BC File Offset: 0x00018BBC
		public sealed override int updateEvent1Index
		{
			get
			{
				return 69;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x000246E2 File Offset: 0x000228E2
		public HitSkinBasica hitSkinBasica
		{
			get
			{
				return this.m_HitSkinBasica;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x000246EA File Offset: 0x000228EA
		public List<SemenHit> hits
		{
			get
			{
				return this.m_hits;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x000246F2 File Offset: 0x000228F2
		public SkinSensibleASemen.TocadoPorSemenDeChar tocadoPorSemenDeMaleChar
		{
			get
			{
				return this.m_TocadoPorSemenDeMaleChar;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060007D8 RID: 2008 RVA: 0x000246FA File Offset: 0x000228FA
		public SkinSensibleASemen.TocadoPorSemenDeChar tocadoPorWaterDeMaleChar
		{
			get
			{
				return this.m_TocadoPorWaterDeMaleChar;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x00024702 File Offset: 0x00022902
		public SkinSensibleASemen.TocadoPorSemenDeChar tocadoPorLubeDeMaleChar
		{
			get
			{
				return this.m_TocadoPorLubeDeMaleChar;
			}
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x060007DA RID: 2010 RVA: 0x0002470C File Offset: 0x0002290C
		// (remove) Token: 0x060007DB RID: 2011 RVA: 0x00024744 File Offset: 0x00022944
		public event Action<SemenHit> onContactoRegistrado;

		// Token: 0x060007DC RID: 2012 RVA: 0x0002477C File Offset: 0x0002297C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_HitSkinBasica = base.GetComponent<HitSkinBasica>();
			if (this.m_HitSkinBasica == null)
			{
				throw new ArgumentNullException("m_HitSkinBasica", "m_HitSkinBasica null reference.");
			}
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
			this.m_TocadoPorSemenDeMaleChar = new SkinSensibleASemen.TocadoPorSemenDeChar(TipoDeSemen.semen, this.m_HitSkinBasica, this.m_PrioridadesDeObjetoEstimulado, this);
			this.m_TocadoPorWaterDeMaleChar = new SkinSensibleASemen.TocadoPorSemenDeChar(TipoDeSemen.water, this.m_HitSkinBasica, this.m_PrioridadesDeObjetoEstimulado, this);
			this.m_TocadoPorLubeDeMaleChar = new SkinSensibleASemen.TocadoPorSemenDeChar(TipoDeSemen.lubricante, this.m_HitSkinBasica, this.m_PrioridadesDeObjetoEstimulado, this);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x00024829 File Offset: 0x00022A29
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00024831 File Offset: 0x00022A31
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Clear();
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x00024840 File Offset: 0x00022A40
		private void Clear()
		{
			for (int i = 0; i < this.m_hits.Count; i++)
			{
				this.m_poolDeSemenHits.ReturnItem(this.m_hits[i]);
			}
			this.m_hits.Clear();
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00024885 File Offset: 0x00022A85
		public sealed override void OnUpdateEvent1()
		{
			this.m_TocadoPorSemenDeMaleChar.Update_();
			this.m_TocadoPorWaterDeMaleChar.Update_();
			this.m_TocadoPorLubeDeMaleChar.Update_();
			this.Clear();
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x000248B0 File Offset: 0x00022AB0
		public void RegistrarContacto(IPeneSimple Owner, TipoDeSemen tipo, Vector3 wPosition, Vector3 wNormal, Vector3 velocity, IReadOnlyList<BodyPartEnum> impactadas)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			if (impactadas == null || impactadas.Count == 0)
			{
				HitSkin hitSkin = this.m_HitSkinBasica as HitSkin;
				if (hitSkin != null)
				{
					parteDelCuerpoHumano = Singleton<FemaleHeroBodyPartHitCalculador>.instance.DefaultResult(hitSkin.hitParte).ParseAParteHumana();
				}
				else
				{
					if (this.m_HitSkinBasica.requiereBodyPartEnumCalculo == null)
					{
						return;
					}
					parteDelCuerpoHumano = this.m_HitSkinBasica.requiereBodyPartEnumCalculo.Value.ParseAParteHumana();
				}
			}
			else
			{
				try
				{
					for (int i = 0; i < impactadas.Count; i++)
					{
						SkinSensibleASemen.m_TempParteDelCuerpoHumano.Add(impactadas[i].ParseAParteHumana());
					}
					parteDelCuerpoHumano = SkinSensibleASemen.m_TempParteDelCuerpoHumano.ObtenerLaDeMayorPrioridadTactilFixed(Sexo.femenino);
				}
				finally
				{
					SkinSensibleASemen.m_TempParteDelCuerpoHumano.Clear();
				}
			}
			SemenHit item = this.m_poolDeSemenHits.GetItem();
			item.parteImpactada = parteDelCuerpoHumano;
			item.tipo = tipo;
			item.velocidad = velocity.magnitude;
			item.pene = Owner;
			item.intersection = wPosition;
			item.normal = wNormal;
			this.m_hits.Add(item);
			Action<SemenHit> action = this.onContactoRegistrado;
			if (action == null)
			{
				return;
			}
			action(item);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x000249DC File Offset: 0x00022BDC
		[Obsolete("", true)]
		private float ObtenerVelocidad(int count, List<ParticleCollisionEvent> collisionEvents, out Vector3 punto, out Vector3 normal)
		{
			float num = 0f;
			punto = Vector3.zero;
			normal = Vector3.zero;
			int num2 = Mathf.Min(count, 5);
			for (int i = 0; i < num2; i++)
			{
				ParticleCollisionEvent particleCollisionEvent = collisionEvents[i];
				num += particleCollisionEvent.velocity.magnitude;
				punto += particleCollisionEvent.intersection;
				normal += particleCollisionEvent.normal;
			}
			punto /= (float)num2;
			normal = normal.normalized;
			return num / (float)num2;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x00024A8C File Offset: 0x00022C8C
		[Obsolete("", true)]
		private BodyPartEnum ObtenerPartEnum(HitSkin skin, int count, List<ParticleCollisionEvent> collisionEvents)
		{
			if (count <= 0)
			{
				return Singleton<FemaleHeroBodyPartHitCalculador>.instance.DefaultResult(skin.hitParte);
			}
			bool queriesHitBackfaces = Physics.queriesHitBackfaces;
			Physics.queriesHitBackfaces = true;
			int num = Mathf.Min(count, 5);
			bool flag = false;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			float num2 = 0.1f;
			try
			{
				for (int i = 0; i < num; i++)
				{
					ParticleCollisionEvent particleCollisionEvent = collisionEvents[i];
					Collider collider = particleCollisionEvent.colliderComponent as Collider;
					if (!(collider == null))
					{
						if (!this.m_HitSkinBasica.skinCollidersSet.Contains(collider))
						{
							Debug.LogWarning("Hit skin: " + this.m_HitSkinBasica.name + ". no contiene collider: " + collider.name, collider);
						}
						else
						{
							Ray ray = new Ray(particleCollisionEvent.intersection + particleCollisionEvent.normal * 0.02f, -particleCollisionEvent.normal);
							bool flag2 = this.debugDraw;
							RaycastHit raycastHit;
							BodyPartEnum bodyPartEnum;
							if (collider.Raycast(ray, out raycastHit, 0.04f) && Singleton<FemaleHeroBodyPartHitCalculador>.instance.CalcularParteImpactada(skin.hitParte, raycastHit, out bodyPartEnum))
							{
								bool flag3 = this.debugDraw;
								return bodyPartEnum;
							}
						}
					}
				}
				flag = true;
				int num3 = Mathf.Min(count, 30);
				for (int j = 0; j < num3; j++)
				{
					ParticleCollisionEvent particleCollisionEvent2 = collisionEvents[j];
					vector += particleCollisionEvent2.intersection;
					vector2 += particleCollisionEvent2.normal;
				}
				vector /= (float)num3;
				vector2 = vector2.normalized;
				for (int k = 0; k < 3; k++)
				{
					float num4 = num2 * (float)(k + 1);
					for (int l = 0; l < this.m_HitSkinBasica.skinColliders.Count; l++)
					{
						Collider collider2 = this.m_HitSkinBasica.skinColliders[l];
						if (!(collider2 == null))
						{
							Ray ray2 = new Ray(vector + vector2 * (num4 * 0.5f), -vector2);
							bool flag4 = this.debugDraw;
							RaycastHit raycastHit2;
							BodyPartEnum bodyPartEnum2;
							if (collider2.Raycast(ray2, out raycastHit2, num4) && Singleton<FemaleHeroBodyPartHitCalculador>.instance.CalcularParteImpactada(skin.hitParte, raycastHit2, out bodyPartEnum2))
							{
								bool flag5 = this.debugDraw;
								return bodyPartEnum2;
							}
						}
					}
				}
			}
			finally
			{
				Physics.queriesHitBackfaces = queriesHitBackfaces;
			}
			Debug.LogError("Nose encontro BodyPartEnum de hit de particulas de semen chocando", this);
			if (Application.isEditor)
			{
				HashSet<Component> hashSet = new HashSet<Component>();
				for (int m = 0; m < num; m++)
				{
					ParticleCollisionEvent particleCollisionEvent3 = collisionEvents[m];
					new Ray(particleCollisionEvent3.intersection + particleCollisionEvent3.normal * 0.02f, -particleCollisionEvent3.normal);
					hashSet.Add(particleCollisionEvent3.colliderComponent);
				}
				if (flag)
				{
					for (int n = 0; n < 3; n++)
					{
						float num5 = num2 * (float)(n + 1);
						for (int num6 = 0; num6 < this.m_HitSkinBasica.skinColliders.Count; num6++)
						{
							new Ray(vector + vector2 * (num5 * 0.5f), -vector2);
						}
					}
				}
				Debug.LogError("Particulas Chocando Contra:", this);
				foreach (Component component in hashSet)
				{
					Debug.LogError(component.name, component);
				}
				Debug.Break();
			}
			return Singleton<FemaleHeroBodyPartHitCalculador>.instance.DefaultResult(skin.hitParte);
		}

		// Token: 0x0400062F RID: 1583
		public bool debugDraw;

		// Token: 0x04000630 RID: 1584
		private HitSkinBasica m_HitSkinBasica;

		// Token: 0x04000631 RID: 1585
		[Obsolete("", true)]
		private ParticulasDeSemenParaSkins m_ParticulasDeSemenParaSkins;

		// Token: 0x04000632 RID: 1586
		private List<SemenHit> m_hits = new List<SemenHit>();

		// Token: 0x04000633 RID: 1587
		private SimplePoolDeClearables<SemenHit> m_poolDeSemenHits = new SimplePoolDeClearables<SemenHit>();

		// Token: 0x04000634 RID: 1588
		private SkinSensibleASemen.TocadoPorSemenDeChar m_TocadoPorSemenDeMaleChar;

		// Token: 0x04000635 RID: 1589
		private SkinSensibleASemen.TocadoPorSemenDeChar m_TocadoPorWaterDeMaleChar;

		// Token: 0x04000636 RID: 1590
		private SkinSensibleASemen.TocadoPorSemenDeChar m_TocadoPorLubeDeMaleChar;

		// Token: 0x04000637 RID: 1591
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x04000639 RID: 1593
		private static List<ParteDelCuerpoHumano> m_TempParteDelCuerpoHumano = new List<ParteDelCuerpoHumano>();

		// Token: 0x0200015C RID: 348
		public sealed class TocadoPorSemenDeChar : TocadoPorSemenDeCharacter<ICharacter, HitSkinBasica>
		{
			// Token: 0x060007E6 RID: 2022 RVA: 0x00024E72 File Offset: 0x00023072
			public TocadoPorSemenDeChar(TipoDeSemen paraTipo, HitSkinBasica estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, SkinSensibleASemen skin)
				: base(paraTipo, estimulado, PrioridadesDeObjetoEstimulado, skin)
			{
			}

			// Token: 0x060007E7 RID: 2023 RVA: 0x00024E7F File Offset: 0x0002307F
			protected override object ParceEstimulante(object estimulante)
			{
				if (estimulante is Penis)
				{
					return ((Penis)estimulante).inmediateOwner;
				}
				return estimulante;
			}

			// Token: 0x060007E8 RID: 2024 RVA: 0x00024E98 File Offset: 0x00023098
			protected override bool TryGetParteDelCuerpoHumanoDeObjectoPenetrado(IPenetrable penetrado, out ParteDelCuerpoHumano parte)
			{
				parte = ParteDelCuerpoHumano.pecho;
				if (base.estimulado.requiereBodyPartEnumCalculo == null)
				{
					return false;
				}
				parte = base.estimulado.requiereBodyPartEnumCalculo.Value.ParseAParteHumana();
				return true;
			}
		}
	}
}
