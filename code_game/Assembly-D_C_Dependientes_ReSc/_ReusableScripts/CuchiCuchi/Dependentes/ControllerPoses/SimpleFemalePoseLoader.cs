using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Base.Behaviours.Runtime.Anims;
using Assets.Base.Plugins.Runtime;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Poses;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ControllerPoses
{
	// Token: 0x02000213 RID: 531
	public sealed class SimpleFemalePoseLoader : BaseFemalePoseLoader
	{
		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000D5E RID: 3422 RVA: 0x000066D6 File Offset: 0x000048D6
		public override bool conControlSobreElPersonaje
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000D5F RID: 3423 RVA: 0x0003BFDE File Offset: 0x0003A1DE
		// (set) Token: 0x06000D60 RID: 3424 RVA: 0x0003BFE6 File Offset: 0x0003A1E6
		public override TipoDePose currentPose
		{
			get
			{
				return this.m_currentTipoPose;
			}
			set
			{
				this.tipoDePose = value;
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000D61 RID: 3425 RVA: 0x000066D6 File Offset: 0x000048D6
		public override int updateEvent1Index
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x000205A7 File Offset: 0x0001E7A7
		public override int updateEvent2Index
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000D63 RID: 3427 RVA: 0x0003BFEF File Offset: 0x0003A1EF
		public override Animator animator
		{
			get
			{
				return this.m_Animator;
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000D64 RID: 3428 RVA: 0x0003BFF7 File Offset: 0x0003A1F7
		// (set) Token: 0x06000D65 RID: 3429 RVA: 0x0003BFFF File Offset: 0x0003A1FF
		public override FemaleAnimatedPoseIDs animatedPoseID
		{
			get
			{
				return this.m_currentFemaleAnimatedPoseIDs;
			}
			set
			{
				this.m_FemaleAnimatedPoseIDs = value;
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000D66 RID: 3430 RVA: 0x0003C008 File Offset: 0x0003A208
		[Obsolete]
		public SimpleFemalePoseLoader.AnimatorVariables animatorVariables
		{
			get
			{
				return this.m_AnimatorVariables;
			}
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000D67 RID: 3431 RVA: 0x0003C010 File Offset: 0x0003A210
		// (remove) Token: 0x06000D68 RID: 3432 RVA: 0x0003C048 File Offset: 0x0003A248
		public override event Action<AnimController> poseChanged;

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000D69 RID: 3433 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override bool forzandoPelvisAltura
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x0003C080 File Offset: 0x0003A280
		protected override void AwakeUnityEvent()
		{
			this.m_AnimatorVariables.Init(this);
			base.AwakeUnityEvent();
			this.m_Animator = base.GetComponentInChildren<Animator>();
			List<int> list = new List<int>();
			for (int i = 0; i < this.animator.layerCount; i++)
			{
				string layerName = this.animator.GetLayerName(i);
				if (!layerName.Contains("face", StringComparison.OrdinalIgnoreCase) && !layerName.Contains("facial", StringComparison.OrdinalIgnoreCase))
				{
					list.Add(i);
				}
			}
			this.m_layerToChangeW = list.ToArray();
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x0003C103 File Offset: 0x0003A303
		protected override void AfterStartUnityEvent()
		{
			base.AfterStartUnityEvent();
			this.m_GrounderIkWeigthModificador = this.GetComponentEnRoot(false).grounderIkWeigthModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x0003C124 File Offset: 0x0003A324
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_currentTipoPose = TipoDePose.None;
			this.m_lastFemaleAnimatedPoseIDs = (this.m_currentFemaleAnimatedPoseIDs = FemaleAnimatedPoseIDs.None);
			this.m_GrounderIkWeigthModificador.valor.valor = 1f;
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x0003C164 File Offset: 0x0003A364
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_GrounderIkWeigthModificador.TryRemoverDeOwner(true);
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x0003C17C File Offset: 0x0003A37C
		public override void OnUpdateEvent1()
		{
			bool flag = false;
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.HeroineScale, this.m_FemaleChar.escala);
			if (this.m_FemaleChar.isStared && this.m_currentFemaleAnimatedPoseIDs != this.m_FemaleAnimatedPoseIDs)
			{
				flag = true;
				this.m_lastFemaleAnimatedPoseIDs = this.m_currentFemaleAnimatedPoseIDs;
				this.m_currentFemaleAnimatedPoseIDs = this.m_FemaleAnimatedPoseIDs;
				this.m_Animator.SetInteger(FemaleAnimController.FemaleAnimatorVariables.AnimPoseID, (int)this.m_currentFemaleAnimatedPoseIDs);
				this.tipoDePose = this.m_currentFemaleAnimatedPoseIDs.GetTipoDePoseDeAnimPose();
				this.UpdatePoseConfigClearing(true);
				this.UpdateSegundario();
				this.UpdatePoseConfig(true);
			}
			if (this.updatePose && !flag)
			{
				this.UpdateTipoDePose();
			}
			float num = ((this.m_currentFemaleAnimatedPoseIDs == FemaleAnimatedPoseIDs.None && base.EstaEnLocomotion()) ? 1f : 0f);
			for (int i = 1; i < this.m_layerToChangeW.Length; i++)
			{
				float num2 = Mathf.MoveTowards(this.animator.GetLayerWeight(i), num, 3f * Time.deltaTime);
				this.animator.SetLayerWeight(i, num2);
			}
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x0003C285 File Offset: 0x0003A485
		public override void ForceIdleState()
		{
			base.ForceIdleState();
			this.m_GrounderIkWeigthModificador.valor.valor = 1f;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x0003C2A2 File Offset: 0x0003A4A2
		public override bool EstaEnRecostadaState()
		{
			return this.animator.GetBool(FemaleAnimController.FemaleAnimatorVariables.Recostada);
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x0003C2B4 File Offset: 0x0003A4B4
		public override bool EstaRecostada()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			AnimatorStateInfo nextAnimatorStateInfo = this.animator.GetNextAnimatorStateInfo(0);
			bool flag = this.animator.IsInTransition(0);
			foreach (object obj in typeof(FemaleAnimatedRecostarseIDs).GetEnumValoresLimpiosObject())
			{
				FemaleAnimatedRecostarseIDs femaleAnimatedRecostarseIDs = (FemaleAnimatedRecostarseIDs)obj;
				if (femaleAnimatedRecostarseIDs != FemaleAnimatedRecostarseIDs.None)
				{
					string text = femaleAnimatedRecostarseIDs.ToString();
					if ((!flag && currentAnimatorStateInfo.IsTag(text)) || (flag && nextAnimatorStateInfo.IsTag(text)))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x0003C378 File Offset: 0x0003A578
		public override bool EstaRecostada(FemaleAnimatedRecostarseIDs tipoDeRecostamiento)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			AnimatorStateInfo nextAnimatorStateInfo = this.animator.GetNextAnimatorStateInfo(0);
			string text = tipoDeRecostamiento.ToString();
			return (!this.animator.IsInTransition(0) && currentAnimatorStateInfo.IsTag(text)) || (this.animator.IsInTransition(0) && nextAnimatorStateInfo.IsTag(text));
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x0003C3E0 File Offset: 0x0003A5E0
		public override void RecostarseEnCurrentRecostable(FemaleAnimatedRecostarseIDs tipoDeRecostamiento)
		{
			if (this.animatedPoseID == (FemaleAnimatedPoseIDs)tipoDeRecostamiento)
			{
				return;
			}
			if (tipoDeRecostamiento == FemaleAnimatedRecostarseIDs.None)
			{
				this.LevantarseDeCurrentRecostable();
				return;
			}
			IRecostable currentRecostableOnRange = base.currentRecostableOnRange;
			if (currentRecostableOnRange == null)
			{
				return;
			}
			this.UpdateSuperficieRecostadaValue(currentRecostableOnRange, tipoDeRecostamiento);
			currentRecostableOnRange.UpdateGoto(this.character);
			this.animatedPoseID = (FemaleAnimatedPoseIDs)tipoDeRecostamiento;
			if (this.m_SyncRootConSillaCoroutine != null)
			{
				base.StopCoroutine(this.m_SyncRootConSillaCoroutine);
			}
			this.m_SyncRootConSillaCoroutine = null;
			if (this.m_EsperarDesSentarseCoroutine != null)
			{
				base.StopCoroutine(this.m_EsperarDesSentarseCoroutine);
			}
			this.m_EsperarDesSentarseCoroutine = null;
			if (this.m_FollowDinamicOffSetDeSillaCoroutine != null)
			{
				base.StopCoroutine(this.m_FollowDinamicOffSetDeSillaCoroutine);
			}
			this.m_FollowDinamicOffSetDeSillaCoroutine = null;
			if (!this.EstaRecostada())
			{
				this.m_SyncRootConSillaCoroutine = base.StartCoroutine(this.SyncRootConRecostableRutine(currentRecostableOnRange));
			}
			else
			{
				this.m_FollowDinamicOffSetDeSillaCoroutine = base.StartCoroutine(this.FollowDinamicOffSetDeSellaRutine(currentRecostableOnRange));
			}
			this.m_EsperarDesSentarseCoroutine = base.StartCoroutine(this.EsperarDesRecostarseRutine(currentRecostableOnRange));
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x0003C4BC File Offset: 0x0003A6BC
		public override void LevantarseDeCurrentRecostable()
		{
			if (this.animatedPoseID == FemaleAnimatedPoseIDs.None)
			{
				return;
			}
			IRecostable currentRecostableOnRange = base.currentRecostableOnRange;
			bool flag = this.animatedPoseID.EsRecostadaAnim();
			if (currentRecostableOnRange == null)
			{
				if (flag)
				{
					this.animatedPoseID = FemaleAnimatedPoseIDs.None;
				}
				return;
			}
			if (!flag)
			{
				return;
			}
			if (this.m_EsperarDesSentarseCoroutine == null)
			{
				this.m_EsperarDesSentarseCoroutine = base.StartCoroutine(this.EsperarDesRecostarseRutine(currentRecostableOnRange));
			}
			if (flag)
			{
				this.animatedPoseID = FemaleAnimatedPoseIDs.None;
			}
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x0003C51C File Offset: 0x0003A71C
		public void UpdateSuperficieRecostadaValue(IRecostable recostable, FemaleAnimatedRecostarseIDs tipoDeRecostamiento)
		{
			float num = this.m_FemaleChar.estatura * 0.5506608f;
			float num2 = recostable.worldAltura / num;
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.SuperficieRecostadaAlturaMod, num2);
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x0003C555 File Offset: 0x0003A755
		private IEnumerator SyncRootConRecostableRutine(IRecostable recostable)
		{
			Vector3 startPos = this.animator.transform.position;
			Quaternion startRot = this.animator.transform.rotation;
			AnimatorStateInfo animatorStateInfo;
			do
			{
				yield return null;
				animatorStateInfo = this.animator.GetNextAnimatorStateInfo(0);
			}
			while (!animatorStateInfo.IsTag("MainEntry"));
			bool flag = recostable.IsOnGotoPosition(this.character, 2f);
			while (animatorStateInfo.normalizedTime < 1f && animatorStateInfo.IsTag("MainEntry") && flag)
			{
				if (!this.animatedPoseID.EsRecostadaAnim())
				{
					yield break;
				}
				float num = Mathf.InverseLerp(0f, 0.45f, animatorStateInfo.normalizedTime).InPow(6f);
				Vector3 vector = Vector3.Lerp(startPos, recostable.idleRootWorldPositon + recostable.dinamicOffset, num);
				Quaternion quaternion = Quaternion.Slerp(startRot, recostable.worldRotation, num);
				this.animator.transform.SetPositionAndRotation(vector, quaternion);
				this.m_GrounderIkWeigthModificador.valor.valor = 1f - num;
				yield return null;
				if (this.animator.IsInTransition(0))
				{
					animatorStateInfo = this.animator.GetNextAnimatorStateInfo(0);
				}
				else
				{
					animatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
				}
				flag = recostable.IsOnGotoPosition(this.character, 2f);
			}
			if (flag)
			{
				this.animator.transform.SetPositionAndRotation(recostable.idleRootWorldPositon + recostable.dinamicOffset, recostable.worldRotation);
				this.m_GrounderIkWeigthModificador.valor.valor = 0f;
			}
			this.m_SyncRootConSillaCoroutine = null;
			if (this.m_FollowDinamicOffSetDeSillaCoroutine != null)
			{
				base.StopCoroutine(this.m_FollowDinamicOffSetDeSillaCoroutine);
			}
			this.m_FollowDinamicOffSetDeSillaCoroutine = base.StartCoroutine(this.FollowDinamicOffSetDeSellaRutine(recostable));
			yield break;
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x0003C56B File Offset: 0x0003A76B
		private IEnumerator FollowDinamicOffSetDeSellaRutine(IRecostable recostable)
		{
			yield return null;
			while (this.EstaEnRecostadaState())
			{
				if (recostable.dinamicOffset != Vector3.zero)
				{
					this.animator.transform.position = recostable.idleRootWorldPositon + recostable.dinamicOffset;
				}
				yield return null;
			}
			this.m_FollowDinamicOffSetDeSillaCoroutine = null;
			yield break;
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x0003C581 File Offset: 0x0003A781
		private IEnumerator EsperarDesRecostarseRutine(IRecostable recostable)
		{
			bool estabaRecostada = false;
			bool recostada;
			do
			{
				recostada = this.m_FemaleAnimatedPoseIDs.EsRecostadaAnim() || this.m_currentFemaleAnimatedPoseIDs.EsRecostadaAnim();
				estabaRecostada = estabaRecostada || recostada;
				yield return null;
			}
			while (recostada);
			if (estabaRecostada)
			{
				AnimatorStateInfo animatorStateInfo;
				do
				{
					yield return null;
					animatorStateInfo = this.animator.GetNextAnimatorStateInfo(0);
				}
				while (!animatorStateInfo.IsTag("MainExit"));
				if (this.m_FollowDinamicOffSetDeSillaCoroutine != null)
				{
					base.StopCoroutine(this.m_FollowDinamicOffSetDeSillaCoroutine);
				}
				this.m_FollowDinamicOffSetDeSillaCoroutine = null;
				bool flag = recostable.IsOnGotoPosition(this.character, 2f);
				while (animatorStateInfo.normalizedTime < 1f && animatorStateInfo.IsTag("MainExit") && flag)
				{
					float num = Mathf.InverseLerp(0.666f, 1f, animatorStateInfo.normalizedTime).OutPow(3f);
					Vector3 vector = Vector3.Lerp(recostable.idleRootWorldPositon + recostable.dinamicOffset, recostable.gotoWorldPositon, num);
					this.m_GrounderIkWeigthModificador.valor.valor = num;
					this.animator.transform.position = vector;
					yield return null;
					if (this.animator.IsInTransition(0))
					{
						animatorStateInfo = this.animator.GetNextAnimatorStateInfo(0);
					}
					else
					{
						animatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
					}
					flag = recostable.IsOnGotoPosition(this.character, 2f);
				}
				if (flag)
				{
					this.animator.transform.position = recostable.gotoWorldPositon;
					this.m_GrounderIkWeigthModificador.valor.valor = 1f;
				}
			}
			this.m_EsperarDesSentarseCoroutine = null;
			yield break;
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x0003C597 File Offset: 0x0003A797
		public void UpdateTipoDePose()
		{
			if (!this.m_FemaleChar.isStared)
			{
				return;
			}
			this.UpdatePoseConfigClearing(false);
			this.UpdateSegundario();
			this.UpdatePoseConfig(false);
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x0003C5BB File Offset: 0x0003A7BB
		public override void OnPose()
		{
			BaseFemalePoseLoader.Pose current = this.m_current;
			if (current == null)
			{
				return;
			}
			current.OnPose(this.m_AtadurasDePuppet);
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x0003C5D3 File Offset: 0x0003A7D3
		private void UpdateSegundario()
		{
			this.m_Animator.SetBool(FemaleAnimController.FemaleAnimatorVariables.EstaSentada, this.estadosSegundarios.estaSentada);
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0003C5F0 File Offset: 0x0003A7F0
		private void UpdatePoseConfigClearing(bool force = false)
		{
			if (!force && this.tipoDePose == this.m_currentTipoPose)
			{
				return;
			}
			if (this.m_current != null)
			{
				this.m_current.ClearPose(this.m_AtadurasDePuppet);
				this.m_current = null;
			}
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x0003C624 File Offset: 0x0003A824
		public override void UpdatePoseConfig(bool force = false)
		{
			if (!force && this.tipoDePose == this.m_currentTipoPose)
			{
				return;
			}
			if (!Singleton<FemalePosesConfigs>.instance.ContieneConfig(this.tipoDePose))
			{
				Debug.LogError("No se puede cambiar la pose a " + this.tipoDePose.ToString() + ", no existe configuracion.", this);
				this.tipoDePose = this.m_currentTipoPose;
				return;
			}
			this.m_currentTipoPose = this.tipoDePose;
			if (this.m_current != null)
			{
				this.m_current.ClearPose(this.m_AtadurasDePuppet);
			}
			this.m_current = new BaseFemalePoseLoader.Pose(this, this.m_PuppetMaster, this.m_AtadurasDePuppet, this.m_FemaleChar.bodyAnimator, this.tipoDePose, this.m_lastFemaleAnimatedPoseIDs.EsRecostadaAnim() || this.m_currentFemaleAnimatedPoseIDs.EsRecostadaAnim());
			for (int i = 0; i < this.m_PuppetMaster.behaviours.Length; i++)
			{
				this.m_PuppetMaster.behaviours[i].enabled = this.m_currentTipoPose == TipoDePose.dePieRigida;
			}
			Action<AnimController> action = this.poseChanged;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x00002BEA File Offset: 0x00000DEA
		public override void OnUpdateEvent2()
		{
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0003C735 File Offset: 0x0003A935
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.UpdatePoseConfig(true);
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x0003C744 File Offset: 0x0003A944
		public override void SetDefaultPose()
		{
			this.tipoDePose = TipoDePose.dePieRigida;
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x0003C750 File Offset: 0x0003A950
		public override void SetIdlePoseStyle(float value)
		{
			try
			{
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.WalkLegsStyle, value);
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Exception ahead", base.gameObject);
				throw ex;
			}
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x0003C794 File Offset: 0x0003A994
		public override void SetIdlePoseEmos(float extro, float grosera, float pervert, float timida, float asustada)
		{
			try
			{
				float num = 1f - Mathf.Clamp01(extro + grosera + pervert + timida + asustada);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseExtrovertida, extro);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseGrosera, grosera);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PosePervertida, pervert);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseTimida, timida);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseNormal, num);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseAsustada, asustada);
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Exception ahead", base.gameObject);
				throw ex;
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x0003C844 File Offset: 0x0003AA44
		public override void SetFingersIdlePoseEmos(float extro, float grosera, float pervert, float timida, float asustada)
		{
			try
			{
				float num = 1f - Mathf.Clamp01(extro + grosera + pervert + timida + asustada);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseExtrovertidaFingers, extro);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseGroseraFingers, grosera);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PosePervertidaFingers, pervert);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseTimidaFingers, timida);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseNormalFingers, num);
				this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseAsustadaFingers, asustada);
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Exception ahead", base.gameObject);
				throw ex;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000D84 RID: 3460 RVA: 0x0003C8F4 File Offset: 0x0003AAF4
		public override string aplicarButtonString
		{
			get
			{
				return "Aplicar Position Config";
			}
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x0003C8FC File Offset: 0x0003AAFC
		public override void Strafe(float horizontal, float vertical, float magnitude)
		{
			Vector2 vector = new Vector2(horizontal, vertical);
			if (vector.sqrMagnitude > 0f)
			{
				this.lastInputStrafeDirection = vector.normalized;
				this.lastInputStrafeDirectionPolarity = (float)((horizontal < 0f) ? (-1) : 1);
			}
			float num = Mathf.Lerp(0.2f, 1f, magnitude);
			float num2 = this.lastInputStrafeDirection.x * num;
			float num3 = this.lastInputStrafeDirection.y * num;
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.Horizontal, num2);
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.Vertical, num3);
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.Magnitude, (magnitude > 0f) ? num : magnitude);
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x0003C9AB File Offset: 0x0003ABAB
		public override void Walk(float horizontal, float vertical, float magnitude)
		{
			this.Strafe(horizontal, vertical, magnitude);
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x0003C9B8 File Offset: 0x0003ABB8
		public override void Turn90(float weightPolarizado)
		{
			float @float = this.m_Animator.GetFloat(FemaleAnimController.FemaleAnimatorVariables.WalkLegsStyle);
			float num = Mathf.Lerp(0.5f, 0f, @float.InPow(2f));
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.TurnTypeAngle, num);
			weightPolarizado = Mathf.Clamp(weightPolarizado, -1f, 1f);
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.TurnMagnitude, weightPolarizado);
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x0003CA28 File Offset: 0x0003AC28
		public override void Turn180(float weightPolarizado)
		{
			float @float = this.m_Animator.GetFloat(FemaleAnimController.FemaleAnimatorVariables.WalkLegsStyle);
			float num = Mathf.Lerp(1f, 0f, @float.InPow(2f));
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.TurnTypeAngle, num);
			weightPolarizado = Mathf.Clamp(weightPolarizado, -1f, 1f);
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.TurnMagnitude, weightPolarizado);
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x0003CA95 File Offset: 0x0003AC95
		public override void StopMoving()
		{
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.Magnitude, 0f);
			this.m_Animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.TurnMagnitude, 0f);
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x0003CAC1 File Offset: 0x0003ACC1
		protected override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "TEST Sentarse",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x0003CADA File Offset: 0x0003ACDA
		protected override void OnAplicar5()
		{
			base.OnAplicar5();
			if (!this.animatedPoseID.EsRecostadaAnim())
			{
				base.ForzarRecostarseEn(FemaleAnimatedRecostarseIDs.sentarse, this.m_sillaTEST);
				return;
			}
			this.UpdateSuperficieRecostadaValue(this.m_sillaTEST, FemaleAnimatedRecostarseIDs.sentarse);
		}

		// Token: 0x0400091A RID: 2330
		public bool updatePose = true;

		// Token: 0x0400091B RID: 2331
		public SimpleFemalePoseLoader.EstadosSegundarios estadosSegundarios = new SimpleFemalePoseLoader.EstadosSegundarios();

		// Token: 0x0400091C RID: 2332
		private Animator m_Animator;

		// Token: 0x0400091D RID: 2333
		private Coroutine m_SyncRootConSillaCoroutine;

		// Token: 0x0400091E RID: 2334
		private Coroutine m_EsperarDesSentarseCoroutine;

		// Token: 0x0400091F RID: 2335
		private Coroutine m_FollowDinamicOffSetDeSillaCoroutine;

		// Token: 0x04000920 RID: 2336
		public TipoDePose tipoDePose = TipoDePose.dePieRigida;

		// Token: 0x04000921 RID: 2337
		[NonSerialized]
		private TipoDePose m_currentTipoPose;

		// Token: 0x04000922 RID: 2338
		[SerializeField]
		private FemaleAnimatedPoseIDs m_FemaleAnimatedPoseIDs;

		// Token: 0x04000923 RID: 2339
		[NonSerialized]
		private FemaleAnimatedPoseIDs m_currentFemaleAnimatedPoseIDs;

		// Token: 0x04000924 RID: 2340
		[NonSerialized]
		private FemaleAnimatedPoseIDs m_lastFemaleAnimatedPoseIDs;

		// Token: 0x04000925 RID: 2341
		private Vector2 lastInputStrafeDirection;

		// Token: 0x04000926 RID: 2342
		private float lastInputStrafeDirectionPolarity = 1f;

		// Token: 0x04000927 RID: 2343
		[Obsolete]
		private SimpleFemalePoseLoader.AnimatorVariables m_AnimatorVariables = new SimpleFemalePoseLoader.AnimatorVariables();

		// Token: 0x04000928 RID: 2344
		private int[] m_layerToChangeW;

		// Token: 0x0400092A RID: 2346
		private ModificadorDeFloat m_GrounderIkWeigthModificador;

		// Token: 0x0400092B RID: 2347
		public const float magnitudeToStop = 0.1f;

		// Token: 0x0400092C RID: 2348
		public const float magnitudeToMove = 0.2f;

		// Token: 0x0400092D RID: 2349
		public const float maxMagnitude = 1f;

		// Token: 0x0400092E RID: 2350
		private const float maxRotationInput = 180f;

		// Token: 0x0400092F RID: 2351
		[Header("Debug")]
		[SerializeField]
		private SillaGenerica m_sillaTEST;

		// Token: 0x02000214 RID: 532
		[Serializable]
		public class EstadosSegundarios
		{
			// Token: 0x04000930 RID: 2352
			public bool estaSentada;
		}

		// Token: 0x02000215 RID: 533
		[Obsolete]
		public new class AnimatorVariables
		{
			// Token: 0x06000D8E RID: 3470 RVA: 0x0003CB44 File Offset: 0x0003AD44
			public void Init(SimpleFemalePoseLoader loader)
			{
				this.EstaSentada = Animator.StringToHash("EstaSentada");
				this.WalkLegsStyle = Animator.StringToHash("WalkLegsStyle");
				this.Horizontal = Animator.StringToHash("Horizontal");
				this.Vertical = Animator.StringToHash("Vertical");
				this.Magnitude = Animator.StringToHash("Magnitude");
				this.IsRightLegUp = Animator.StringToHash("IsRightLegUp");
				this.LegSwitch = Animator.StringToHash("LegSwitch");
				this.PoseNormal = Animator.StringToHash("PoseNormal");
				this.PoseExtrovertida = Animator.StringToHash("PoseExtrovertida");
				this.PoseGrosera = Animator.StringToHash("PoseGrosera");
				this.PosePervertida = Animator.StringToHash("PosePervertida");
				this.PoseTimida = Animator.StringToHash("PoseTimida");
				this.PoseAsustada = Animator.StringToHash("PoseAsustada");
				this.PoseNormalFingers = Animator.StringToHash("PoseNormalFingers");
				this.PoseExtrovertidaFingers = Animator.StringToHash("PoseExtrovertidaFingers");
				this.PoseGroseraFingers = Animator.StringToHash("PoseGroseraFingers");
				this.PosePervertidaFingers = Animator.StringToHash("PosePervertidaFingers");
				this.PoseTimidaFingers = Animator.StringToHash("PoseTimidaFingers");
				this.PoseAsustadaFingers = Animator.StringToHash("PoseAsustadaFingers");
				this.TurnMagnitude = Animator.StringToHash("TurnMagnitude");
				this.TurnTypeAngle = Animator.StringToHash("TurnTypeAngle");
				this.PoseEstimuladaWeight = Animator.StringToHash("PoseEstimuladaWeight");
				this.AnimPoseID = Animator.StringToHash("AnimatedPoseValue");
				this.HeroineScale = Animator.StringToHash("HeroineScale");
				this.SuperficieRecostadaAlturaMod = Animator.StringToHash("SuperficieSentarAlturaMod");
			}

			// Token: 0x04000931 RID: 2353
			[Obsolete("", true)]
			public int L0MotionPhase;

			// Token: 0x04000932 RID: 2354
			public int EstaSentada;

			// Token: 0x04000933 RID: 2355
			public int WalkLegsStyle;

			// Token: 0x04000934 RID: 2356
			[Obsolete("", true)]
			public int RotationDirection;

			// Token: 0x04000935 RID: 2357
			public int Horizontal;

			// Token: 0x04000936 RID: 2358
			public int Vertical;

			// Token: 0x04000937 RID: 2359
			public int Magnitude;

			// Token: 0x04000938 RID: 2360
			public int IsRightLegUp;

			// Token: 0x04000939 RID: 2361
			public int LegSwitch;

			// Token: 0x0400093A RID: 2362
			public int PoseNormal;

			// Token: 0x0400093B RID: 2363
			public int PoseExtrovertida;

			// Token: 0x0400093C RID: 2364
			public int PoseGrosera;

			// Token: 0x0400093D RID: 2365
			public int PosePervertida;

			// Token: 0x0400093E RID: 2366
			public int PoseTimida;

			// Token: 0x0400093F RID: 2367
			public int PoseAsustada;

			// Token: 0x04000940 RID: 2368
			public int PoseNormalFingers;

			// Token: 0x04000941 RID: 2369
			public int PoseExtrovertidaFingers;

			// Token: 0x04000942 RID: 2370
			public int PoseGroseraFingers;

			// Token: 0x04000943 RID: 2371
			public int PosePervertidaFingers;

			// Token: 0x04000944 RID: 2372
			public int PoseTimidaFingers;

			// Token: 0x04000945 RID: 2373
			public int PoseAsustadaFingers;

			// Token: 0x04000946 RID: 2374
			public int TurnMagnitude;

			// Token: 0x04000947 RID: 2375
			public int TurnTypeAngle;

			// Token: 0x04000948 RID: 2376
			public int PoseEstimuladaWeight;

			// Token: 0x04000949 RID: 2377
			public int AnimPoseID;

			// Token: 0x0400094A RID: 2378
			public int HeroineScale;

			// Token: 0x0400094B RID: 2379
			public int SuperficieRecostadaAlturaMod;
		}
	}
}
