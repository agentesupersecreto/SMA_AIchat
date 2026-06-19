using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Scriptables
{
	// Token: 0x02000097 RID: 151
	[CreateAssetMenu(fileName = "MapaDeMaleHitParts", menuName = "Mapas/Mapa De Hit Parts De Male")]
	public class MapaDeMaleHitParts : BoneMap
	{
		// Token: 0x06000398 RID: 920 RVA: 0x0000DC58 File Offset: 0x0000BE58
		public bool ContainsSkinName(string n)
		{
			if (this.names == null || this.names.Count == 0)
			{
				this.InitHashSet();
			}
			return this.names.Contains(n);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000DC81 File Offset: 0x0000BE81
		private void InitHashSet()
		{
			this.names = new HashSet<string>();
			this.partes.AddToNames(this.names);
		}

		// Token: 0x040002B1 RID: 689
		public MapaDeMaleHitParts.Partes partes;

		// Token: 0x040002B2 RID: 690
		[NonSerialized]
		private HashSet<string> names;

		// Token: 0x02000098 RID: 152
		[Serializable]
		public class Partes
		{
			// Token: 0x0600039B RID: 923 RVA: 0x0000DCA0 File Offset: 0x0000BEA0
			public void AddToNames(HashSet<string> names)
			{
				this.Add(names, this.torzo);
				this.Add(names, this.brazos);
				this.Add(names, this.anteBrazos);
				this.Add(names, this.piernas);
				this.Add(names, this.canillas);
			}

			// Token: 0x0600039C RID: 924 RVA: 0x0000DAE9 File Offset: 0x0000BCE9
			private void Add(HashSet<string> names, string n)
			{
				if (!names.Add(n))
				{
					throw new InvalidOperationException("hit skin name repetido: " + n);
				}
			}

			// Token: 0x0600039D RID: 925 RVA: 0x0000DCEE File Offset: 0x0000BEEE
			private void Add(HashSet<string> names, MapaDeMaleHitParts.ParWithMainBone par)
			{
				this.Add(names, par.l);
				this.Add(names, par.r);
			}

			// Token: 0x0600039E RID: 926 RVA: 0x0000DD0A File Offset: 0x0000BF0A
			private void Add(HashSet<string> names, MapaDeMaleHitParts.SingleWithMainBone n)
			{
				this.Add(names, n.name);
			}

			// Token: 0x040002B3 RID: 691
			public MapaDeMaleHitParts.SingleWithMainBone torzo;

			// Token: 0x040002B4 RID: 692
			public MapaDeMaleHitParts.ParWithMainBone brazos;

			// Token: 0x040002B5 RID: 693
			public MapaDeMaleHitParts.ParWithMainBone anteBrazos;

			// Token: 0x040002B6 RID: 694
			public MapaDeMaleHitParts.ParWithMainBone piernas;

			// Token: 0x040002B7 RID: 695
			public MapaDeMaleHitParts.ParWithMainBone canillas;
		}

		// Token: 0x02000099 RID: 153
		[Serializable]
		public class SingleWithMainBone
		{
			// Token: 0x1700010E RID: 270
			// (get) Token: 0x060003A0 RID: 928 RVA: 0x0000DD19 File Offset: 0x0000BF19
			public string nombreDeBone
			{
				get
				{
					return MapaSingleton<MapaSingletonDeMaleBones>.instance.ObtenerNombreDeHueso(this.m_bone);
				}
			}

			// Token: 0x040002B8 RID: 696
			public string name;

			// Token: 0x040002B9 RID: 697
			[SerializeField]
			[StringSelector(typeof(MapaSingletonDeMaleBones), "fieldNamesEditor")]
			private string m_bone;

			// Token: 0x040002BA RID: 698
			public SkinConfig skinConfig = new SkinConfig();
		}

		// Token: 0x0200009A RID: 154
		[Serializable]
		public class ParWithMainBone
		{
			// Token: 0x040002BB RID: 699
			public MapaDeMaleHitParts.SingleWithMainBone r = new MapaDeMaleHitParts.SingleWithMainBone();

			// Token: 0x040002BC RID: 700
			public MapaDeMaleHitParts.SingleWithMainBone l = new MapaDeMaleHitParts.SingleWithMainBone();
		}
	}
}
