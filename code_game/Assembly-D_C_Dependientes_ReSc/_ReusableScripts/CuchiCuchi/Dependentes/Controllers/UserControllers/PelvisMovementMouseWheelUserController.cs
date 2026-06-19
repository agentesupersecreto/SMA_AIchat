using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Clases;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.UserControllers
{
	// Token: 0x020001B3 RID: 435
	[RequireComponent(typeof(PelvisMovementController))]
	public sealed class PelvisMovementMouseWheelUserController : UserController
	{
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000A6D RID: 2669 RVA: 0x0003400C File Offset: 0x0003220C
		[Obsolete("usar controller.ismovingpelvis", true)]
		public bool isMoving
		{
			get
			{
				return this.m_smoothedAxis != 0f;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000A6E RID: 2670 RVA: 0x0003401E File Offset: 0x0003221E
		public override int updateEvent1Index
		{
			get
			{
				return (int)this.m_updateEvent;
			}
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00034026 File Offset: 0x00032226
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_controller = base.GetComponent<PelvisMovementController>();
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x0003403C File Offset: 0x0003223C
		public override void OnUpdateEvent1()
		{
			if (Singleton<ConfiguracionGeneralDeInputs>.instance.isCursorOverUIElement)
			{
				return;
			}
			if (!this.controlProfundidadActivado && !this.controlVerticalActivado)
			{
				return;
			}
			InputProxyVirtuales characterMovement = Singleton<PlayerInputProxy>.instance.characterMovement;
			this.m_currentAxis = characterMovement.wheelAxis;
			bool goingFaster = characterMovement.goingFaster;
			bool goingSlower = characterMovement.goingSlower;
			AnimatorCharacter character = this.m_controller.character;
			float valueOrDefault = ((character != null) ? new float?(character.escala) : null).GetValueOrDefault(base.transform.localScale.Escala());
			float num = (goingFaster ? 2f : 1f) * (goingSlower ? 0.5f : 1f);
			this.m_smoothedAxis = Mathf.Lerp(this.m_smoothedAxis, this.m_currentAxis, Time.deltaTime / this.m_timeSmooth * num * valueOrDefault);
			bool crouchDown = characterMovement.crouchDown;
			bool riseUp = characterMovement.riseUp;
			if (Mathf.Approximately(this.m_smoothedAxis, 0f))
			{
				this.m_smoothedAxis = 0f;
			}
			if (!crouchDown && !riseUp && this.m_smoothedAxis == 0f)
			{
				return;
			}
			bool goingDown = characterMovement.goingDown;
			float num2 = this.modificadorDeSensivilidad;
			if (crouchDown || riseUp)
			{
				float num3 = (float)(crouchDown ? 1 : (riseUp ? (-1) : 0)) * this.digitalSensibility * num2 * (goingFaster ? this.modificadorPorRunning : 1f) * (goingSlower ? this.modificadorPorWalking : 1f);
				if (this.controlVerticalActivado && num3 != 0f)
				{
					this.m_controller.AddVerticalDelta(num3 * -1f);
				}
			}
			if (this.m_smoothedAxis != 0f)
			{
				float num4 = Singleton<ConfiguracionGeneralDeInputs>.instance.deepMovement.Obtener(this.m_smoothedAxis);
				float num5 = this.m_smoothedAxis * num4 * num2 * (goingFaster ? this.modificadorPorRunning : 1f) * (goingSlower ? this.modificadorPorWalking : 1f);
				if (!goingDown)
				{
					if (this.controlProfundidadActivado)
					{
						this.m_controller.AddProfundidadDelta(num5);
					}
				}
				else if (this.controlVerticalActivado)
				{
					this.m_controller.AddVerticalDelta(num5 * -1f);
				}
				if (this.debugUserInputs)
				{
					base.PrintInput(num5);
				}
			}
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00034272 File Offset: 0x00032472
		protected override void OnAplicar()
		{
			base.OnAplicar();
			base.ReSubscribeToGlobalUpdater();
		}

		// Token: 0x040007DF RID: 2015
		[SerializeField]
		private GlobalUpdater.UpdateType m_updateEvent = GlobalUpdater.UpdateType.update2;

		// Token: 0x040007E0 RID: 2016
		public bool controlVerticalActivado = true;

		// Token: 0x040007E1 RID: 2017
		public bool controlProfundidadActivado = true;

		// Token: 0x040007E2 RID: 2018
		[Range(0f, 20f)]
		public float modificadorDeSensivilidad = 0.33f;

		// Token: 0x040007E3 RID: 2019
		public float digitalSensibility = 0.05f;

		// Token: 0x040007E4 RID: 2020
		[Range(0f, 1f)]
		public float modificadorPorWalking = 0.4444f;

		// Token: 0x040007E5 RID: 2021
		[Range(1f, 10f)]
		public float modificadorPorRunning = 2.25f;

		// Token: 0x040007E6 RID: 2022
		private PelvisMovementController m_controller;

		// Token: 0x040007E7 RID: 2023
		[Obsolete("", true)]
		private float m_smoothWeight = 0.333f;

		// Token: 0x040007E8 RID: 2024
		[Obsolete("", true)]
		private float m_currentSmooth;

		// Token: 0x040007E9 RID: 2025
		[SerializeField]
		private float m_timeSmooth = 0.05f;

		// Token: 0x040007EA RID: 2026
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentAxis;

		// Token: 0x040007EB RID: 2027
		[SerializeField]
		[ReadOnlyUI]
		private float m_smoothedAxis;
	}
}
