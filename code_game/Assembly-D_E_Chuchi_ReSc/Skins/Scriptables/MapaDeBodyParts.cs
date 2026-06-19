using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Scriptables
{
	// Token: 0x02000090 RID: 144
	[CreateAssetMenu(fileName = "MapaDeBodyParts", menuName = "Mapas/Mapa De Body Parts")]
	public class MapaDeBodyParts : BoneMap
	{
		// Token: 0x06000382 RID: 898 RVA: 0x0000D860 File Offset: 0x0000BA60
		public bool ContainsSkinName(string n)
		{
			if (this.names == null || this.names.Count == 0)
			{
				this.InitHashSet();
			}
			return this.names.Contains(n);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000D889 File Offset: 0x0000BA89
		private void InitHashSet()
		{
			this.names = new HashSet<string>();
			this.cabeza.AddToNames(this.names);
			this.cuerpo.AddToNames(this.names);
		}

		// Token: 0x04000279 RID: 633
		public MapaDeBodyParts.Cabeza cabeza;

		// Token: 0x0400027A RID: 634
		public MapaDeBodyParts.Cuerpo cuerpo;

		// Token: 0x0400027B RID: 635
		[NonSerialized]
		private HashSet<string> names;

		// Token: 0x02000091 RID: 145
		[Serializable]
		public class Cabeza
		{
			// Token: 0x06000385 RID: 901 RVA: 0x0000D8C0 File Offset: 0x0000BAC0
			public void AddToNames(HashSet<string> names)
			{
				this.Add(names, this.cabeza);
				this.Add(names, this.cuello);
				this.Add(names, this.mandibula);
				this.Add(names, this.boca);
				this.Add(names, this.bocaInterno);
				this.Add(names, this.nariz);
				this.Add(names, this.mejillas);
				this.Add(names, this.ojos);
				this.Add(names, this.ojosInterno);
				this.Add(names, this.cejas);
				this.Add(names, this.cienes);
				this.Add(names, this.frente);
			}

			// Token: 0x06000386 RID: 902 RVA: 0x0000D969 File Offset: 0x0000BB69
			private void Add(HashSet<string> names, string n)
			{
				if (!names.Add(n))
				{
					throw new InvalidOperationException("body part skin name repetido: " + n);
				}
			}

			// Token: 0x06000387 RID: 903 RVA: 0x0000D985 File Offset: 0x0000BB85
			private void Add(HashSet<string> names, BoneNameIndexPar par)
			{
				this.Add(names, par.l);
				this.Add(names, par.r);
			}

			// Token: 0x0400027C RID: 636
			public string cabeza;

			// Token: 0x0400027D RID: 637
			public string cuello;

			// Token: 0x0400027E RID: 638
			public string mandibula;

			// Token: 0x0400027F RID: 639
			public string boca;

			// Token: 0x04000280 RID: 640
			public string bocaInterno;

			// Token: 0x04000281 RID: 641
			public string nariz;

			// Token: 0x04000282 RID: 642
			public BoneNameIndexPar mejillas;

			// Token: 0x04000283 RID: 643
			public BoneNameIndexPar ojos;

			// Token: 0x04000284 RID: 644
			public BoneNameIndexPar ojosInterno;

			// Token: 0x04000285 RID: 645
			public BoneNameIndexPar cejas;

			// Token: 0x04000286 RID: 646
			public BoneNameIndexPar cienes;

			// Token: 0x04000287 RID: 647
			public string frente;
		}

		// Token: 0x02000092 RID: 146
		[Serializable]
		public class Cuerpo
		{
			// Token: 0x06000389 RID: 905 RVA: 0x0000D9A4 File Offset: 0x0000BBA4
			public void AddToNames(HashSet<string> names)
			{
				this.Add(names, this.pecho);
				this.Add(names, this.espalda);
				this.Add(names, this.hombros);
				this.Add(names, this.axilas);
				this.Add(names, this.brazos);
				this.Add(names, this.anteBrazos);
				this.Add(names, this.manos);
				this.Add(names, this.senos);
				this.Add(names, this.pezones);
				this.Add(names, this.abdomen);
				this.Add(names, this.cintura);
				this.Add(names, this.caderas);
				this.Add(names, this.coxis);
				this.Add(names, this.vientre);
				this.Add(names, this.nalgas);
				this.Add(names, this.vagina);
				this.Add(names, this.perineo);
				this.Add(names, this.anoHole);
				this.Add(names, this.vagHole);
				this.Add(names, this.hombligo);
				this.Add(names, this.piernas);
				this.Add(names, this.rodillas);
				this.Add(names, this.canillas);
				this.Add(names, this.pies);
			}

			// Token: 0x0600038A RID: 906 RVA: 0x0000DAE9 File Offset: 0x0000BCE9
			private void Add(HashSet<string> names, string n)
			{
				if (!names.Add(n))
				{
					throw new InvalidOperationException("hit skin name repetido: " + n);
				}
			}

			// Token: 0x0600038B RID: 907 RVA: 0x0000DB05 File Offset: 0x0000BD05
			private void Add(HashSet<string> names, BoneNameIndexPar par)
			{
				this.Add(names, par.l);
				this.Add(names, par.r);
			}

			// Token: 0x04000288 RID: 648
			public string pecho;

			// Token: 0x04000289 RID: 649
			public string espalda;

			// Token: 0x0400028A RID: 650
			public BoneNameIndexPar hombros;

			// Token: 0x0400028B RID: 651
			public BoneNameIndexPar axilas;

			// Token: 0x0400028C RID: 652
			public BoneNameIndexPar brazos;

			// Token: 0x0400028D RID: 653
			public BoneNameIndexPar anteBrazos;

			// Token: 0x0400028E RID: 654
			public BoneNameIndexPar manos;

			// Token: 0x0400028F RID: 655
			public BoneNameIndexPar senos;

			// Token: 0x04000290 RID: 656
			public BoneNameIndexPar pezones;

			// Token: 0x04000291 RID: 657
			public string abdomen;

			// Token: 0x04000292 RID: 658
			public string cintura;

			// Token: 0x04000293 RID: 659
			public BoneNameIndexPar caderas;

			// Token: 0x04000294 RID: 660
			public string coxis;

			// Token: 0x04000295 RID: 661
			public string vientre;

			// Token: 0x04000296 RID: 662
			public BoneNameIndexPar nalgas;

			// Token: 0x04000297 RID: 663
			public string vagina;

			// Token: 0x04000298 RID: 664
			public string perineo;

			// Token: 0x04000299 RID: 665
			public string anoHole;

			// Token: 0x0400029A RID: 666
			public string vagHole;

			// Token: 0x0400029B RID: 667
			public string hombligo;

			// Token: 0x0400029C RID: 668
			public BoneNameIndexPar piernas;

			// Token: 0x0400029D RID: 669
			public BoneNameIndexPar rodillas;

			// Token: 0x0400029E RID: 670
			public BoneNameIndexPar canillas;

			// Token: 0x0400029F RID: 671
			public BoneNameIndexPar pies;
		}
	}
}
