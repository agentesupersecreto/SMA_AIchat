using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.TValle.IU.Runtime.Scenas.Mapas
{
	// Token: 0x020000CC RID: 204
	[CreateAssetMenu(fileName = "MapaDeScenas", menuName = "Objetos/Scenas/MapaDeScenas")]
	public class MapaDeScenas : AplicableScriptable
	{
		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00015FE7 File Offset: 0x000141E7
		public IReadOnlyList<MapaDeScenas.Scena> scenas
		{
			get
			{
				return this.m_scenas;
			}
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00015FF0 File Offset: 0x000141F0
		private void OnValidate()
		{
			for (int i = 0; i < this.m_scenas.Count; i++)
			{
				MapaDeScenas.Scena scena = this.m_scenas[i];
				if (scena != null)
				{
					scena.OnValidate();
				}
			}
		}

		// Token: 0x04000236 RID: 566
		[SerializeField]
		private List<MapaDeScenas.Scena> m_scenas = new List<MapaDeScenas.Scena>();

		// Token: 0x020001A1 RID: 417
		[Serializable]
		public class Scena : GlobalUserData
		{
			// Token: 0x170002F2 RID: 754
			// (get) Token: 0x06000B75 RID: 2933 RVA: 0x00024151 File Offset: 0x00022351
			[Obsolete("", true)]
			public override int id
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x06000B76 RID: 2934 RVA: 0x00024158 File Offset: 0x00022358
			protected override void OnInit()
			{
				AssetReference assetReference = this.address;
				if (string.IsNullOrEmpty((assetReference != null) ? assetReference.AssetGUID : null) && !this.m_sceneInBuild && this.m_sceneInBuild && this.m_sceneIndex < 0 && string.IsNullOrEmpty(this.m_scenePath))
				{
					throw new ArgumentNullException("scene", "scene null reference.");
				}
			}

			// Token: 0x06000B77 RID: 2935 RVA: 0x000241B4 File Offset: 0x000223B4
			protected override void OnInitiatedID()
			{
			}

			// Token: 0x06000B78 RID: 2936 RVA: 0x000241B6 File Offset: 0x000223B6
			protected override bool OnIsPostInitValid()
			{
				return true;
			}

			// Token: 0x06000B79 RID: 2937 RVA: 0x000241B9 File Offset: 0x000223B9
			protected override bool OnIsPreInitValid()
			{
				AssetReference assetReference = this.address;
				return !string.IsNullOrEmpty((assetReference != null) ? assetReference.AssetGUID : null) || (this.m_sceneInBuild && this.m_sceneIndex >= 0) || !string.IsNullOrEmpty(this.m_scenePath);
			}

			// Token: 0x06000B7A RID: 2938 RVA: 0x000241F5 File Offset: 0x000223F5
			internal void OnValidate()
			{
				this.m_sceneObject != null;
			}

			// Token: 0x0400054E RID: 1358
			[Header("Se puede usar address o scene object")]
			public AssetReference address;

			// Token: 0x0400054F RID: 1359
			[SerializeField]
			private Object m_sceneObject;

			// Token: 0x04000550 RID: 1360
			[ReadOnlyUI]
			[SerializeField]
			private bool m_sceneInBuild;

			// Token: 0x04000551 RID: 1361
			[ReadOnlyUI]
			[SerializeField]
			private int m_sceneIndex = -1;

			// Token: 0x04000552 RID: 1362
			[ReadOnlyUI]
			[SerializeField]
			private string m_scenePath;
		}
	}
}
