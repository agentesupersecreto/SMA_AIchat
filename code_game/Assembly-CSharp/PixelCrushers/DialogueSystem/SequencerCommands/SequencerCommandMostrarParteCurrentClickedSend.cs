using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ropa.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000032 RID: 50
	public class SequencerCommandMostrarParteCurrentClickedSend : SequencerCommand
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x00009798 File Offset: 0x00007998
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(0, true);
				this.datos = new SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar();
				this.datos.Load(parameterAsBool, base.Sequencer);
				if (this.datos.EsValidoParaPartes(parameterAsBool, base.Sequencer))
				{
					RopaCubre currentClickedEnum = this.datos.opcionesDePartes.selectedEnums.Last<RopaCubre>();
					this.datos.loader.CantidadPiezasCubriendo(currentClickedEnum, true, this.m_idsEnropaCubre);
					if (!base.GetParameterAsBool(1, true))
					{
						throw new NotImplementedException();
					}
					bool parameterAsBool2 = base.GetParameterAsBool(2, false);
					if (!this.datos.opcionesDePartes.puedeDesvestir && !parameterAsBool2)
					{
						using (List<string>.Enumerator enumerator = this.m_idsEnropaCubre.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string text = enumerator.Current;
								this.datos.registrdor.TryRegistrarPedido(text, this.datos.opcionesDePartes.puedeDesvestir, parameterAsBool2, this.datos.by);
							}
							return;
						}
					}
					List<ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> list = new List<ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>>();
					Predicate<MapaDeRopa.RopaData> predicate = (MapaDeRopa.RopaData d) => !((int)d.cubreFlag).HasFlag((int)currentClickedEnum);
					List<MapaDeRopa.RopaData> list2 = new List<MapaDeRopa.RopaData>();
					for (int i = 0; i < this.m_idsEnropaCubre.Count; i++)
					{
						string text2 = this.m_idsEnropaCubre[i];
						MapaDeRopa.RopaData ropaData = this.datos.RopaParaAvatar.SeleccionarBestSubPrenda(text2, predicate);
						if (ropaData == null)
						{
							list.Add(new ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(this.datos.RopaParaAvatar.ObtenerData(text2), null, null));
						}
						else
						{
							try
							{
								this.datos.RopaParaAvatar.SeleccionarJerarquiaPadres(text2, ropaData.stringId, list2);
								if (list2.Count == 0)
								{
									list.Add(new ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(this.datos.RopaParaAvatar.ObtenerData(text2), null, null));
								}
								else
								{
									list2.Add(ropaData);
									for (int j = 0; j < list2.Count - 1; j++)
									{
										MapaDeRopa.RopaData ropaData2 = list2[j];
										MapaDeRopa.RopaData ropaData3 = list2[j + 1];
										MapaDeRopa.RopaData.Interacciones interacciones = null;
										MapaDeRopa.RopaData.Interacciones interacciones2 = null;
										for (int k = 0; k < ropaData2.interacciones.Count; k++)
										{
											MapaDeRopa.RopaData.Interacciones interacciones3 = ropaData2.interacciones[k];
											if (interacciones3.subPrendaIDString == ropaData3.stringId)
											{
												string text3 = interacciones3.id.ToString();
												if (text3.EndsWith('L') || text3.EndsWith('l') || text3.EndsWith('F') || text3.EndsWith('f'))
												{
													interacciones2 = interacciones3;
												}
												else
												{
													interacciones = interacciones3;
												}
											}
										}
										if (interacciones == null && interacciones2 == null)
										{
											list.Add(new ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(this.datos.RopaParaAvatar.ObtenerData(text2), null, null));
											break;
										}
										list.Add(new ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(ropaData2, (interacciones != null) ? this.datos.Guias.ObtenerGuia(interacciones.id) : null, (interacciones2 != null) ? this.datos.Guias.ObtenerGuia(interacciones2.id) : null));
									}
								}
							}
							finally
							{
								list2.Clear();
							}
						}
					}
					this.m_CoroutineV2 = new CoroutineCapsuleMonoGeneric(this);
					this.m_contexto = this.m_CoroutineV2.Start(SequencerCommandMostrarParteCurrentClickedSend.InteractualConPiezasConAnimacionRutina(this, this.datos, list, this.datos.opcionesDePartes.puedeDesvestir, parameterAsBool2, this.datos.by), new float?((float)(list.Count * 10)), null);
				}
			}
			finally
			{
				if (this.m_CoroutineV2 == null || !this.m_CoroutineV2.ejecutandose)
				{
					base.Stop();
				}
				this.m_idsEnropaCubre.Clear();
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00009BA0 File Offset: 0x00007DA0
		public void Update()
		{
			BaseCoroutineCapsule<MonoBehaviour>.Contexto contexto = this.m_contexto;
			bool valueOrDefault = ((contexto != null) ? new bool?(contexto.IsTimeOver()) : null).GetValueOrDefault();
			if (this.m_CoroutineV2 == null || !this.m_CoroutineV2.ejecutandose || valueOrDefault)
			{
				base.Stop();
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00009BF8 File Offset: 0x00007DF8
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

		// Token: 0x060000F8 RID: 248 RVA: 0x00009C31 File Offset: 0x00007E31
		public static IEnumerator InteractualConPiezasConAnimacionRutina(MonoBehaviour mono, SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar datos, List<ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> piezasInteractableRLPar, bool puedeDesvestirse, bool forzar, Object by)
		{
			if (!puedeDesvestirse && !forzar)
			{
				for (int j = 0; j < piezasInteractableRLPar.Count; j++)
				{
					ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable> valueTuple = piezasInteractableRLPar[j];
					datos.registrdor.TryRegistrarPedido(valueTuple.Item1.stringId, puedeDesvestirse, forzar, by);
				}
				yield break;
			}
			bool puedeUsarLMano = datos.InteractionController.IsLHandsFree();
			bool puedeUsarRMano = datos.InteractionController.IsRHandsFree();
			Side side = Side.L;
			Action sideChanger = delegate
			{
				if (side == Side.L)
				{
					side = Side.R;
					return;
				}
				side = Side.L;
			};
			int num;
			for (int i = 0; i < piezasInteractableRLPar.Count; i = num + 1)
			{
				ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable> valueTuple2 = piezasInteractableRLPar[i];
				if (valueTuple2.Item2 == null && valueTuple2.Item3 == null)
				{
					yield return SequencerCommandMostrarParteCurrentClickedSend.InteractualConPiezaConAnimacionRutinaGenerico(mono, datos, valueTuple2.Item1.stringId, side, forzar, by, puedeUsarLMano, puedeUsarRMano, sideChanger, null);
				}
				else
				{
					yield return SequencerCommandMostrarParteCurrentClickedSend.InteractualConPiezaConAnimacionRutina(mono, datos, valueTuple2, side, forzar, by, puedeUsarLMano, puedeUsarRMano, sideChanger, null);
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00009C68 File Offset: 0x00007E68
		public static IEnumerator InteractualConPiezaConAnimacionRutinaGenerico(MonoBehaviour mono, SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar datos, string piezaId, Side side, bool forzar, Object by, bool puedeUsarLMano, bool puedeUsarRMano, Action changeSide, Action OnFinish)
		{
			List<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> list = new List<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>>();
			SequencerCommandQuitarPiezaRopaCurrentClickedSend.GetInteractable(datos.Guias, datos.RopaParaAvatar, piezaId, list);
			List<ValueTuple<GuiaDeRopaInteractable, RopaInteractableInteraccion>> interactables = new List<ValueTuple<GuiaDeRopaInteractable, RopaInteractableInteraccion>>();
			if (puedeUsarLMano || puedeUsarRMano)
			{
				int j = 0;
				while (j < list.Count)
				{
					ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable> valueTuple = list[j];
					switch (side)
					{
					case Side.none:
					case Side.F:
					case Side.B:
						goto IL_0157;
					case Side.L:
						if (puedeUsarLMano)
						{
							changeSide();
							interactables.Add(new ValueTuple<GuiaDeRopaInteractable, RopaInteractableInteraccion>(valueTuple.Item2, datos.interaccionL));
						}
						else
						{
							interactables.Add(new ValueTuple<GuiaDeRopaInteractable, RopaInteractableInteraccion>(valueTuple.Item1, datos.interaccionR));
						}
						break;
					case Side.R:
						if (puedeUsarRMano)
						{
							changeSide();
							interactables.Add(new ValueTuple<GuiaDeRopaInteractable, RopaInteractableInteraccion>(valueTuple.Item1, datos.interaccionR));
						}
						else
						{
							interactables.Add(new ValueTuple<GuiaDeRopaInteractable, RopaInteractableInteraccion>(valueTuple.Item2, datos.interaccionL));
						}
						break;
					default:
						goto IL_0157;
					}
					j++;
					continue;
					IL_0157:
					throw new ArgumentOutOfRangeException(side.ToString());
				}
			}
			List<RopaInteractableInteraccion> ejecutadas = new List<RopaInteractableInteraccion>();
			int num;
			for (int i = 0; i < interactables.Count; i = num + 1)
			{
				ValueTuple<GuiaDeRopaInteractable, RopaInteractableInteraccion> valueTuple2 = interactables[i];
				yield return SequencerCommandQuitarPiezaRopaCurrentClickedSend.InteractuarConInteractable(valueTuple2.Item1, valueTuple2.Item2, i == 0, ejecutadas, null);
				num = i;
			}
			yield return new WaitForSeconds(0.333f);
			datos.registrdor.TryRegistrarPedido(piezaId, true, forzar, by);
			yield return new WaitForSeconds(0.1f);
			for (int k = 0; k < ejecutadas.Count; k++)
			{
				ejecutadas[k].interaccion.Detener(false);
			}
			if (OnFinish != null)
			{
				OnFinish();
			}
			yield break;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00009CC0 File Offset: 0x00007EC0
		public static IEnumerator InteractualConPiezaConAnimacionRutina(MonoBehaviour mono, SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar datos, ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable> par, Side side, bool forzar, Object by, bool puedeUsarLMano, bool puedeUsarRMano, Action changeSide, Action OnFinish)
		{
			if (!puedeUsarLMano && !puedeUsarRMano)
			{
				yield return SequencerCommandMostrarParteCurrentClickedSend.InteractualConPiezaConAnimacionRutinaGenerico(mono, datos, par.Item1.stringId, side, forzar, by, puedeUsarLMano, puedeUsarRMano, changeSide, null);
				if (OnFinish != null)
				{
					OnFinish();
				}
				yield break;
			}
			GuiaDeRopaInteractable item = par.Item2;
			GuiaDeRopaInteractable item2 = par.Item3;
			GuiaDeRopaInteractable interactable;
			RopaInteractableInteraccion inter;
			GenericAgarranteObjeto agarrante;
			if (puedeUsarLMano && puedeUsarRMano)
			{
				switch (side)
				{
				case Side.L:
					if (item2 != null)
					{
						changeSide();
						interactable = item2;
						inter = datos.interaccionL;
						agarrante = datos.agarranteManoL;
						goto IL_028B;
					}
					interactable = item;
					inter = datos.interaccionR;
					agarrante = datos.agarranteManoR;
					goto IL_028B;
				case Side.R:
					if (item != null)
					{
						changeSide();
						interactable = item;
						inter = datos.interaccionR;
						agarrante = datos.agarranteManoR;
						goto IL_028B;
					}
					interactable = item2;
					inter = datos.interaccionL;
					agarrante = datos.agarranteManoL;
					goto IL_028B;
				}
				throw new ArgumentOutOfRangeException(side.ToString());
			}
			if (puedeUsarLMano)
			{
				if (item2 != null)
				{
					interactable = item2;
				}
				else
				{
					interactable = item;
				}
				inter = datos.interaccionL;
				agarrante = datos.agarranteManoL;
			}
			else
			{
				if (item != null)
				{
					interactable = item;
				}
				else
				{
					interactable = item2;
				}
				inter = datos.interaccionR;
				agarrante = datos.agarranteManoR;
			}
			IL_028B:
			if (interactable == null || interactable.interactableCon == null)
			{
				yield return SequencerCommandMostrarParteCurrentClickedSend.InteractualConPiezaConAnimacionRutinaGenerico(mono, datos, par.Item1.stringId, side, forzar, by, puedeUsarLMano, puedeUsarRMano, changeSide, null);
				if (OnFinish != null)
				{
					OnFinish();
				}
				yield break;
			}
			inter.interaccion.FolloweOwnerCharacterPose(true);
			inter.FollowStartPose(interactable);
			yield return null;
			if (!inter.interaccion.Ejecutar(2147483647, -1f, ControllerPrioridadConfig.prioridad, 1f, 1f, false))
			{
				yield return SequencerCommandMostrarParteCurrentClickedSend.InteractualConPiezaConAnimacionRutinaGenerico(mono, datos, par.Item1.stringId, side, forzar, by, puedeUsarLMano, puedeUsarRMano, changeSide, null);
				if (OnFinish != null)
				{
					OnFinish();
				}
				yield break;
			}
			while (inter.interaccion.currentEstado.EstadosTimerWeigthPromedio(0f) < 1f)
			{
				yield return null;
			}
			agarrante.ComenzarAgarrar(interactable.start.position);
			interactable.ForzarAgarrante(agarrante);
			inter.StartFollowing(interactable);
			while (inter.w < 1f)
			{
				yield return null;
				agarrante.ActualizarAgarrarPosition(inter.worldPosition);
			}
			if (interactable.currentAgarradoPor == agarrante)
			{
				yield return interactable.EfectuarInteraccion();
			}
			yield return new WaitForSeconds(0.2f);
			agarrante.FinalizarAgarrado();
			inter.StopFollowing();
			yield return new WaitForSeconds(0.333f);
			inter.interaccion.Detener(false);
			yield break;
		}

		// Token: 0x040000A0 RID: 160
		private SequencerCommandQuitarPiezaRopaCurrentClickedSend.DatosDeChar datos;

		// Token: 0x040000A1 RID: 161
		private CoroutineCapsuleMonoGeneric m_CoroutineV2;

		// Token: 0x040000A2 RID: 162
		private BaseCoroutineCapsule<MonoBehaviour>.Contexto m_contexto;

		// Token: 0x040000A3 RID: 163
		private List<string> m_idsEnropaCubre = new List<string>();
	}
}
