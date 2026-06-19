using System;
using System.Collections;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Chars;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Props;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes
{
	// Token: 0x0200008C RID: 140
	public class UltrasonidoOrgansActivation : AplicableBehaviour
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x000211C8 File Offset: 0x0001F3C8
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x000211D0 File Offset: 0x0001F3D0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_self = base.GetComponent<GrabbableProp>();
			if (this.m_self == null)
			{
				throw new ArgumentNullException("m_self", "m_self null reference.");
			}
			if (this.m_organsSkin == null)
			{
				throw new ArgumentNullException("m_organsSkin", "m_organsSkin null reference.");
			}
			this.m_hearthBeat = new ShapeKey("BODY_HearthBitA");
			base.SetYieldStart();
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00021241 File Offset: 0x0001F441
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_self.onStadoChanged += this.M_self_onStadoChanged;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00021260 File Offset: 0x0001F460
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_self != null)
			{
				this.m_self.onStadoChanged -= this.M_self_onStadoChanged;
			}
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00021290 File Offset: 0x0001F490
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_targetSkins != null)
			{
				ArmatureSkins targetSkins = this.m_targetSkins;
				Skin skin = this.m_skin;
				InternalOrgansSkin skin2 = this.m_skin;
				targetSkins.RemoveSkin(skin, ((skin2 != null) ? skin2.skinnedMeshRenderer : null) != null, false, true);
			}
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000212DE File Offset: 0x0001F4DE
		protected override IEnumerator YieldStartUnityEvent()
		{
			Character target;
			do
			{
				target = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character;
				if (target == null)
				{
					yield return null;
				}
			}
			while (target == null);
			this.m_targetSkins = null;
			do
			{
				if (this.m_targetSkins == null)
				{
					this.m_targetSkins = target.GetComponentEnRoot<ArmatureSkins>();
				}
				if (this.m_targetSkins == null || !this.m_targetSkins.isStared)
				{
					yield return null;
				}
			}
			while (this.m_targetSkins == null);
			this.m_respirador = this.m_targetSkins.GetComponentEnRoot(true);
			this.m_placer = this.m_targetSkins.GetComponentEnRoot(true);
			if (this.m_respirador == null)
			{
				Debug.LogError("no se encontro respirador");
			}
			if (this.m_placer == null)
			{
				Debug.LogError("no se encontro placer");
			}
			int layer = this.m_organsSkin.gameObject.layer;
			this.m_skin = this.m_targetSkins.AddSkin<InternalOrgansSkin, InternalOrgansSkin>(this.m_organsSkin.transform, false, false, null);
			this.m_organsSkin.gameObject.layer = layer;
			this.m_shapeCopier = GenericShapeKeyCopier.Add(this.m_organsSkin, this.m_targetSkins.mainSkin.skinnedMeshRenderer);
			this.m_shapeCopier.enabled = false;
			this.m_organsSkin.enabled = false;
			yield break;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x000212F0 File Offset: 0x0001F4F0
		private void M_self_onStadoChanged(GrabbablePropEstado current, GrabbablePropEstado last, GrabbableProp sender)
		{
			if (!base.isStared)
			{
				return;
			}
			if (current <= GrabbablePropEstado.NotGrabbed)
			{
				this.m_shapeCopier.enabled = false;
				this.m_organsSkin.enabled = false;
				return;
			}
			if (current - GrabbablePropEstado.Grabbed > 1)
			{
				throw new ArgumentOutOfRangeException(current.ToString());
			}
			this.m_shapeCopier.enabled = true;
			this.m_organsSkin.enabled = true;
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00021358 File Offset: 0x0001F558
		public override void OnUpdateEvent1()
		{
			GrabbablePropEstado estado = this.m_self.estado;
			if (estado - GrabbablePropEstado.Grabbed <= 1)
			{
				float num = Mathf.Lerp(200f, 60f, this.m_respirador.saturacionDeOxigenoWeigth);
				float num2 = Mathf.Lerp(60f, 160f, this.m_placer.value.mod.InPow(3f));
				float num3 = Mathf.Max(num, num2);
				float num4 = 30f;
				if (num3 > this.m_currentHearRate)
				{
					num4 = 60f;
				}
				else if (num3 < this.m_currentHearRate)
				{
					num4 = 5f;
				}
				this.m_currentHearRate = Mathf.MoveTowards(this.m_currentHearRate, num3, Time.deltaTime * num4);
				float num5 = this.m_currentHearRate / 60f;
				float num6 = Mathf.InverseLerp(200f, 60f, this.m_currentHearRate).InPow(3f);
				float num7 = Mathf.Lerp(1f, 5f, num6);
				num7 *= Mathf.Lerp(1f, 1.25f, num6);
				if (this.m_currentHearVal > 66f)
				{
					this.m_currentSpeedMod = num7 * 0.9f;
					this.m_currentHearValTarget = float.MinValue;
					this.m_currentHearVal = 66f;
				}
				if (this.m_currentHearVal < -66f)
				{
					this.m_heartRest.ApplyNext(1f / num5 * (1f - 1f / num7));
					this.m_currentSpeedMod = num7 * 1.1f;
					this.m_currentHearValTarget = float.MaxValue;
					this.m_currentHearVal = -66f;
				}
				if (!this.m_heartRest.isOn)
				{
					this.m_currentHearVal = Mathf.MoveTowards(this.m_currentHearVal, this.m_currentHearValTarget, num5 * Time.deltaTime * 66f * 4f * this.m_currentSpeedMod);
					this.m_hearthBeat.SetValor(this.m_organsSkin, this.m_currentHearVal);
					return;
				}
			}
			else
			{
				this.m_currentSpeedMod = 1f;
				this.m_currentHearRate = 60f;
				this.m_currentHearValTarget = float.MaxValue;
				this.m_currentHearVal = 0f;
				this.m_heartRest.Reset();
			}
		}

		// Token: 0x0400037F RID: 895
		private GrabbableProp m_self;

		// Token: 0x04000380 RID: 896
		[SerializeField]
		private SkinnedMeshRenderer m_organsSkin;

		// Token: 0x04000381 RID: 897
		private GenericShapeKeyCopier m_shapeCopier;

		// Token: 0x04000382 RID: 898
		private ShapeKey m_hearthBeat;

		// Token: 0x04000383 RID: 899
		private ICharacterRespirador m_respirador;

		// Token: 0x04000384 RID: 900
		private PlacerBase m_placer;

		// Token: 0x04000385 RID: 901
		private ArmatureSkins m_targetSkins;

		// Token: 0x04000386 RID: 902
		private InternalOrgansSkin m_skin;

		// Token: 0x04000387 RID: 903
		private float m_currentHearRate = 1f;

		// Token: 0x04000388 RID: 904
		private float m_currentHearVal;

		// Token: 0x04000389 RID: 905
		private float m_currentHearValTarget = float.MaxValue;

		// Token: 0x0400038A RID: 906
		private float m_currentSpeedMod = 1f;

		// Token: 0x0400038B RID: 907
		private CoolDown m_heartRest = new CoolDown();
	}
}
