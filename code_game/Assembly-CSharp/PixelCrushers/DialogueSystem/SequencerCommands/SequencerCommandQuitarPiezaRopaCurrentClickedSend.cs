using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.UI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ropa.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using RootMotion.Dynamics;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000033 RID: 51
	public class SequencerCommandQuitarPiezaRopaCurrentClickedSend : SequencerCommand
	{
		// Token: 0x060000FC RID: 252 RVA: 0x00009D34 File Offset: 0x00007F34
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(0, true);
				this.datos = new SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar();
				this.datos.Load(parameterAsBool, base.Sequencer);
				if (this.datos.EsValidoParaPiezas(parameterAsBool, base.Sequencer))
				{
					string text = this.datos.opcionesDePiezas.selectedKeys.Last<string>();
					if (!base.GetParameterAsBool(1, true))
					{
						throw new NotImplementedException();
					}
					bool parameterAsBool2 = base.GetParameterAsBool(2, false);
					if (!this.datos.opcionesDePiezas.puedeDesvestirse && !parameterAsBool2)
					{
						this.datos.registrdor.TryRegistrarPedido(text, this.datos.opcionesDePiezas.puedeDesvestirse, parameterAsBool2, this.datos.by);
					}
					else
					{
						this.m_CoroutineV2 = new CoroutineCapsuleMonoGeneric(this);
						this.m_contexto = this.m_CoroutineV2.Start(SequencerCommandQuitarPiezaRopaCurrentClickedSend.RemoverPiezaConAnimacionRutina(this, this.datos, text, this.datos.registrdor, this.datos.opcionesDePiezas.puedeDesvestirse, parameterAsBool2, this.datos.by), new float?((float)15), null);
					}
				}
			}
			finally
			{
				if (this.m_CoroutineV2 == null || !this.m_CoroutineV2.ejecutandose)
				{
					base.Stop();
				}
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00009E88 File Offset: 0x00008088
		public void Update()
		{
			BaseCoroutineCapsule<MonoBehaviour>.Contexto contexto = this.m_contexto;
			bool valueOrDefault = ((contexto != null) ? new bool?(contexto.IsTimeOver()) : null).GetValueOrDefault();
			if (this.m_CoroutineV2 == null || !this.m_CoroutineV2.ejecutandose || valueOrDefault)
			{
				base.Stop();
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00009EE0 File Offset: 0x000080E0
		public void OnDestroy()
		{
			SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar datosDeChar = this.datos;
			if (datosDeChar != null)
			{
				datosDeChar.Clear();
			}
			CoroutineCapsuleMonoGeneric coroutineV = this.m_CoroutineV2;
			if (coroutineV != null)
			{
				coroutineV.Destroy();
			}
			this.datos = null;
			this.m_CoroutineV2 = null;
			this.m_contexto = null;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00009F19 File Offset: 0x00008119
		public static IEnumerator RemoverPiezaConAnimacionRutina(MonoBehaviour mono, SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar datos, string piezaId, EstimulosPorQuitarPrendasDeRopa registrdor, bool puedeDesvestirse, bool forzar, Object by)
		{
			if (!puedeDesvestirse && !forzar)
			{
				registrdor.TryRegistrarPedido(piezaId, puedeDesvestirse, forzar, by);
				yield break;
			}
			List<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> interactablesRLB = new List<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>>();
			SequencerCommandQuitarPiezaRopaCurrentClickedSend.GetInteractable(datos.Guias, datos.RopaParaAvatar, piezaId, interactablesRLB);
			bool puedeUsarLMano = datos.InteractionController.IsLHandsFree();
			bool puedeUsarRMano = datos.InteractionController.IsRHandsFree();
			List<RopaInteractableInteraccion> ejecutadas = new List<RopaInteractableInteraccion>();
			int num;
			for (int i = 0; i < interactablesRLB.Count; i = num + 1)
			{
				ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable> valueTuple = interactablesRLB[i];
				yield return SequencerCommandQuitarPiezaRopaCurrentClickedSend.InteractuarConInteractable2(mono, valueTuple, i == 0, datos.interaccionR, datos.interaccionL, datos.interaccionRL, puedeUsarLMano, puedeUsarRMano, ejecutadas);
				num = i;
			}
			yield return new WaitForSeconds(0.333f);
			registrdor.TryRegistrarPedido(piezaId, puedeDesvestirse, forzar, by);
			yield return new WaitForSeconds(0.1f);
			for (int j = 0; j < ejecutadas.Count; j++)
			{
				ejecutadas[j].interaccion.Detener(false);
			}
			yield break;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00009F58 File Offset: 0x00008158
		public static IEnumerator InteractuarConInteractable2(MonoBehaviour mono, ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable> interactablesRLB, bool isFirst, RopaInteractableInteraccion r, RopaInteractableInteraccion l, RopaInteractableInteraccion rl, bool puedeUsarLMano, bool puedeUsarRMano, List<RopaInteractableInteraccion> ejecutadas)
		{
			GuiaDeRopaInteractable item = interactablesRLB.Item1;
			GuiaDeRopaInteractable item2 = interactablesRLB.Item2;
			GuiaDeRopaInteractable item3 = interactablesRLB.Item3;
			if (puedeUsarLMano && puedeUsarRMano && item3 != null)
			{
				SequencerCommandQuitarPiezaRopaCurrentClickedSend.<>c__DisplayClass7_0 CS$<>8__locals1 = new SequencerCommandQuitarPiezaRopaCurrentClickedSend.<>c__DisplayClass7_0();
				CS$<>8__locals1.finiched = false;
				mono.StartCoroutine(SequencerCommandQuitarPiezaRopaCurrentClickedSend.InteractuarConInteractable(item3, rl, isFirst, ejecutadas, delegate
				{
					CS$<>8__locals1.finiched = true;
				}));
				while (!CS$<>8__locals1.finiched)
				{
					yield return null;
				}
				CS$<>8__locals1 = null;
			}
			else
			{
				SequencerCommandQuitarPiezaRopaCurrentClickedSend.<>c__DisplayClass7_1 CS$<>8__locals2 = new SequencerCommandQuitarPiezaRopaCurrentClickedSend.<>c__DisplayClass7_1();
				bool flag = puedeUsarLMano && item2 != null;
				bool flag2 = puedeUsarRMano && item != null;
				CS$<>8__locals2.finichedL = false;
				CS$<>8__locals2.finichedR = false;
				if (flag)
				{
					mono.StartCoroutine(SequencerCommandQuitarPiezaRopaCurrentClickedSend.InteractuarConInteractable(item2, l, isFirst, ejecutadas, delegate
					{
						CS$<>8__locals2.finichedL = true;
					}));
				}
				else
				{
					CS$<>8__locals2.finichedL = true;
				}
				if (flag2)
				{
					mono.StartCoroutine(SequencerCommandQuitarPiezaRopaCurrentClickedSend.InteractuarConInteractable(item, r, isFirst, ejecutadas, delegate
					{
						CS$<>8__locals2.finichedR = true;
					}));
				}
				else
				{
					CS$<>8__locals2.finichedR = true;
				}
				while (!CS$<>8__locals2.finichedL || !CS$<>8__locals2.finichedR)
				{
					yield return null;
				}
				CS$<>8__locals2 = null;
			}
			yield break;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00009FAF File Offset: 0x000081AF
		public static IEnumerator InteractuarConInteractable(GuiaDeRopaInteractable interactable, RopaInteractableInteraccion interaccion, bool isFirst, List<RopaInteractableInteraccion> ejecutadas, Action OnFinish)
		{
			interaccion.interaccion.FolloweOwnerCharacterPose(true);
			interaccion.FollowStartPose(interactable);
			yield return null;
			if (!interaccion.interaccion.Ejecutar(2147483647, -1f, ControllerPrioridadConfig.prioridad, 1f, 1f, false))
			{
				if (OnFinish != null)
				{
					OnFinish();
				}
				yield break;
			}
			if (ejecutadas != null)
			{
				ejecutadas.Add(interaccion);
			}
			if (isFirst)
			{
				yield return new WaitForSeconds(interaccion.interaccion.ObtenerDuracionPorDefecto() / 2f);
			}
			interaccion.StartFollowing(interactable);
			while (interaccion.w < 1f)
			{
				yield return null;
			}
			interaccion.StopFollowing();
			if (OnFinish != null)
			{
				OnFinish();
			}
			yield break;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00009FDC File Offset: 0x000081DC
		public static void GetInteractable(ControlladorDeGuiasDeInteraccionDeRopa Guias, IRopaParaAvatar iRopaParaAvatar, string piezaId, IList<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> result)
		{
			if (Guias == null)
			{
				return;
			}
			MapaDeRopa.RopaData ropaData = ((iRopaParaAvatar != null) ? iRopaParaAvatar.ObtenerData(piezaId) : null);
			if (ropaData == null)
			{
				return;
			}
			switch (ropaData.posicion)
			{
			case RopaPosicion.None:
			case RopaPosicion.cueroCabelludo:
			case RopaPosicion.ojos:
			case RopaPosicion.boca:
			case RopaPosicion.pies:
			case RopaPosicion.manos:
				Debug.Log("TODO: aun no se a desarrollado animacion para esta posicion de ropa");
				return;
			case RopaPosicion.torzo:
				switch (ropaData.layer)
				{
				case RopaLayer.debajoDeRopaInterior:
				case RopaLayer.ropaInterior:
					result.Add(new ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(Guias.ExposeNipples_R, Guias.ExposeNipples_L, null));
					return;
				case RopaLayer.debajoDeRopa:
				case RopaLayer.ropa:
				case RopaLayer.debajoDeAbrigo:
				case RopaLayer.abrigo:
					result.Add(new ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(Guias.ExposeTorzoHalf1F, Guias.ExposeTorzoHalf1F, Guias.ExposeTorzoHalf1F));
					result.Add(new ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(Guias.ExposeTorzoHalf2F, Guias.ExposeTorzoHalf2F, Guias.ExposeTorzoHalf2F));
					return;
				case RopaLayer.debajoDeAccesorios:
				case RopaLayer.accesorios:
					Debug.Log("TODO: aun no se a desarrollado animacion para este layer de ropa");
					return;
				default:
					throw new ArgumentOutOfRangeException(ropaData.layer.ToString());
				}
				break;
			case RopaPosicion.caderas:
				switch (ropaData.layer)
				{
				case RopaLayer.debajoDeRopaInterior:
				case RopaLayer.ropaInterior:
				case RopaLayer.debajoDeRopa:
				case RopaLayer.ropa:
				case RopaLayer.debajoDeAbrigo:
				case RopaLayer.abrigo:
					result.Add(new ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(Guias.ExposeHipsHalf1R, Guias.ExposeHipsHalf1L, null));
					result.Add(new ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(Guias.ExposeHipsHalf2R, Guias.ExposeHipsHalf2L, null));
					return;
				case RopaLayer.debajoDeAccesorios:
				case RopaLayer.accesorios:
					Debug.Log("TODO: aun no se a desarrollado animacion para este layer de ropa");
					return;
				default:
					throw new ArgumentOutOfRangeException(ropaData.layer.ToString());
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(ropaData.posicion.ToString());
			}
		}

		// Token: 0x040000A4 RID: 164
		private SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar datos;

		// Token: 0x040000A5 RID: 165
		private CoroutineCapsuleMonoGeneric m_CoroutineV2;

		// Token: 0x040000A6 RID: 166
		private BaseCoroutineCapsule<MonoBehaviour>.Contexto m_contexto;

		// Token: 0x020000DA RID: 218
		public class DatosDeChar
		{
			// Token: 0x0600055B RID: 1371 RVA: 0x00019E50 File Offset: 0x00018050
			public void Load(bool isSpeaker, Sequencer Sequencer)
			{
				PuppetMaster puppetMaster;
				if (isSpeaker)
				{
					this.registrdor = Sequencer.Speaker.GetComponentEnRoot(true);
					this.opcionesDePiezas = Sequencer.Speaker.GetComponentEnRoot(true);
					this.opcionesDePartes = Sequencer.Speaker.GetComponentEnRoot(true);
					this.loader = Sequencer.Speaker.GetComponentEnRoot(true);
					this.by = Sequencer.Listener.GetComponentEnRoot(true);
					this.interaccionesDeCharacter = Sequencer.Speaker.GetComponentEnRoot(false);
					this.Guias = Sequencer.Speaker.GetComponentEnRoot(false);
					this.RopaParaAvatar = AsyncSingleton<RopaParaAvatarUnificado>.instance;
					this.InteractionController = Sequencer.Speaker.GetComponentEnRoot(false);
					puppetMaster = Sequencer.Speaker.GetComponentEnRoot(false);
				}
				else
				{
					this.registrdor = Sequencer.Listener.GetComponentEnRoot(true);
					this.opcionesDePiezas = Sequencer.Listener.GetComponentEnRoot(true);
					this.opcionesDePartes = Sequencer.Listener.GetComponentEnRoot(true);
					this.loader = Sequencer.Listener.GetComponentEnRoot(true);
					this.by = Sequencer.Speaker.GetComponentEnRoot(true);
					this.interaccionesDeCharacter = Sequencer.Listener.GetComponentEnRoot(false);
					this.Guias = Sequencer.Listener.GetComponentEnRoot(false);
					this.RopaParaAvatar = AsyncSingleton<RopaParaAvatarUnificado>.instance;
					this.InteractionController = Sequencer.Listener.GetComponentEnRoot(false);
					puppetMaster = Sequencer.Listener.GetComponentEnRoot(false);
				}
				Interaccion interaccion = null;
				Interaccion interaccion2 = null;
				Interaccion interaccion3 = null;
				IInteraccionesDeCharacter interaccionesDeCharacter = this.interaccionesDeCharacter;
				if (interaccionesDeCharacter != null)
				{
					interaccionesDeCharacter.TryObtenerSiEsValida(InteraccionSegundariaName.InteractuarRopaDerecha.GetInteractionID(), out interaccion);
				}
				IInteraccionesDeCharacter interaccionesDeCharacter2 = this.interaccionesDeCharacter;
				if (interaccionesDeCharacter2 != null)
				{
					interaccionesDeCharacter2.TryObtenerSiEsValida(InteraccionSegundariaName.InteractuarRopaIzquierda.GetInteractionID(), out interaccion2);
				}
				IInteraccionesDeCharacter interaccionesDeCharacter3 = this.interaccionesDeCharacter;
				if (interaccionesDeCharacter3 != null)
				{
					interaccionesDeCharacter3.TryObtenerSiEsValida(InteraccionSegundariaName.InteractuarRopaDerechaIzquierda.GetInteractionID(), out interaccion3);
				}
				this.interaccionR = ((interaccion != null) ? interaccion.GetComponent<RopaInteractableInteraccion>() : null);
				this.interaccionL = ((interaccion2 != null) ? interaccion2.GetComponent<RopaInteractableInteraccion>() : null);
				this.interaccionRL = ((interaccion3 != null) ? interaccion3.GetComponent<RopaInteractableInteraccion>() : null);
				GenericAgarranteObjeto genericAgarranteObjeto;
				if (puppetMaster == null)
				{
					genericAgarranteObjeto = null;
				}
				else
				{
					Muscle muscle = puppetMaster.GetMuscle(HumanBodyBones.RightHand);
					genericAgarranteObjeto = ((muscle != null) ? muscle.rigidbody.GetComponentInChildren<GenericAgarranteObjeto>() : null);
				}
				this.agarranteManoR = genericAgarranteObjeto;
				GenericAgarranteObjeto genericAgarranteObjeto2;
				if (puppetMaster == null)
				{
					genericAgarranteObjeto2 = null;
				}
				else
				{
					Muscle muscle2 = puppetMaster.GetMuscle(HumanBodyBones.LeftHand);
					genericAgarranteObjeto2 = ((muscle2 != null) ? muscle2.rigidbody.GetComponentInChildren<GenericAgarranteObjeto>() : null);
				}
				this.agarranteManoL = genericAgarranteObjeto2;
				if (this.interaccionR == null)
				{
					throw new ArgumentNullException("interaccionR", "interaccionR null reference.");
				}
				if (this.interaccionL == null)
				{
					throw new ArgumentNullException("interaccionL", "interaccionL null reference.");
				}
				if (this.interaccionRL == null)
				{
					throw new ArgumentNullException("interaccionRL", "interaccionRL null reference.");
				}
				if (this.agarranteManoR == null)
				{
					throw new ArgumentNullException("agarranteManoR", "agarranteManoR null reference.");
				}
				if (this.agarranteManoL == null)
				{
					throw new ArgumentNullException("agarranteManoL", "agarranteManoL null reference.");
				}
			}

			// Token: 0x0600055C RID: 1372 RVA: 0x0001A128 File Offset: 0x00018328
			public bool EsValidoParaPiezas(bool isSpeaker, Sequencer Sequencer)
			{
				if (this.registrdor == null)
				{
					Debug.LogError("EstimulosPorQuitarPrendasDeRopa no existe en objeto.", isSpeaker ? Sequencer.Speaker : Sequencer.Listener);
					return false;
				}
				if (this.opcionesDePiezas == null)
				{
					Debug.LogError("OpcionesDeTHSDonaDePiezaDeRopaPuesta no existe en objeto.", isSpeaker ? Sequencer.Speaker : Sequencer.Listener);
					return false;
				}
				if (this.opcionesDePiezas.selected.Count == 0)
				{
					Debug.LogError("OpcionesDeTHSDonaDePiezaDeRopaPuesta no existe current clicked. ", isSpeaker ? Sequencer.Speaker : Sequencer.Listener);
					return false;
				}
				return true;
			}

			// Token: 0x0600055D RID: 1373 RVA: 0x0001A1BC File Offset: 0x000183BC
			public bool EsValidoParaPartes(bool isSpeaker, Sequencer Sequencer)
			{
				if (this.loader == null)
				{
					Debug.LogError("ConjuntoDeRopaLoader no existe en objeto.", isSpeaker ? Sequencer.Speaker : Sequencer.Listener);
					return false;
				}
				if (this.registrdor == null)
				{
					Debug.LogError("EstimulosPorQuitarPrendasDeRopa no existe en objeto.", isSpeaker ? Sequencer.Speaker : Sequencer.Listener);
					return false;
				}
				if (this.opcionesDePartes == null)
				{
					Debug.LogError("OpcionesDeTHSDonaDeRopaCubreConTextoMutado no existe en objeto.", isSpeaker ? Sequencer.Speaker : Sequencer.Listener);
					return false;
				}
				if (this.opcionesDePartes.selected.Count == 0)
				{
					Debug.LogError("OpcionesDeTHSDonaDeRopaCubreConTextoMutado no existe current clicked. ", isSpeaker ? Sequencer.Speaker : Sequencer.Listener);
					return false;
				}
				return true;
			}

			// Token: 0x0600055E RID: 1374 RVA: 0x0001A27C File Offset: 0x0001847C
			public void Clear()
			{
				this.by = null;
				this.registrdor = null;
				this.opcionesDePiezas = null;
				this.opcionesDePartes = null;
				this.loader = null;
				this.interaccionesDeCharacter = null;
				this.interaccionR = null;
				this.interaccionL = null;
				this.interaccionRL = null;
				this.Guias = null;
				this.RopaParaAvatar = null;
				this.InteractionController = null;
			}

			// Token: 0x040002D6 RID: 726
			public Character by;

			// Token: 0x040002D7 RID: 727
			public EstimulosPorQuitarPrendasDeRopa registrdor;

			// Token: 0x040002D8 RID: 728
			public OpcionesDeTHSDonaDePiezaDeRopaPuesta opcionesDePiezas;

			// Token: 0x040002D9 RID: 729
			public OpcionesDeTHSDonaDeRopaCubreConTextoMutado opcionesDePartes;

			// Token: 0x040002DA RID: 730
			public ConjuntoDeRopaLoader loader;

			// Token: 0x040002DB RID: 731
			public IInteraccionesDeCharacter interaccionesDeCharacter;

			// Token: 0x040002DC RID: 732
			public RopaInteractableInteraccion interaccionR;

			// Token: 0x040002DD RID: 733
			public RopaInteractableInteraccion interaccionL;

			// Token: 0x040002DE RID: 734
			public RopaInteractableInteraccion interaccionRL;

			// Token: 0x040002DF RID: 735
			public ControlladorDeGuiasDeInteraccionDeRopa Guias;

			// Token: 0x040002E0 RID: 736
			public IRopaParaAvatar RopaParaAvatar;

			// Token: 0x040002E1 RID: 737
			public IInteractionController InteractionController;

			// Token: 0x040002E2 RID: 738
			public GenericAgarranteObjeto agarranteManoR;

			// Token: 0x040002E3 RID: 739
			public GenericAgarranteObjeto agarranteManoL;
		}
	}
}
