using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Estimulos.Sonidos
{
	// Token: 0x020000A8 RID: 168
	public static class RerpoductorHitSkinsTouchParaManyHelpler
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x0000DDB5 File Offset: 0x0000BFB5
		public static void CancelInit(this ReproductorDeSonidos repro)
		{
			repro.SetAutoStart();
			repro.CancelInicializable();
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000DDC4 File Offset: 0x0000BFC4
		public static bool TrySetEstimulables(this IReproductorDeSonidoDeToques repro, List<HitPartEnum> paraHitSkins, List<BodyPartEnum> paraEmulatedHitSkins, bool paraPadre)
		{
			if (paraHitSkins.Count == 0 && paraEmulatedHitSkins.Count == 0 && !paraPadre)
			{
				throw new InvalidOperationException();
			}
			Component component = repro as Component;
			List<IEstimulablePorToques> list = new List<IEstimulablePorToques>();
			if (!paraPadre)
			{
				List<IHitSkinEstimulablePorToques> list2 = new List<IHitSkinEstimulablePorToques>();
				component.GetComponentsEnRoot(false, list2);
				paraHitSkins.Distinct<HitPartEnum>();
				for (int i = list2.Count - 1; i >= 0; i--)
				{
					IHitSkinEstimulablePorToques hitSkinEstimulablePorToques = list2[i];
					if (!paraHitSkins.Contains(hitSkinEstimulablePorToques.hitParte))
					{
						list2.RemoveAt(i);
					}
				}
				for (int j = 0; j < list2.Count; j++)
				{
					list.Add(list2[j]);
				}
				List<IEmulatedHitSkinEstimulablePorToques> list3 = new List<IEmulatedHitSkinEstimulablePorToques>();
				component.GetComponentsEnRoot(false, list3);
				paraEmulatedHitSkins.Distinct<BodyPartEnum>();
				for (int k = list3.Count - 1; k >= 0; k--)
				{
					IEmulatedHitSkinEstimulablePorToques emulatedHitSkinEstimulablePorToques = list3[k];
					if (!paraEmulatedHitSkins.Contains(emulatedHitSkinEstimulablePorToques.bodyPart))
					{
						list3.RemoveAt(k);
					}
				}
				for (int l = 0; l < list3.Count; l++)
				{
					list.Add(list3[l]);
				}
			}
			else
			{
				IEstimulablePorToques componentInParent = component.GetComponentInParent<IEstimulablePorToques>();
				if (componentInParent != null)
				{
					list.Add(componentInParent);
				}
			}
			if (list.Count == 0)
			{
				return false;
			}
			repro.Init(list);
			return true;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000DF08 File Offset: 0x0000C108
		public static void ForceEstimulablesOfGenericHitSkin(this IReproductorDeSonidoDeToques repro, List<HitPartEnum> paraHitSkins)
		{
			HitPartEnum hitPartEnum;
			if (paraHitSkins.Count == 0)
			{
				hitPartEnum = HitPartEnum.torzo;
			}
			else
			{
				hitPartEnum = paraHitSkins.First<HitPartEnum>();
			}
			Component component = repro as Component;
			Rigidbody componentInParent = component.GetComponentInParent<Rigidbody>();
			Transform transform;
			if (componentInParent == null)
			{
				transform = component.transform;
			}
			else
			{
				transform = componentInParent.transform;
			}
			GenericHitSkin genericHitSkin = transform.gameObject.AddComponent<GenericHitSkin>();
			genericHitSkin.Init(hitPartEnum, transform, null);
			genericHitSkin.bodyPartEnum = BodyPartEnum.frente;
			repro.Init(genericHitSkin);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000DF78 File Offset: 0x0000C178
		public static void ForceEstimulablesOfGenericVirtualHitSkin(this IReproductorDeSonidoDeToques repro, List<HitPartEnum> paraHitSkins)
		{
			HitPartEnum hitPartEnum;
			if (paraHitSkins.Count == 0)
			{
				hitPartEnum = HitPartEnum.torzo;
			}
			else
			{
				hitPartEnum = paraHitSkins.First<HitPartEnum>();
			}
			Component component = repro as Component;
			Rigidbody componentInParent = component.GetComponentInParent<Rigidbody>();
			Transform transform;
			if (componentInParent == null)
			{
				transform = component.transform;
			}
			else
			{
				transform = componentInParent.transform;
			}
			GenericVirtualHitSkin genericVirtualHitSkin = transform.gameObject.AddComponent<GenericVirtualHitSkin>();
			genericVirtualHitSkin.Init(hitPartEnum, BodyPartEnum.frente, transform, null, Side.none);
			repro.Init(genericVirtualHitSkin);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000DFE4 File Offset: 0x0000C1E4
		public static void ForceEstimulablesOfGenericEmulatedHitSkin(this IReproductorDeSonidoDeToques repro, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			Component component = repro as Component;
			SphereCollider sphereCollider = component.GetComponentInParent<SphereCollider>();
			if (sphereCollider == null)
			{
				sphereCollider = component.transform.root.gameObject.AddComponent<SphereCollider>();
			}
			GenericProxyHitSkin genericProxyHitSkin = sphereCollider.gameObject.AddComponent<GenericProxyHitSkin>();
			genericProxyHitSkin.Init(sphereCollider, Side.none, BodyPartEnum.frente, component.transform, null, layerMask, queryTriggerInteraction);
			repro.Init(genericProxyHitSkin);
		}

		// Token: 0x020000A9 RID: 169
		public enum TipoDeHitSkinsDebug
		{
			// Token: 0x040002C1 RID: 705
			normal,
			// Token: 0x040002C2 RID: 706
			@virtual,
			// Token: 0x040002C3 RID: 707
			emulada
		}
	}
}
