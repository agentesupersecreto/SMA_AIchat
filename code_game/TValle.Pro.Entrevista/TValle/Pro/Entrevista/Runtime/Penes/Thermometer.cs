using System;
using Assets.TValle.Pro.Entrevista.Runtime.Penes.Holes;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Penes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using TMPro;
using TValleCustomClases;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes
{
	// Token: 0x0200008A RID: 138
	public class Thermometer : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x00020F3A File Offset: 0x0001F13A
		public float currentDefaultRoomTemp
		{
			get
			{
				return Thermometer.m_currentDefaultRoomTemp.Value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x00020F46 File Offset: 0x0001F146
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00020F50 File Offset: 0x0001F150
		protected override void AwakeUnityEvent()
		{
			if (Thermometer.m_currentDefaultRoomTemp == null)
			{
				Thermometer.m_currentDefaultRoomTemp = new float?(20f.Random(0.1f));
			}
			this.m_currentTemp = this.currentDefaultRoomTemp;
			base.AwakeUnityEvent();
			this.m_self = base.GetComponent<GrabbableToy>();
			if (this.m_self == null)
			{
				throw new ArgumentNullException("m_self", "m_self null reference.");
			}
			if (this.m_tempText == null)
			{
				throw new ArgumentNullException("m_tempText", "m_tempText null reference.");
			}
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00020FDC File Offset: 0x0001F1DC
		public override void OnUpdateEvent1()
		{
			if (this.m_CoolDown.isOn || !this.m_self.isStared)
			{
				return;
			}
			this.m_CoolDown.ApplyNext(0.333f.Random(0.1f));
			BoneStretchedChain boneStretchedChain;
			float num;
			if (this.m_self.toy.IsPenetratingHole(out boneStretchedChain))
			{
				num = boneStretchedChain.GetComponentNotNull<HoleTemperature>().currentTemp;
			}
			else
			{
				num = this.currentDefaultRoomTemp;
			}
			this.m_currentTemp = Mathf.MoveTowards(this.m_currentTemp, num, 20f * Time.deltaTime.Random(0.333f));
			this.m_tempText.text = Mathf.Clamp(this.m_currentTemp, 0f, 99f).ToString("00.0");
		}

		// Token: 0x04000377 RID: 887
		public const float defaultRoomTemp = 20f;

		// Token: 0x04000378 RID: 888
		private static float? m_currentDefaultRoomTemp;

		// Token: 0x04000379 RID: 889
		private GrabbableToy m_self;

		// Token: 0x0400037A RID: 890
		[SerializeField]
		private TextMeshPro m_tempText;

		// Token: 0x0400037B RID: 891
		private float m_currentTemp;

		// Token: 0x0400037C RID: 892
		private CoolDown m_CoolDown = new CoolDown();
	}
}
