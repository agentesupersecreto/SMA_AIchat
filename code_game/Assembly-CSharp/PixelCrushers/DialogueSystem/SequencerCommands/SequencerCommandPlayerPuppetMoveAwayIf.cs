using System;
using Assets;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii;
using TValleCustomClases;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000024 RID: 36
	public class SequencerCommandPlayerPuppetMoveAwayIf : SequencerCommand
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x00008004 File Offset: 0x00006204
		public void Start()
		{
			try
			{
				IPuppetChar puppetChar;
				IPuppetChar puppetChar2;
				if (base.GetParameterAsBool(3, false))
				{
					puppetChar = base.Sequencer.Speaker.GetComponentEnRoot(false);
					puppetChar2 = base.Sequencer.Listener.GetComponentEnRoot(false);
				}
				else
				{
					puppetChar = base.Sequencer.Listener.GetComponentEnRoot(false);
					puppetChar2 = base.Sequencer.Speaker.GetComponentEnRoot(false);
				}
				if (puppetChar == null)
				{
					throw new ArgumentNullException("player", "player null reference.");
				}
				if (puppetChar2 == null)
				{
					throw new ArgumentNullException("other", "other null reference.");
				}
				MotionAndActorControllerActivable componentInChildren = puppetChar.self.GetComponentInChildren<MotionAndActorControllerActivable>();
				if (componentInChildren == null)
				{
					throw new ArgumentNullException("motionAndActorControllerActivable", "motionAndActorControllerActivable null reference.");
				}
				IInteraccionesDeCharacter componentInChildren2 = puppetChar.self.GetComponentInChildren<IInteraccionesDeCharacter>();
				if (componentInChildren2 == null)
				{
					throw new ArgumentNullException("interaccionesDePlayer", "interaccionesDePlayer null reference.");
				}
				if (componentInChildren2.ObtenerFirstEjecutandosePrimaria() != null)
				{
					base.Stop();
				}
				else
				{
					this.m_MotionAndActorForzados = componentInChildren.estanForzadamenteActivosModificable.ObtenerModificadorNotNull(this);
					this.m_MotionAndActorForzados.valor.valor = true;
					Vector3 position = puppetChar2.musculos.hips.rigidbody.transform.position;
					Vector3 position2 = puppetChar.musculos.hips.rigidbody.transform.position;
					Quaternion rotacion = puppetChar.self.rotacion;
					Vector3 vector = rotacion * Vector3.up;
					Vector3 vector2 = position - position2;
					Vector3 vector3 = Math3d.ProjectVectorOnPlane(vector, vector2);
					Vector3 vector4 = Math3d.InverseTransformDirectionMath(rotacion, vector3);
					Vector2 normalized = new Vector2(vector4.x, vector4.z).normalized;
					IEmulableMovementInputs emulables = Singleton<PlayerInputProxy>.instance.emulables;
					float num = Mathf.InverseLerp(base.GetParameterAsFloat(0, 9999f), 0f, vector3.magnitude).OutPow(2f);
					float parameterAsFloat = base.GetParameterAsFloat(2, 1f);
					float parameterAsFloat2 = base.GetParameterAsFloat(1, 1f);
					bool parameterAsBool = base.GetParameterAsBool(4, false);
					this.m_puedeMoverseTimer.ApplyNext(parameterAsFloat2);
					this.m_EmulateAxisTimer.ApplyNext(Mathf.Clamp(parameterAsFloat2 - 0.75f, parameterAsFloat2 * 0.5f, parameterAsFloat2));
					this.m_goFaster = emulables.isGoingFaster.ObtenerModificadorNotNull(this);
					this.m_xAxis = emulables.xValorPromedio.ObtenerModificadorNotNull(this);
					this.m_yAxis = emulables.zValorPromedio.ObtenerModificadorNotNull(this);
					this.m_goFaster.valor.valor = parameterAsBool;
					this.m_xAxis.valor.valor = -normalized.x * num * parameterAsFloat;
					this.m_yAxis.valor.valor = -normalized.y * num * parameterAsFloat;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				base.Stop();
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000082C8 File Offset: 0x000064C8
		public void Update()
		{
			if (!this.m_puedeMoverseTimer.isOn)
			{
				this.m_MotionAndActorForzados.valor.valor = false;
			}
			if (!this.m_EmulateAxisTimer.isOn)
			{
				this.m_goFaster.valor.valor = false;
				this.m_xAxis.valor.valor = 0f;
				this.m_yAxis.valor.valor = 0f;
			}
			if (!this.m_puedeMoverseTimer.isOn && !this.m_EmulateAxisTimer.isOn)
			{
				base.Stop();
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000835C File Offset: 0x0000655C
		public void OnDestroy()
		{
			ModificadorDeBool goFaster = this.m_goFaster;
			if (goFaster != null)
			{
				goFaster.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat xAxis = this.m_xAxis;
			if (xAxis != null)
			{
				xAxis.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat yAxis = this.m_yAxis;
			if (yAxis != null)
			{
				yAxis.TryRemoverDeOwner(true);
			}
			ModificadorDeBool motionAndActorForzados = this.m_MotionAndActorForzados;
			if (motionAndActorForzados == null)
			{
				return;
			}
			motionAndActorForzados.TryRemoverDeOwner(true);
		}

		// Token: 0x0400008D RID: 141
		private CoolDown m_puedeMoverseTimer = new CoolDown();

		// Token: 0x0400008E RID: 142
		private CoolDown m_EmulateAxisTimer = new CoolDown();

		// Token: 0x0400008F RID: 143
		private ModificadorDeBool m_goFaster;

		// Token: 0x04000090 RID: 144
		private ModificadorDeFloat m_xAxis;

		// Token: 0x04000091 RID: 145
		private ModificadorDeFloat m_yAxis;

		// Token: 0x04000092 RID: 146
		private ModificadorDeBool m_MotionAndActorForzados;
	}
}
