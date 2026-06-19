using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000D0 RID: 208
	[CreateAssetMenu(fileName = "MapaDeMaleBlendShapes", menuName = "Objetos/Mapas/Mapa De Male Blend Shapes")]
	public class MapaDeMaleBlendShapes : MapaSingletonDeValoresUnicos<MapaDeMaleBlendShapes>, IMapaDeMaleBlendShapes<string>
	{
		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x0001638B File Offset: 0x0001458B
		string IMapaDeMaleBlendShapes<string>.fat
		{
			get
			{
				return this.fat;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x00016393 File Offset: 0x00014593
		string IMapaDeMaleBlendShapes<string>.thin
		{
			get
			{
				return this.thin;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x0001639B File Offset: 0x0001459B
		string IMapaDeMaleBlendShapes<string>.muscle
		{
			get
			{
				return this.muscle;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x000163A3 File Offset: 0x000145A3
		string IMapaDeMaleBlendShapes<string>.old
		{
			get
			{
				return this.old;
			}
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x000163AC File Offset: 0x000145AC
		protected override void LoadValores(List<string> valores, List<string> fields)
		{
			valores.Add(this.fat);
			fields.Add("fat");
			valores.Add(this.thin);
			fields.Add("thin");
			valores.Add(this.muscle);
			fields.Add("muscle");
			valores.Add(this.old);
			fields.Add("old");
			valores.Add(this.package);
			fields.Add("package");
			valores.Add(this.altura);
			fields.Add("altura");
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00016443 File Offset: 0x00014643
		protected override void OnJuegoLanzadoValoresUnicos()
		{
		}

		// Token: 0x04000416 RID: 1046
		public string fat = "Fat";

		// Token: 0x04000417 RID: 1047
		public string thin = "Thin";

		// Token: 0x04000418 RID: 1048
		public string muscle = "Muscle";

		// Token: 0x04000419 RID: 1049
		public string old = "Old";

		// Token: 0x0400041A RID: 1050
		public string package = "Package";

		// Token: 0x0400041B RID: 1051
		public string altura = "Scala_Puppet_";
	}
}
