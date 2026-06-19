using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002B8 RID: 696
	[RequireComponent(typeof(IReproductorDeSonidoDeToques))]
	public class ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada : ModificadorDeTouchingSound
	{
		// Token: 0x06000FA0 RID: 4000 RVA: 0x00047870 File Offset: 0x00045A70
		protected override void OnEnableUnityEvent()
		{
			this.Actualizar();
			base.OnEnableUnityEvent();
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x0004787E File Offset: 0x00045A7E
		public void Actualizar()
		{
			ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.Load(this.m_volumenModsDePartes, this.volumenModsToLoad);
			ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.Load(this.m_pitchModsDePartes, this.pitchModsToLoad);
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x000478A4 File Offset: 0x00045AA4
		private static void Load(DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> dic, List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> toload)
		{
			dic.Clear();
			for (int i = 0; i < toload.Count; i++)
			{
				ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar estimulanteModPar = toload[i];
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

		// Token: 0x06000FA3 RID: 4003 RVA: 0x0004790C File Offset: 0x00045B0C
		protected override void OnRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender)
		{
			float num = 1f;
			ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar estimulanteModPar;
			if (this.m_pitchModsDePartes.TryGetValue(toque.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), out estimulanteModPar))
			{
				num = estimulanteModPar.mod;
			}
			float num2 = 1f;
			ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar estimulanteModPar2;
			if (this.m_volumenModsDePartes.TryGetValue(toque.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), out estimulanteModPar2))
			{
				num2 = estimulanteModPar2.mod;
			}
			mods.pitch *= num;
			mods.volumen *= num2;
		}

		// Token: 0x04000CE6 RID: 3302
		[CoolArrayItem]
		public List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> volumenModsToLoad = ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar.defaultsDeVolumen;

		// Token: 0x04000CE7 RID: 3303
		[CoolArrayItem]
		public List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> pitchModsToLoad = ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar.defaultsDePitch;

		// Token: 0x04000CE8 RID: 3304
		private DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> m_volumenModsDePartes = new DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar>((ParteDelCuerpoHumano x) => (int)x);

		// Token: 0x04000CE9 RID: 3305
		private DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> m_pitchModsDePartes = new DiccionaryEnum<ParteDelCuerpoHumano, ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar>((ParteDelCuerpoHumano x) => (int)x);

		// Token: 0x020002B9 RID: 697
		[Serializable]
		public class EstimulanteModPar
		{
			// Token: 0x1700037B RID: 891
			// (get) Token: 0x06000FA5 RID: 4005 RVA: 0x000479F8 File Offset: 0x00045BF8
			public static List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> defaultsDeVolumen
			{
				get
				{
					List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> list = new List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar>(DiccDeModDeSonidoPatConcavaDeParteEstimulada.modsDeVolumen.Count);
					foreach (KeyValuePair<int, float> keyValuePair in DiccDeModDeSonidoPatConcavaDeParteEstimulada.modsDeVolumen)
					{
						list.Add(new ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar
						{
							estimulante = (ParteDelCuerpoHumano)keyValuePair.Key,
							mod = keyValuePair.Value
						});
					}
					return list;
				}
			}

			// Token: 0x1700037C RID: 892
			// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x00047A74 File Offset: 0x00045C74
			public static List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> defaultsDePitch
			{
				get
				{
					List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar> list = new List<ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar>(DiccDeModDeSonidoPatConcavaDeParteEstimulada.modsDePitch.Count);
					foreach (KeyValuePair<int, float> keyValuePair in DiccDeModDeSonidoPatConcavaDeParteEstimulada.modsDePitch)
					{
						list.Add(new ModificadorDeTouchingSoundPatConcavaSegunParteEstimulada.EstimulanteModPar
						{
							estimulante = (ParteDelCuerpoHumano)keyValuePair.Key,
							mod = keyValuePair.Value
						});
					}
					return list;
				}
			}

			// Token: 0x04000CEA RID: 3306
			public ParteDelCuerpoHumano estimulante;

			// Token: 0x04000CEB RID: 3307
			public float mod;
		}
	}
}
