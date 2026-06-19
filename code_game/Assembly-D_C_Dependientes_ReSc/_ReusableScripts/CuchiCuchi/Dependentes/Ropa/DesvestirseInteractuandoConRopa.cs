using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ropa.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ropa
{
	// Token: 0x020000FB RID: 251
	public class DesvestirseInteractuandoConRopa
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0001CB33 File Offset: 0x0001AD33
		public bool ejecutandose
		{
			get
			{
				return this.m_CoroutineV2 != null && this.m_CoroutineV2.ejecutandose;
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0001CB4A File Offset: 0x0001AD4A
		public void Init(Character self, Character by)
		{
			this.datos = new DesvestirseInteractuandoConRopa.DatosDeChar();
			this.datos.Load(self, by);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0001CB64 File Offset: 0x0001AD64
		public void Quitar(MonoBehaviour mono, List<string> piezasAQuitar, bool puedeDesvestirse, bool forzar)
		{
			try
			{
				this.datos.piezasAQuitar = piezasAQuitar;
				this.datos.puedeDesvestirse = puedeDesvestirse;
				if (this.datos.EsValidoParaPiezas())
				{
					if (!puedeDesvestirse && !forzar)
					{
						using (List<string>.Enumerator enumerator = piezasAQuitar.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string text = enumerator.Current;
								this.datos.registrdor.TryRegistrarPedido(text, puedeDesvestirse, forzar, this.datos.by);
							}
							return;
						}
					}
					List<MapaDeRopa.RopaData> list = (from id in piezasAQuitar
						select this.datos.RopaParaAvatar.ObtenerData(id) into d
						where d != null
						orderby (int)d.layer descending
						select d).ToList<MapaDeRopa.RopaData>();
					this.m_CoroutineV2 = new CoroutineCapsuleMonoGeneric(mono);
					this.m_contexto = this.m_CoroutineV2.Start(DesvestirseInteractuandoConRopa.RemoverPiezasConAnimacionRutina(mono, this.datos, list, this.datos.registrdor, puedeDesvestirse, forzar, this.datos.by), new float?((float)(15 * list.Count)), null);
					this.m_contexto.onDone += this.M_contexto_onDone;
				}
			}
			finally
			{
				if (!this.ejecutandose)
				{
					this.Destroy();
				}
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0001CD00 File Offset: 0x0001AF00
		public void Quitar(MonoBehaviour mono, List<RopaCubre> aQuitar, bool puedeDesvestirse, bool forzar)
		{
			List<string> list = new List<string>();
			foreach (RopaCubre ropaCubre in aQuitar)
			{
				this.datos.loader.CantidadPiezasCubriendo(ropaCubre, true, list);
			}
			list = list.Distinct<string>().ToList<string>();
			if (list.Count == 0)
			{
				return;
			}
			this.Quitar(mono, list, puedeDesvestirse, forzar);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0001CD84 File Offset: 0x0001AF84
		public void Quitar(MonoBehaviour mono, List<ParteDelCuerpoHumano> cubriendoAQuitar, bool puedeDesvestirse, bool forzar)
		{
			List<RopaCubre> list = cubriendoAQuitar.Select((ParteDelCuerpoHumano p) => p.Parce()).Distinct<RopaCubre>().ToList<RopaCubre>();
			this.Quitar(mono, list, puedeDesvestirse, forzar);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0001CDCC File Offset: 0x0001AFCC
		public void Quitar(MonoBehaviour mono, List<RopaLayer> aQuitar, bool puedeDesvestirse, bool forzar)
		{
			List<string> list = new List<string>();
			foreach (RopaLayer ropaLayer in aQuitar)
			{
				this.datos.loader.CantidadPiezas(ropaLayer, true, list);
			}
			list = list.Distinct<string>().ToList<string>();
			if (list.Count == 0)
			{
				return;
			}
			this.Quitar(mono, list, puedeDesvestirse, forzar);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0001CE50 File Offset: 0x0001B050
		public void Quitar(MonoBehaviour mono, List<RopaPosicion> aQuitar, bool puedeDesvestirse, bool forzar)
		{
			List<string> list = new List<string>();
			foreach (RopaPosicion ropaPosicion in aQuitar)
			{
				this.datos.loader.CantidadPiezas(ropaPosicion, true, list);
			}
			list = list.Distinct<string>().ToList<string>();
			if (list.Count == 0)
			{
				return;
			}
			this.Quitar(mono, list, puedeDesvestirse, forzar);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0001CED4 File Offset: 0x0001B0D4
		public void Mover(MonoBehaviour mono, List<RopaCubre> cubriendoAMover, bool puedeDesvestirse, bool forzar)
		{
			try
			{
				this.datos.cubriendoAMover = cubriendoAMover;
				this.datos.puedeDesvestirse = puedeDesvestirse;
				if (this.datos.EsValidoParaPartes())
				{
					List<string> list = new List<string>();
					foreach (RopaCubre ropaCubre in cubriendoAMover)
					{
						this.datos.loader.CantidadPiezasCubriendo(ropaCubre, true, list);
					}
					list = list.Distinct<string>().ToList<string>();
					if (!puedeDesvestirse && !forzar)
					{
						using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								string text = enumerator2.Current;
								this.datos.registrdor.TryRegistrarPedido(text, puedeDesvestirse, forzar, this.datos.by);
							}
							return;
						}
					}
					(from id in list
						select this.datos.RopaParaAvatar.ObtenerData(id) into d
						where d != null
						orderby (int)d.layer descending
						select d).ToList<MapaDeRopa.RopaData>();
					this.m_CoroutineV2 = new CoroutineCapsuleMonoGeneric(mono);
					this.m_contexto = this.m_CoroutineV2.Start(DesvestirseInteractuandoConRopa.InteractualConCubirendoConAnimacionRutina(mono, this.datos, cubriendoAMover, puedeDesvestirse, forzar, this.datos.by), new float?((float)(15 * list.Count)), null);
					this.m_contexto.onDone += this.M_contexto_onDone;
				}
			}
			finally
			{
				if (!this.ejecutandose)
				{
					this.Destroy();
				}
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0001D0D0 File Offset: 0x0001B2D0
		public void Mover(MonoBehaviour mono, List<ParteDelCuerpoHumano> cubriendoAMover, bool puedeDesvestirse, bool forzar)
		{
			List<RopaCubre> list = cubriendoAMover.Select((ParteDelCuerpoHumano p) => p.Parce()).Distinct<RopaCubre>().ToList<RopaCubre>();
			if (list.Count == 0)
			{
				return;
			}
			this.Mover(mono, list, puedeDesvestirse, forzar);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0001D124 File Offset: 0x0001B324
		public void Update()
		{
			BaseCoroutineCapsule<MonoBehaviour>.Contexto contexto = this.m_contexto;
			bool valueOrDefault = ((contexto != null) ? new bool?(contexto.IsTimeOver()) : null).GetValueOrDefault();
			if (!this.ejecutandose || valueOrDefault)
			{
				this.Destroy();
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0001D16C File Offset: 0x0001B36C
		private void Destroy()
		{
			DesvestirseInteractuandoConRopa.DatosDeChar datosDeChar = this.datos;
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

		// Token: 0x060004DE RID: 1246 RVA: 0x0001D1A5 File Offset: 0x0001B3A5
		private void M_contexto_onDone()
		{
			this.ForzeRemovePiezas();
			this.ForzeMoverPiezas();
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0001D1B4 File Offset: 0x0001B3B4
		private void ForzeRemovePiezas()
		{
			if (this.datos.piezasAQuitar != null)
			{
				for (int i = 0; i < this.datos.piezasAQuitar.Count; i++)
				{
					if (this.datos.loader.manager.piezasPuestasPorId.ContainsKey(this.datos.piezasAQuitar[i]))
					{
						this.datos.loader.RemovePieza(this.datos.piezasAQuitar[i], true, this.datos.by);
					}
				}
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0001D244 File Offset: 0x0001B444
		private void ForzeMoverPiezas()
		{
			if (this.datos.cubriendoAMover != null)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < this.datos.cubriendoAMover.Count; i++)
				{
					try
					{
						if (this.datos.loader.CantidadPiezasCubriendo(this.datos.cubriendoAMover[i], true, list) > 0)
						{
							foreach (string text in list)
							{
								this.datos.loader.RemovePieza(text, true, this.datos.by);
							}
						}
					}
					finally
					{
						list.Clear();
					}
				}
			}
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0001D31C File Offset: 0x0001B51C
		public static IEnumerator InteractualConCubirendoConAnimacionRutina(MonoBehaviour mono, DesvestirseInteractuandoConRopa.DatosDeChar datos, List<RopaCubre> cubriendoAMover, bool puedeDesvestirse, bool forzar, Object by)
		{
			yield return null;
			List<string> m_idsEnropaCubre = new List<string>();
			List<MapaDeRopa.RopaData> tempDeJerarquiaPadres = new List<MapaDeRopa.RopaData>();
			List<ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> piezasInteractableRLPar = new List<ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>>();
			using (List<RopaCubre>.Enumerator enumerator = cubriendoAMover.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					RopaCubre currentPiezaCubre = enumerator.Current;
					try
					{
						datos.loader.CantidadPiezasCubriendo(currentPiezaCubre, true, m_idsEnropaCubre);
						Predicate<MapaDeRopa.RopaData> predicate = (MapaDeRopa.RopaData d) => !((int)d.cubreFlag).HasFlag((int)currentPiezaCubre);
						for (int i = 0; i < m_idsEnropaCubre.Count; i++)
						{
							string text = m_idsEnropaCubre[i];
							MapaDeRopa.RopaData ropaData = datos.RopaParaAvatar.SeleccionarBestSubPrenda(text, predicate);
							if (ropaData == null)
							{
								piezasInteractableRLPar.Add(new ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(datos.RopaParaAvatar.ObtenerData(text), null, null));
							}
							else
							{
								try
								{
									datos.RopaParaAvatar.SeleccionarJerarquiaPadres(text, ropaData.stringId, tempDeJerarquiaPadres);
									if (tempDeJerarquiaPadres.Count == 0)
									{
										piezasInteractableRLPar.Add(new ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(datos.RopaParaAvatar.ObtenerData(text), null, null));
									}
									else
									{
										tempDeJerarquiaPadres.Add(ropaData);
										for (int j = 0; j < tempDeJerarquiaPadres.Count - 1; j++)
										{
											MapaDeRopa.RopaData ropaData2 = tempDeJerarquiaPadres[j];
											MapaDeRopa.RopaData ropaData3 = tempDeJerarquiaPadres[j + 1];
											MapaDeRopa.RopaData.Interacciones interacciones = null;
											MapaDeRopa.RopaData.Interacciones interacciones2 = null;
											for (int k = 0; k < ropaData2.interacciones.Count; k++)
											{
												MapaDeRopa.RopaData.Interacciones interacciones3 = ropaData2.interacciones[k];
												if (interacciones3.subPrendaIDString == ropaData3.stringId)
												{
													string text2 = interacciones3.id.ToString();
													if (text2.EndsWith('L') || text2.EndsWith('l') || text2.EndsWith('F') || text2.EndsWith('f'))
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
												piezasInteractableRLPar.Add(new ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(datos.RopaParaAvatar.ObtenerData(text), null, null));
												break;
											}
											piezasInteractableRLPar.Add(new ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>(ropaData2, (interacciones != null) ? datos.Guias.ObtenerGuia(interacciones.id) : null, (interacciones2 != null) ? datos.Guias.ObtenerGuia(interacciones2.id) : null));
										}
									}
								}
								finally
								{
									tempDeJerarquiaPadres.Clear();
								}
							}
						}
						yield return DesvestirseInteractuandoConRopa.InteractualConPiezasConAnimacionRutina(mono, datos, piezasInteractableRLPar, puedeDesvestirse, forzar, datos.by);
					}
					finally
					{
						piezasInteractableRLPar.Clear();
						m_idsEnropaCubre.Clear();
					}
				}
			}
			List<RopaCubre>.Enumerator enumerator = default(List<RopaCubre>.Enumerator);
			yield break;
			yield break;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0001D348 File Offset: 0x0001B548
		public static IEnumerator InteractualConPiezasConAnimacionRutina(MonoBehaviour mono, DesvestirseInteractuandoConRopa.DatosDeChar datos, List<ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> piezasInteractableRLPar, bool puedeDesvestirse, bool forzar, Object by)
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
					yield return DesvestirseInteractuandoConRopa.InteractualConPiezaConAnimacionRutinaGenerico(mono, datos, valueTuple2.Item1.stringId, side, forzar, by, puedeUsarLMano, puedeUsarRMano, sideChanger, null);
				}
				else
				{
					yield return DesvestirseInteractuandoConRopa.InteractualConPiezaConAnimacionRutina(mono, datos, valueTuple2, side, forzar, by, puedeUsarLMano, puedeUsarRMano, sideChanger, null);
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0001D37C File Offset: 0x0001B57C
		public static IEnumerator InteractualConPiezaConAnimacionRutinaGenerico(MonoBehaviour mono, DesvestirseInteractuandoConRopa.DatosDeChar datos, string piezaId, Side side, bool forzar, Object by, bool puedeUsarLMano, bool puedeUsarRMano, Action changeSide, Action OnFinish)
		{
			List<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> list = new List<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>>();
			DesvestirseInteractuandoConRopa.GetInteractable(datos.Guias, datos.RopaParaAvatar, piezaId, list);
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
				yield return DesvestirseInteractuandoConRopa.InteractuarConInteractable(valueTuple2.Item1, valueTuple2.Item2, i == 0, ejecutadas, null);
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

		// Token: 0x060004E4 RID: 1252 RVA: 0x0001D3D4 File Offset: 0x0001B5D4
		public static IEnumerator InteractualConPiezaConAnimacionRutina(MonoBehaviour mono, DesvestirseInteractuandoConRopa.DatosDeChar datos, ValueTuple<MapaDeRopa.RopaData, GuiaDeRopaInteractable, GuiaDeRopaInteractable> par, Side side, bool forzar, Object by, bool puedeUsarLMano, bool puedeUsarRMano, Action changeSide, Action OnFinish)
		{
			if (!puedeUsarLMano && !puedeUsarRMano)
			{
				yield return DesvestirseInteractuandoConRopa.InteractualConPiezaConAnimacionRutinaGenerico(mono, datos, par.Item1.stringId, side, forzar, by, puedeUsarLMano, puedeUsarRMano, changeSide, null);
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
				yield return DesvestirseInteractuandoConRopa.InteractualConPiezaConAnimacionRutinaGenerico(mono, datos, par.Item1.stringId, side, forzar, by, puedeUsarLMano, puedeUsarRMano, changeSide, null);
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
				yield return DesvestirseInteractuandoConRopa.InteractualConPiezaConAnimacionRutinaGenerico(mono, datos, par.Item1.stringId, side, forzar, by, puedeUsarLMano, puedeUsarRMano, changeSide, null);
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

		// Token: 0x060004E5 RID: 1253 RVA: 0x0001D433 File Offset: 0x0001B633
		public static IEnumerator RemoverPiezasConAnimacionRutina(MonoBehaviour mono, DesvestirseInteractuandoConRopa.DatosDeChar datos, List<MapaDeRopa.RopaData> piezas, EstimulosPorQuitarPrendasDeRopa registrdor, bool puedeDesvestirse, bool forzar, Object by)
		{
			yield return null;
			int num;
			for (int i = 0; i < piezas.Count; i = num + 1)
			{
				yield return DesvestirseInteractuandoConRopa.RemoverPiezaConAnimacionRutina(mono, datos, piezas[i].stringId, registrdor, puedeDesvestirse, forzar, by);
				num = i;
			}
			yield break;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0001D46F File Offset: 0x0001B66F
		public static IEnumerator RemoverPiezaConAnimacionRutina(MonoBehaviour mono, DesvestirseInteractuandoConRopa.DatosDeChar datos, string piezaId, EstimulosPorQuitarPrendasDeRopa registrdor, bool puedeDesvestirse, bool forzar, Object by)
		{
			if (!puedeDesvestirse && !forzar)
			{
				registrdor.TryRegistrarPedido(piezaId, puedeDesvestirse, forzar, by);
				yield break;
			}
			List<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>> interactablesRLB = new List<ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable>>();
			DesvestirseInteractuandoConRopa.GetInteractable(datos.Guias, datos.RopaParaAvatar, piezaId, interactablesRLB);
			bool puedeUsarLMano = datos.InteractionController.IsLHandsFree();
			bool puedeUsarRMano = datos.InteractionController.IsRHandsFree();
			List<RopaInteractableInteraccion> ejecutadas = new List<RopaInteractableInteraccion>();
			int num;
			for (int i = 0; i < interactablesRLB.Count; i = num + 1)
			{
				ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable> valueTuple = interactablesRLB[i];
				yield return DesvestirseInteractuandoConRopa.InteractuarConInteractable2(mono, valueTuple, i == 0, datos.interaccionR, datos.interaccionL, datos.interaccionRL, puedeUsarLMano, puedeUsarRMano, ejecutadas);
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

		// Token: 0x060004E7 RID: 1255 RVA: 0x0001D4AC File Offset: 0x0001B6AC
		public static IEnumerator InteractuarConInteractable2(MonoBehaviour mono, ValueTuple<GuiaDeRopaInteractable, GuiaDeRopaInteractable, GuiaDeRopaInteractable> interactablesRLB, bool isFirst, RopaInteractableInteraccion r, RopaInteractableInteraccion l, RopaInteractableInteraccion rl, bool puedeUsarLMano, bool puedeUsarRMano, List<RopaInteractableInteraccion> ejecutadas)
		{
			GuiaDeRopaInteractable item = interactablesRLB.Item1;
			GuiaDeRopaInteractable item2 = interactablesRLB.Item2;
			GuiaDeRopaInteractable item3 = interactablesRLB.Item3;
			if (puedeUsarLMano && puedeUsarRMano && item3 != null)
			{
				DesvestirseInteractuandoConRopa.<>c__DisplayClass24_0 CS$<>8__locals1 = new DesvestirseInteractuandoConRopa.<>c__DisplayClass24_0();
				CS$<>8__locals1.finiched = false;
				mono.StartCoroutine(DesvestirseInteractuandoConRopa.InteractuarConInteractable(item3, rl, isFirst, ejecutadas, delegate
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
				DesvestirseInteractuandoConRopa.<>c__DisplayClass24_1 CS$<>8__locals2 = new DesvestirseInteractuandoConRopa.<>c__DisplayClass24_1();
				bool flag = puedeUsarLMano && item2 != null;
				bool flag2 = puedeUsarRMano && item != null;
				CS$<>8__locals2.finichedL = false;
				CS$<>8__locals2.finichedR = false;
				if (flag)
				{
					mono.StartCoroutine(DesvestirseInteractuandoConRopa.InteractuarConInteractable(item2, l, isFirst, ejecutadas, delegate
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
					mono.StartCoroutine(DesvestirseInteractuandoConRopa.InteractuarConInteractable(item, r, isFirst, ejecutadas, delegate
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

		// Token: 0x060004E8 RID: 1256 RVA: 0x0001D503 File Offset: 0x0001B703
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

		// Token: 0x060004E9 RID: 1257 RVA: 0x0001D530 File Offset: 0x0001B730
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

		// Token: 0x040003C2 RID: 962
		private DesvestirseInteractuandoConRopa.DatosDeChar datos;

		// Token: 0x040003C3 RID: 963
		private CoroutineCapsuleMonoGeneric m_CoroutineV2;

		// Token: 0x040003C4 RID: 964
		private BaseCoroutineCapsule<MonoBehaviour>.Contexto m_contexto;

		// Token: 0x020000FC RID: 252
		public class DatosDeChar
		{
			// Token: 0x060004ED RID: 1261 RVA: 0x0001D6E8 File Offset: 0x0001B8E8
			public void Load(Character self, Character by)
			{
				this.self = self;
				this.by = by;
				this.registrdor = self.GetComponentEnRoot(true);
				this.loader = self.GetComponentEnRoot(true);
				this.interaccionesDeCharacter = self.GetComponentEnRoot<IInteraccionesDeCharacter>();
				this.Guias = self.GetComponentEnRoot<ControlladorDeGuiasDeInteraccionDeRopa>();
				this.RopaParaAvatar = AsyncSingleton<RopaParaAvatarUnificado>.instance;
				this.InteractionController = self.GetComponentEnRoot<IInteractionController>();
				PuppetMaster componentEnRoot = self.GetComponentEnRoot<PuppetMaster>();
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
				if (componentEnRoot == null)
				{
					genericAgarranteObjeto = null;
				}
				else
				{
					Muscle muscle = componentEnRoot.GetMuscle(HumanBodyBones.RightHand);
					genericAgarranteObjeto = ((muscle != null) ? muscle.rigidbody.GetComponentInChildren<GenericAgarranteObjeto>() : null);
				}
				this.agarranteManoR = genericAgarranteObjeto;
				GenericAgarranteObjeto genericAgarranteObjeto2;
				if (componentEnRoot == null)
				{
					genericAgarranteObjeto2 = null;
				}
				else
				{
					Muscle muscle2 = componentEnRoot.GetMuscle(HumanBodyBones.LeftHand);
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

			// Token: 0x060004EE RID: 1262 RVA: 0x0001D8C0 File Offset: 0x0001BAC0
			public bool EsValidoParaPiezas()
			{
				if (this.registrdor == null)
				{
					Debug.LogError("EstimulosPorQuitarPrendasDeRopa no existe en objeto.");
					return false;
				}
				if (this.piezasAQuitar == null || this.piezasAQuitar.Count == 0)
				{
					Debug.LogError("no hay piezas para quitar");
					return false;
				}
				return true;
			}

			// Token: 0x060004EF RID: 1263 RVA: 0x0001D900 File Offset: 0x0001BB00
			public bool EsValidoParaPartes()
			{
				if (this.loader == null)
				{
					Debug.LogError("ConjuntoDeRopaLoader no existe en objeto.");
					return false;
				}
				if (this.registrdor == null)
				{
					Debug.LogError("EstimulosPorQuitarPrendasDeRopa no existe en objeto.");
					return false;
				}
				if (this.cubriendoAMover == null || this.cubriendoAMover.Count == 0)
				{
					Debug.LogError("no hay cubriendo para mover");
					return false;
				}
				return true;
			}

			// Token: 0x060004F0 RID: 1264 RVA: 0x0001D964 File Offset: 0x0001BB64
			public void Clear()
			{
				this.self = null;
				this.by = null;
				this.registrdor = null;
				this.piezasAQuitar = null;
				this.registrdor = null;
				this.loader = null;
				this.interaccionesDeCharacter = null;
				this.interaccionR = null;
				this.interaccionL = null;
				this.interaccionRL = null;
				this.Guias = null;
				this.RopaParaAvatar = null;
				this.InteractionController = null;
			}

			// Token: 0x040003C5 RID: 965
			public Character self;

			// Token: 0x040003C6 RID: 966
			public Character by;

			// Token: 0x040003C7 RID: 967
			public EstimulosPorQuitarPrendasDeRopa registrdor;

			// Token: 0x040003C8 RID: 968
			public List<string> piezasAQuitar;

			// Token: 0x040003C9 RID: 969
			public List<RopaCubre> cubriendoAMover;

			// Token: 0x040003CA RID: 970
			public bool puedeDesvestirse;

			// Token: 0x040003CB RID: 971
			public ConjuntoDeRopaLoader loader;

			// Token: 0x040003CC RID: 972
			public IInteraccionesDeCharacter interaccionesDeCharacter;

			// Token: 0x040003CD RID: 973
			public RopaInteractableInteraccion interaccionR;

			// Token: 0x040003CE RID: 974
			public RopaInteractableInteraccion interaccionL;

			// Token: 0x040003CF RID: 975
			public RopaInteractableInteraccion interaccionRL;

			// Token: 0x040003D0 RID: 976
			public ControlladorDeGuiasDeInteraccionDeRopa Guias;

			// Token: 0x040003D1 RID: 977
			public IRopaParaAvatar RopaParaAvatar;

			// Token: 0x040003D2 RID: 978
			public IInteractionController InteractionController;

			// Token: 0x040003D3 RID: 979
			public GenericAgarranteObjeto agarranteManoR;

			// Token: 0x040003D4 RID: 980
			public GenericAgarranteObjeto agarranteManoL;
		}
	}
}
