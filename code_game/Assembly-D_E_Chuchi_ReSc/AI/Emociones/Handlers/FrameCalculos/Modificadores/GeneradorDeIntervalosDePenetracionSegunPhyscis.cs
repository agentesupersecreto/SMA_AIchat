using System;
using System.Collections;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins.Holes;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores
{
	// Token: 0x02000522 RID: 1314
	public sealed class GeneradorDeIntervalosDePenetracionSegunPhyscis : CustomUpdatedMonobehaviourBase, IPhyscisIntervalosDeProfundidadMiddle, IPhyscisIntervalosDeProfundidadAbove
	{
		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x06001FF8 RID: 8184 RVA: 0x00078C5B File Offset: 0x00076E5B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update3);
			}
		}

		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x06001FF9 RID: 8185 RVA: 0x00078C63 File Offset: 0x00076E63
		RangeValueV2 IPhyscisIntervalosDeProfundidadMiddle.vagUnLimited
		{
			get
			{
				return this.m_vagInterval;
			}
		}

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x06001FFA RID: 8186 RVA: 0x00078C6B File Offset: 0x00076E6B
		RangeValueV2 IPhyscisIntervalosDeProfundidadMiddle.anusUnLimited
		{
			get
			{
				return this.m_anusInterval;
			}
		}

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06001FFB RID: 8187 RVA: 0x00078C73 File Offset: 0x00076E73
		RangeValueV2 IPhyscisIntervalosDeProfundidadMiddle.facialUnLimited
		{
			get
			{
				return this.m_bocaInterval;
			}
		}

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x06001FFC RID: 8188 RVA: 0x00078C63 File Offset: 0x00076E63
		RangeValueV2 IPhyscisIntervalosDeProfundidadAbove.vagUnLimited
		{
			get
			{
				return this.m_vagInterval;
			}
		}

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x06001FFD RID: 8189 RVA: 0x00078C6B File Offset: 0x00076E6B
		RangeValueV2 IPhyscisIntervalosDeProfundidadAbove.anusUnLimited
		{
			get
			{
				return this.m_anusInterval;
			}
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x06001FFE RID: 8190 RVA: 0x00078C73 File Offset: 0x00076E73
		RangeValueV2 IPhyscisIntervalosDeProfundidadAbove.facialUnLimited
		{
			get
			{
				return this.m_bocaInterval;
			}
		}

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x06001FFF RID: 8191 RVA: 0x00078C7B File Offset: 0x00076E7B
		RangeValueV2 IPhyscisIntervalosDeProfundidadMiddle.vag
		{
			get
			{
				return this.m_vagIntervalPlacer;
			}
		}

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x06002000 RID: 8192 RVA: 0x00078C83 File Offset: 0x00076E83
		RangeValueV2 IPhyscisIntervalosDeProfundidadMiddle.anus
		{
			get
			{
				return this.m_anusIntervalPlacer;
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x06002001 RID: 8193 RVA: 0x00078C8B File Offset: 0x00076E8B
		RangeValueV2 IPhyscisIntervalosDeProfundidadMiddle.facial
		{
			get
			{
				return this.m_bocaIntervalPlacer;
			}
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x06002002 RID: 8194 RVA: 0x00078C93 File Offset: 0x00076E93
		RangeValueV2 IPhyscisIntervalosDeProfundidadAbove.vag
		{
			get
			{
				return this.m_vagIntervalDolor;
			}
		}

		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x06002003 RID: 8195 RVA: 0x00078C9B File Offset: 0x00076E9B
		RangeValueV2 IPhyscisIntervalosDeProfundidadAbove.anus
		{
			get
			{
				return this.m_anusIntervalDolor;
			}
		}

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x06002004 RID: 8196 RVA: 0x00078CA3 File Offset: 0x00076EA3
		RangeValueV2 IPhyscisIntervalosDeProfundidadAbove.facial
		{
			get
			{
				return this.m_bocaIntervalDolor;
			}
		}

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x06002005 RID: 8197 RVA: 0x00078CAB File Offset: 0x00076EAB
		float IPhyscisIntervalosDeProfundidadAbove.vagWeight
		{
			get
			{
				return this.m_vagPenetration;
			}
		}

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x06002006 RID: 8198 RVA: 0x00078CB3 File Offset: 0x00076EB3
		float IPhyscisIntervalosDeProfundidadAbove.anusWeight
		{
			get
			{
				return this.m_anusPenetration;
			}
		}

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x06002007 RID: 8199 RVA: 0x00078CBB File Offset: 0x00076EBB
		float IPhyscisIntervalosDeProfundidadAbove.facialWeight
		{
			get
			{
				return this.m_bocaPenetration;
			}
		}

		// Token: 0x06002008 RID: 8200 RVA: 0x00078CC4 File Offset: 0x00076EC4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_skins = this.GetComponentEnRoot(false);
			this.m_vag = this.GetComponentEnRoot(false);
			this.m_anus = this.GetComponentEnRoot(false);
			this.m_boca = this.GetComponentEnRoot(false);
			if (this.m_skins == null)
			{
				throw new ArgumentNullException("m_skins", "m_skins null reference.");
			}
			if (this.m_boca == null)
			{
				throw new ArgumentNullException("m_boca", "m_boca null reference.");
			}
			if (this.m_anus == null)
			{
				throw new ArgumentNullException("m_anus", "m_anus null reference.");
			}
			if (this.m_vag == null)
			{
				throw new ArgumentNullException("m_vag", "m_vag null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x06002009 RID: 8201 RVA: 0x00078D83 File Offset: 0x00076F83
		protected override IEnumerator YieldStartUnityEvent()
		{
			if (!this.m_skins.usesHitSkins || !this.m_skins.enableHitSkins)
			{
				yield break;
			}
			do
			{
				this.m_vagFondo = this.GetComponentEnRoot(false);
				if (this.m_vagFondo == null)
				{
					yield return null;
				}
			}
			while (this.m_vagFondo == null);
			do
			{
				this.m_anusFondo = this.GetComponentEnRoot(false);
				if (this.m_anusFondo == null)
				{
					yield return null;
				}
			}
			while (this.m_anusFondo == null);
			do
			{
				this.m_bocaFondo = this.GetComponentEnRoot(false);
				if (this.m_bocaFondo == null)
				{
					yield return null;
				}
			}
			while (this.m_bocaFondo == null);
			yield break;
		}

		// Token: 0x0600200A RID: 8202 RVA: 0x00078D94 File Offset: 0x00076F94
		public override void OnUpdateEvent1()
		{
			this.m_vagInterval = GeneradorDeIntervalosDePenetracionSegunPhyscis.Update(this.m_vag);
			this.m_anusInterval = GeneradorDeIntervalosDePenetracionSegunPhyscis.Update(this.m_anus);
			this.m_bocaInterval = GeneradorDeIntervalosDePenetracionSegunPhyscis.Update(this.m_boca);
			this.m_vagIntervalPlacer = GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateMiddle(this.m_vag, FemalePenetracionTipo.vag);
			this.m_anusIntervalPlacer = GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateMiddle(this.m_anus, FemalePenetracionTipo.anus);
			this.m_bocaIntervalPlacer = GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateMiddle(this.m_boca, FemalePenetracionTipo.facial);
			this.m_vagIntervalDolor = GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateAbove(this.m_vag, this.m_vagIntervalPlacer);
			this.m_anusIntervalDolor = GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateAbove(this.m_anus, this.m_anusIntervalPlacer);
			this.m_bocaIntervalDolor = GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateAbove(this.m_boca, this.m_bocaIntervalPlacer);
			this.m_vagPenetration = ((!this.m_skins.usesHitSkins || !this.m_skins.enableHitSkins) ? 1f : GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateWeight(this.m_vagFondo));
			this.m_anusPenetration = ((!this.m_skins.usesHitSkins || !this.m_skins.enableHitSkins) ? 1f : GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateWeight(this.m_anusFondo));
			this.m_bocaPenetration = ((!this.m_skins.usesHitSkins || !this.m_skins.enableHitSkins) ? 1f : GeneradorDeIntervalosDePenetracionSegunPhyscis.UpdateWeight(this.m_bocaFondo));
		}

		// Token: 0x0600200B RID: 8203 RVA: 0x00078EE5 File Offset: 0x000770E5
		private static RangeValueV2 Update(BoneStretchedChain hole)
		{
			return new RangeValueV2(0f, hole.maxProfundidadPhysicsLocal);
		}

		// Token: 0x0600200C RID: 8204 RVA: 0x00078EF8 File Offset: 0x000770F8
		private static RangeValueV2 UpdateMiddle(BoneStretchedChain hole, FemalePenetracionTipo tipoHole)
		{
			float maxProfundidadPhysicsLocal = hole.maxProfundidadPhysicsLocal;
			float num = maxProfundidadPhysicsLocal;
			for (int i = hole.hardPointsList.Count - 1; i >= 0; i--)
			{
				HoleVirtualHardPoint holeVirtualHardPoint = hole.hardPointsList[i];
				num = Mathf.Lerp(holeVirtualHardPoint.GetProfundidadLocalFromInternals() - holeVirtualHardPoint.GetLocalRadiusFromInternals(), num, holeVirtualHardPoint.desgaste.InPow(2f));
			}
			float num2 = num * GeneradorDeIntervalosDePenetracionSegunPhyscis.GetMinMod(tipoHole);
			num = Mathf.Clamp(num, 0f, maxProfundidadPhysicsLocal);
			return new RangeValueV2(Mathf.Clamp(num2, 0f, maxProfundidadPhysicsLocal), num);
		}

		// Token: 0x0600200D RID: 8205 RVA: 0x00078F7D File Offset: 0x0007717D
		private static float GetMinMod(FemalePenetracionTipo tipoHole)
		{
			switch (tipoHole)
			{
			case FemalePenetracionTipo.anus:
				return 0.3f;
			case FemalePenetracionTipo.vag:
				return 0.2f;
			case FemalePenetracionTipo.facial:
				return 0.1f;
			default:
				throw new ArgumentOutOfRangeException(tipoHole.ToString());
			}
		}

		// Token: 0x0600200E RID: 8206 RVA: 0x00078FB8 File Offset: 0x000771B8
		private static RangeValueV2 UpdateAbove(BoneStretchedChain hole, RangeValueV2 Middle)
		{
			float maxProfundidadPhysicsLocal = hole.maxProfundidadPhysicsLocal;
			return new RangeValueV2(Middle.max * 0.95f, maxProfundidadPhysicsLocal);
		}

		// Token: 0x0600200F RID: 8207 RVA: 0x00078FE0 File Offset: 0x000771E0
		private static float UpdateWeight(HoleFondoHitSkin fondo)
		{
			float num = 1f;
			float num2 = 1f;
			int num3 = 0;
			while (num3 < fondo.checksDeCollisiones.Count && num2 > 0f)
			{
				HoleFondoHitSkin.Check check = fondo.checksDeCollisiones[num3];
				float lastPenetrationWeightSpacial = check.lastPenetrationWeightSpacial;
				if (lastPenetrationWeightSpacial >= 0.6666f)
				{
					float num4 = 1f - Mathf.InverseLerp(0.6666f, 1f, lastPenetrationWeightSpacial);
					if (check.id == "MainFondo")
					{
						num2 *= num4;
					}
					else
					{
						HoleVirtualHardPoint holeVirtualHardPoint = fondo.hole.hardPoints[check.id];
						float num5 = holeVirtualHardPoint.desgaste.OutPow(2f);
						num4 = Mathf.Lerp(num4, 1f, num5);
						num2 *= num4;
						num *= Mathf.Lerp(holeVirtualHardPoint.aiWeight, 1f, num5);
					}
				}
				num3++;
			}
			return (1f - Mathf.Clamp01(num2)) * num;
		}

		// Token: 0x06002010 RID: 8208 RVA: 0x000790D8 File Offset: 0x000772D8
		private void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying || !base.isStared)
			{
				return;
			}
			Gizmos.color = Color.gray;
			Gizmos.DrawRay(this.m_vag.centroDePuntos.position, -this.m_vag.worldOutHoleDirection * this.m_vagIntervalPlacer.min * this.m_vag.worldScaleReal);
			Gizmos.DrawRay(this.m_anus.centroDePuntos.position, -this.m_anus.worldOutHoleDirection * this.m_anusIntervalPlacer.min * this.m_vag.worldScaleReal);
			Gizmos.DrawRay(this.m_boca.centroDePuntos.position, -this.m_boca.worldOutHoleDirection * this.m_bocaIntervalPlacer.min * this.m_vag.worldScaleReal);
			Gizmos.color = Color.green;
			Gizmos.DrawRay(this.m_vag.centroDePuntos.position + -this.m_vag.worldOutHoleDirection * this.m_vagIntervalPlacer.min * this.m_vag.worldScaleReal, -this.m_vag.worldOutHoleDirection * this.m_vagIntervalPlacer.max * this.m_vag.worldScaleReal);
			Gizmos.DrawRay(this.m_anus.centroDePuntos.position + -this.m_anus.worldOutHoleDirection * this.m_anusIntervalPlacer.min * this.m_vag.worldScaleReal, -this.m_anus.worldOutHoleDirection * this.m_anusIntervalPlacer.max * this.m_vag.worldScaleReal);
			Gizmos.DrawRay(this.m_boca.centroDePuntos.position + -this.m_boca.worldOutHoleDirection * this.m_bocaIntervalPlacer.min * this.m_vag.worldScaleReal, -this.m_boca.worldOutHoleDirection * this.m_bocaIntervalPlacer.max * this.m_vag.worldScaleReal);
			Gizmos.color = Color.red;
			Gizmos.DrawRay(this.m_vag.centroDePuntos.position + -this.m_vag.worldOutHoleDirection * this.m_vagIntervalDolor.min * this.m_vag.worldScaleReal, -this.m_vag.worldOutHoleDirection * this.m_vagIntervalDolor.max * this.m_vag.worldScaleReal);
			Gizmos.DrawRay(this.m_anus.centroDePuntos.position + -this.m_anus.worldOutHoleDirection * this.m_anusIntervalDolor.min * this.m_vag.worldScaleReal, -this.m_anus.worldOutHoleDirection * this.m_anusIntervalDolor.max * this.m_vag.worldScaleReal);
			Gizmos.DrawRay(this.m_boca.centroDePuntos.position + -this.m_boca.worldOutHoleDirection * this.m_bocaIntervalDolor.min * this.m_vag.worldScaleReal, -this.m_boca.worldOutHoleDirection * this.m_bocaIntervalDolor.max * this.m_vag.worldScaleReal);
		}

		// Token: 0x0400150D RID: 5389
		[SerializeField]
		private RangeValueV2 m_vagIntervalPlacer;

		// Token: 0x0400150E RID: 5390
		[SerializeField]
		private RangeValueV2 m_anusIntervalPlacer;

		// Token: 0x0400150F RID: 5391
		[SerializeField]
		private RangeValueV2 m_bocaIntervalPlacer;

		// Token: 0x04001510 RID: 5392
		[SerializeField]
		private RangeValueV2 m_vagIntervalDolor;

		// Token: 0x04001511 RID: 5393
		[SerializeField]
		private RangeValueV2 m_anusIntervalDolor;

		// Token: 0x04001512 RID: 5394
		[SerializeField]
		private RangeValueV2 m_bocaIntervalDolor;

		// Token: 0x04001513 RID: 5395
		[SerializeField]
		private RangeValueV2 m_vagInterval;

		// Token: 0x04001514 RID: 5396
		[SerializeField]
		private RangeValueV2 m_anusInterval;

		// Token: 0x04001515 RID: 5397
		[SerializeField]
		private RangeValueV2 m_bocaInterval;

		// Token: 0x04001516 RID: 5398
		[SerializeField]
		private float m_vagPenetration;

		// Token: 0x04001517 RID: 5399
		[SerializeField]
		private float m_anusPenetration;

		// Token: 0x04001518 RID: 5400
		[SerializeField]
		private float m_bocaPenetration;

		// Token: 0x04001519 RID: 5401
		private VagHole m_vag;

		// Token: 0x0400151A RID: 5402
		private AnusHole m_anus;

		// Token: 0x0400151B RID: 5403
		private BocaHole m_boca;

		// Token: 0x0400151C RID: 5404
		private VagFondoHitSkin m_vagFondo;

		// Token: 0x0400151D RID: 5405
		private AnusFondoHitSkin m_anusFondo;

		// Token: 0x0400151E RID: 5406
		private BocaFondoHitSkin m_bocaFondo;

		// Token: 0x0400151F RID: 5407
		private IFemaleSkins m_skins;
	}
}
