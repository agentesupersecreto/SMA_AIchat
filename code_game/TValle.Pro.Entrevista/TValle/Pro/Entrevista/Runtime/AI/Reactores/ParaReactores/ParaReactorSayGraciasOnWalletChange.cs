using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.AI.Reactores.ParaReactores
{
	// Token: 0x0200010E RID: 270
	public class ParaReactorSayGraciasOnWalletChange : ParaReactor
	{
		// Token: 0x0600091C RID: 2332 RVA: 0x00037054 File Offset: 0x00035254
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_SimpleWallet = this.GetComponentEnRoot(false);
			this.m_Personalidad = this.GetComponentEnRoot(false);
			this.m_controller = this.GetComponentEnRoot(false);
			this.m_controllerExp = this.GetComponentEnRoot(false);
			this.controllerLook = this.GetComponentEnRoot(false);
			if (this.m_controllerExp == null)
			{
				throw new ArgumentNullException("m_controllerExp", "m_controllerExp null reference.");
			}
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			if (this.m_SimpleWallet == null)
			{
				throw new ArgumentNullException("m_SimpleWallet", "m_SimpleWallet null reference.");
			}
			if (this.m_controller == null)
			{
				throw new ArgumentNullException("m_controller", "m_controller null reference.");
			}
			if (this.controllerLook == null)
			{
				throw new ArgumentNullException("controllerLook", "controllerLook null reference.");
			}
			this.m_SimpleWallet.onChanged += this.M_SimpleWallet_onChanged1;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0003714F File Offset: 0x0003534F
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_SimpleWallet != null)
			{
				this.m_SimpleWallet.onChanged -= this.M_SimpleWallet_onChanged1;
			}
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0003717D File Offset: 0x0003537D
		private void M_SimpleWallet_onChanged1(string arg1, float arg2, string arg3)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (arg2 > 0f)
			{
				this.m_positiveChanges += arg2;
			}
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x000371A0 File Offset: 0x000353A0
		protected override bool ReaccionarArgumento(object arg)
		{
			if (this.m_positiveChanges <= 0f)
			{
				this.m_positiveChanges = 0f;
				return false;
			}
			if (!Singleton<DialogosDeSayGracias>.IsInScene)
			{
				return false;
			}
			bool flag;
			try
			{
				Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina = this.m_Personalidad.ObtenerTipoDeRespuestaSegunPersonalidadYEmociones();
				Singleton<DialogosDeSayGracias>.instance.RandomLoadParaTipo(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, tipoDeRespuestaDeDialogoDeHeroina, ParaReactorSayGraciasOnWalletChange.resultTEMP);
				if (ParaReactorSayGraciasOnWalletChange.resultTEMP.Count == 0)
				{
					Debug.LogError("No dialogues for gracias found with per: " + tipoDeRespuestaDeDialogoDeHeroina.ToString(), this);
					flag = false;
				}
				else
				{
					DialogoInfoGenericoConTipoDeRespuesta dialogoInfoGenericoConTipoDeRespuesta = ParaReactorSayGraciasOnWalletChange.resultTEMP.RandomItem<DialogoInfoGenericoConTipoDeRespuesta>();
					bool flag2 = false;
					if (!this.m_controller.PuedeMostrarBark(this.m_prioridadParaController, ControllerPrioridadConfig.prioridad, ref flag2))
					{
						flag = false;
					}
					else
					{
						string text = dialogoInfoGenericoConTipoDeRespuesta.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, 0);
						if (string.IsNullOrWhiteSpace(text) || !this.m_controller.Bark(text, true, this.m_prioridadParaController, ControllerPrioridadConfig.prioridad, 1f, 1f))
						{
							flag = false;
						}
						else
						{
							ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoDeExpresion;
							switch (tipoDeRespuestaDeDialogoDeHeroina)
							{
							case Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None:
							case Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable:
								tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria;
								goto IL_0145;
							case Personalidad.TipoDeRespuestaDeDialogoDeHeroina.grosera:
								tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
								goto IL_0145;
							case Personalidad.TipoDeRespuestaDeDialogoDeHeroina.timida:
								tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
								goto IL_0145;
							case Personalidad.TipoDeRespuestaDeDialogoDeHeroina.pervertida:
								tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer;
								goto IL_0145;
							}
							throw new ArgumentOutOfRangeException(tipoDeRespuestaDeDialogoDeHeroina.ToString());
							IL_0145:
							this.m_controllerExp.ExagerarYSuprimirOtros(tipoDeExpresion, this.baseConfig.coolDownGeneral, 1f, 0.666f, 0f, null);
							Character character = MainChar.instance.character;
							Transform transform = ((character.cameraAtadaTransform != null) ? character.cameraAtadaTransform : character.trasnformParaObservar);
							if (transform != null)
							{
								this.controllerLook.Mirar(1f, 1f, transform, LookAtControllerV2.LookAtType.fijamente, true, LookAtControllerV2.LookAtType.fijamente, true, 1f, this.m_prioridadParaController, 1f, ControllerPrioridadConfig.prioridad, default(Vector3), true, 5f);
							}
							flag = true;
						}
					}
				}
			}
			finally
			{
				ParaReactorSayGraciasOnWalletChange.resultTEMP.Clear();
				this.m_positiveChanges = 0f;
			}
			return flag;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x000373D0 File Offset: 0x000355D0
		protected override float ModificadorDeCoolDown(object arg)
		{
			return 1f;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x000373D7 File Offset: 0x000355D7
		protected override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			return 1f;
		}

		// Token: 0x04000516 RID: 1302
		private SimpleWallet m_SimpleWallet;

		// Token: 0x04000517 RID: 1303
		private Personalidad m_Personalidad;

		// Token: 0x04000518 RID: 1304
		private float m_positiveChanges;

		// Token: 0x04000519 RID: 1305
		private IControlladorDeBark m_controller;

		// Token: 0x0400051A RID: 1306
		private ControlladorDeGestosFacialesEmocionales m_controllerExp;

		// Token: 0x0400051B RID: 1307
		private LookAtControllerV2 controllerLook;

		// Token: 0x0400051C RID: 1308
		[SerializeField]
		[Tooltip("igual q orgasmo")]
		private int m_prioridadParaController;

		// Token: 0x0400051D RID: 1309
		private static List<DialogoInfoGenericoConTipoDeRespuesta> resultTEMP = new List<DialogoInfoGenericoConTipoDeRespuesta>();
	}
}
