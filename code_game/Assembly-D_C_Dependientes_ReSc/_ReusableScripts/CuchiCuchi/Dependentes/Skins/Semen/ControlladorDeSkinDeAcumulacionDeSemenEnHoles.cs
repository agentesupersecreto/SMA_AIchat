using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.Semen;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores.Pieles;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Skins.Globales;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen
{
	// Token: 0x02000043 RID: 67
	public class ControlladorDeSkinDeAcumulacionDeSemenEnHoles : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600018A RID: 394 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000B28C File Offset: 0x0000948C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_rutineDataAnus = new ValueTuple<float, int>(-1f, -1);
			this.m_rutineDataVag = new ValueTuple<float, int>(-1f, -1);
			base.SetYieldStart();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000B2BC File Offset: 0x000094BC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			GlobalUpdater.Corrutina updateWeightRutineAnus = this.m_updateWeightRutineAnus;
			if (updateWeightRutineAnus != null)
			{
				updateWeightRutineAnus.Stop();
			}
			GlobalUpdater.Corrutina updateWeightRutineVag = this.m_updateWeightRutineVag;
			if (updateWeightRutineVag != null)
			{
				updateWeightRutineVag.Stop();
			}
			this.m_rutineDataAnus = new ValueTuple<float, int>(-1f, -1);
			this.m_rutineDataVag = new ValueTuple<float, int>(-1f, -1);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000B314 File Offset: 0x00009514
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (!Singleton<TiempoDeJuego>.IsInScene || !Singleton<TiempoDeJuego>.instance.firstLoaded)
			{
				yield return null;
			}
			this.m_SemenParaAnus = this.GetComponentEnRoot(false);
			this.m_SemenParaVag = this.GetComponentEnRoot(false);
			this.m_MemoriaDeCharacterGeneralPermanente = this.GetComponentEnRoot(false);
			this.m_ControlladorDeSemenParaAnusInternal = this.GetComponentEnRoot(false);
			this.m_ControlladorDeSemenParaVagInternal = this.GetComponentEnRoot(false);
			while (this.m_SemenParaAnus == null)
			{
				yield return null;
				this.m_SemenParaAnus = this.GetComponentEnRoot(false);
			}
			while (this.m_SemenParaVag == null)
			{
				yield return null;
				this.m_SemenParaVag = this.GetComponentEnRoot(false);
			}
			while (this.m_MemoriaDeCharacterGeneralPermanente == null)
			{
				yield return null;
				this.m_MemoriaDeCharacterGeneralPermanente = this.GetComponentEnRoot(false);
			}
			while (this.m_ControlladorDeSemenParaAnusInternal == null)
			{
				yield return null;
				this.m_ControlladorDeSemenParaAnusInternal = this.GetComponentEnRoot(false);
			}
			while (this.m_ControlladorDeSemenParaVagInternal == null)
			{
				yield return null;
				this.m_ControlladorDeSemenParaVagInternal = this.GetComponentEnRoot(false);
			}
			while (!this.m_SemenParaAnus.isStared)
			{
				yield return null;
			}
			while (!this.m_SemenParaVag.isStared)
			{
				yield return null;
			}
			while (!this.m_MemoriaDeCharacterGeneralPermanente.owner.isMemoryLoaded)
			{
				yield return null;
			}
			this.m_MemoriaDeCharacterGeneralPermanente.saving += this.M_MemoriaDeCharacterGeneralPermanente_saving;
			this.m_lastSessionWeightAnus = MemoriaDeCharacterBase.LeerFloat(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "AnuV", 0f);
			this.m_lastSessionWeightVag = MemoriaDeCharacterBase.LeerFloat(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "VagV", 0f);
			this.m_AnusSkinIndex = MemoriaDeCharacterBase.LeerInt(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "AnuI", Random.Range(0, Singleton<SemenSkinsParaHoleInternals>.instance.anus.prefabs.Count));
			this.m_VagSkinIndex = MemoriaDeCharacterBase.LeerInt(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "VagI", Random.Range(0, Singleton<SemenSkinsParaHoleInternals>.instance.vag.prefabs.Count));
			this.m_lastSessionWeightAnus = Mathf.Clamp01(this.m_lastSessionWeightAnus);
			this.m_lastSessionWeightVag = Mathf.Clamp01(this.m_lastSessionWeightVag);
			this.m_lastSessionWeightAnusDate = MemoriaDeCharacterBase.Leer(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "AnuD");
			this.m_lastSessionWeightVagDate = MemoriaDeCharacterBase.Leer(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "VagD");
			DateTime now = Singleton<TiempoDeJuego>.instance.now;
			this.m_lastSessionWeightVagDays = (now - this.m_lastSessionWeightVagDate).TotalDays;
			this.m_lastSessionWeightAnusDays = (now - this.m_lastSessionWeightAnusDate).TotalDays;
			this.m_lastSessionWeightAnus *= (float)MathfExtension.InverseLerp(3.0, 0.0, this.m_lastSessionWeightAnusDays);
			this.m_lastSessionWeightVag *= (float)MathfExtension.InverseLerp(7.0, 0.0, this.m_lastSessionWeightVagDays);
			yield break;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000B324 File Offset: 0x00009524
		private void M_MemoriaDeCharacterGeneralPermanente_saving(MemoriaDeCharacterBase obj)
		{
			string text = UDateTime.Serialize(Singleton<TiempoDeJuego>.instance.now);
			MemoriaDeCharacterBase.Registrar(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "AnuD", text);
			MemoriaDeCharacterBase.Registrar(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "VagD", text);
			MemoriaDeCharacterBase.Registrar(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "AnuV", Mathf.Clamp01(this.m_lastSessionWeightAnus + this.m_sessionWeightAnusMax));
			MemoriaDeCharacterBase.Registrar(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "VagV", Mathf.Clamp01(this.m_lastSessionWeightVag + this.m_sessionWeightVagMax));
			MemoriaDeCharacterBase.Registrar(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "AnuI", this.m_AnusSkinIndex);
			MemoriaDeCharacterBase.Registrar(this.m_MemoriaDeCharacterGeneralPermanente, "Smen", "VagI", this.m_VagSkinIndex);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000B3F4 File Offset: 0x000095F4
		public override void OnUpdateEvent1()
		{
			if (!this.m_currentSessionCooldDown.isOn)
			{
				float num;
				float num2;
				this.m_SemenParaAnus.MililitrosAcumulados(TipoDeSemen.semen, out num, out num2);
				float num3;
				float num4;
				this.m_SemenParaVag.MililitrosAcumulados(TipoDeSemen.semen, out num3, out num4);
				this.m_sessionWeightAnusMax = Mathf.Max(num2, this.m_sessionWeightAnusMax);
				this.m_sessionWeightVagMax = Mathf.Max(num4, this.m_sessionWeightVagMax);
				ValueTuple<float, int> valueTuple = new ValueTuple<float, int>(Mathf.Clamp01(this.m_lastSessionWeightAnus + this.m_sessionWeightAnusMax), this.m_AnusSkinIndex);
				ValueTuple<float, int> valueTuple2 = new ValueTuple<float, int>(Mathf.Clamp01(this.m_lastSessionWeightVag + this.m_sessionWeightVagMax), this.m_VagSkinIndex);
				ValueTuple<float, int> valueTuple3 = valueTuple;
				ValueTuple<float, int> valueTuple4 = this.m_rutineDataAnus;
				if (valueTuple3.Item1 != valueTuple4.Item1 || valueTuple3.Item2 != valueTuple4.Item2)
				{
					this.m_rutineDataAnus = valueTuple;
					GlobalUpdater.Corrutina updateWeightRutineAnus = this.m_updateWeightRutineAnus;
					if (updateWeightRutineAnus != null)
					{
						updateWeightRutineAnus.Stop();
					}
					this.m_updateWeightRutineAnus = GlobalUpdater.instancia.StartCorrutinaOnEvent<ValueTuple<float, int>>(GlobalUpdater.UpdateType.update2, this.m_rutineDataAnus, this, ControlladorDeSkinDeAcumulacionDeSemenEnHoles.UpdateWeightRutine(this.m_rutineDataAnus, this.m_ControlladorDeSemenParaAnusInternal), null);
				}
				ValueTuple<float, int> valueTuple5 = valueTuple2;
				valueTuple4 = this.m_rutineDataVag;
				if (valueTuple5.Item1 != valueTuple4.Item1 || valueTuple5.Item2 != valueTuple4.Item2)
				{
					this.m_rutineDataVag = valueTuple2;
					GlobalUpdater.Corrutina updateWeightRutineVag = this.m_updateWeightRutineVag;
					if (updateWeightRutineVag != null)
					{
						updateWeightRutineVag.Stop();
					}
					this.m_updateWeightRutineVag = GlobalUpdater.instancia.StartCorrutinaOnEvent<ValueTuple<float, int>>(GlobalUpdater.UpdateType.update2, this.m_rutineDataVag, this, ControlladorDeSkinDeAcumulacionDeSemenEnHoles.UpdateWeightRutine(this.m_rutineDataVag, this.m_ControlladorDeSemenParaVagInternal), null);
				}
				this.m_currentSessionCooldDown.ApplyNext(0.333f.Random(0.1f));
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000B58D File Offset: 0x0000978D
		private static IEnumerator UpdateWeightRutine([TupleElementNames(new string[] { "targetW", "semenSkinIndex" })] ValueTuple<float, int> data, ControlladorDeSemenParaInternalHole controller)
		{
			if (controller.skinIndex < 0 || data.Item2 != controller.skinIndex)
			{
				controller.SetSkinIndex(data.Item2);
			}
			if (data.Item1 > 0f)
			{
				controller.TryLoad();
			}
			float sW = controller.w;
			while (!data.Item1.AlmostEqualV2(controller.w, 1E-45f))
			{
				sW = Mathf.MoveTowards(sW, data.Item1, Time.deltaTime * 0.2f);
				controller.UpdateWeight(sW);
				yield return null;
			}
			if (controller.w <= 0f)
			{
				controller.Clear();
			}
			yield break;
		}

		// Token: 0x04000163 RID: 355
		private const string semenKey = "Smen";

		// Token: 0x04000164 RID: 356
		private const string semenVagValueKey = "VagV";

		// Token: 0x04000165 RID: 357
		private const string semenAnusValueKey = "AnuV";

		// Token: 0x04000166 RID: 358
		private const string semenVagDateKey = "VagD";

		// Token: 0x04000167 RID: 359
		private const string semenAnusDateKey = "AnuD";

		// Token: 0x04000168 RID: 360
		private const string semenVagIndexKey = "VagI";

		// Token: 0x04000169 RID: 361
		private const string semenAnusIndexKey = "AnuI";

		// Token: 0x0400016A RID: 362
		private SemenParaAnus m_SemenParaAnus;

		// Token: 0x0400016B RID: 363
		private SemenParaVag m_SemenParaVag;

		// Token: 0x0400016C RID: 364
		private ControlladorDeSemenParaAnusInternal m_ControlladorDeSemenParaAnusInternal;

		// Token: 0x0400016D RID: 365
		private ControlladorDeSemenParaVagInternal m_ControlladorDeSemenParaVagInternal;

		// Token: 0x0400016E RID: 366
		private MemoriaDeCharacterGeneralPermanente m_MemoriaDeCharacterGeneralPermanente;

		// Token: 0x0400016F RID: 367
		private CoolDown m_currentSessionCooldDown = new CoolDown();

		// Token: 0x04000170 RID: 368
		[SerializeField]
		[ReadOnlyUI]
		private float m_sessionWeightAnusMax;

		// Token: 0x04000171 RID: 369
		[SerializeField]
		[ReadOnlyUI]
		private float m_sessionWeightVagMax;

		// Token: 0x04000172 RID: 370
		[SerializeField]
		[ReadOnlyUI]
		private int m_AnusSkinIndex = -1;

		// Token: 0x04000173 RID: 371
		[SerializeField]
		[ReadOnlyUI]
		private int m_VagSkinIndex = -1;

		// Token: 0x04000174 RID: 372
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastSessionWeightAnus;

		// Token: 0x04000175 RID: 373
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastSessionWeightVag;

		// Token: 0x04000176 RID: 374
		[SerializeField]
		[ReadOnlyUI]
		private UDateTime m_lastSessionWeightAnusDate;

		// Token: 0x04000177 RID: 375
		[SerializeField]
		[ReadOnlyUI]
		private UDateTime m_lastSessionWeightVagDate;

		// Token: 0x04000178 RID: 376
		[SerializeField]
		[ReadOnlyUI]
		private double m_lastSessionWeightAnusDays;

		// Token: 0x04000179 RID: 377
		[SerializeField]
		[ReadOnlyUI]
		private double m_lastSessionWeightVagDays;

		// Token: 0x0400017A RID: 378
		private GlobalUpdater.Corrutina m_updateWeightRutineAnus;

		// Token: 0x0400017B RID: 379
		[TupleElementNames(new string[] { "targetW", "semenSkinIndex" })]
		private ValueTuple<float, int> m_rutineDataAnus;

		// Token: 0x0400017C RID: 380
		private GlobalUpdater.Corrutina m_updateWeightRutineVag;

		// Token: 0x0400017D RID: 381
		[TupleElementNames(new string[] { "targetW", "semenSkinIndex" })]
		private ValueTuple<float, int> m_rutineDataVag;
	}
}
