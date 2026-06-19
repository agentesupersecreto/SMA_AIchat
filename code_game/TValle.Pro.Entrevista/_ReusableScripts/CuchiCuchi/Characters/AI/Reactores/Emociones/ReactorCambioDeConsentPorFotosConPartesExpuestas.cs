using System;
using System.Collections.Generic;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.AI.Reactores.Emociones
{
	// Token: 0x02000022 RID: 34
	public class ReactorCambioDeConsentPorFotosConPartesExpuestas : ReactorACalculoDeEstimulo<ICalculoDeEstimuloVisual>
	{
		// Token: 0x0600015A RID: 346 RVA: 0x00007EA8 File Offset: 0x000060A8
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_ConsentToHero = this.GetComponentEnRoot(false);
			if (this.m_ConsentToHero == null)
			{
				throw new ArgumentNullException("m_ConsentToHero", "m_ConsentToHero null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_ConsentPorInteraciones = this.GetComponentEnRoot(false);
			if (this.m_ConsentPorInteraciones == null)
			{
				throw new ArgumentNullException("m_ConsentPorInteraciones", "m_ConsentPorInteraciones null reference.");
			}
			this.m_PiezasDeRopaLoader = this.GetComponentEnRoot(false);
			if (this.m_PiezasDeRopaLoader == null)
			{
				throw new ArgumentNullException("m_PiezasDeRopaLoader", "m_PiezasDeRopaLoader null reference.");
			}
			this.m_Char = this.GetComponentEnRoot(false);
			if (this.m_Char == null)
			{
				throw new ArgumentNullException("m_Char", "m_Char null reference.");
			}
			this.m_tempMEM = this.GetComponentEnRoot(false);
			if (this.m_tempMEM == null)
			{
				throw new ArgumentNullException("m_tempMEM", "m_tempMEM null reference.");
			}
			this.Subscribe();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00007FEE File Offset: 0x000061EE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.Subscribe();
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00008004 File Offset: 0x00006204
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Unsubscribe();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00008013 File Offset: 0x00006213
		private void Subscribe()
		{
			this.m_PiezasDeRopaLoader.changed += this.M_PiezasDeRopaLoader_changed;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000802C File Offset: 0x0000622C
		private void Unsubscribe()
		{
			if (this.m_PiezasDeRopaLoader != null)
			{
				this.m_PiezasDeRopaLoader.changed -= this.M_PiezasDeRopaLoader_changed;
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00008054 File Offset: 0x00006254
		protected override bool CalculoEsValido(ICalculoDeEstimuloVisual calculo)
		{
			return calculo.tipo == TipoDeCalculoDeEstimulo.frame && calculo.estimulo.tipoDeEstimuloVisual == TipoDeEstimuloVisual.fotografiada && calculo.emocion.reaccion == ReaccionHumana.placer && this.YaAceptoFotografias() && this.m_tempMEM.InitialOutfitWasLoaded();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000080A5 File Offset: 0x000062A5
		private void M_PiezasDeRopaLoader_changed(RopaCubre last, RopaCubre nuevas, PiezasDeRopaLoader sender)
		{
			if (!this.YaAceptoFotografias() || !this.m_tempMEM.InitialOutfitWasLoaded())
			{
				return;
			}
			PiezasDeRopaLoader.Comparar(last, nuevas, this.m_cubiertasEnSession, this.m_expuestasEnSession);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000080D0 File Offset: 0x000062D0
		private bool YaAceptoFotografias()
		{
			return MemoriaDeSMAModelosFemeninas.AceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, this.m_Char.ID_UnicoString);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000080E8 File Offset: 0x000062E8
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloVisual calculo)
		{
			if (this.m_ConsentPorInteraciones.alMaximo || this.m_ConsentToHero.valueAtMax)
			{
				return false;
			}
			MapaDePersonalidad personalidad = this.m_Personalidad.currentPersonalidad.personalidad;
			if (personalidad == null)
			{
				return false;
			}
			if (this.m_expuestasConBonus.Count >= 12 || this.m_cubiertasConBonus.Count >= 12)
			{
				return false;
			}
			if (this.m_expuestasEnSession.Count == 0 && this.m_cubiertasEnSession.Count == 0)
			{
				return false;
			}
			float num = personalidad.CurrentMaxConsentPorInteraciones() / 2f / 12f;
			this.m_lastExpuestas.Clear();
			for (int i = 0; i < this.m_expuestasEnSession.Count; i++)
			{
				if (!this.m_cubiertasEnSession.Contains(this.m_expuestasEnSession[i]))
				{
					this.m_lastExpuestas.Add(this.m_expuestasEnSession[i]);
				}
			}
			this.m_lastCubiertas.Clear();
			for (int j = 0; j < this.m_cubiertasEnSession.Count; j++)
			{
				if (!this.m_expuestasEnSession.Contains(this.m_cubiertasEnSession[j]))
				{
					this.m_lastCubiertas.Add(this.m_cubiertasEnSession[j]);
				}
			}
			this.m_expuestasEnSession.Clear();
			this.m_cubiertasEnSession.Clear();
			bool flag = false;
			for (int k = 0; k < this.m_lastExpuestas.Count; k++)
			{
				RopaCubre ropaCubre = this.m_lastExpuestas[k];
				if (this.m_expuestasConBonus.Add((int)ropaCubre))
				{
					this.m_ConsentPorInteraciones.Cambiar(num, calculo);
					flag = true;
				}
			}
			for (int l = 0; l < this.m_lastCubiertas.Count; l++)
			{
				RopaCubre ropaCubre2 = this.m_lastCubiertas[l];
				if (this.m_cubiertasConBonus.Add((int)ropaCubre2))
				{
					this.m_ConsentPorInteraciones.Cambiar(num, calculo);
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000082CD File Offset: 0x000064CD
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000082D4 File Offset: 0x000064D4
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x040000C8 RID: 200
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x040000C9 RID: 201
		private ConsentToHero m_ConsentToHero;

		// Token: 0x040000CA RID: 202
		private Personalidad m_Personalidad;

		// Token: 0x040000CB RID: 203
		private ConsentPorInteraciones m_ConsentPorInteraciones;

		// Token: 0x040000CC RID: 204
		private PiezasDeRopaLoader m_PiezasDeRopaLoader;

		// Token: 0x040000CD RID: 205
		[SerializeField]
		private SerializableEnumHashSetListSlow<RopaCubre> m_expuestasEnSession = new SerializableEnumHashSetListSlow<RopaCubre>();

		// Token: 0x040000CE RID: 206
		[SerializeField]
		private SerializableEnumHashSetListSlow<RopaCubre> m_cubiertasEnSession = new SerializableEnumHashSetListSlow<RopaCubre>();

		// Token: 0x040000CF RID: 207
		[SerializeField]
		private SerializableEnumHashSetListSlow<RopaCubre> m_lastExpuestas = new SerializableEnumHashSetListSlow<RopaCubre>();

		// Token: 0x040000D0 RID: 208
		[SerializeField]
		private SerializableEnumHashSetListSlow<RopaCubre> m_lastCubiertas = new SerializableEnumHashSetListSlow<RopaCubre>();

		// Token: 0x040000D1 RID: 209
		private HashSet<int> m_expuestasConBonus = new HashSet<int>();

		// Token: 0x040000D2 RID: 210
		private HashSet<int> m_cubiertasConBonus = new HashSet<int>();

		// Token: 0x040000D3 RID: 211
		private Character m_Char;

		// Token: 0x040000D4 RID: 212
		private MemoriaDeCharacterGeneralTemporal m_tempMEM;
	}
}
