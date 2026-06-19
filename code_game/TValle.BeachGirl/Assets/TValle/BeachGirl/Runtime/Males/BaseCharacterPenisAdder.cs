using System;
using System.Collections;
using Assets.Base.BeachGirl.Mapas;
using Assets.TValle.BeachGirl.Runtime.Penes;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Penes;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Males
{
	// Token: 0x0200009C RID: 156
	[RequireComponent(typeof(ICharacter))]
	public abstract class BaseCharacterPenisAdder<PenisType> : BehaviourAdder where PenisType : Penetrador
	{
		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000F105 File Offset: 0x0000D305
		public sealed override object addedResult
		{
			get
			{
				return this.m_Penis;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0000F112 File Offset: 0x0000D312
		public PenisType penis
		{
			get
			{
				return this.m_Penis;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x0000F11A File Offset: 0x0000D31A
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060004B0 RID: 1200
		protected abstract IPenisBoneMap penisBoneMap { get; }

		// Token: 0x060004B1 RID: 1201
		protected abstract void Awaking(Transform chainHolder);

		// Token: 0x060004B2 RID: 1202
		protected abstract Transform GetChainHolder();

		// Token: 0x060004B3 RID: 1203
		protected abstract Transform GetSkeletonRoot();

		// Token: 0x060004B4 RID: 1204
		protected abstract Transform GetPushingBone();

		// Token: 0x060004B5 RID: 1205
		protected abstract Transform GetConnstraintsRootBone();

		// Token: 0x060004B6 RID: 1206
		protected abstract PenisPoint.Configuracion GetConfig();

		// Token: 0x060004B7 RID: 1207
		protected abstract PenisPointColliderSizeGetterHandler SizeGetter();

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000F120 File Offset: 0x0000D320
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (!base.enabled)
			{
				return;
			}
			base.SetYieldStart();
			base.SetManualStart();
			this.m_Character = base.GetComponent<ICharacter>();
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			Transform chainHolder = this.GetChainHolder();
			this.Awaking(chainHolder);
			this.m_PenisLinearChain = chainHolder.gameObject.AddComponent<PenisLinearChain>();
			this.m_PenisLinearChain.SetManualStart();
			this.m_PenisLinearChain.onRootConfigCreated += this.OnRootConfigCreated;
			this.m_PenisLinearChain.onSettingConfigToPoint += this.OnSettingConfigToPoint;
			this.m_Penis = chainHolder.gameObject.AddComponent<PenisType>();
			this.m_Penis.SetManualStart();
			if (this.m_overrideSkinSurfaceTransform != null)
			{
				this.m_Penis.SetSkinSurfaceTransform(this.m_overrideSkinSurfaceTransform);
			}
			if (this.m_Character.isStared)
			{
				base.ManualStart();
				return;
			}
			this.m_Character.justStared += this.M_Character_stared;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000F236 File Offset: 0x0000D436
		private void M_Character_stared(object sender)
		{
			base.YieldManualStartFromMethod();
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0000F23F File Offset: 0x0000D43F
		protected sealed override IEnumerator YieldStartUnityEvent()
		{
			while (this.Waiting())
			{
				yield return null;
			}
			try
			{
				this.m_PenisLinearChain.SetRefereces(this.penisBoneMap, this.m_Character.centerOfMassUpDirection, this.GetSkeletonRoot(), this.GetPushingBone(), this.GetConnstraintsRootBone(), this.GetConfig(), this.SizeGetter());
				this.AfterReferencesSetted();
				this.m_PenisLinearChain.angleAgaintsGravity = this.m_angleAgaintsGravity;
				this.BeforeStartPenis();
				this.m_Penis.ManualStart();
				this.m_Penis.gameObject.AddComponent<ControlladorIPeneEsEstirable>();
				this.m_PenisLinearChain.gameObject.AddComponent<PenisMassModSetter>().pelvisMassGetter = this.PelvisMassGetter();
				this.AfterStaredPenis();
				PeneSizeModificable peneSizeModificable = this.m_PenisLinearChain.gameObject.AddComponent<PeneSizeModificable>();
				PeneRigidesModificable peneRigidesModificable = this.m_PenisLinearChain.gameObject.AddComponent<PeneRigidesModificable>();
				peneRigidesModificable.massMod = 1f;
				peneRigidesModificable.peneSizeModificable = peneSizeModificable;
				base.OnAddBehaviour();
				this.m_Penis.largo = (peneSizeModificable.size = this.m_initailSize);
				this.m_Penis.ancho = (peneSizeModificable.anchoMod = 1f);
				this.m_Penis.SetErectionTarget(this.m_initailErection);
				if (this.m_initailErection <= 0f)
				{
					this.m_Penis.Hide();
				}
				yield break;
			}
			catch (Exception)
			{
				throw;
			}
			yield break;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000F24E File Offset: 0x0000D44E
		protected virtual bool Waiting()
		{
			return false;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0000F251 File Offset: 0x0000D451
		public virtual Func<float> PelvisMassGetter()
		{
			return () => 1f;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0000F272 File Offset: 0x0000D472
		protected virtual void OnRootConfigCreated(PenisPoint.Configuracion arg1, PenisLinearChain arg2)
		{
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000F274 File Offset: 0x0000D474
		protected virtual void OnSettingConfigToPoint(PenisPoint point, int index, ref PenisPoint.Configuracion config, LinearChainTipo2<PenisPoint, PenisPoint.Configuracion> sender)
		{
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0000F276 File Offset: 0x0000D476
		protected virtual void AfterReferencesSetted()
		{
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000F278 File Offset: 0x0000D478
		protected virtual void BeforeStartPenis()
		{
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000F27A File Offset: 0x0000D47A
		protected virtual void AfterStaredPenis()
		{
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0000F27C File Offset: 0x0000D47C
		protected override void AddBehaviour()
		{
		}

		// Token: 0x040002C3 RID: 707
		[SerializeField]
		protected Transform m_overrideSkinSurfaceTransform;

		// Token: 0x040002C4 RID: 708
		[SerializeField]
		[Range(0f, 100f)]
		protected float m_initailErection = 100f;

		// Token: 0x040002C5 RID: 709
		[SerializeField]
		[Range(0f, 5f)]
		protected float m_initailSize = 0.75f;

		// Token: 0x040002C6 RID: 710
		[SerializeField]
		protected float m_angleAgaintsGravity;

		// Token: 0x040002C7 RID: 711
		protected ICharacter m_Character;

		// Token: 0x040002C8 RID: 712
		protected PenisLinearChain m_PenisLinearChain;

		// Token: 0x040002C9 RID: 713
		protected PenisType m_Penis;

		// Token: 0x040002CA RID: 714
		protected PenisMassModSetter m_PenisMassModSetter;
	}
}
