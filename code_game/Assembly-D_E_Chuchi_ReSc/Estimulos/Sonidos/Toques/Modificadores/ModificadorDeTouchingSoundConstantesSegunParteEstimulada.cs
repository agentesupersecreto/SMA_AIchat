using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002B5 RID: 693
	[RequireComponent(typeof(IReproductorDeSonidoDeToques))]
	public class ModificadorDeTouchingSoundConstantesSegunParteEstimulada : ModificadorDeTouchingSound
	{
		// Token: 0x06000F94 RID: 3988 RVA: 0x000475E4 File Offset: 0x000457E4
		protected override void OnEnableUnityEvent()
		{
			this.Actualizar();
			base.OnEnableUnityEvent();
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x000475F2 File Offset: 0x000457F2
		public void Actualizar()
		{
			ModificadorDeTouchingSoundConstantesSegunParteEstimulada.Load(this.m_volumenModsDePartes, this.volumenModsToLoad);
			ModificadorDeTouchingSoundConstantesSegunParteEstimulada.Load(this.m_pitchModsDePartes, this.pitchModsToLoad);
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x00047618 File Offset: 0x00045818
		private static void Load(DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> dic, List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> toload)
		{
			dic.Clear();
			for (int i = 0; i < toload.Count; i++)
			{
				ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar estimulanteModPar = toload[i];
				if (dic.ContainsKey(estimulanteModPar.estimulante))
				{
					dic[estimulanteModPar.estimulante].mod *= estimulanteModPar.mod;
				}
				else
				{
					dic.Add(estimulanteModPar.estimulante, estimulanteModPar);
				}
			}
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x00047680 File Offset: 0x00045880
		protected override void OnRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender)
		{
			float num = 1f;
			ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar estimulanteModPar;
			if (this.m_pitchModsDePartes.TryGetValue(toque.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), out estimulanteModPar))
			{
				num = estimulanteModPar.mod;
			}
			float num2 = 1f;
			ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar estimulanteModPar2;
			if (this.m_volumenModsDePartes.TryGetValue(toque.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), out estimulanteModPar2))
			{
				num2 = estimulanteModPar2.mod;
			}
			mods.pitch *= num;
			mods.volumen *= num2;
		}

		// Token: 0x04000CDD RID: 3293
		[CoolArrayItem]
		public List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> volumenModsToLoad = ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar.defaultsDeVolumen;

		// Token: 0x04000CDE RID: 3294
		[CoolArrayItem]
		public List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> pitchModsToLoad = ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar.defaultsDePitch;

		// Token: 0x04000CDF RID: 3295
		private DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> m_volumenModsDePartes = new DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar>((ParteDelCuerpoHumano x) => (int)x);

		// Token: 0x04000CE0 RID: 3296
		private DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> m_pitchModsDePartes = new DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar>((ParteDelCuerpoHumano x) => (int)x);

		// Token: 0x020002B6 RID: 694
		[Serializable]
		public class EstimulanteModPar
		{
			// Token: 0x17000379 RID: 889
			// (get) Token: 0x06000F99 RID: 3993 RVA: 0x0004776C File Offset: 0x0004596C
			public static List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> defaultsDeVolumen
			{
				get
				{
					List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> list = new List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar>(DiccDeModDeSonidoConstantesDeParteEstimulada.modsDeVolumen.Count);
					foreach (KeyValuePair<int, float> keyValuePair in DiccDeModDeSonidoConstantesDeParteEstimulada.modsDeVolumen)
					{
						list.Add(new ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar
						{
							estimulante = (ParteDelCuerpoHumano)keyValuePair.Key,
							mod = keyValuePair.Value
						});
					}
					return list;
				}
			}

			// Token: 0x1700037A RID: 890
			// (get) Token: 0x06000F9A RID: 3994 RVA: 0x000477E8 File Offset: 0x000459E8
			public static List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> defaultsDePitch
			{
				get
				{
					List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar> list = new List<ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar>(DiccDeModDeSonidoConstantesDeParteEstimulada.modsDePitch.Count);
					foreach (KeyValuePair<int, float> keyValuePair in DiccDeModDeSonidoConstantesDeParteEstimulada.modsDePitch)
					{
						list.Add(new ModificadorDeTouchingSoundConstantesSegunParteEstimulada.EstimulanteModPar
						{
							estimulante = (ParteDelCuerpoHumano)keyValuePair.Key,
							mod = keyValuePair.Value
						});
					}
					return list;
				}
			}

			// Token: 0x04000CE1 RID: 3297
			public ParteDelCuerpoHumano estimulante;

			// Token: 0x04000CE2 RID: 3298
			public float mod;
		}
	}
}
