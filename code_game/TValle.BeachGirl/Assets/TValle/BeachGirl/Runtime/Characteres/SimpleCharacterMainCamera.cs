using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Characteres
{
	// Token: 0x020000B8 RID: 184
	[RequireComponent(typeof(SimpleCharacter))]
	[RequireComponent(typeof(Camera))]
	public class SimpleCharacterMainCamera : CustomMonobehaviour, CurrentMainChar.ICamera
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x00011E31 File Offset: 0x00010031
		public Camera camara
		{
			get
			{
				return this.m_Camera;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x00011E39 File Offset: 0x00010039
		public Transform cameraTransform
		{
			get
			{
				return this.m_Camera.transform;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x00011E46 File Offset: 0x00010046
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x00011E49 File Offset: 0x00010049
		public CurrentMainChar.AnchorMode anchorMode
		{
			get
			{
				return CurrentMainChar.AnchorMode.animatorRootMotion;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00011E50 File Offset: 0x00010050
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SimpleCharacter = base.GetComponent<Camera>();
			this.m_Camera = base.GetComponent<Camera>();
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00011E70 File Offset: 0x00010070
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<CurrentMainChar>.instance.SetCamera(this);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00011E83 File Offset: 0x00010083
		public void DejarDeForzarVista()
		{
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00011E85 File Offset: 0x00010085
		public void ForzarVista(Vector3 point)
		{
			base.transform.LookAt(point);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00011E93 File Offset: 0x00010093
		public void UpdateCamera()
		{
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00011E95 File Offset: 0x00010095
		public void Ver(Vector3 point)
		{
			base.transform.LookAt(point);
		}

		// Token: 0x0400039D RID: 925
		private Camera m_SimpleCharacter;

		// Token: 0x0400039E RID: 926
		private Camera m_Camera;
	}
}
