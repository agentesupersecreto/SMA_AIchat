using System;
using System.Collections;
using Assets.Base.BeachGirl.Mapas.Runtime;
using Assets.TValle.BeachGirl.Runtime.Guias;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa.Glases
{
	// Token: 0x02000148 RID: 328
	public sealed class GlasesSkin : PiezaDeRopaBase
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x0002285D File Offset: 0x00020A5D
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterAnimationConstraints);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x00022866 File Offset: 0x00020A66
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdateAfterCameraController);
			}
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0002286F File Offset: 0x00020A6F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_helper = this.GetComponentEnRoot(false);
			if (this.m_helper == null)
			{
				throw new ArgumentNullException("m_helper", "m_helper null reference.");
			}
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x000228A4 File Offset: 0x00020AA4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			MapaSingletonDeGlasesBones instance = MapaSingleton<MapaSingletonDeGlasesBones>.instance;
			this.bones.head = base.transform.FindDeepChild(instance.head, true);
			this.bones.frente = base.transform.FindDeepChild(instance.frente, true);
			this.bones.temporal_L = base.transform.FindDeepChild(instance.temporal_L, true);
			this.bones.temporal_R = base.transform.FindDeepChild(instance.temporal_R, true);
			this.bones.ear_L = base.transform.FindDeepChild(instance.ear_L, true);
			this.bones.ear_R = base.transform.FindDeepChild(instance.ear_R, true);
			this.bones.nose_L = base.transform.FindDeepChild(instance.nose_L, true);
			this.bones.nose_R = base.transform.FindDeepChild(instance.nose_R, true);
			this.bones.back_def_L = base.transform.FindDeepChild(instance.back_def_L, true);
			this.bones.back_def_R = base.transform.FindDeepChild(instance.back_def_R, true);
			this.bones.temporal_def_L = base.transform.FindDeepChild(instance.temporal_def_L, true);
			this.bones.temporal_def_R = base.transform.FindDeepChild(instance.temporal_def_R, true);
			this.bones.front_def_Center = base.transform.FindDeepChild(instance.front_def_Center, true);
			this.bones.front_def_L = base.transform.FindDeepChild(instance.front_def_L, true);
			this.bones.front_def_R = base.transform.FindDeepChild(instance.front_def_R, true);
			this.bones.eye_def_L = base.transform.FindDeepChild(instance.eye_def_L, true);
			this.bones.eye_def_R = base.transform.FindDeepChild(instance.eye_def_R, true);
			this.bones.nose_def_L = base.transform.FindDeepChild(instance.nose_def_L, true);
			this.bones.nose_def_R = base.transform.FindDeepChild(instance.nose_def_R, true);
			this.m_initialBackBoneLocalRotationL = this.bones.back_def_L.localRotation;
			this.m_initialBackBoneLocalRotationR = this.bones.back_def_R.localRotation;
			this.m_frenteDefaultLocalPositionDesdeHead = this.bones.head.InverseTransformPoint(this.bones.frente.position);
			this.m_temportalDefaultLocalPositionDesdeFrenteL = this.bones.frente.InverseTransformPoint(this.bones.temporal_L.position);
			this.m_temportalDefaultLocalPositionDesdeFrenteR = this.bones.frente.InverseTransformPoint(this.bones.temporal_R.position);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00022B84 File Offset: 0x00020D84
		protected override Transform ObtenerBoneTargetParaSubSkin<T>(MapaDeRopa.RopaData.SkinCollider.TipoDeMontura tipoDeMontura, T subSkin)
		{
			Transform transform;
			if (tipoDeMontura == MapaDeRopa.RopaData.SkinCollider.TipoDeMontura.skinSkeleton)
			{
				transform = this.m_helper.head;
			}
			else
			{
				transform = base.owner.rootBone;
			}
			return transform;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00022BB0 File Offset: 0x00020DB0
		public override void OnUpdateEvent1()
		{
			this.bones.head.SetPositionAndRotation(this.m_helper.head.position, this.m_helper.head.rotation);
			this.bones.head.localScale = this.m_helper.head.lossyScale;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00022C10 File Offset: 0x00020E10
		public override void OnUpdateEvent2()
		{
			this.bones.head.SetPositionAndRotation(this.m_helper.head.position, this.m_helper.head.rotation);
			this.bones.head.localScale = this.m_helper.head.lossyScale;
			this.bones.frente.position = this.bones.head.TransformPoint(this.m_frenteDefaultLocalPositionDesdeHead);
			this.bones.frente.localScale = Vector3.one;
			this.bones.temporal_L.rotation = this.m_helper.guias.temporalL.rotation;
			this.bones.temporal_R.rotation = this.m_helper.guias.temporalR.rotation;
			Vector3 vector = Math3d.ProjectPointOnPlane(this.m_helper.guias.temporalL.forward, this.m_helper.guias.temporalL.position, this.bones.frente.TransformPoint(this.m_temportalDefaultLocalPositionDesdeFrenteL));
			this.bones.temporal_L.position = vector;
			this.bones.temporal_L.position = this.bones.temporal_L.TransformPoint(new Vector3(0f, 0f, this.offsetLocalDeTemporal));
			Vector3 vector2 = Math3d.ProjectPointOnPlane(this.m_helper.guias.temporalR.forward, this.m_helper.guias.temporalR.position, this.bones.frente.TransformPoint(this.m_temportalDefaultLocalPositionDesdeFrenteR));
			this.bones.temporal_R.position = vector2;
			this.bones.temporal_R.position = this.bones.temporal_R.TransformPoint(new Vector3(0f, 0f, this.offsetLocalDeTemporal));
			this.bones.ear_L.SetPositionAndRotation(this.m_helper.guias.orejaL.TransformPoint(new Vector3(0f, 0f, this.offsetLocalDeOrejas)), this.m_helper.guias.orejaL.rotation);
			this.bones.ear_R.SetPositionAndRotation(this.m_helper.guias.orejaR.TransformPoint(new Vector3(0f, 0f, this.offsetLocalDeOrejas)), this.m_helper.guias.orejaR.rotation);
			Vector3 vector3 = Math3d.ProjectPointOnPlane(this.m_helper.guias.front1.forward, this.m_helper.guias.front1.position, this.bones.frente.position);
			vector3 = Math3d.ProjectPointOnPlane(this.m_helper.guias.front2.forward, this.m_helper.guias.front2.position, vector3);
			vector3 = Math3d.ProjectPointOnPlane(this.m_helper.guias.front3.forward, this.m_helper.guias.front3.position, vector3);
			for (int i = 0; i < 4; i++)
			{
				if (Vector3.Dot((vector3 - this.m_helper.guias.front1.position).normalized, this.m_helper.guias.front1.forward) <= 0f)
				{
					vector3 = Math3d.ProjectPointOnPlane(this.m_helper.guias.front1.forward, this.m_helper.guias.front1.position, vector3);
				}
				if (Vector3.Dot((vector3 - this.m_helper.guias.front2.position).normalized, this.m_helper.guias.front2.forward) <= 0f)
				{
					vector3 = Math3d.ProjectPointOnPlane(this.m_helper.guias.front2.forward, this.m_helper.guias.front2.position, vector3);
				}
				if (Vector3.Dot((vector3 - this.m_helper.guias.front3.position).normalized, this.m_helper.guias.front3.forward) <= 0f)
				{
					vector3 = Math3d.ProjectPointOnPlane(this.m_helper.guias.front3.forward, this.m_helper.guias.front3.position, vector3);
				}
			}
			this.bones.frente.position = this.bones.frente.TransformPoint(this.bones.frente.InverseTransformPoint(vector3) + new Vector3(0f, 0f, this.offsetLocalDeFrente));
			this.bones.nose_L.SetPositionAndRotation(this.m_helper.guias.noseL.TransformPoint(new Vector3(0f, 0f, this.offsetLocalDeNose)), this.m_helper.guias.noseL.rotation);
			this.bones.nose_R.SetPositionAndRotation(this.m_helper.guias.noseR.TransformPoint(new Vector3(0f, 0f, this.offsetLocalDeNose)), this.m_helper.guias.noseR.rotation);
			Quaternion quaternion = Math3d.DampedTrackRotation(this.bones.back_def_L, this.bones.temporal_def_L, this.m_initialBackBoneLocalRotationL, Vector3.forward, false);
			Quaternion quaternion2 = Math3d.DampedTrackRotation(this.bones.back_def_R, this.bones.temporal_def_R, this.m_initialBackBoneLocalRotationR, Vector3.forward, false);
			this.bones.back_def_L.rotation = quaternion;
			this.bones.back_def_R.rotation = quaternion2;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0002321F File Offset: 0x0002141F
		protected override IEnumerator OnSkinCollidersLoaded()
		{
			yield return base.OnSkinCollidersLoaded();
			for (int i = 0; i < this.m_subSkins.Count; i++)
			{
				Skin skin = this.m_subSkins[i];
				if (skin is HitSkinBasica)
				{
					skin.GetComponentNotNull<VisualmenteTransparenteHitSkin>();
				}
			}
			yield break;
		}

		// Token: 0x040005D9 RID: 1497
		public GlasesSkin.Bones bones = new GlasesSkin.Bones();

		// Token: 0x040005DA RID: 1498
		private GuiasParaGlasesHelper m_helper;

		// Token: 0x040005DB RID: 1499
		private Quaternion m_initialBackBoneLocalRotationL;

		// Token: 0x040005DC RID: 1500
		private Quaternion m_initialBackBoneLocalRotationR;

		// Token: 0x040005DD RID: 1501
		private Vector3 m_frenteDefaultLocalPositionDesdeHead;

		// Token: 0x040005DE RID: 1502
		private Vector3 m_temportalDefaultLocalPositionDesdeFrenteL;

		// Token: 0x040005DF RID: 1503
		private Vector3 m_temportalDefaultLocalPositionDesdeFrenteR;

		// Token: 0x040005E0 RID: 1504
		public float offsetLocalDeTemporal = 0.0012f;

		// Token: 0x040005E1 RID: 1505
		public float offsetLocalDeOrejas = 0.00025f;

		// Token: 0x040005E2 RID: 1506
		public float offsetLocalDeFrente = 0.00075f;

		// Token: 0x040005E3 RID: 1507
		public float offsetLocalDeNose = 0.00075f;

		// Token: 0x02000149 RID: 329
		[Serializable]
		public class Bones
		{
			// Token: 0x040005E4 RID: 1508
			public Transform head;

			// Token: 0x040005E5 RID: 1509
			public Transform frente;

			// Token: 0x040005E6 RID: 1510
			public Transform ear_L;

			// Token: 0x040005E7 RID: 1511
			public Transform ear_R;

			// Token: 0x040005E8 RID: 1512
			public Transform temporal_L;

			// Token: 0x040005E9 RID: 1513
			public Transform temporal_R;

			// Token: 0x040005EA RID: 1514
			public Transform nose_L;

			// Token: 0x040005EB RID: 1515
			public Transform nose_R;

			// Token: 0x040005EC RID: 1516
			public Transform back_def_L;

			// Token: 0x040005ED RID: 1517
			public Transform back_def_R;

			// Token: 0x040005EE RID: 1518
			public Transform temporal_def_L;

			// Token: 0x040005EF RID: 1519
			public Transform temporal_def_R;

			// Token: 0x040005F0 RID: 1520
			public Transform front_def_Center;

			// Token: 0x040005F1 RID: 1521
			public Transform front_def_L;

			// Token: 0x040005F2 RID: 1522
			public Transform front_def_R;

			// Token: 0x040005F3 RID: 1523
			public Transform eye_def_L;

			// Token: 0x040005F4 RID: 1524
			public Transform eye_def_R;

			// Token: 0x040005F5 RID: 1525
			public Transform nose_def_L;

			// Token: 0x040005F6 RID: 1526
			public Transform nose_def_R;
		}
	}
}
