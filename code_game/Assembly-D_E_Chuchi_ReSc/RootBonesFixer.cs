using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x0200000F RID: 15
	public class RootBonesFixer : ExtendedMonoBehaviour
	{
		// Token: 0x06000063 RID: 99 RVA: 0x000038D1 File Offset: 0x00001AD1
		private void Awake()
		{
			if (this.fixOnAwake)
			{
				this.FixRootBones();
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000038E4 File Offset: 0x00001AE4
		public void FixRootBones()
		{
			MapaCorrectorDeSkinBoneRoot correctorDeRoot = Singleton<MapasDeHuesos>.instance.otros.correctorDeRoot;
			if (correctorDeRoot == null)
			{
				return;
			}
			RootBonesFixer.FixRootBones(correctorDeRoot, base.transform);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003918 File Offset: 0x00001B18
		public static void FixRootBones(MapaCorrectorDeSkinBoneRoot rootBonesMap, Transform charRoot)
		{
			if (rootBonesMap == null)
			{
				return;
			}
			foreach (MapaCorrectorDeSkinBoneRoot.Par par in rootBonesMap.pares)
			{
				RootBonesFixer.FixRootBone(charRoot, par);
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003970 File Offset: 0x00001B70
		private static void FixRootBone(Transform transform, MapaCorrectorDeSkinBoneRoot.Par par)
		{
			Transform transform2 = transform.FindDeepChild(par.skinName, true);
			if (transform2 == null)
			{
				throw new ArgumentNullException(par.skinName, par.skinName + " body part was not found in " + transform.name);
			}
			SkinnedMeshRenderer component = transform2.GetComponent<SkinnedMeshRenderer>();
			if (component == null)
			{
				throw new ArgumentNullException(par.skinName, par.skinName + " is not a skin renderer. " + transform.name);
			}
			Transform transform3 = transform.FindDeepChild(par.boneName, true);
			if (transform3 == null)
			{
				throw new ArgumentNullException(par.boneName, par.boneName + " bone was not found in " + transform.name);
			}
			RootBonesFixer.CambiarRootBone(component, transform3, par.boundsExpansion);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003A2C File Offset: 0x00001C2C
		public static void CambiarRootBone(SkinnedMeshRenderer skin, Transform newRoot, float boundsExtendsMod)
		{
			Bounds bounds = skin.bounds;
			Vector3 vector = newRoot.InverseTransformPoint(bounds.center);
			Vector3 vector2 = newRoot.InverseTransformPoint(bounds.center + bounds.extents) - vector;
			skin.rootBone = newRoot;
			Bounds bounds2 = new Bounds(vector, vector2 * 2f * boundsExtendsMod);
			skin.localBounds = bounds2;
		}

		// Token: 0x04000059 RID: 89
		[SerializeField]
		private bool fixOnAwake;
	}
}
