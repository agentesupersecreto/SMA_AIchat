using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002BB RID: 699
	[RequireComponent(typeof(IReproductorDeSonidoDeToques))]
	public class ModificadorDeTouchingSoundPatSegunParteEstimulada : ModificadorDeTouchingSound
	{
		// Token: 0x06000FAC RID: 4012 RVA: 0x00047AFC File Offset: 0x00045CFC
		protected override void OnEnableUnityEvent()
		{
			this.Actualizar();
			base.OnEnableUnityEvent();
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x00047B0A File Offset: 0x00045D0A
		public void Actualizar()
		{
			ModificadorDeTouchingSoundPatSegunParteEstimulada.Load(this.m_volumenModsDePartes, this.volumenModsToLoad);
			ModificadorDeTouchingSoundPatSegunParteEstimulada.Load(this.m_pitchModsDePartes, this.pitchModsToLoad);
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x00047B30 File Offset: 0x00045D30
		private static void Load(DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> dic, List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> toload)
		{
			dic.Clear();
			for (int i = 0; i < toload.Count; i++)
			{
				ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar estimulanteModPar = toload[i];
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

		// Token: 0x06000FAF RID: 4015 RVA: 0x00047B98 File Offset: 0x00045D98
		protected override void OnRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender)
		{
			float num = 1f;
			ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar estimulanteModPar;
			if (this.m_pitchModsDePartes.TryGetValue(toque.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), out estimulanteModPar))
			{
				num = estimulanteModPar.mod;
			}
			float num2 = 1f;
			ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar estimulanteModPar2;
			if (this.m_volumenModsDePartes.TryGetValue(toque.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), out estimulanteModPar2))
			{
				num2 = estimulanteModPar2.mod;
			}
			mods.pitch *= num;
			mods.volumen *= num2;
		}

		// Token: 0x04000CEF RID: 3311
		[CoolArrayItem]
		public List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> volumenModsToLoad = ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar.defaultsDeVolumen;

		// Token: 0x04000CF0 RID: 3312
		[CoolArrayItem]
		public List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> pitchModsToLoad = ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar.defaultsDePitch;

		// Token: 0x04000CF1 RID: 3313
		private DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> m_volumenModsDePartes = new DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar>((ParteDelCuerpoHumano x) => (int)x);

		// Token: 0x04000CF2 RID: 3314
		private DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> m_pitchModsDePartes = new DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar>((ParteDelCuerpoHumano x) => (int)x);

		// Token: 0x020002BC RID: 700
		[Serializable]
		public class EstimulanteModPar
		{
			// Token: 0x1700037D RID: 893
			// (get) Token: 0x06000FB1 RID: 4017 RVA: 0x00047C84 File Offset: 0x00045E84
			public static List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> defaultsDeVolumen
			{
				get
				{
					List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> list = new List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar>(DiccDeModDeSonidoPatDeParteEstimulada.modsDeVolumen.Count);
					foreach (KeyValuePair<int, float> keyValuePair in DiccDeModDeSonidoPatDeParteEstimulada.modsDeVolumen)
					{
						list.Add(new ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar
						{
							estimulante = (ParteDelCuerpoHumano)keyValuePair.Key,
							mod = keyValuePair.Value
						});
					}
					return list;
				}
			}

			// Token: 0x1700037E RID: 894
			// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x00047D00 File Offset: 0x00045F00
			public static List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> defaultsDePitch
			{
				get
				{
					List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar> list = new List<ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar>(DiccDeModDeSonidoPatDeParteEstimulada.modsDePitch.Count);
					foreach (KeyValuePair<int, float> keyValuePair in DiccDeModDeSonidoPatDeParteEstimulada.modsDePitch)
					{
						list.Add(new ModificadorDeTouchingSoundPatSegunParteEstimulada.EstimulanteModPar
						{
							estimulante = (ParteDelCuerpoHumano)keyValuePair.Key,
							mod = keyValuePair.Value
						});
					}
					return list;
				}
			}

			// Token: 0x04000CF3 RID: 3315
			public ParteDelCuerpoHumano estimulante;

			// Token: 0x04000CF4 RID: 3316
			public float mod;
		}
	}
}
