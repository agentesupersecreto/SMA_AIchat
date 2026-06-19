using System;
using Assets.Base.BeachGirl.Mapas.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.SystemasConstraints.RunTime.ChildOfConstraints.Implementation;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000090 RID: 144
	public sealed class LabiosSuckPose : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0000D55D File Offset: 0x0000B75D
		public ModificableDeFloat minValorModificable
		{
			get
			{
				return this.m_minValorModificable;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000D565 File Offset: 0x0000B765
		public ModificableDeFloat valorModificable
		{
			get
			{
				return this.m_valorModificable;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0000D56D File Offset: 0x0000B76D
		public float currentWeight
		{
			get
			{
				return this.m_currentWeight;
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000D578 File Offset: 0x0000B778
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			this.m_entrada = base.transform.FindDeepChild(instance.LabiosEntrada, true);
			this.m_in_Up = base.transform.FindDeepChild(instance.LabioInUp, true);
			this.m_in_Down = base.transform.FindDeepChild(instance.LabioInDown, true);
			this.m_in_Up_L = base.transform.FindDeepChild(instance.LabioInUp_L, true);
			this.m_in_Up_R = base.transform.FindDeepChild(instance.LabioInUp_R, true);
			this.m_in_Down_L = base.transform.FindDeepChild(instance.LabioInDown_L, true);
			this.m_in_Down_R = base.transform.FindDeepChild(instance.LabioInDown_R, true);
			this.m_in_L = base.transform.FindDeepChild(instance.LabioInSide_L, true);
			this.m_in_R = base.transform.FindDeepChild(instance.LabioInSide_R, true);
			Quaternion quaternion = Quaternion.Inverse(this.m_entrada.rotation);
			this.m_in_Up_initialRotation = quaternion * this.m_in_Up.rotation;
			this.m_in_Down_initialRotation = quaternion * this.m_in_Down.rotation;
			this.m_in_Up_L_initialRotation = quaternion * this.m_in_Up_L.rotation;
			this.m_in_Up_R_initialRotation = quaternion * this.m_in_Up_R.rotation;
			this.m_in_Down_L_initialRotation = quaternion * this.m_in_Down_L.rotation;
			this.m_in_Down_R_initialRotation = quaternion * this.m_in_Down_R.rotation;
			this.m_in_L_initialRotation = quaternion * this.m_in_L.rotation;
			this.m_in_R_initialRotation = quaternion * this.m_in_R.rotation;
			Singleton<SystemaMainChildOf>.instance.completedCalled += this.Instance_completedCalled;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000D748 File Offset: 0x0000B948
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Singleton<MapasDeHuesos>.instance.otros.MapaDeContraccionDeLabios.Normalize();
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000D764 File Offset: 0x0000B964
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (Singleton<SystemaMainChildOf>.IsInScene)
			{
				Singleton<SystemaMainChildOf>.instance.completedCalled -= this.Instance_completedCalled;
			}
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0000D78C File Offset: 0x0000B98C
		private void Instance_completedCalled(SystemaMainChildOf obj)
		{
			float num = this.m_minValorModificable.MaximoValorIncluyendo(this.m_weight);
			num = this.m_valorModificable.ModificarValor(num);
			num = Mathf.Clamp01(num);
			this.m_currentWeight = Mathf.MoveTowards(this.m_currentWeight, num, Time.deltaTime);
			if (this.m_currentWeight > 0f)
			{
				this.UpdatePoses();
				this.LoadPose();
			}
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000D7F0 File Offset: 0x0000B9F0
		public void UpdatePoses()
		{
			this.m_currentEntradaPose = default(Matrix4x4);
			Vector3 lossyScale = this.m_entrada.lossyScale;
			float num = lossyScale.Escala();
			this.m_currentEntradaPose.SetTRS(this.m_entrada.position + this.m_entrada.forward * (this.zOffset * num), this.m_entrada.rotation, lossyScale);
			MapaDeContraccionDeHole8 mapaDeContraccionDeLabios = Singleton<MapasDeHuesos>.instance.otros.MapaDeContraccionDeLabios;
			this.m_in_Up_posePosition = mapaDeContraccionDeLabios._12.direction.SetMagnitud(this.openning * mapaDeContraccionDeLabios._12.contraccionDistanceMod);
			this.m_in_Down_posePosition = mapaDeContraccionDeLabios._6.direction.SetMagnitud(this.openning * mapaDeContraccionDeLabios._6.contraccionDistanceMod);
			this.m_in_Up_L_posePosition = mapaDeContraccionDeLabios._1030.direction.SetMagnitud(this.openning * mapaDeContraccionDeLabios._1030.contraccionDistanceMod);
			this.m_in_Up_R_posePosition = mapaDeContraccionDeLabios._130.direction.SetMagnitud(this.openning * mapaDeContraccionDeLabios._130.contraccionDistanceMod);
			this.m_in_Down_L_posePosition = mapaDeContraccionDeLabios._730.direction.SetMagnitud(this.openning * mapaDeContraccionDeLabios._730.contraccionDistanceMod);
			this.m_in_Down_R_posePosition = mapaDeContraccionDeLabios._430.direction.SetMagnitud(this.openning * mapaDeContraccionDeLabios._430.contraccionDistanceMod);
			this.m_in_L_posePosition = mapaDeContraccionDeLabios._9.direction.SetMagnitud(this.openning * mapaDeContraccionDeLabios._9.contraccionDistanceMod);
			this.m_in_R_posePosition = mapaDeContraccionDeLabios._3.direction.SetMagnitud(this.openning * mapaDeContraccionDeLabios._3.contraccionDistanceMod);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000D9AC File Offset: 0x0000BBAC
		public void LoadPose()
		{
			this.m_in_Up.rotation = Quaternion.Lerp(this.m_in_Up.rotation, this.m_entrada.rotation * this.m_in_Up_initialRotation, this.m_currentWeight);
			this.m_in_Down.rotation = Quaternion.Lerp(this.m_in_Down.rotation, this.m_entrada.rotation * this.m_in_Down_initialRotation, this.m_currentWeight);
			this.m_in_Up_L.rotation = Quaternion.Lerp(this.m_in_Up_L.rotation, this.m_entrada.rotation * this.m_in_Up_L_initialRotation, this.m_currentWeight);
			this.m_in_Up_R.rotation = Quaternion.Lerp(this.m_in_Up_R.rotation, this.m_entrada.rotation * this.m_in_Up_R_initialRotation, this.m_currentWeight);
			this.m_in_Down_L.rotation = Quaternion.Lerp(this.m_in_Down_L.rotation, this.m_entrada.rotation * this.m_in_Down_L_initialRotation, this.m_currentWeight);
			this.m_in_Down_R.rotation = Quaternion.Lerp(this.m_in_Down_R.rotation, this.m_entrada.rotation * this.m_in_Down_R_initialRotation, this.m_currentWeight);
			this.m_in_L.rotation = Quaternion.Lerp(this.m_in_L.rotation, this.m_entrada.rotation * this.m_in_L_initialRotation, this.m_currentWeight);
			this.m_in_R.rotation = Quaternion.Lerp(this.m_in_R.rotation, this.m_entrada.rotation * this.m_in_R_initialRotation, this.m_currentWeight);
			this.m_in_Up.position = Vector3.Lerp(this.m_in_Up.position, this.m_currentEntradaPose.MultiplyPoint3x4(this.m_in_Up_posePosition), this.m_currentWeight);
			this.m_in_Down.position = Vector3.Lerp(this.m_in_Down.position, this.m_currentEntradaPose.MultiplyPoint3x4(this.m_in_Down_posePosition), this.m_currentWeight);
			this.m_in_Up_L.position = Vector3.Lerp(this.m_in_Up_L.position, this.m_currentEntradaPose.MultiplyPoint3x4(this.m_in_Up_L_posePosition), this.m_currentWeight);
			this.m_in_Up_R.position = Vector3.Lerp(this.m_in_Up_R.position, this.m_currentEntradaPose.MultiplyPoint3x4(this.m_in_Up_R_posePosition), this.m_currentWeight);
			this.m_in_Down_L.position = Vector3.Lerp(this.m_in_Down_L.position, this.m_currentEntradaPose.MultiplyPoint3x4(this.m_in_Down_L_posePosition), this.m_currentWeight);
			this.m_in_Down_R.position = Vector3.Lerp(this.m_in_Down_R.position, this.m_currentEntradaPose.MultiplyPoint3x4(this.m_in_Down_R_posePosition), this.m_currentWeight);
			this.m_in_L.position = Vector3.Lerp(this.m_in_L.position, this.m_currentEntradaPose.MultiplyPoint3x4(this.m_in_L_posePosition), this.m_currentWeight);
			this.m_in_R.position = Vector3.Lerp(this.m_in_R.position, this.m_currentEntradaPose.MultiplyPoint3x4(this.m_in_R_posePosition), this.m_currentWeight);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000DD01 File Offset: 0x0000BF01
		private void OnDrawGizmosSelected()
		{
		}

		// Token: 0x04000273 RID: 627
		[Obsolete("Reempalzado por check de physcis Boca.presionEstaAislada", true)]
		public const float thresholdToSuck = 0.333f;

		// Token: 0x04000274 RID: 628
		[SerializeField]
		private ModificableDeFloat m_minValorModificable = new ModificableDeFloat(0f);

		// Token: 0x04000275 RID: 629
		[SerializeField]
		private ModificableDeFloat m_valorModificable = new ModificableDeFloat(1f);

		// Token: 0x04000276 RID: 630
		[SerializeField]
		[Range(0f, 1f)]
		private float m_weight;

		// Token: 0x04000277 RID: 631
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentWeight;

		// Token: 0x04000278 RID: 632
		public float zOffset = 0.01f;

		// Token: 0x04000279 RID: 633
		[Range(0.005f, 0.025f)]
		public float openning = 0.008f;

		// Token: 0x0400027A RID: 634
		private Transform m_entrada;

		// Token: 0x0400027B RID: 635
		private Transform m_in_Up;

		// Token: 0x0400027C RID: 636
		private Transform m_in_Down;

		// Token: 0x0400027D RID: 637
		private Transform m_in_Up_L;

		// Token: 0x0400027E RID: 638
		private Transform m_in_Up_R;

		// Token: 0x0400027F RID: 639
		private Transform m_in_Down_L;

		// Token: 0x04000280 RID: 640
		private Transform m_in_Down_R;

		// Token: 0x04000281 RID: 641
		private Transform m_in_L;

		// Token: 0x04000282 RID: 642
		private Transform m_in_R;

		// Token: 0x04000283 RID: 643
		private Quaternion m_in_Up_initialRotation;

		// Token: 0x04000284 RID: 644
		private Quaternion m_in_Down_initialRotation;

		// Token: 0x04000285 RID: 645
		private Quaternion m_in_Up_L_initialRotation;

		// Token: 0x04000286 RID: 646
		private Quaternion m_in_Up_R_initialRotation;

		// Token: 0x04000287 RID: 647
		private Quaternion m_in_Down_L_initialRotation;

		// Token: 0x04000288 RID: 648
		private Quaternion m_in_Down_R_initialRotation;

		// Token: 0x04000289 RID: 649
		private Quaternion m_in_L_initialRotation;

		// Token: 0x0400028A RID: 650
		private Quaternion m_in_R_initialRotation;

		// Token: 0x0400028B RID: 651
		private Vector3 m_in_Up_posePosition;

		// Token: 0x0400028C RID: 652
		private Vector3 m_in_Down_posePosition;

		// Token: 0x0400028D RID: 653
		private Vector3 m_in_Up_L_posePosition;

		// Token: 0x0400028E RID: 654
		private Vector3 m_in_Up_R_posePosition;

		// Token: 0x0400028F RID: 655
		private Vector3 m_in_Down_L_posePosition;

		// Token: 0x04000290 RID: 656
		private Vector3 m_in_Down_R_posePosition;

		// Token: 0x04000291 RID: 657
		private Vector3 m_in_L_posePosition;

		// Token: 0x04000292 RID: 658
		private Vector3 m_in_R_posePosition;

		// Token: 0x04000293 RID: 659
		private Matrix4x4 m_currentEntradaPose;
	}
}
