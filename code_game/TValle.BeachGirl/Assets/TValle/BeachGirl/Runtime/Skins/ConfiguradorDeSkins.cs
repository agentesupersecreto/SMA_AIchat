using System;
using System.Collections.Generic;
using Assets.Scripts.MeshCalcules;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.WorkingMeshCalcules;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.WorkingMeshCalcules.Semis;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.WorkingMeshCalcules.Semis.Abstracts;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.MeshCalcules.Runtime.ImplementacionLayer.WorkingMeshCalcules;
using Assets.TValle.MeshCalcules.TUpdaters.Runtime;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Skins
{
	// Token: 0x02000069 RID: 105
	public class ConfiguradorDeSkins : Singleton<ConfiguradorDeSkins>
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060001D5 RID: 469 RVA: 0x000043C8 File Offset: 0x000025C8
		// (remove) Token: 0x060001D6 RID: 470 RVA: 0x00004400 File Offset: 0x00002600
		public event ConfiguradorDeSkins.AddingComponentesExtrasHandler adding;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060001D7 RID: 471 RVA: 0x00004438 File Offset: 0x00002638
		// (remove) Token: 0x060001D8 RID: 472 RVA: 0x00004470 File Offset: 0x00002670
		public event ConfiguradorDeSkins.AddingComponentesExtrasHandler onAdd;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060001D9 RID: 473 RVA: 0x000044A8 File Offset: 0x000026A8
		// (remove) Token: 0x060001DA RID: 474 RVA: 0x000044E0 File Offset: 0x000026E0
		public event ConfiguradorDeSkins.AddingComponentesExtrasHandler added;

		// Token: 0x060001DB RID: 475 RVA: 0x00004518 File Offset: 0x00002718
		public void AddComponentesExtras(SkinnedMeshRenderer renderer, Animator source, SkinConfig config, ICharacterSkinMeshConfig charConfig = null, object extraData = null, Transform ownArmature = null)
		{
			ConfiguradorDeSkins.AddingComponentesExtrasHandler addingComponentesExtrasHandler = this.adding;
			if (addingComponentesExtrasHandler != null)
			{
				addingComponentesExtrasHandler(renderer, source, config, charConfig, extraData, ownArmature);
			}
			bool flag = (charConfig == null && config.recalculadores.Count > 0) || (config.recalculadores.Count > 0 && ((charConfig != null) ? new bool?(charConfig.recalculaNormales) : null).GetValueOrDefault());
			bool flag2 = !config.forceNoNormalRecalculation;
			if (config.canBeBakedIntoACollider || flag || flag2)
			{
				if (ownArmature != null)
				{
					bool flag3;
					ISkeletonGeneral componentNotNull = ownArmature.GetComponentNotNull(out flag3);
					if (flag3)
					{
						((Skeleton)componentNotNull).prefabLayout = renderer.gameObject;
					}
				}
				renderer.GetComponentNotNull<BaseWorkingMeshSemiWritable, SkinnedWorkingMesh>();
				renderer.GetComponentNotNull<WorkingMeshUpdater>();
				renderer.GetComponentNotNull<MeshSkeleton>();
				renderer.GetComponentNotNull<ShapeKeysWeightsGetter>();
				if (flag)
				{
					ConfiguradorDeSkins.AddRecalculadoresLegacy(renderer, config.recalculadores);
				}
				if (flag2)
				{
					ConfiguradorDeSkins.AddFullMeshRecalculadores(renderer);
				}
			}
			if (!config.canTriangleSurfaceAttachment)
			{
				renderer.GetComponentNotNull<ISkinIgnoreAttachments, SkinIgnoreAttachments>();
			}
			ConfiguradorDeSkins.AddingComponentesExtrasHandler addingComponentesExtrasHandler2 = this.onAdd;
			if (addingComponentesExtrasHandler2 != null)
			{
				addingComponentesExtrasHandler2(renderer, source, config, charConfig, extraData, ownArmature);
			}
			ConfiguradorDeSkins.AddingComponentesExtrasHandler addingComponentesExtrasHandler3 = this.added;
			if (addingComponentesExtrasHandler3 == null)
			{
				return;
			}
			addingComponentesExtrasHandler3(renderer, source, config, charConfig, extraData, ownArmature);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000463E File Offset: 0x0000283E
		public static void AddRecalculadoresLegacy(SkinnedMeshRenderer renderer, List<NormalRecalculadorBoneMap.Tipo> recalculadores)
		{
			NormalRecalculadorBoneMap.AñadirRecalculadoresV2(renderer, recalculadores);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00004647 File Offset: 0x00002847
		public static void AddFullMeshRecalculadores(SkinnedMeshRenderer renderer)
		{
			NormalRecalculadorBoneMap.AñadirFullMeshRecalculadores(renderer);
		}

		// Token: 0x0200014E RID: 334
		// (Invoke) Token: 0x06000DCD RID: 3533
		public delegate void AddingComponentesExtrasHandler(SkinnedMeshRenderer renderer, Animator source, SkinConfig config, ICharacterSkinMeshConfig charConfig = null, object extraData = null, Transform ownArmature = null);
	}
}
