using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x0200013C RID: 316
	public class SimpleRopaLoader : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000747 RID: 1863 RVA: 0x000224E1 File Offset: 0x000206E1
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (!this.enStart)
			{
				this.Añadir();
			}
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x000224F7 File Offset: 0x000206F7
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.enStart)
			{
				this.Añadir();
			}
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00022510 File Offset: 0x00020710
		private void Añadir()
		{
			ArmatureSkins componentInParent = base.GetComponentInParent<ArmatureSkins>();
			SkinnedMeshRenderer[] componentsInChildren = this.setPrefab.GetComponentsInChildren<SkinnedMeshRenderer>();
			ICharacterSkinMeshConfig characterSkinMeshConfig = componentInParent.animator.transform.GetComponentEnRoot(false);
			if (characterSkinMeshConfig == null)
			{
				characterSkinMeshConfig = default(SimpleRopaLoader.DEF_CharacterMeshConfig);
			}
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
			{
				SkinnedMeshRenderer skinnedMeshRenderer2;
				if (this.isntanciar)
				{
					skinnedMeshRenderer2 = Object.Instantiate<SkinnedMeshRenderer>(skinnedMeshRenderer);
				}
				else
				{
					skinnedMeshRenderer2 = skinnedMeshRenderer;
				}
				Skin skin = componentInParent.AddSkin<Skin, Skin>(skinnedMeshRenderer2, new SkinConfig
				{
					clonarMateriales = true,
					usarTessellation = true
				}, true, false, characterSkinMeshConfig, null, null);
				this.añadidos.Add(skin);
			}
		}

		// Token: 0x040005C5 RID: 1477
		public bool enStart = true;

		// Token: 0x040005C6 RID: 1478
		public bool isntanciar = true;

		// Token: 0x040005C7 RID: 1479
		[Tooltip("cargara todas las piezas en este prefab")]
		public GameObject setPrefab;

		// Token: 0x040005C8 RID: 1480
		[ReadOnlyUI]
		public List<Skin> añadidos = new List<Skin>();

		// Token: 0x040005C9 RID: 1481
		public List<NormalRecalculadorBoneMap.Tipo> recalculadores = new List<NormalRecalculadorBoneMap.Tipo>();

		// Token: 0x0200013D RID: 317
		private struct DEF_CharacterMeshConfig : ICharacterSkinMeshConfig
		{
			// Token: 0x17000186 RID: 390
			// (get) Token: 0x0600074B RID: 1867 RVA: 0x00004252 File Offset: 0x00002452
			bool ICharacterSkinMeshConfig.arreglaNormalesMagnitud
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000187 RID: 391
			// (get) Token: 0x0600074C RID: 1868 RVA: 0x00004252 File Offset: 0x00002452
			bool ICharacterSkinMeshConfig.copiaShapeKeys
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000188 RID: 392
			// (get) Token: 0x0600074D RID: 1869 RVA: 0x00004252 File Offset: 0x00002452
			bool ICharacterSkinMeshConfig.recalculaNormales
			{
				get
				{
					return false;
				}
			}
		}
	}
}
