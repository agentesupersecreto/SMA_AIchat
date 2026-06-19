using System;
using System.Linq;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Estimulos;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Controlladores;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x0200036B RID: 875
	public class ReactorSuckPenePartePorTocar : ReactorACalculoDeEstimulo<ICalculoDeEstimuloTactil>
	{
		// Token: 0x060015CE RID: 5582 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x060015CF RID: 5583 RVA: 0x000677B0 File Offset: 0x000659B0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
			this.m_isValidToSuck = new Func<bool>(this.IsValidToSuck);
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
			this.m_conversador = this.GetComponentEnRoot(false);
			if (this.m_conversador == null)
			{
				throw new ArgumentNullException("m_conversador", "m_IBocaHole null reference.");
			}
			this.m_hablador = this.GetComponentEnRoot(false);
			if (this.m_hablador == null)
			{
				throw new ArgumentNullException("m_hablador", "m_IBocaHole null reference.");
			}
			this.m_ICharacter = this.GetComponentEnRoot(false);
			if (this.m_ICharacter == null)
			{
				throw new ArgumentNullException("m_ICharacter", "m_ICharacter null reference.");
			}
			this.m_characterGestuable = this.GetComponentEnRoot(false);
			if (this.m_characterGestuable == null)
			{
				throw new ArgumentNullException("m_characterGestuable", "m_characterGestuable null reference.");
			}
			this.m_ControlladorDeToChainPointJoints = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeToChainPointJoints == null)
			{
				throw new ArgumentNullException("m_ControlladorDeToChainPointJoints", "m_ControlladorDeToChainPointJoints null reference.");
			}
			this.m_ControlladorDeSuckPose = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeSuckPose == null)
			{
				throw new ArgumentNullException("m_ControlladorDeSuckPose", "m_ControlladorDeSuckPose null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_TouchesByMainInFrame = this.GetComponentEnRoot(false);
			if (this.m_TouchesByMainInFrame == null)
			{
				throw new ArgumentNullException("m_TouchesByMainInFrame", "m_TouchesByMainInFrame null reference.");
			}
			OralPosibilidadScore[] componentsInParent = base.GetComponentsInParent<OralPosibilidadScore>();
			this.m_paraPene = componentsInParent.First((OralPosibilidadScore c) => c.paraParte == ParteQuePuedeEstimular.pene);
			this.m_paraDedo = componentsInParent.First((OralPosibilidadScore c) => c.paraParte == ParteQuePuedeEstimular.dedo);
		}

		// Token: 0x060015D0 RID: 5584 RVA: 0x000679C4 File Offset: 0x00065BC4
		protected override bool CalculoEsValido(ICalculoDeEstimuloTactil calculo)
		{
			return calculo.estimuloBasico.tipo == DireccionDeEstimulo.recibida && !this.m_IBocaHole.isPenetrated && this.m_characterGestuable.estadoDeBocaPorUser != CharacterEstadoDeBoca.sellada && (calculo.estimuloBasico.ContineParte(ParteDelCuerpoHumano.labios) || calculo.estimuloBasico.ContineParte(ParteDelCuerpoHumano.bocaInterno)) && calculo.estimulanteParte.EsPenetrador() && calculo.estimuloBasico.estimulante is TocanteObjeto;
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x00067A40 File Offset: 0x00065C40
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			if (this.m_IBocaHole.isPenetrated != this.m_wasPenetrated)
			{
				this.m_wasPenetrated = this.m_IBocaHole.isPenetrated;
				return 0f;
			}
			return 1f;
		}

		// Token: 0x060015D2 RID: 5586 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x00067A74 File Offset: 0x00065C74
		private bool IsValidToSuck()
		{
			if (this.m_IBocaHole.isPenetrated)
			{
				return false;
			}
			if (this.m_hablador.estaHablando)
			{
				return false;
			}
			if (this.m_conversador.estaConversando)
			{
				return false;
			}
			DictionaryDeEstimulosTactiles frameTouchesConPrioridad = this.m_TouchesByMainInFrame.frameTouchesConPrioridad;
			ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> valueTuple;
			frameTouchesConPrioridad.TryGetValue(DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, out valueTuple);
			ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> valueTuple2;
			frameTouchesConPrioridad.TryGetValue(DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.dedo, out valueTuple2);
			ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> valueTuple3;
			frameTouchesConPrioridad.TryGetValue(DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.propSexToy, out valueTuple3);
			EstimuloTactil item = valueTuple.Item1;
			if (!((item != null) ? new bool?(item.ContineParte(ParteDelCuerpoHumano.labios)) : null).GetValueOrDefault())
			{
				EstimuloTactil item2 = valueTuple.Item1;
				if (!((item2 != null) ? new bool?(item2.ContineParte(ParteDelCuerpoHumano.bocaInterno)) : null).GetValueOrDefault())
				{
					EstimuloTactil item3 = valueTuple2.Item1;
					if (!((item3 != null) ? new bool?(item3.ContineParte(ParteDelCuerpoHumano.labios)) : null).GetValueOrDefault())
					{
						EstimuloTactil item4 = valueTuple2.Item1;
						if (!((item4 != null) ? new bool?(item4.ContineParte(ParteDelCuerpoHumano.bocaInterno)) : null).GetValueOrDefault())
						{
							EstimuloTactil item5 = valueTuple3.Item1;
							if (!((item5 != null) ? new bool?(item5.ContineParte(ParteDelCuerpoHumano.labios)) : null).GetValueOrDefault())
							{
								EstimuloTactil item6 = valueTuple3.Item1;
								return ((item6 != null) ? new bool?(item6.ContineParte(ParteDelCuerpoHumano.bocaInterno)) : null).GetValueOrDefault();
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x060015D4 RID: 5588 RVA: 0x00067BE4 File Offset: 0x00065DE4
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloTactil calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			PenisPart penisPart;
			calculo.estimulo.estimulante.TryGetComponent<PenisPart>(out penisPart);
			Penetrador penetrador = ((penisPart != null) ? penisPart.penis : null);
			if (penetrador == null)
			{
				return false;
			}
			IPeneConPartes peneConPartes;
			int num;
			AutoSexPosibilidadScore.Resultados resultados;
			if (maleChar.ObjetoEsMiPene(penetrador))
			{
				peneConPartes = penetrador;
				this.m_paraPene.DoUpdate(peneConPartes, calculo, this.prioridadParaConstroller, out num);
				resultados = this.m_paraPene.resultados;
			}
			else if (maleChar.ObjetoEsMiDedo(penetrador))
			{
				peneConPartes = penetrador;
				this.m_paraDedo.DoUpdate(peneConPartes, calculo, this.prioridadParaConstroller, out num);
				resultados = this.m_paraDedo.resultados;
			}
			else
			{
				if (maleChar.ObjetoEsProp(penetrador.transform))
				{
					Debug.LogException(new NotImplementedException(), this);
					return false;
				}
				return false;
			}
			bool flag = this.m_ConsentForzado.EsCorrupted(calculo);
			bool penetracionEsConsentida = resultados.penetracionEsConsentida;
			float num2 = ((flag && !penetracionEsConsentida) ? resultados.scoreByDesires : resultados.scoreV2);
			float num3 = Mathf.InverseLerp(resultados.thresholds.scoreParaAsistencia, resultados.thresholds.scoreParaConstantAsistencia, num2);
			float num4 = Mathf.Lerp(0f, this.maxSuckWeight, num3);
			if (num4 <= 0f)
			{
				return false;
			}
			if (!penetracionEsConsentida && !flag)
			{
				return false;
			}
			int num5 = ((resultados.indexDeParte < 0) ? (peneConPartes.countDePartes - 1) : resultados.indexDeParte);
			float num6 = this.duracion.Random(0.2f);
			Rigidbody physicBone = peneConPartes.partesEnOrden[num5].physicBone;
			float num7 = Vector3.Distance(this.m_IBocaHole.rootParaNoPenetracionSuckJoints.position, physicBone.position);
			float num8 = Mathf.Max(peneConPartes.worldTipPartLength, peneConPartes.worldTipPartWidth);
			if (num7 >= num8)
			{
				return false;
			}
			float num9 = Mathf.Clamp(num7 * 2f, 0.001f, num8);
			ControlladorDeSuccion.JointData jointData = ControlladorDeSuccion.JointData.Nuevo(num3, num9, num5, physicBone, this.inTime * this.inPhyscisTimeMod, this.outTime * this.outPhyscisTimeMod, new float?(this.breakForce));
			return this.m_ControlladorDeSuckPose.Chupar(num4, num, ControllerPrioridadConfig.prioridad, num6, this.inTime, this.outTime, this.m_isValidToSuck, this.m_isValidToSuck, jointData);
		}

		// Token: 0x060015D5 RID: 5589 RVA: 0x00067E1B File Offset: 0x0006601B
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Emular Reaccion",
				editorTimeVisible = false
			};
		}

		// Token: 0x060015D6 RID: 5590 RVA: 0x00067E34 File Offset: 0x00066034
		protected override void OnAplicar2()
		{
			float num = this.maxSuckWeight;
			int num2 = 1;
			MaleChar maleChar = MainChar.current as MaleChar;
			Penis penis = ((maleChar != null) ? maleChar.pene : null);
			int num3 = penis.countDePartes - 1;
			Rigidbody physicBone = penis.partesEnOrden[num3].physicBone;
			float num4 = Vector3.Distance(this.m_IBocaHole.rootParaNoPenetracionSuckJoints.position, physicBone.position) * 1.25f;
			ControlladorDeSuccion.JointData jointData = ControlladorDeSuccion.JointData.Nuevo(num, num4, num3, physicBone, this.inTime * this.inPhyscisTimeMod, this.outTime * this.outPhyscisTimeMod, null);
			this.m_ControlladorDeSuckPose.Chupar(num, num2, ControllerPrioridadConfig.prioridad, this.duracion, this.inTime, this.outTime, this.m_isValidToSuck, this.m_isValidToSuck, jointData);
		}

		// Token: 0x04000F88 RID: 3976
		private ControlladorDeSuccionJoints m_ControlladorDeToChainPointJoints;

		// Token: 0x04000F89 RID: 3977
		private ControlladorDeSuccion m_ControlladorDeSuckPose;

		// Token: 0x04000F8A RID: 3978
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F8B RID: 3979
		public int prioridadParaConstroller = 10;

		// Token: 0x04000F8C RID: 3980
		public float duracion = 0.666f;

		// Token: 0x04000F8D RID: 3981
		public float inTime = 0.333f;

		// Token: 0x04000F8E RID: 3982
		public float outTime = 0.1f;

		// Token: 0x04000F8F RID: 3983
		public float inPhyscisTimeMod = 1f;

		// Token: 0x04000F90 RID: 3984
		public float outPhyscisTimeMod = 1f;

		// Token: 0x04000F91 RID: 3985
		public float maxSuckWeight = 0.55f;

		// Token: 0x04000F92 RID: 3986
		public float breakForce = 0.01f;

		// Token: 0x04000F93 RID: 3987
		private ICharacter m_ICharacter;

		// Token: 0x04000F94 RID: 3988
		private OralPosibilidadScore m_paraPene;

		// Token: 0x04000F95 RID: 3989
		private OralPosibilidadScore m_paraDedo;

		// Token: 0x04000F96 RID: 3990
		private Personalidad m_Personalidad;

		// Token: 0x04000F97 RID: 3991
		private bool m_wasPenetrated;

		// Token: 0x04000F98 RID: 3992
		private ICharacterConversador m_conversador;

		// Token: 0x04000F99 RID: 3993
		private ICharacterHablador m_hablador;

		// Token: 0x04000F9A RID: 3994
		private TouchesByMainInFrame m_TouchesByMainInFrame;

		// Token: 0x04000F9B RID: 3995
		private Func<bool> m_isValidToSuck;

		// Token: 0x04000F9C RID: 3996
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x04000F9D RID: 3997
		private ICharacterGestuable m_characterGestuable;
	}
}
