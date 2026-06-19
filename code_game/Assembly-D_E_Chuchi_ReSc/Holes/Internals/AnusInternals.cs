using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.Constraints.Anus;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Unity.Mathematics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals
{
	// Token: 0x0200019A RID: 410
	public class AnusInternals : HoleInternal, IAnusInternals, IHoleInternals
	{
		// Token: 0x060009B9 RID: 2489 RVA: 0x0002B076 File Offset: 0x00029276
		private void AwakeDesgaste()
		{
			this.m_desgastable = this.GetComponentEnRoot(false);
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0002B085 File Offset: 0x00029285
		private void UpdateDesgaste()
		{
			this.m_currentDesgaste = this.m_desgastable.anchura.current;
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0002B0A0 File Offset: 0x000292A0
		private float2 GetCanalDefaultScale(float defaultScaleX, float defaultScaleY, int index, int cantidad)
		{
			float num = Mathf.InverseLerp((float)cantidad, 1f, (float)(index + 1)).OutPow(this.desgasteConfig.power);
			float num2 = Mathf.Lerp(this.desgasteConfig.minScaleMod, this.desgasteConfig.maxScaleMod, num);
			float num3 = Mathf.Lerp(defaultScaleX, defaultScaleX * num2, this.m_currentDesgaste);
			float num4 = Mathf.Lerp(defaultScaleY, defaultScaleY * num2, this.m_currentDesgaste);
			return new float2(num3, num4);
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0002B114 File Offset: 0x00029314
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_AnusHoleInnerConstraintsAdder == null)
			{
				throw new ArgumentNullException("m_AnusHoleInnerConstraintsAdder", "m_AnusHoleInnerConstraintsAdder null reference.");
			}
			if (this.m_anusStartBone == null)
			{
				throw new ArgumentNullException("m_anusStartBone", "m_anusStartBone null reference.");
			}
			if (this.m_IntestinalTipRoot == null)
			{
				throw new ArgumentNullException("m_IntestinalTipRoot", "m_IntestinalTipRoot null reference.");
			}
			if (this.m_IntestinalTip == null)
			{
				throw new ArgumentNullException("m_IntestinalTip", "m_IntestinalTip null reference.");
			}
			this.AwakeDesgaste();
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void Starting()
		{
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0002B1A8 File Offset: 0x000293A8
		private void MountHole()
		{
			ArmatureSkins componentEnRoot = this.m_hole.owner.GetComponentEnRoot<ArmatureSkins>();
			HashSet<Transform> holeBonesSet = new HashSet<Transform>(this.m_holeRoot.GetComponentsInChildren<Transform>());
			Skin.CambiarBonesReferences(componentEnRoot, this.m_SkinnedMeshRenderer, (Transform t) => holeBonesSet.Contains(t));
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0002B1F8 File Offset: 0x000293F8
		protected override void Started()
		{
			this.MountHole();
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0002B200 File Offset: 0x00029400
		protected override void FixRotations()
		{
			base.FixRotations();
			this.ResetScales();
			this.UpdateIntestinalTip();
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0002B214 File Offset: 0x00029414
		private void UpdateIntestinalTip()
		{
			this.m_AllPuntosDicc[this.m_IntestinalTip].ForzeUpdatePositionByPenetrationTip(this.m_hole);
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0002B234 File Offset: 0x00029434
		private void ResetScales()
		{
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Anus_000, 2f, this.GetCanalDefaultScale(this.configScaleForAnus000.defaultScaleX, this.configScaleForAnus000.defaultScaleY, 0, 4));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Anus_001, 2f, this.GetCanalDefaultScale(this.configScaleForAnus001.defaultScaleX, this.configScaleForAnus001.defaultScaleY, 1, 4));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Anus_002, 2f, this.GetCanalDefaultScale(this.configScaleForAnus002.defaultScaleX, this.configScaleForAnus002.defaultScaleY, 2, 4));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Anus_003, 2f, this.GetCanalDefaultScale(this.configScaleForAnus003.defaultScaleX, this.configScaleForAnus003.defaultScaleY, 3, 4));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Rectus_000, 2f, new float2(this.configScaleForRectus000.defaultScaleX, this.configScaleForRectus000.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Rectus_001, 2f, new float2(this.configScaleForRectus001.defaultScaleX, this.configScaleForRectus001.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Rectus_002, 2f, new float2(this.configScaleForRectus002.defaultScaleX, this.configScaleForRectus002.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Rectus_003, 2f, new float2(this.configScaleForRectus003.defaultScaleX, this.configScaleForRectus003.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Rectus_004, 2f, new float2(this.configScaleForRectus.defaultScaleX, this.configScaleForRectus.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Rectus_005, 2f, new float2(this.configScaleForRectus.defaultScaleX, this.configScaleForRectus.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Rectus_006, 2f, new float2(this.configScaleForRectus.defaultScaleX, this.configScaleForRectus.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Rectus_007, 2f, new float2(this.configScaleForRectus.defaultScaleX, this.configScaleForRectus.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_000, 2f, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_001, 2f, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_002, 2f, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_003, 2f, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			HoleInternal.ResetScaleToStretchTo(this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_004, 2f, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0002B580 File Offset: 0x00029780
		protected override void AfterElasticLoops()
		{
			base.AfterElasticLoops();
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Anus_000, this.configScaleForAnus000, this.GetCanalDefaultScale(this.configScaleForAnus000.defaultScaleX, this.configScaleForAnus000.defaultScaleY, 0, 4));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Anus_001, this.configScaleForAnus001, this.GetCanalDefaultScale(this.configScaleForAnus001.defaultScaleX, this.configScaleForAnus001.defaultScaleY, 1, 4));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Anus_002, this.configScaleForAnus002, this.GetCanalDefaultScale(this.configScaleForAnus002.defaultScaleX, this.configScaleForAnus002.defaultScaleY, 2, 4));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Anus_003, this.configScaleForAnus003, this.GetCanalDefaultScale(this.configScaleForAnus003.defaultScaleX, this.configScaleForAnus003.defaultScaleY, 3, 4));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Rectus_000, this.configScaleForRectus000, new float2(this.configScaleForRectus000.defaultScaleX, this.configScaleForRectus000.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Rectus_001, this.configScaleForRectus001, new float2(this.configScaleForRectus001.defaultScaleX, this.configScaleForRectus001.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Rectus_002, this.configScaleForRectus002, new float2(this.configScaleForRectus002.defaultScaleX, this.configScaleForRectus002.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Rectus_003, this.configScaleForRectus003, new float2(this.configScaleForRectus003.defaultScaleX, this.configScaleForRectus003.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Rectus_004, this.configScaleForRectus, new float2(this.configScaleForRectus.defaultScaleX, this.configScaleForRectus.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Rectus_005, this.configScaleForRectus, new float2(this.configScaleForRectus.defaultScaleX, this.configScaleForRectus.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Rectus_006, this.configScaleForRectus, new float2(this.configScaleForRectus.defaultScaleX, this.configScaleForRectus.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Rectus_007, this.configScaleForRectus, new float2(this.configScaleForRectus.defaultScaleX, this.configScaleForRectus.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_000, this.configScaleForIntestinal, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_001, this.configScaleForIntestinal, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_002, this.configScaleForIntestinal, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_003, this.configScaleForIntestinal, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			HoleInternal.SetScaleToStretchTo(this, this.m_AnusHoleInnerConstraintsAdder.m_Intestinal_004, this.configScaleForIntestinal, new float2(this.configScaleForIntestinal.defaultScaleX, this.configScaleForIntestinal.defaultScaleY));
			this.UpdateDesgaste();
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0002B8F8 File Offset: 0x00029AF8
		protected override bool MaxAngleLateral1PointsOfRanges(out Vector3 worldStartPoint, out Vector3 worldEndPoint, out Vector3 worldNormal, out Vector3 worldConePoint, out float coneAngle, out float worldConeMaxRadius)
		{
			worldStartPoint = this.m_hole.entrada.position;
			worldEndPoint = this.m_hole.fondoPhysics.position;
			worldNormal = -this.m_hole.worldOutHoleDirection;
			worldConePoint = worldStartPoint + worldNormal * this.configLateral.point1Retroceso * this.m_hole.owner.escala;
			coneAngle = this.configLateral.maxAngle1;
			worldConeMaxRadius = Vector3.Distance(worldConePoint, worldEndPoint) * Mathf.Tan(coneAngle * 0.017453292f);
			worldStartPoint += worldNormal * this.m_hole.owner.escala * 0.001f;
			return true;
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0002B9ED File Offset: 0x00029BED
		protected override void MaxAngleLateralLastPointsOfRanges(out Vector3 worldStartPoint, out Vector3 worldEndPoint, out Vector3 worldNormal, out Vector3 worldConePoint, out float coneAngle, out float worldConeMaxRadius)
		{
			this.MaxAngleLateral1PointsOfRanges(out worldStartPoint, out worldEndPoint, out worldNormal, out worldConePoint, out coneAngle, out worldConeMaxRadius);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0002BA00 File Offset: 0x00029C00
		protected override void ProduceElasticPoints(List<HoleInternal.ElasticInternalPoint> puntos)
		{
			HoleInternal.ProduceSetionElasticPoints(puntos, null, this.m_anus, this.m_rectus, true);
			HoleInternal.ProduceSetionElasticPoints(puntos, this.m_anus, this.m_rectus, this.m_intestines, true);
			HoleInternal.ProduceSetionElasticPoints(puntos, this.m_rectus, this.m_intestines, null, true);
			puntos.First<HoleInternal.ElasticInternalPoint>().previus = this.m_anusStartBone;
			HoleInternal.ProduceSetionElasticPoints(puntos, null, this.m_overIntestines, null, false);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0002BA6E File Offset: 0x00029C6E
		protected override void ProducePoints(List<HoleInternal.InternalPoint> puntos)
		{
			HoleInternal.ProduceSetionPoints(puntos, this.m_intestinesTip);
		}

		// Token: 0x04000790 RID: 1936
		[Header("Anus")]
		[SerializeField]
		private AnusHoleInnerConstraintsAdder m_AnusHoleInnerConstraintsAdder;

		// Token: 0x04000791 RID: 1937
		public HoleInternal.ConfigLateral configLateral = new HoleInternal.ConfigLateral();

		// Token: 0x04000792 RID: 1938
		[Header("Puntos Elasticos")]
		[SerializeField]
		private HoleInternal.Seccion m_anus = new HoleInternal.Seccion();

		// Token: 0x04000793 RID: 1939
		[SerializeField]
		private HoleInternal.Seccion m_rectus = new HoleInternal.Seccion();

		// Token: 0x04000794 RID: 1940
		[SerializeField]
		private HoleInternal.Seccion m_intestines = new HoleInternal.Seccion();

		// Token: 0x04000795 RID: 1941
		[Header("Puntos")]
		[SerializeField]
		private HoleInternal.Seccion m_intestinesTip = new HoleInternal.Seccion();

		// Token: 0x04000796 RID: 1942
		[SerializeField]
		private HoleInternal.Seccion m_overIntestines = new HoleInternal.Seccion();

		// Token: 0x04000797 RID: 1943
		[SerializeField]
		private Transform m_anusStartBone;

		// Token: 0x04000798 RID: 1944
		[SerializeField]
		private Transform m_IntestinalTipRoot;

		// Token: 0x04000799 RID: 1945
		[SerializeField]
		private Transform m_IntestinalTip;

		// Token: 0x0400079A RID: 1946
		[Header("Anus Configs")]
		public float tipPositionByPenetrationOutPower = 1f;

		// Token: 0x0400079B RID: 1947
		public HoleInternal.ConfigScale configScaleForAnus000 = new HoleInternal.ConfigScale();

		// Token: 0x0400079C RID: 1948
		public HoleInternal.ConfigScale configScaleForAnus001 = new HoleInternal.ConfigScale();

		// Token: 0x0400079D RID: 1949
		public HoleInternal.ConfigScale configScaleForAnus002 = new HoleInternal.ConfigScale();

		// Token: 0x0400079E RID: 1950
		public HoleInternal.ConfigScale configScaleForAnus003 = new HoleInternal.ConfigScale();

		// Token: 0x0400079F RID: 1951
		public HoleInternal.ConfigScale configScaleForRectus000 = new HoleInternal.ConfigScale();

		// Token: 0x040007A0 RID: 1952
		public HoleInternal.ConfigScale configScaleForRectus001 = new HoleInternal.ConfigScale();

		// Token: 0x040007A1 RID: 1953
		public HoleInternal.ConfigScale configScaleForRectus002 = new HoleInternal.ConfigScale();

		// Token: 0x040007A2 RID: 1954
		public HoleInternal.ConfigScale configScaleForRectus003 = new HoleInternal.ConfigScale();

		// Token: 0x040007A3 RID: 1955
		public HoleInternal.ConfigScale configScaleForRectus = new HoleInternal.ConfigScale();

		// Token: 0x040007A4 RID: 1956
		public HoleInternal.ConfigScale configScaleForIntestinal = new HoleInternal.ConfigScale();

		// Token: 0x040007A5 RID: 1957
		private IAnusDesgastable m_desgastable;

		// Token: 0x040007A6 RID: 1958
		[Header("Desgaste")]
		public AnusInternals.DesgasteConfig desgasteConfig = new AnusInternals.DesgasteConfig();

		// Token: 0x040007A7 RID: 1959
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentDesgaste;

		// Token: 0x040007A8 RID: 1960
		[Header("Hole Mount")]
		[SerializeField]
		private Transform m_holeRoot;

		// Token: 0x0200019B RID: 411
		[Serializable]
		public class DesgasteConfig
		{
			// Token: 0x040007A9 RID: 1961
			public float power = 1f;

			// Token: 0x040007AA RID: 1962
			public float maxScaleMod = 6f;

			// Token: 0x040007AB RID: 1963
			public float minScaleMod = 4f;
		}
	}
}
