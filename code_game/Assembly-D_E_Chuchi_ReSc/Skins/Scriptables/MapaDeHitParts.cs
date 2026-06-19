using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Scriptables
{
	// Token: 0x02000093 RID: 147
	[CreateAssetMenu(fileName = "MapaDeHitParts", menuName = "Mapas/Mapa De Hit Parts")]
	public class MapaDeHitParts : BoneMap
	{
		// Token: 0x0600038D RID: 909 RVA: 0x0000DB21 File Offset: 0x0000BD21
		public bool ContainsSkinName(string n)
		{
			if (this.names == null || this.names.Count == 0)
			{
				this.InitHashSet();
			}
			return this.names.Contains(n);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000DB4A File Offset: 0x0000BD4A
		private void InitHashSet()
		{
			this.names = new HashSet<string>();
			this.partes.AddToNames(this.names);
		}

		// Token: 0x040002A0 RID: 672
		public MapaDeHitParts.Partes partes;

		// Token: 0x040002A1 RID: 673
		[NonSerialized]
		private HashSet<string> names;

		// Token: 0x02000094 RID: 148
		[Serializable]
		public class Partes
		{
			// Token: 0x06000390 RID: 912 RVA: 0x0000DB68 File Offset: 0x0000BD68
			public void AddToNames(HashSet<string> names)
			{
				this.Add(names, this.torzo);
				this.Add(names, this.cabeza);
				this.Add(names, this.brazos);
				this.Add(names, this.anteBrazos);
				this.Add(names, this.senos000);
				this.Add(names, this.senos001);
				this.Add(names, this.nalgas);
				this.Add(names, this.piernas);
				this.Add(names, this.canillas);
			}

			// Token: 0x06000391 RID: 913 RVA: 0x0000DAE9 File Offset: 0x0000BCE9
			private void Add(HashSet<string> names, string n)
			{
				if (!names.Add(n))
				{
					throw new InvalidOperationException("hit skin name repetido: " + n);
				}
			}

			// Token: 0x06000392 RID: 914 RVA: 0x0000DBEA File Offset: 0x0000BDEA
			private void Add(HashSet<string> names, MapaDeHitParts.ParWithMainBone par)
			{
				this.Add(names, par.l);
				this.Add(names, par.r);
			}

			// Token: 0x06000393 RID: 915 RVA: 0x0000DC06 File Offset: 0x0000BE06
			private void Add(HashSet<string> names, MapaDeHitParts.SingleWithMainBone n)
			{
				this.Add(names, n.name);
			}

			// Token: 0x040002A2 RID: 674
			[Obsolete("", true)]
			[NonSerialized]
			public MapaDeHitParts.SingleWithMainBone torzoCabezaPiernas;

			// Token: 0x040002A3 RID: 675
			public MapaDeHitParts.SingleWithMainBone torzo;

			// Token: 0x040002A4 RID: 676
			public MapaDeHitParts.SingleWithMainBone cabeza;

			// Token: 0x040002A5 RID: 677
			public MapaDeHitParts.ParWithMainBone brazos;

			// Token: 0x040002A6 RID: 678
			public MapaDeHitParts.ParWithMainBone anteBrazos;

			// Token: 0x040002A7 RID: 679
			public MapaDeHitParts.ParWithMainBone senos000;

			// Token: 0x040002A8 RID: 680
			public MapaDeHitParts.ParWithMainBone senos001;

			// Token: 0x040002A9 RID: 681
			public MapaDeHitParts.ParWithMainBone nalgas;

			// Token: 0x040002AA RID: 682
			public MapaDeHitParts.ParWithMainBone piernas;

			// Token: 0x040002AB RID: 683
			public MapaDeHitParts.ParWithMainBone canillas;
		}

		// Token: 0x02000095 RID: 149
		[Serializable]
		public class SingleWithMainBone
		{
			// Token: 0x1700010D RID: 269
			// (get) Token: 0x06000395 RID: 917 RVA: 0x0000DC15 File Offset: 0x0000BE15
			public string nombreDeBone
			{
				get
				{
					return MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerNombreDeHueso(this.m_bone);
				}
			}

			// Token: 0x040002AC RID: 684
			public string name;

			// Token: 0x040002AD RID: 685
			[SerializeField]
			[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
			private string m_bone;

			// Token: 0x040002AE RID: 686
			public SkinConfig skinConfig = new SkinConfig();
		}

		// Token: 0x02000096 RID: 150
		[Serializable]
		public class ParWithMainBone
		{
			// Token: 0x040002AF RID: 687
			public MapaDeHitParts.SingleWithMainBone r = new MapaDeHitParts.SingleWithMainBone();

			// Token: 0x040002B0 RID: 688
			public MapaDeHitParts.SingleWithMainBone l = new MapaDeHitParts.SingleWithMainBone();
		}
	}
}
