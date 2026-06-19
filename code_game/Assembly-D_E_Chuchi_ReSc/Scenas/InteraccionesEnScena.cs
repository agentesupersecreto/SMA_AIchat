using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Scenas.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Scenas
{
	// Token: 0x020000B9 RID: 185
	public class InteraccionesEnScena : Singleton<InteraccionesEnScena>, ISceneInteractions
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x0000ED6B File Offset: 0x0000CF6B
		public bool isRecording
		{
			get
			{
				return this.m_isRecording;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x0000ED73 File Offset: 0x0000CF73
		public float sceneTime
		{
			get
			{
				return Time.time - this.m_startTime;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x0000ED81 File Offset: 0x0000CF81
		public int sceneFrames
		{
			get
			{
				return Time.frameCount - this.m_startFrame;
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060003E4 RID: 996 RVA: 0x0000ED90 File Offset: 0x0000CF90
		// (remove) Token: 0x060003E5 RID: 997 RVA: 0x0000EDC8 File Offset: 0x0000CFC8
		public event OnCharactersInteractionHandler onInteraction;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060003E6 RID: 998 RVA: 0x0000EE00 File Offset: 0x0000D000
		// (remove) Token: 0x060003E7 RID: 999 RVA: 0x0000EE38 File Offset: 0x0000D038
		public event OnRegisterChangedHandler onRegister;

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000EE6D File Offset: 0x0000D06D
		protected override void DoAwake()
		{
			base.DoAwake();
			this.m_onInteractionCompleted = new InteraccionesEnScena.OnInteractionCompletedHandler(this.OnInteractionCompleted);
			this.m_poolDeInteracciones.IncrementarDeudaBy(5L);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000EE94 File Offset: 0x0000D094
		protected override void OnDestroyingThisDuplicated()
		{
			base.OnDestroyingThisDuplicated();
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000EE9C File Offset: 0x0000D09C
		private void CallOnCombinationEvent(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> combination, InteraccionesEnScena.Interaccion interaction, InteraccionesEnScena.Interaccion result, InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters, InteraccionesEnScena.InteraccionesEntreCharacters.Stacked sender)
		{
			OnRegisterChangedHandler onRegisterChangedHandler = this.onRegister;
			if (onRegisterChangedHandler == null)
			{
				return;
			}
			onRegisterChangedHandler(ref result.toReport, sender, interaccionesEntreCharacters.from.sceneCharacter, interaccionesEntreCharacters.to.sceneCharacter, this);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000EECF File Offset: 0x0000D0CF
		public void StartRecording()
		{
			this.Clear();
			this.m_isRecording = true;
			this.m_startTime = Time.time;
			this.m_startFrame = Time.frameCount;
			this.m_sceneDate = Singleton<TiempoDeJuego>.instance.tiempoActual;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000EF04 File Offset: 0x0000D104
		public ICharactersSceneInteractions GetTakingPlaceInteractions(SceneCharacter from, SceneCharacter to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (from == null || to == null || !this.TryGetInteractionesEntreChars(from.ID, to.ID, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.bufferedInteraccion;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0000EF45 File Offset: 0x0000D145
		public ICharactersSceneInteractions GetTakingPlaceInteractionsNotNull(SceneCharacter from, SceneCharacter to)
		{
			if (from == null || to == null)
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return this.GetInteractionesNotNullEntreChars(from.GetComponent<ICharacterUnico>(), to.GetComponent<ICharacterUnico>()).bufferedInteraccion;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000EF78 File Offset: 0x0000D178
		public ICharactersSceneInteractionsArchived GetMainArchivedInteractions(Guid from, Guid to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (!this.TryGetInteractionesEntreChars(ref from, ref to, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedMain;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000EFA0 File Offset: 0x0000D1A0
		public ICharactersSceneInteractionsArchived GetSecondaryArchivedInteractions(Guid from, Guid to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (!this.TryGetInteractionesEntreChars(ref from, ref to, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedSec;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000EFC8 File Offset: 0x0000D1C8
		public ICharactersSceneInteractionsArchived GetMainAndSecondaryArchivedInteractions(Guid from, Guid to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (!this.TryGetInteractionesEntreChars(ref from, ref to, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedMainSec;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0000EFEF File Offset: 0x0000D1EF
		public ICharactersSceneInteractionsArchived GetMainAndSecondaryArchivedInteractionsNotNull(SceneCharacter from, SceneCharacter to)
		{
			if (from == null || to == null)
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return this.GetInteractionesNotNullEntreChars(from.GetComponent<ICharacterUnico>(), to.GetComponent<ICharacterUnico>()).stackedMainSec;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000F020 File Offset: 0x0000D220
		public ICharactersSceneInteractionsArchived GetMainArchivedInteractions(SceneCharacter from, SceneCharacter to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (from == null || to == null || !this.TryGetInteractionesEntreChars(from.ID, to.ID, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedMain;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000F064 File Offset: 0x0000D264
		public ICharactersSceneInteractionsArchived GetSecondaryArchivedInteractions(SceneCharacter from, SceneCharacter to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (from == null || to == null || !this.TryGetInteractionesEntreChars(from.ID, to.ID, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedSec;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000F0A8 File Offset: 0x0000D2A8
		public ICharactersSceneInteractionsArchived GetMainAndSecondaryArchivedInteractions(SceneCharacter from, SceneCharacter to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (from == null || to == null || !this.TryGetInteractionesEntreChars(from.ID, to.ID, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedMainSec;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000F0EC File Offset: 0x0000D2EC
		public ICharactersSceneInteractions GetTakingPlaceInteractions(ICharacterUnico from, ICharacterUnico to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (from == null || to == null || !this.TryGetInteractionesEntreChars(from.ID_Unico, to.ID_Unico, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.bufferedInteraccion;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000F121 File Offset: 0x0000D321
		public ICharactersSceneInteractions GetTakingPlaceInteractionsNotNull(ICharacterUnico from, ICharacterUnico to)
		{
			if (from == null || to == null)
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return this.GetInteractionesNotNullEntreChars(from, to).bufferedInteraccion;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000F13C File Offset: 0x0000D33C
		public ICharactersSceneInteractionsArchived GetMainArchivedInteractions(ICharacterUnico from, ICharacterUnico to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (from == null || to == null || !this.TryGetInteractionesEntreChars(from.ID_Unico, to.ID_Unico, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedMain;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000F174 File Offset: 0x0000D374
		public ICharactersSceneInteractionsArchived GetSecondaryArchivedInteractions(ICharacterUnico from, ICharacterUnico to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (from == null || to == null || !this.TryGetInteractionesEntreChars(from.ID_Unico, to.ID_Unico, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedSec;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000F1AC File Offset: 0x0000D3AC
		public ICharactersSceneInteractionsArchived GetMainAndSecondaryArchivedInteractions(ICharacterUnico from, ICharacterUnico to)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (from == null || to == null || !this.TryGetInteractionesEntreChars(from.ID_Unico, to.ID_Unico, out interaccionesEntreCharacters))
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return interaccionesEntreCharacters.stackedMainSec;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000F1E1 File Offset: 0x0000D3E1
		public ICharactersSceneInteractionsArchived GetMainAndSecondaryArchivedInteractionsNotNull(ICharacterUnico from, ICharacterUnico to)
		{
			if (from == null || to == null)
			{
				return EmptyCharactersSceneInteractions.Instance;
			}
			return this.GetInteractionesNotNullEntreChars(from, to).stackedMainSec;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000F1FC File Offset: 0x0000D3FC
		public void EndRecordign()
		{
			this.m_isRecording = false;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000F208 File Offset: 0x0000D408
		public void Clear()
		{
			for (int i = 0; i < this.m_todasLasInteraccionesEntreCharacters.Count; i++)
			{
				this.m_todasLasInteraccionesEntreCharacters[i].Dispose();
			}
			this.m_todasLasInteraccionesEntreCharacters.Clear();
			this.m_indexDePar.Clear();
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0000F254 File Offset: 0x0000D454
		public void UpdateBuffered()
		{
			for (int i = 0; i < this.m_todasLasInteraccionesEntreCharacters.Count; i++)
			{
				InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters = this.m_todasLasInteraccionesEntreCharacters[i];
				interaccionesEntreCharacters.bufferedInteraccion.RemoveTimeOut(interaccionesEntreCharacters.frameInteraccion, interaccionesEntreCharacters, this.m_onInteractionCompleted);
				interaccionesEntreCharacters.frameInteraccion.Clear();
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0000F2A8 File Offset: 0x0000D4A8
		public void Registrar(ICharacterUnico from, SceneCharacter fromSceneCharacter, ICharacterUnico to, SceneCharacter toSceneCharacter, ICalculoDeEstimuloCompleto calculo)
		{
			if (!this.m_isRecording)
			{
				return;
			}
			if (calculo.emocion.reaccion == ReaccionHumana.desHielo)
			{
				return;
			}
			if (calculo.tipo != TipoDeCalculoDeEstimulo.frame && calculo.emocion.reaccion != ReaccionHumana.concentToHero)
			{
				return;
			}
			if (calculo.estimulanteParte == ParteQuePuedeEstimular.None)
			{
				throw new NotImplementedException();
			}
			if (calculo == null || from == null || to == null || toSceneCharacter == null || fromSceneCharacter == null)
			{
				throw new ArgumentNullException();
			}
			if (from == to || fromSceneCharacter == toSceneCharacter)
			{
				throw new ArgumentNullException();
			}
			Emotion emotion;
			if (!calculo.emocion.reaccion.TryParse(out emotion))
			{
				return;
			}
			this.RegistrarEstimulo(from, fromSceneCharacter, to, toSceneCharacter, calculo, emotion, calculo.estimuloBasico, calculo.estimulanteParte);
			if (calculo.estimuloBasico.tieneCopiaInvertida && calculo.estimulanteParteInvertido != ParteQuePuedeEstimular.None)
			{
				this.RegistrarEstimulo(to, toSceneCharacter, from, fromSceneCharacter, calculo, emotion, calculo.estimuloInvertidoBasico, calculo.estimulanteParteInvertido);
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0000F398 File Offset: 0x0000D598
		private void RegistrarEstimulo(ICharacterUnico from, SceneCharacter fromSceneCharacter, ICharacterUnico to, SceneCharacter toSceneCharacter, ICalculoDeEstimuloConEstado calculo, Emotion emotion, InteracionEstimulanteBasica estimulo, ParteQuePuedeEstimular estimulante)
		{
			TipoDeEstimulo tipoDeEstimulo = estimulo.tipoDeEstimulo;
			if (tipoDeEstimulo == TipoDeEstimulo.None)
			{
				throw new NotSupportedException();
			}
			if (tipoDeEstimulo == TipoDeEstimulo.tactil)
			{
				this.RegistrarTactiles(from, fromSceneCharacter, to, toSceneCharacter, calculo, emotion, estimulo, estimulante);
				return;
			}
			if (tipoDeEstimulo != TipoDeEstimulo.coital)
			{
				this.RegistrarGeneric(from, fromSceneCharacter, to, toSceneCharacter, calculo, emotion, estimulo, estimulante);
				return;
			}
			this.RegistrarCoitales(from, fromSceneCharacter, to, toSceneCharacter, calculo, emotion, estimulo, estimulante);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0000F3FC File Offset: 0x0000D5FC
		private void RegistrarTactiles(ICharacterUnico from, SceneCharacter fromSceneCharacter, ICharacterUnico to, SceneCharacter toSceneCharacter, ICalculoDeEstimuloConEstado calculo, Emotion emotion, InteracionEstimulanteBasica estimulo, ParteQuePuedeEstimular estimulante)
		{
			if (!calculo.esSingleEstado)
			{
				Debug.LogError("no se puede procesar la cantidad real de estados", this);
			}
			UmbralBasico.Estado estado;
			calculo.GetSingleEstado(out estado);
			InterationReceivedType? interationReceivedType = null;
			int? num = null;
			if (estimulo is EstimuloTactilDeSemen)
			{
				EstimuloTactilDeSemen estimuloTactilDeSemen = (EstimuloTactilDeSemen)estimulo;
				num = new int?((int)estimuloTactilDeSemen.tipoDeSemen);
				TipoDeEstimuloTactil tipoDeEstimuloTactil = estimuloTactilDeSemen.tipoDeEstimuloTactil;
				if (tipoDeEstimuloTactil != TipoDeEstimuloTactil.derramamientoSobre)
				{
					if (tipoDeEstimuloTactil == TipoDeEstimuloTactil.derramamientoDentro)
					{
						interationReceivedType = new InterationReceivedType?(InterationReceivedType.pouringIn);
					}
				}
				else
				{
					interationReceivedType = new InterationReceivedType?(InterationReceivedType.pouringOn);
				}
			}
			else if (estimulo is EstimuloTactil)
			{
				EstimuloTactil estimuloTactil = (EstimuloTactil)estimulo;
				TipoDeEstimuloTactilInvertido tipoDeEstimuloTactilInvertido = estimuloTactil.tipoDeEstimuloTactilInvertido;
				if (tipoDeEstimuloTactilInvertido != TipoDeEstimuloTactilInvertido.None)
				{
					if (tipoDeEstimuloTactilInvertido != TipoDeEstimuloTactilInvertido.massage)
					{
						if (tipoDeEstimuloTactilInvertido != TipoDeEstimuloTactilInvertido.handjob)
						{
							throw new ArgumentOutOfRangeException(estimuloTactil.tipoDeEstimuloTactilInvertido.ToString());
						}
						interationReceivedType = new InterationReceivedType?(InterationReceivedType.handJob);
						num = new int?(-1);
					}
					else
					{
						interationReceivedType = new InterationReceivedType?(InterationReceivedType.caress);
						num = new int?(-1);
					}
				}
				else
				{
					interationReceivedType = null;
				}
			}
			this.RegistrarMultiple(estimulo.partesDelCuerpoHumanoEstimuladas, from, fromSceneCharacter, to, toSceneCharacter, calculo, estimulo, estimulante, num, interationReceivedType, emotion, ref estado);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0000F51C File Offset: 0x0000D71C
		private void RegistrarCoitales(ICharacterUnico from, SceneCharacter fromSceneCharacter, ICharacterUnico to, SceneCharacter toSceneCharacter, ICalculoDeEstimuloConEstado calculo, Emotion emotion, InteracionEstimulanteBasica estimulo, ParteQuePuedeEstimular estimulante)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.PartePrincipalEstimulada(estimulo);
			int num = (int)((estimulo.tipo == DireccionDeEstimulo.dada) ? parteDelCuerpoHumano.ObtenerTipoDeEstimuloCoitalInvertido() : ((TipoDeEstimuloCoital)estimulante.ObtenerTipoDeEstimulo(estimulo.tipoDeEstimulo, parteDelCuerpoHumano, calculo.tag == "golpe", estimulo)));
			InterationReceivedType interationReceivedType = estimulo.tipoDeEstimulo.GetInterationReceivedType(num, estimulo.tipo, parteDelCuerpoHumano, estimulante);
			for (int i = 0; i < calculo.cantidadDeEstados; i++)
			{
				TipoDeEstimuloCoitalSegundaria tipoDeEstimuloCoitalSegundaria = calculo.ObtenerTipoDeEstimuloCoitalSegundaria(i);
				if (tipoDeEstimuloCoitalSegundaria != TipoDeEstimuloCoitalSegundaria.None && tipoDeEstimuloCoitalSegundaria != TipoDeEstimuloCoitalSegundaria.movimientoDeCentro && tipoDeEstimuloCoitalSegundaria != TipoDeEstimuloCoitalSegundaria.apertura)
				{
					SensitiveFemaleHoleType sensitiveFemaleHoleType;
					switch (tipoDeEstimuloCoitalSegundaria)
					{
					case TipoDeEstimuloCoitalSegundaria.velocidad:
						sensitiveFemaleHoleType = SensitiveFemaleHoleType.hole;
						break;
					case TipoDeEstimuloCoitalSegundaria.apertura:
					case TipoDeEstimuloCoitalSegundaria.movimientoDeCentro:
						goto IL_00AD;
					case TipoDeEstimuloCoitalSegundaria.profundidad:
						sensitiveFemaleHoleType = SensitiveFemaleHoleType.bottom;
						break;
					case TipoDeEstimuloCoitalSegundaria.anchura:
						sensitiveFemaleHoleType = SensitiveFemaleHoleType.walls;
						break;
					default:
						goto IL_00AD;
					}
					UmbralBasico.Estado estado;
					calculo.GetEstadoCopia(i, out estado);
					SensitiveBodyPart sensitiveBodyPart = ((estimulo.tipo == DireccionDeEstimulo.recibida) ? ModdingParser.GetHolePart(parteDelCuerpoHumano, sensitiveFemaleHoleType) : parteDelCuerpoHumano.GetPart());
					TriggeringBodyPart partComplete = estimulante.GetPartComplete(estimulo.tipo, estimulo.tipoDeEstimulo, num, estimulo.GetRealEstimulante, true);
					this.RegistrarSingle(from, fromSceneCharacter, to, toSceneCharacter, calculo, estimulo, partComplete, sensitiveBodyPart, interationReceivedType, emotion, ref estado, 1);
					goto IL_011E;
					IL_00AD:
					throw new ArgumentOutOfRangeException(tipoDeEstimuloCoitalSegundaria.ToString());
				}
				IL_011E:;
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000F658 File Offset: 0x0000D858
		private void RegistrarGeneric(ICharacterUnico from, SceneCharacter fromSceneCharacter, ICharacterUnico to, SceneCharacter toSceneCharacter, ICalculoDeEstimuloConEstado calculo, Emotion emotion, InteracionEstimulanteBasica estimulo, ParteQuePuedeEstimular estimulante)
		{
			if (!calculo.esSingleEstado)
			{
				Debug.LogError("no se puede procesar la cantidad real de estados", this);
			}
			UmbralBasico.Estado estado;
			calculo.GetSingleEstado(out estado);
			this.RegistrarMultiple(estimulo.partesDelCuerpoHumanoEstimuladas, from, fromSceneCharacter, to, toSceneCharacter, calculo, estimulo, estimulante, null, null, emotion, ref estado);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000F6B0 File Offset: 0x0000D8B0
		private void RegistrarMultiple(IReadOnlyList<ParteDelCuerpoHumano> estimuladas, ICharacterUnico from, SceneCharacter fromSceneCharacter, ICharacterUnico to, SceneCharacter toSceneCharacter, ICalculoDeEstimulo calculo, InteracionEstimulanteBasica estimulo, ParteQuePuedeEstimular estimulante, int? overrideSubtipo, InterationReceivedType? overrideInterationReceivedType, Emotion emotion, ref UmbralBasico.Estado estado)
		{
			for (int i = 0; i < estimuladas.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = estimuladas[i];
				int num = overrideSubtipo ?? estimulante.ObtenerTipoDeEstimulo(estimulo.tipoDeEstimulo, parteDelCuerpoHumano, calculo.tag == "golpe", estimulo);
				InterationReceivedType interationReceivedType = overrideInterationReceivedType ?? estimulo.tipoDeEstimulo.GetInterationReceivedType(num, estimulo.tipo, parteDelCuerpoHumano, estimulante);
				SensitiveBodyPart part = parteDelCuerpoHumano.GetPart();
				TriggeringBodyPart partComplete = estimulante.GetPartComplete(estimulo.tipo, estimulo.tipoDeEstimulo, num, estimulo.GetRealEstimulante, true);
				this.RegistrarSingle(from, fromSceneCharacter, to, toSceneCharacter, calculo, estimulo, partComplete, part, interationReceivedType, emotion, ref estado, estimuladas.Count);
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000F78C File Offset: 0x0000D98C
		public static void GenericParser(InteracionEstimulanteBasica estimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular estimulante, bool esGolpe, SensitiveFemaleHoleType? siParteDelCuerpoHumanoEsHole, out InterationReceivedType interationReceivedType, out SensitiveBodyPart sensitiveBodyPart, out TriggeringBodyPart triggeringBodyPart)
		{
			TipoDeEstimulo tipoDeEstimulo = estimulo.tipoDeEstimulo;
			if (tipoDeEstimulo == TipoDeEstimulo.None)
			{
				throw new NotSupportedException();
			}
			if (tipoDeEstimulo != TipoDeEstimulo.tactil)
			{
				if (tipoDeEstimulo == TipoDeEstimulo.coital)
				{
					if (siParteDelCuerpoHumanoEsHole != null)
					{
						int num = (int)((estimulo.tipo == DireccionDeEstimulo.dada) ? parteDelCuerpoHumano.ObtenerTipoDeEstimuloCoitalInvertido() : ((TipoDeEstimuloCoital)estimulante.ObtenerTipoDeEstimulo(estimulo.tipoDeEstimulo, parteDelCuerpoHumano, esGolpe, estimulo)));
						interationReceivedType = estimulo.tipoDeEstimulo.GetInterationReceivedType(num, estimulo.tipo, parteDelCuerpoHumano, estimulante);
						sensitiveBodyPart = ((estimulo.tipo == DireccionDeEstimulo.recibida) ? ModdingParser.GetHolePart(parteDelCuerpoHumano, siParteDelCuerpoHumanoEsHole.Value) : parteDelCuerpoHumano.GetPart());
						triggeringBodyPart = estimulante.GetPartComplete(estimulo.tipo, estimulo.tipoDeEstimulo, num, estimulo.GetRealEstimulante, false);
						return;
					}
				}
				int num2 = estimulante.ObtenerTipoDeEstimulo(estimulo.tipoDeEstimulo, parteDelCuerpoHumano, esGolpe, estimulo);
				interationReceivedType = estimulo.tipoDeEstimulo.GetInterationReceivedType(num2, estimulo.tipo, parteDelCuerpoHumano, estimulante);
				sensitiveBodyPart = parteDelCuerpoHumano.GetPart();
				triggeringBodyPart = estimulante.GetPartComplete(estimulo.tipo, estimulo.tipoDeEstimulo, num2, estimulo.GetRealEstimulante, false);
				return;
			}
			InterationReceivedType? interationReceivedType2 = null;
			int? num3 = null;
			if (estimulo is EstimuloTactilDeSemen)
			{
				EstimuloTactilDeSemen estimuloTactilDeSemen = (EstimuloTactilDeSemen)estimulo;
				num3 = new int?((int)estimuloTactilDeSemen.tipoDeSemen);
				TipoDeEstimuloTactil tipoDeEstimuloTactil = estimuloTactilDeSemen.tipoDeEstimuloTactil;
				if (tipoDeEstimuloTactil != TipoDeEstimuloTactil.derramamientoSobre)
				{
					if (tipoDeEstimuloTactil == TipoDeEstimuloTactil.derramamientoDentro)
					{
						interationReceivedType2 = new InterationReceivedType?(InterationReceivedType.pouringIn);
					}
				}
				else
				{
					interationReceivedType2 = new InterationReceivedType?(InterationReceivedType.pouringOn);
				}
			}
			else if (estimulo is EstimuloTactil)
			{
				EstimuloTactil estimuloTactil = (EstimuloTactil)estimulo;
				TipoDeEstimuloTactilInvertido tipoDeEstimuloTactilInvertido = estimuloTactil.tipoDeEstimuloTactilInvertido;
				if (tipoDeEstimuloTactilInvertido != TipoDeEstimuloTactilInvertido.None)
				{
					if (tipoDeEstimuloTactilInvertido != TipoDeEstimuloTactilInvertido.massage)
					{
						if (tipoDeEstimuloTactilInvertido != TipoDeEstimuloTactilInvertido.handjob)
						{
							throw new ArgumentOutOfRangeException(estimuloTactil.tipoDeEstimuloTactilInvertido.ToString());
						}
						interationReceivedType2 = new InterationReceivedType?(InterationReceivedType.handJob);
						num3 = new int?(-1);
					}
					else
					{
						interationReceivedType2 = new InterationReceivedType?(InterationReceivedType.caress);
						num3 = new int?(-1);
					}
				}
				else
				{
					interationReceivedType2 = null;
				}
			}
			int num4 = num3 ?? estimulante.ObtenerTipoDeEstimulo(estimulo.tipoDeEstimulo, parteDelCuerpoHumano, esGolpe, estimulo);
			interationReceivedType = interationReceivedType2 ?? estimulo.tipoDeEstimulo.GetInterationReceivedType(num4, estimulo.tipo, parteDelCuerpoHumano, estimulante);
			sensitiveBodyPart = parteDelCuerpoHumano.GetPart();
			triggeringBodyPart = estimulante.GetPartComplete(estimulo.tipo, estimulo.tipoDeEstimulo, num4, estimulo.GetRealEstimulante, estimulo is EstimuloTactilDeSemen);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000F9E0 File Offset: 0x0000DBE0
		public static void GenericParser(TipoDeEstimulo tipo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular estimulante, DireccionDeEstimulo direccion, out InterationReceivedType interationReceivedType, out SensitiveBodyPart sensitiveBodyPart, out TriggeringBodyPart triggeringBodyPart)
		{
			int num = estimulante.ObtenerTipoDeEstimulo(tipo, parteDelCuerpoHumano, false, null);
			interationReceivedType = tipo.GetInterationReceivedType(num, direccion, parteDelCuerpoHumano, estimulante);
			sensitiveBodyPart = parteDelCuerpoHumano.GetPart();
			triggeringBodyPart = estimulante.GetPartComplete(direccion, tipo, num, null, false);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000FA1C File Offset: 0x0000DC1C
		private void RegistrarSingle(ICharacterUnico from, SceneCharacter fromSceneCharacter, ICharacterUnico to, SceneCharacter toSceneCharacter, ICalculoDeEstimulo calculo, InteracionEstimulanteBasica estimulo, TriggeringBodyPart triggeringBodyPart, SensitiveBodyPart sensitiveBodyPart, InterationReceivedType interationReceivedType, Emotion emotion, ref UmbralBasico.Estado estado, int cantidadDePartesEstimuladas)
		{
			InteraccionesEnScena.InteraccionesEntreCharacters interactionesNotNullEntreChars = this.GetInteractionesNotNullEntreChars(from, to);
			ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(triggeringBodyPart, sensitiveBodyPart, interationReceivedType, emotion, calculo.causoMaxValue);
			InteraccionesEnScena.Interaccion interaccion;
			if (interactionesNotNullEntreChars.bufferedInteraccion.IsBuffered(valueTuple, out interaccion))
			{
				InteraccionesEnScena.Interaccion interaccion2 = this.ProducirNewInteraccion(calculo, from, to, fromSceneCharacter, toSceneCharacter, ref valueTuple, ref estado, cantidadDePartesEstimuladas);
				if (interactionesNotNullEntreChars.frameInteraccion.Contains(valueTuple))
				{
					interactionesNotNullEntreChars.bufferedInteraccion.StackDuplicated(calculo as ICalculoDeEstimuloBuffeador, interaccion, interaccion2, ref estado, cantidadDePartesEstimuladas);
				}
				else
				{
					interactionesNotNullEntreChars.bufferedInteraccion.Stack(calculo as ICalculoDeEstimuloBuffeador, interaccion, interaccion2, ref estado, cantidadDePartesEstimuladas);
				}
				this.m_poolDeInteracciones.ReturnItem(interaccion2);
			}
			else
			{
				this.RegistrarNewInteraction(calculo, estimulo, interactionesNotNullEntreChars, from, to, fromSceneCharacter, toSceneCharacter, ref valueTuple, ref estado, cantidadDePartesEstimuladas);
			}
			interactionesNotNullEntreChars.frameInteraccion.Add(valueTuple);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000FADC File Offset: 0x0000DCDC
		private void RegistrarNewInteraction(ICalculoDeEstimulo calculo, InteracionEstimulanteBasica estimulo, InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters, ICharacterUnico from, ICharacterUnico to, SceneCharacter fromSceneCharacter, SceneCharacter toSceneCharacter, ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, ref UmbralBasico.Estado estado, int cantidadDePartesEstimuladas)
		{
			if (fromSceneCharacter == null)
			{
				throw new ArgumentNullException("fromSceneCharacter", "fromSceneCharacter null reference.");
			}
			if (toSceneCharacter == null)
			{
				throw new ArgumentNullException("toSceneCharacter", "toSceneCharacter null reference.");
			}
			InteraccionesEnScena.Interaccion interaccion = this.ProducirNewInteraccion(calculo, from, to, fromSceneCharacter, toSceneCharacter, ref key, ref estado, cantidadDePartesEstimuladas);
			Guid estimuloID = estimulo.estimuloID;
			interaccionesEntreCharacters.bufferedInteraccion.Add(ref key, interaccion, ref estimuloID);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000FB4C File Offset: 0x0000DD4C
		private InteraccionesEnScena.Interaccion ProducirNewInteraccion(ICalculoDeEstimulo calculo, ICharacterUnico from, ICharacterUnico to, SceneCharacter fromSceneCharacter, SceneCharacter toSceneCharacter, ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, ref UmbralBasico.Estado estado, int cantidadDePartesEstimuladas)
		{
			if (fromSceneCharacter == null)
			{
				throw new ArgumentNullException("fromSceneCharacter", "fromSceneCharacter null reference.");
			}
			if (toSceneCharacter == null)
			{
				throw new ArgumentNullException("toSceneCharacter", "toSceneCharacter null reference.");
			}
			InteraccionesEnScena.Interaccion item = this.m_poolDeInteracciones.GetItem();
			item.Initiate(from, to);
			ICalculoDeEstimuloBuffeador calculoDeEstimuloBuffeador = calculo as ICalculoDeEstimuloBuffeador;
			item.canProduceBuff = ((calculoDeEstimuloBuffeador != null) ? new bool?(calculoDeEstimuloBuffeador.canProduceBuff) : null).GetValueOrDefault(true);
			item.toReport.fromID = fromSceneCharacter.ID.ToString();
			item.toReport.toID = toSceneCharacter.ID.ToString();
			item.toReport.fromPart = key.Item1;
			item.toReport.toPart = key.Item2;
			item.toReport.interationReceivedType = key.Item3;
			item.toReport.emotion = key.Item4;
			item.toReport.date = this.m_sceneDate;
			item.toReport.times = 1;
			item.toReport.stacks = 1;
			item.toReport.startTime = this.sceneTime;
			item.toReport.endTime = this.sceneTime + Time.deltaTime;
			item.toReport.startFrame = this.sceneFrames;
			item.toReport.endFrame = this.sceneFrames + 1;
			item.toReport.emotionAtMaxValueTimes = (calculo.emocion.valueAtMax ? 1 : 0);
			item.toReport.triggerMaxValueTimes = (calculo.causoMaxValue ? 1 : 0);
			item.toReport.damagePercentageDone = estado.estimulacionGeneradaEnFrame / (float)cantidadDePartesEstimuladas;
			item.toReport.overshootOrUndershootTotal = estado.offsetMod;
			item.toReport.damageScoreTotal = estado.spotScore.SpotScoreToWeight();
			return item;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000FD40 File Offset: 0x0000DF40
		private bool TryGetInteractionesEntreChars(ref Guid from, ref Guid to, out InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters)
		{
			ValueTuple<Guid, Guid> valueTuple = new ValueTuple<Guid, Guid>(from, to);
			return this.TryGetInteractionesEntreChars(ref valueTuple, out interaccionesEntreCharacters);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000FD6C File Offset: 0x0000DF6C
		private bool TryGetInteractionesEntreChars(Guid from, Guid to, out InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters)
		{
			ValueTuple<Guid, Guid> valueTuple = new ValueTuple<Guid, Guid>(from, to);
			return this.TryGetInteractionesEntreChars(ref valueTuple, out interaccionesEntreCharacters);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000FD8C File Offset: 0x0000DF8C
		private bool TryGetInteractionesEntreChars([TupleElementNames(new string[] { "from", "to" })] ref ValueTuple<Guid, Guid> key, out InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters)
		{
			int num;
			if (!this.m_indexDePar.TryGetValue(key, out num))
			{
				interaccionesEntreCharacters = null;
				return false;
			}
			interaccionesEntreCharacters = this.m_todasLasInteraccionesEntreCharacters[num];
			return true;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000FDC4 File Offset: 0x0000DFC4
		private InteraccionesEnScena.InteraccionesEntreCharacters GetInteractionesNotNullEntreChars(ICharacterUnico from, ICharacterUnico to)
		{
			if (from == to)
			{
				throw new InvalidOperationException();
			}
			ValueTuple<Guid, Guid> valueTuple = new ValueTuple<Guid, Guid>(from.ID_Unico, to.ID_Unico);
			int count;
			InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters;
			if (!this.m_indexDePar.TryGetValue(valueTuple, out count))
			{
				interaccionesEntreCharacters = new InteraccionesEnScena.InteraccionesEntreCharacters(this, from, to);
				count = this.m_todasLasInteraccionesEntreCharacters.Count;
				this.m_indexDePar.Add(valueTuple, count);
				this.m_todasLasInteraccionesEntreCharacters.Add(interaccionesEntreCharacters);
			}
			else
			{
				interaccionesEntreCharacters = this.m_todasLasInteraccionesEntreCharacters[count];
			}
			return interaccionesEntreCharacters;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000FE3C File Offset: 0x0000E03C
		private void DEBUG_GenerateStackedRandom(float badInteractionTimesMod = 1f, float goodInteractionTimesMod = 1f, float badEmotionDamageMod = 1f, float goodEmotionDamageMod = 1f)
		{
			Character current = MainChar.current;
			Character current2 = TargetChar.current;
			SceneCharacter component = current.GetComponent<SceneCharacter>();
			SceneCharacter component2 = current2.GetComponent<SceneCharacter>();
			InteraccionesEnScena.InteraccionesEntreCharacters interactionesNotNullEntreChars = this.GetInteractionesNotNullEntreChars(current, current2);
			EmocionesHumanasValues emptyValid = EmocionesHumanasValues.emptyValid;
			foreach (object obj in typeof(InterationReceivedType).GetEnumValoresObject())
			{
				InterationReceivedType interationReceivedType = (InterationReceivedType)obj;
				if (interationReceivedType > InterationReceivedType.None)
				{
					float num;
					float num2;
					switch (interationReceivedType)
					{
					case InterationReceivedType.lookAt:
						num = 10000f;
						num2 = 0.1f;
						break;
					case InterationReceivedType.photoshoot:
						num = 1000f;
						num2 = 1f;
						break;
					case InterationReceivedType.putInFront:
						num = 1000f;
						num2 = 0.1f;
						break;
					case InterationReceivedType.caress:
						num = 2000f * goodInteractionTimesMod;
						num2 = 1f;
						break;
					case InterationReceivedType.kiss:
						num = 200f * goodInteractionTimesMod;
						num2 = 2f;
						break;
					case InterationReceivedType.slap:
						num = 50f * badInteractionTimesMod;
						num2 = 50f;
						break;
					case InterationReceivedType.hump:
						num = 2000f;
						num2 = 0.5f;
						break;
					case InterationReceivedType.poke:
						num = 200f;
						num2 = 2f;
						break;
					case InterationReceivedType.dryhump:
						num = 200f;
						num2 = 2f;
						break;
					case InterationReceivedType.lick:
						num = 500f;
						num2 = 2f;
						break;
					case InterationReceivedType.pouringOn:
						num = 1000f;
						num2 = 10f;
						break;
					case InterationReceivedType.pouringIn:
						num = 1000f;
						num2 = 5f;
						break;
					case InterationReceivedType.punch:
						num = 50f * badInteractionTimesMod;
						num2 = 75f;
						break;
					case InterationReceivedType.penetration:
						num = 1000f;
						num2 = 10f;
						break;
					case InterationReceivedType.fingering:
						num = 100f;
						num2 = 3f;
						break;
					case InterationReceivedType.propped:
						num = 50f;
						num2 = 10f;
						break;
					case InterationReceivedType.expose:
						num = 200f * badInteractionTimesMod;
						num2 = 30f;
						break;
					case InterationReceivedType.askToExpose:
						num = 500f * goodInteractionTimesMod;
						num2 = 1f;
						break;
					case InterationReceivedType.forcePose:
						num = 200f * badInteractionTimesMod;
						num2 = 30f;
						break;
					case InterationReceivedType.askToPose:
						num = 500f * goodInteractionTimesMod;
						num2 = 1f;
						break;
					case InterationReceivedType.manipulateBody:
						num = 200f * badInteractionTimesMod;
						num2 = 30f;
						break;
					case InterationReceivedType.guideBody:
						num = 500f * goodInteractionTimesMod;
						num2 = 1f;
						break;
					default:
						throw new ArgumentOutOfRangeException(interationReceivedType.ToString());
					}
					int num3 = Mathf.FloorToInt(num * Random.Range(0.1f, 1f));
					for (int i = 0; i < num3; i++)
					{
						TriggeringBodyPart triggeringBodyPart = (TriggeringBodyPart)typeof(TriggeringBodyPart).GetEnumRandom();
						SensitiveBodyPart sensitiveBodyPart = (SensitiveBodyPart)typeof(SensitiveBodyPart).GetEnumRandom();
						Emotion emotion = (Emotion)typeof(Emotion).GetEnumRandom();
						if (triggeringBodyPart > TriggeringBodyPart.None && sensitiveBodyPart > SensitiveBodyPart.None && emotion > Emotion.None && EmotionExt.femaleEmotions.Contains(emotion))
						{
							num2 *= (emotion.IsGood() ? goodEmotionDamageMod : badEmotionDamageMod);
							Interaction interaction = default(Interaction);
							interaction.fromID = component.ID.ToString();
							interaction.toID = component2.ID.ToString();
							interaction.fromPart = triggeringBodyPart;
							interaction.toPart = sensitiveBodyPart;
							interaction.interationReceivedType = interationReceivedType;
							interaction.emotion = emotion;
							interaction.date = Singleton<TiempoDeJuego>.instance.now;
							interaction.startTime = this.sceneTime;
							interaction.endTime = this.sceneTime + 10f * Random.value;
							interaction.startFrame = this.sceneFrames;
							interaction.endFrame = this.sceneFrames + Mathf.CeilToInt(interaction.duration * 60f);
							interaction.times = Mathf.CeilToInt(10f * Random.value);
							interaction.damagePercentageDone = num2 * Random.value;
							interaction.overshootOrUndershootTotal = 1f;
							interaction.damageScoreTotal = 0.5f * (float)interaction.times;
							interaction.emotionAtMaxValueTimes = (InteraccionesEnScena.DEBUG_DamageEmotions(emotion, interaction.damagePercentageDone, ref emptyValid) ? 1 : 0);
							interaction.triggerMaxValueTimes = interaction.emotionAtMaxValueTimes;
							InteraccionesEnScena.Interaccion interaccion = new InteraccionesEnScena.Interaccion();
							interaccion.toReport = interaction;
							interaccion.Initiate(current, current2);
							this.OnInteractionCompleted(interactionesNotNullEntreChars, interaccion.GetKey(), interaccion, Guid.NewGuid(), ref emptyValid);
						}
					}
				}
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00010318 File Offset: 0x0000E518
		private static bool DEBUG_DamageEmotions(Emotion emotion, float damage, ref EmocionesHumanasValues emocionesHumanasValues)
		{
			switch (emotion)
			{
			case Emotion.enjoyment:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.alegria, damage);
			case Emotion.relief:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.alivio, damage);
			case Emotion.favorability:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.consentToHero, damage);
			case Emotion.pleasure:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.placer, damage);
			case Emotion.arousal:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.arousal, damage);
			case Emotion.disappointment:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.decepcion, damage);
			case Emotion.rage:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.rage, damage);
			case Emotion.pain:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.dolor, damage);
			case Emotion.fear:
				return InteraccionesEnScena.DEBUG_DamageEmotions(ref emocionesHumanasValues.fear, damage);
			default:
				throw new ArgumentOutOfRangeException(emotion.ToString());
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000103DA File Offset: 0x0000E5DA
		private static bool DEBUG_DamageEmotions(ref float emotionValue, float damage)
		{
			emotionValue += damage / 100f;
			if (emotionValue >= 1f)
			{
				emotionValue = Random.Range(0.05f, 0.75f);
				return true;
			}
			return false;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00010408 File Offset: 0x0000E608
		private void OnInteractionCompleted(InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters, ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, InteraccionesEnScena.Interaccion buffered, Guid Estimulo, ref EmocionesHumanasValues emocionesHumanasValues)
		{
			if (buffered.from == null || buffered.to == null)
			{
				return;
			}
			OnCharactersInteractionHandler onCharactersInteractionHandler = this.onInteraction;
			if (onCharactersInteractionHandler != null)
			{
				onCharactersInteractionHandler(ref buffered.toReport, interaccionesEntreCharacters.bufferedInteraccion, interaccionesEntreCharacters.from.sceneCharacter, interaccionesEntreCharacters.to.sceneCharacter, this);
			}
			if (buffered.canProduceBuff)
			{
				InteraccionesEnScena.Interaccion stackedInteraction = this.GetStackedInteraction(interaccionesEntreCharacters.stackedMain, buffered);
				interaccionesEntreCharacters.stackedMain.Stack(stackedInteraction, buffered, ref Estimulo, ref emocionesHumanasValues);
				return;
			}
			InteraccionesEnScena.Interaccion stackedInteraction2 = this.GetStackedInteraction(interaccionesEntreCharacters.stackedSec, buffered);
			interaccionesEntreCharacters.stackedSec.Stack(stackedInteraction2, buffered, ref Estimulo, ref emocionesHumanasValues);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000104B0 File Offset: 0x0000E6B0
		private InteraccionesEnScena.Interaccion GetStackedInteraction(InteraccionesEnScena.InteraccionesEntreCharacters.Stacked stackedInteractions, InteraccionesEnScena.Interaccion buffered)
		{
			ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(buffered.toReport.fromPart, buffered.toReport.toPart, buffered.toReport.interationReceivedType, buffered.toReport.emotion, buffered.toReport.triggerMaxValue);
			InteraccionesEnScena.Interaccion item;
			if (!stackedInteractions.IsStacked(valueTuple, out item))
			{
				item = this.m_poolDeInteracciones.GetItem();
				item.Initiate(buffered.from, buffered.to);
				item.toReport.fromID = buffered.toReport.fromID;
				item.toReport.toID = buffered.toReport.toID;
				item.toReport.fromPart = buffered.toReport.fromPart;
				item.toReport.toPart = buffered.toReport.toPart;
				item.toReport.interationReceivedType = buffered.toReport.interationReceivedType;
				item.toReport.emotion = buffered.toReport.emotion;
				item.toReport.date = buffered.toReport.date;
				item.toReport.startTime = buffered.toReport.startTime;
				item.toReport.endTime = buffered.toReport.startTime;
				item.toReport.startFrame = buffered.toReport.startFrame;
				item.toReport.endFrame = buffered.toReport.startFrame;
				item.toReport.times = 0;
				item.toReport.stacks = 0;
				item.toReport.emotionAtMaxValueTimes = 0;
				item.toReport.triggerMaxValueTimes = 0;
				item.toReport.damagePercentageDone = 0f;
				item.toReport.overshootOrUndershootTotal = 0f;
				item.toReport.damageScoreTotal = 0f;
				if (!stackedInteractions.Add(valueTuple, item))
				{
					this.m_poolDeInteracciones.ReturnItem(item);
				}
			}
			return item;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00010690 File Offset: 0x0000E890
		private static void AddKeyConbinationsToSingle(InteraccionesEnScena.Interaccion interaction, ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, ref Guid EstimuloID, Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> singleInteractionDeKeyCombinations, Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, Guid> lastIdDeConbinacion, bool canAddTimes, bool fixStartTime, SimplePoolDeClearables<InteraccionesEnScena.Interaccion> poolDeInteracciones, InteraccionesEnScena.OnCombinationHandler onCombination)
		{
			if (key.Item1 == TriggeringBodyPart.All || key.Item2 == SensitiveBodyPart.All || key.Item3 == InterationReceivedType.All || key.Item4 == Emotion.All)
			{
				throw new InvalidOperationException("Key is invalid");
			}
			InteraccionesEnScena.Combonaciones combinacionDeKey = InteraccionesEnScena.GetCombinacionDeKey(ref key);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.aaaa, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.aaab, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.aaba, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.aabb, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.abaa, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.abab, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.abba, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.abbb, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.baaa, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.baab, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.baba, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.babb, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.bbaa, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.bbab, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.bbba, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
			InteraccionesEnScena.addKeyConbinationsToSingle(ref combinacionDeKey.bbbb, interaction, ref EstimuloID, singleInteractionDeKeyCombinations, lastIdDeConbinacion, canAddTimes, fixStartTime, poolDeInteracciones, onCombination);
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00010854 File Offset: 0x0000EA54
		private static void addKeyConbinationsToSingle(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> combination, InteraccionesEnScena.Interaccion interaction, ref Guid EstimuloID, Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> singleInteractionDeKeyCombinations, Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, Guid> lastIdDeConbinacion, bool camAddTimes, bool fixStartTime, SimplePoolDeClearables<InteraccionesEnScena.Interaccion> poolDeInteracciones, InteraccionesEnScena.OnCombinationHandler onCombination)
		{
			bool flag = camAddTimes;
			if (flag && lastIdDeConbinacion != null)
			{
				Guid guid;
				flag = !lastIdDeConbinacion.TryGetValue(combination, out guid) || guid != EstimuloID;
				lastIdDeConbinacion.AddOrReplase(combination, EstimuloID);
			}
			InteraccionesEnScena.Interaccion item;
			if (!singleInteractionDeKeyCombinations.TryGetValue(combination, out item))
			{
				item = poolDeInteracciones.GetItem();
				item.Initiate(interaction.from, interaction.to);
				item.toReport.fromID = interaction.toReport.fromID;
				item.toReport.toID = interaction.toReport.toID;
				item.toReport.fromPart = combination.Item1;
				item.toReport.toPart = combination.Item2;
				item.toReport.interationReceivedType = combination.Item3;
				item.toReport.emotion = combination.Item4;
				item.toReport.date = interaction.toReport.date;
				item.toReport.startTime = interaction.toReport.startTime;
				item.toReport.endTime = interaction.toReport.startTime;
				item.toReport.startFrame = interaction.toReport.startFrame;
				item.toReport.endFrame = interaction.toReport.startFrame;
				item.toReport.times = 1;
				item.toReport.stacks = 0;
				item.toReport.emotionAtMaxValueTimes = 0;
				item.toReport.triggerMaxValueTimes = 0;
				item.toReport.damagePercentageDone = 0f;
				item.toReport.overshootOrUndershootTotal = 0f;
				item.toReport.damageScoreTotal = 0f;
				item.StackOnMe(interaction, false, false);
				singleInteractionDeKeyCombinations.Add(combination, item);
			}
			else
			{
				item.StackOnMe(interaction, flag, fixStartTime);
			}
			if (onCombination != null)
			{
				onCombination(ref combination, interaction, item);
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00010A3C File Offset: 0x0000EC3C
		private static void RemoveKeyConbinationsToSingle(InteraccionesEnScena.Interaccion interaction, ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> singleInteractionDeKeyCombinations, SimplePoolDeClearables<InteraccionesEnScena.Interaccion> poolDeInteracciones)
		{
			if (key.Item1 == TriggeringBodyPart.All || key.Item2 == SensitiveBodyPart.All || key.Item3 == InterationReceivedType.All || key.Item4 == Emotion.All)
			{
				throw new InvalidOperationException("Key is invalid");
			}
			InteraccionesEnScena.Combonaciones combinacionDeKey = InteraccionesEnScena.GetCombinacionDeKey(ref key);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.aaaa, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.aaab, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.aaba, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.aabb, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.abaa, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.abab, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.abba, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.abbb, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.baaa, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.baab, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.baba, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.babb, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.bbaa, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.bbab, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.bbba, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
			InteraccionesEnScena.removeKeyConbinationsToSingle(ref combinacionDeKey.bbbb, interaction, singleInteractionDeKeyCombinations, poolDeInteracciones);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00010B60 File Offset: 0x0000ED60
		private static void removeKeyConbinationsToSingle(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> combination, InteraccionesEnScena.Interaccion interaction, Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> singleInteractionDeKeyCombinations, SimplePoolDeClearables<InteraccionesEnScena.Interaccion> poolDeInteracciones)
		{
			InteraccionesEnScena.Interaccion interaccion;
			if (singleInteractionDeKeyCombinations.TryGetValue(combination, out interaccion))
			{
				if (interaccion.toReport.stacks - interaction.toReport.stacks <= 0)
				{
					singleInteractionDeKeyCombinations.Remove(combination);
					poolDeInteracciones.ReturnItem(interaccion);
					return;
				}
				interaccion.UnStackOnMe(interaction, false);
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00010BB4 File Offset: 0x0000EDB4
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				editorTimeVisible = false,
				text = "toggle recording"
			};
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00010BCD File Offset: 0x0000EDCD
		public override void Aplicar1()
		{
			base.Aplicar1();
			if (this.m_isRecording)
			{
				this.EndRecordign();
				return;
			}
			this.StartRecording();
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00010BEC File Offset: 0x0000EDEC
		public override void Aplicar2()
		{
			base.Aplicar2();
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff;
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff2;
			this.DefaultBuffAndDebuffGenerate(MainChar.current.GetComponent<SceneCharacter>(), TargetChar.current.GetComponent<SceneCharacter>(), false, Singleton<TiempoDeJuego>.instance.now, out sceneCharacterFromToBuffAndDebuff, out sceneCharacterFromToBuffAndDebuff2);
			Debug.LogWarning("---From---");
			sceneCharacterFromToBuffAndDebuff.DebugPrint();
			Debug.LogWarning("---To---");
			sceneCharacterFromToBuffAndDebuff2.DebugPrint();
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00010C48 File Offset: 0x0000EE48
		public override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				text = "Debug Log Buff So Far, (Main Character->Main Target)",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00010C64 File Offset: 0x0000EE64
		public override void Aplicar3()
		{
			base.Aplicar3();
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff;
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff2;
			this.DefaultBuffAndDebuffGenerate(MainChar.current.GetComponent<SceneCharacter>(), TargetChar.current.GetComponent<SceneCharacter>(), false, Singleton<TiempoDeJuego>.instance.now, out sceneCharacterFromToBuffAndDebuff, out sceneCharacterFromToBuffAndDebuff2);
			Debug.LogWarning("---From---");
			sceneCharacterFromToBuffAndDebuff.DebugPrint();
			Debug.LogWarning("---To---");
			sceneCharacterFromToBuffAndDebuff2.DebugPrint();
			sceneCharacterFromToBuffAndDebuff.Apply();
			sceneCharacterFromToBuffAndDebuff2.Apply();
			this.EndRecordign();
			this.StartRecording();
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00010CD8 File Offset: 0x0000EED8
		public override SingletonEditorBotones Boton3()
		{
			return new SingletonEditorBotones
			{
				text = "Debug, Apply And Reset Buff So Far, (Main Character->Main Target)",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00010CF1 File Offset: 0x0000EEF1
		public override void Aplicar4()
		{
			base.Aplicar4();
			this.DEBUG_GenerateStackedRandom(10f, 0.1f, 10f, 0.1f);
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00010D13 File Offset: 0x0000EF13
		public override SingletonEditorBotones Boton4()
		{
			return new SingletonEditorBotones
			{
				text = "Generate Random Interactions (BAD), (Main Character->Main Target)",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00010D2C File Offset: 0x0000EF2C
		public override void Aplicar5()
		{
			base.Aplicar4();
			this.DEBUG_GenerateStackedRandom(0.1f, 10f, 0.1f, 10f);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00010D4E File Offset: 0x0000EF4E
		public override SingletonEditorBotones Boton5()
		{
			return new SingletonEditorBotones
			{
				text = "Generate Random Interactions (GOOD), (Main Character->Main Target)",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00010D67 File Offset: 0x0000EF67
		public void DefaultBuffAndDebuffGenerate(SceneCharacter male, SceneCharacter female, bool sceneAborted, DateTime now, out SceneCharacterFromToBuffAndDebuff maleBuffByInteractions, out SceneCharacterFromToBuffAndDebuff femaleBuffByInteractions)
		{
			maleBuffByInteractions = this.DefaultBuffAndDebuffGenerateForMales(male, female.ID, sceneAborted, now);
			femaleBuffByInteractions = this.DefaultBuffAndDebuffGenerateForFemales(female, male.ID, sceneAborted, now, true);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00010D90 File Offset: 0x0000EF90
		public void DefaultBuffAndDebuffGenerate(SceneCharacter male, Guid female, bool sceneAborted, DateTime now, out SceneCharacterFromToBuffAndDebuff maleBuffByInteractions)
		{
			throw new NotImplementedException("por ahora en jobs no se necesita un job q las female sean desechables");
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00010D9C File Offset: 0x0000EF9C
		public void DefaultBuffAndDebuffGenerate(Guid male, SceneCharacter female, bool sceneAborted, DateTime now, out SceneCharacterFromToBuffAndDebuff femaleBuffByInteractions)
		{
			femaleBuffByInteractions = this.DefaultBuffAndDebuffGenerateForFemales(female, male, sceneAborted, now, false);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00010DB0 File Offset: 0x0000EFB0
		private SceneCharacterFromToBuffAndDebuff DefaultBuffAndDebuffGenerateForFemales(SceneCharacter female, Guid other, bool sceneAborted, DateTime now, bool otherIsPermanentHero)
		{
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff = new SceneCharacterFromToBuffAndDebuff(female);
			sceneCharacterFromToBuffAndDebuff.BuffOnKarma = new Dictionary<ITuple, BuffOnKarma>();
			sceneCharacterFromToBuffAndDebuff.BuffOnPersonalityTrait = new Dictionary<ITuple, BuffOnPersonalityTrait>();
			sceneCharacterFromToBuffAndDebuff.BuffOnDesires = new Dictionary<ITuple, BuffOnDesires>();
			sceneCharacterFromToBuffAndDebuff.BuffOnFavorabilityReqOfInteraction = new Dictionary<ITuple, BuffOnFavorabilityReqOfInteraction>();
			sceneCharacterFromToBuffAndDebuff.BuffOnInteraction = new Dictionary<ITuple, BuffOnInteraction>();
			sceneCharacterFromToBuffAndDebuff.BuffOnEmotionAura = new Dictionary<ITuple, BuffOnEmotionAura>();
			sceneCharacterFromToBuffAndDebuff.BuffOnEmotionTowardCharacter = new Dictionary<ITuple, BuffOnEmotionTowardCharacter>();
			sceneCharacterFromToBuffAndDebuff.BuffOnEmotion = new Dictionary<ITuple, BuffOnEmotion>();
			sceneCharacterFromToBuffAndDebuff.BuffOnHoleWearingWalls = new Dictionary<ITuple, BuffOnHoleWearingWalls>();
			sceneCharacterFromToBuffAndDebuff.BuffOnHoleWearingBottom = new Dictionary<ITuple, BuffOnHoleWearingBottom>();
			sceneCharacterFromToBuffAndDebuff.BuffOnHoleWearingMotion = new Dictionary<ITuple, BuffOnHoleWearingMotion>();
			sceneCharacterFromToBuffAndDebuff.BuffOnOxygenDemand = new Dictionary<ITuple, BuffOnOxygenDemand>();
			Guid id = female.ID;
			DefaultBuffAndDebuffGenerator.GenerateBuffOnKarmaBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnKarma);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnPersonalityTraitBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnPersonalityTrait);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnDesiresBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnDesires);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnFavorabilityReqOfInteractionBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnFavorabilityReqOfInteraction);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnInteractionBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnInteraction);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnEmotionAuraBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnEmotionAura);
			if (otherIsPermanentHero)
			{
				DefaultBuffAndDebuffGenerator.GenerateBuffOnEmotionTowardCharacterBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnEmotionTowardCharacter);
			}
			DefaultBuffAndDebuffGenerator.GenerateBuffOnEmotionBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnEmotion);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnHoleWearingWallsBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnHoleWearingWalls);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnHoleWearingBottomBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnHoleWearingBottom);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnHoleWearingMotionBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnHoleWearingMotion);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnOxygenDemandBySceneInteractionsForFemales(this, other, id, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnOxygenDemand);
			return sceneCharacterFromToBuffAndDebuff;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00010F20 File Offset: 0x0000F120
		private SceneCharacterFromToBuffAndDebuff DefaultBuffAndDebuffGenerateForMales(SceneCharacter male, Guid other, bool sceneAborted, DateTime now)
		{
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff = new SceneCharacterFromToBuffAndDebuff(male);
			sceneCharacterFromToBuffAndDebuff.BuffOnKarma = new Dictionary<ITuple, BuffOnKarma>();
			sceneCharacterFromToBuffAndDebuff.BuffOnEmotionAura = new Dictionary<ITuple, BuffOnEmotionAura>();
			sceneCharacterFromToBuffAndDebuff.BuffOnEmotion = new Dictionary<ITuple, BuffOnEmotion>();
			sceneCharacterFromToBuffAndDebuff.BuffOnEyaculationTimes = new Dictionary<ITuple, BuffOnEyaculationTimes>();
			sceneCharacterFromToBuffAndDebuff.BuffOnEyaculationAmount = new Dictionary<ITuple, BuffOnEyaculationAmount>();
			Guid id = male.ID;
			DefaultBuffAndDebuffGenerator.GenerateBuffOnKarmaBySceneInteractionsForMales(this, id, other, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnKarma);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnEmotionAuraBySceneInteractionsForMales(this, id, other, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnEmotionAura);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnEmotionBySceneInteractionsForMales(this, id, other, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnEmotion);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnEyacTimesBySceneInteractionsForMales(this, id, other, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnEyaculationTimes);
			DefaultBuffAndDebuffGenerator.GenerateBuffOnEyacAmountBySceneInteractionsForMales(this, id, other, sceneAborted, now, sceneCharacterFromToBuffAndDebuff.BuffOnEyaculationAmount);
			return sceneCharacterFromToBuffAndDebuff;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00010FC8 File Offset: 0x0000F1C8
		public static InteraccionesEnScena.Combonaciones GetCombinacionDeKey(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> Key)
		{
			InteraccionesEnScena.Combonaciones combonaciones;
			if (!InteraccionesEnScena.CombinacionesDeKey.TryGetValue(Key, out combonaciones))
			{
				combonaciones = new InteraccionesEnScena.Combonaciones(Key);
				InteraccionesEnScena.CombinacionesDeKey.Add(Key, combonaciones);
			}
			return combonaciones;
		}

		// Token: 0x040002D6 RID: 726
		public const float maxIncativeTime = 0.3333f;

		// Token: 0x040002D7 RID: 727
		[SerializeField]
		private bool m_isRecording;

		// Token: 0x040002D8 RID: 728
		[SerializeField]
		private float m_startTime;

		// Token: 0x040002D9 RID: 729
		[SerializeField]
		private int m_startFrame;

		// Token: 0x040002DA RID: 730
		[SerializeField]
		private DateTime m_sceneDate;

		// Token: 0x040002DB RID: 731
		[SerializeField]
		private List<InteraccionesEnScena.InteraccionesEntreCharacters> m_todasLasInteraccionesEntreCharacters = new List<InteraccionesEnScena.InteraccionesEntreCharacters>();

		// Token: 0x040002DC RID: 732
		[Obsolete("", true)]
		private Dictionary<ValueTuple<ICharacterUnico, ICharacterUnico>, int> m_intexDePar = new Dictionary<ValueTuple<ICharacterUnico, ICharacterUnico>, int>();

		// Token: 0x040002DD RID: 733
		private Dictionary<ValueTuple<Guid, Guid>, int> m_indexDePar = new Dictionary<ValueTuple<Guid, Guid>, int>();

		// Token: 0x040002DE RID: 734
		private SimplePoolDeClearables<InteraccionesEnScena.Interaccion> m_poolDeInteracciones = new SimplePoolDeClearables<InteraccionesEnScena.Interaccion>();

		// Token: 0x040002DF RID: 735
		[Obsolete("", true)]
		private SimplePool<Dictionary<Guid, int>> m_poolDeEstimulosDeCombinacion = new SimplePool<Dictionary<Guid, int>>();

		// Token: 0x040002E0 RID: 736
		private InteraccionesEnScena.OnInteractionCompletedHandler m_onInteractionCompleted;

		// Token: 0x040002E3 RID: 739
		private static readonly Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Combonaciones> CombinacionesDeKey = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Combonaciones>();

		// Token: 0x020000BA RID: 186
		// (Invoke) Token: 0x06000429 RID: 1065
		internal delegate void OnInteractionCompletedHandler(InteraccionesEnScena.InteraccionesEntreCharacters interaccionesEntreCharacters, ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, InteraccionesEnScena.Interaccion interaccion, Guid estimulo, ref EmocionesHumanasValues emocionesHumanasValues);

		// Token: 0x020000BB RID: 187
		// (Invoke) Token: 0x0600042D RID: 1069
		internal delegate void OnCombinationHandler(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> combination, InteraccionesEnScena.Interaccion interaction, InteraccionesEnScena.Interaccion result);

		// Token: 0x020000BC RID: 188
		[Serializable]
		public class InteraccionesEntreCharacters
		{
			// Token: 0x06000430 RID: 1072 RVA: 0x00011054 File Offset: 0x0000F254
			public InteraccionesEntreCharacters(InteraccionesEnScena owner, ICharacterUnico From, ICharacterUnico To)
			{
				if (From == null)
				{
					throw new ArgumentNullException("From", "From null reference.");
				}
				if (To == null)
				{
					throw new ArgumentNullException("To", "To null reference.");
				}
				this.m_owner = owner;
				this.m_ToEmocionesFemeninas = To.GetComponentEnRoot<EmocionesFemeninasBase>();
				SceneCharacter componentInChildren = From.GetComponentInChildren<SceneCharacter>();
				SceneCharacter componentInChildren2 = To.GetComponentInChildren<SceneCharacter>();
				if (componentInChildren == null)
				{
					throw new ArgumentNullException("m_fromSceneCharacter", "m_fromSceneCharacter null reference.");
				}
				if (componentInChildren2 == null)
				{
					throw new ArgumentNullException("m_toSceneCharacter", "m_toSceneCharacter null reference.");
				}
				this.from = new SceneCharacterWrapper(componentInChildren);
				this.to = new SceneCharacterWrapper(componentInChildren2);
				this.fromID = componentInChildren.ID;
				this.toID = componentInChildren2.ID;
				this.fromStringID = componentInChildren.stringID;
				this.toStringID = componentInChildren2.stringID;
				this.stackedMain = new InteraccionesEnScena.InteraccionesEntreCharacters.Stacked(this);
				this.stackedSec = new InteraccionesEnScena.InteraccionesEntreCharacters.Stacked(this);
				this.stackedMainSec = new InteraccionesEnScena.InteraccionesEntreCharacters.StackedMainSec(this, this.stackedMain, this.stackedSec);
				this.bufferedInteraccion = new InteraccionesEnScena.InteraccionesEntreCharacters.BufferedInteraccion(this);
				if (this.m_ToEmocionesFemeninas != null)
				{
					this.m_ToEmocionesFemeninas.updateEmociones2Base += this.M_ToEmociones_updateEmociones2;
				}
			}

			// Token: 0x06000431 RID: 1073 RVA: 0x00011194 File Offset: 0x0000F394
			private void M_ToEmociones_updateEmociones2(EmocionesHumanasBase obj)
			{
				this.emocionesHumanasValues = this.m_ToEmocionesFemeninas.ObtenerModsHumanos();
			}

			// Token: 0x14000017 RID: 23
			// (add) Token: 0x06000432 RID: 1074 RVA: 0x000111A8 File Offset: 0x0000F3A8
			// (remove) Token: 0x06000433 RID: 1075 RVA: 0x000111E0 File Offset: 0x0000F3E0
			public event OnInteractionStackHandler onInteraction;

			// Token: 0x06000434 RID: 1076 RVA: 0x00003B39 File Offset: 0x00001D39
			public void Add()
			{
			}

			// Token: 0x06000435 RID: 1077 RVA: 0x00011218 File Offset: 0x0000F418
			public void Dispose()
			{
				InteraccionesEnScena.InteraccionesEntreCharacters.BufferedInteraccion bufferedInteraccion = this.bufferedInteraccion;
				if (bufferedInteraccion != null)
				{
					bufferedInteraccion.Clear();
				}
				InteraccionesEnScena.InteraccionesEntreCharacters.Stacked stacked = this.stackedMain;
				if (stacked != null)
				{
					stacked.Clear();
				}
				InteraccionesEnScena.InteraccionesEntreCharacters.Stacked stacked2 = this.stackedSec;
				if (stacked2 != null)
				{
					stacked2.Clear();
				}
				InteraccionesEnScena.InteraccionesEntreCharacters.StackedMainSec stackedMainSec = this.stackedMainSec;
				if (stackedMainSec != null)
				{
					stackedMainSec.Clear();
				}
				this.Clear();
			}

			// Token: 0x06000436 RID: 1078 RVA: 0x0001126F File Offset: 0x0000F46F
			public void Clear()
			{
				this.frameInteraccion.Clear();
			}

			// Token: 0x040002E4 RID: 740
			public EmocionesHumanasValues emocionesHumanasValues;

			// Token: 0x040002E5 RID: 741
			public readonly SceneCharacterWrapper from;

			// Token: 0x040002E6 RID: 742
			public readonly SceneCharacterWrapper to;

			// Token: 0x040002E7 RID: 743
			public readonly Guid fromID;

			// Token: 0x040002E8 RID: 744
			public readonly Guid toID;

			// Token: 0x040002E9 RID: 745
			public readonly string fromStringID;

			// Token: 0x040002EA RID: 746
			public readonly string toStringID;

			// Token: 0x040002EB RID: 747
			private EmocionesFemeninasBase m_ToEmocionesFemeninas;

			// Token: 0x040002EC RID: 748
			private InteraccionesEnScena m_owner;

			// Token: 0x040002ED RID: 749
			public InteraccionesEnScena.InteraccionesEntreCharacters.Stacked stackedMain;

			// Token: 0x040002EE RID: 750
			public InteraccionesEnScena.InteraccionesEntreCharacters.Stacked stackedSec;

			// Token: 0x040002EF RID: 751
			public InteraccionesEnScena.InteraccionesEntreCharacters.StackedMainSec stackedMainSec;

			// Token: 0x040002F0 RID: 752
			public InteraccionesEnScena.InteraccionesEntreCharacters.BufferedInteraccion bufferedInteraccion;

			// Token: 0x040002F1 RID: 753
			public HashSet<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>> frameInteraccion = new HashSet<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>>();

			// Token: 0x020000BD RID: 189
			[Serializable]
			public class BufferedInteraccion : ICharactersSceneInteractions
			{
				// Token: 0x06000437 RID: 1079 RVA: 0x0001127C File Offset: 0x0000F47C
				public BufferedInteraccion(InteraccionesEnScena.InteraccionesEntreCharacters self)
				{
					this.m_self = self;
				}

				// Token: 0x14000018 RID: 24
				// (add) Token: 0x06000438 RID: 1080 RVA: 0x000112F0 File Offset: 0x0000F4F0
				// (remove) Token: 0x06000439 RID: 1081 RVA: 0x00011328 File Offset: 0x0000F528
				public event OnInteractionHandler onInteraction;

				// Token: 0x14000019 RID: 25
				// (add) Token: 0x0600043A RID: 1082 RVA: 0x00011360 File Offset: 0x0000F560
				// (remove) Token: 0x0600043B RID: 1083 RVA: 0x00011398 File Offset: 0x0000F598
				public event OnInteractionStackHandler onStackingInteraction;

				// Token: 0x1400001A RID: 26
				// (add) Token: 0x0600043C RID: 1084 RVA: 0x000113D0 File Offset: 0x0000F5D0
				// (remove) Token: 0x0600043D RID: 1085 RVA: 0x00011408 File Offset: 0x0000F608
				public event OnInteractionStackHandler onInteractionStacked;

				// Token: 0x0600043E RID: 1086 RVA: 0x0001143D File Offset: 0x0000F63D
				internal bool IsBuffered(ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, out InteraccionesEnScena.Interaccion interaccion)
				{
					return this.m_bufferedDeKey.TryGetValue(key, out interaccion);
				}

				// Token: 0x0600043F RID: 1087 RVA: 0x0001144C File Offset: 0x0000F64C
				internal void RemoveTimeOut(IReadOnlyCollection<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>> frameInteraccion, InteraccionesEnScena.InteraccionesEntreCharacters owner, InteraccionesEnScena.OnInteractionCompletedHandler onRemoved)
				{
					for (int i = this.m_buffered.Count - 1; i >= 0; i--)
					{
						InteraccionesEnScena.Interaccion interaccion = this.m_buffered[i];
						float num = this.m_inactiveTimes[i];
						ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(interaccion.toReport.fromPart, interaccion.toReport.toPart, interaccion.toReport.interationReceivedType, interaccion.toReport.emotion, interaccion.toReport.triggerMaxValue);
						bool flag = !frameInteraccion.Contains(valueTuple);
						if (flag)
						{
							this.m_inactiveTimes[i] = num + Time.deltaTime;
						}
						else
						{
							this.m_inactiveTimes[i] = 0f;
						}
						if (flag && num > 0.3333f)
						{
							Guid guid = this.m_bindedEstimuloIDDeKey[valueTuple];
							this.m_inactiveTimes.RemoveAt(i);
							this.m_buffered.RemoveAt(i);
							this.m_bufferedDeKey.Remove(valueTuple);
							this.m_bindedEstimuloIDDeKey.Remove(valueTuple);
							this.m_lastBindedEstimuloIDDeKey.AddOrReplase(valueTuple, guid);
							if (this.m_cantidadDeUsosActualesDeEstimuloID.Plus(ref guid, -1) <= 0)
							{
								this.m_cantidadDeUsosActualesDeEstimuloID.Remove(guid);
							}
							InteraccionesEnScena.RemoveKeyConbinationsToSingle(interaccion, ref valueTuple, this.m_singleBufferedDeKeyCombinations, this.m_self.m_owner.m_poolDeInteracciones);
							if (onRemoved != null)
							{
								onRemoved(owner, valueTuple, interaccion, guid, ref this.m_self.emocionesHumanasValues);
							}
							this.m_self.m_owner.m_poolDeInteracciones.ReturnItem(interaccion);
						}
					}
				}

				// Token: 0x06000440 RID: 1088 RVA: 0x000115CC File Offset: 0x0000F7CC
				private void UsarActualEstimuloID0Revivir(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, ref Guid EstimuloId)
				{
					Guid guid;
					int num;
					if (this.m_lastBindedEstimuloIDDeKey.TryGetValue(key, out guid) && this.m_cantidadDeUsosActualesDeEstimuloID.TryGetValue(guid, out num) && num > 0)
					{
						EstimuloId = guid;
					}
				}

				// Token: 0x06000441 RID: 1089 RVA: 0x0001160C File Offset: 0x0000F80C
				internal void Add(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, InteraccionesEnScena.Interaccion nueva, ref Guid EstimuloId)
				{
					if (this.m_bufferedDeKey.TryAdd(key, nueva))
					{
						this.UsarActualEstimuloID0Revivir(ref key, ref EstimuloId);
						this.m_buffered.Add(nueva);
						this.m_inactiveTimes.Add(0f);
						this.m_bindedEstimuloIDDeKey.AddOrReplase(key, EstimuloId);
						this.m_cantidadDeUsosActualesDeEstimuloID.Plus(ref EstimuloId, 1);
						InteraccionesEnScena.AddKeyConbinationsToSingle(nueva, ref key, ref EstimuloId, this.m_singleBufferedDeKeyCombinations, null, false, false, this.m_self.m_owner.m_poolDeInteracciones, null);
						OnInteractionHandler onInteractionHandler = this.onInteraction;
						if (onInteractionHandler == null)
						{
							return;
						}
						onInteractionHandler(ref nueva.toReport, this);
					}
				}

				// Token: 0x06000442 RID: 1090 RVA: 0x000116B4 File Offset: 0x0000F8B4
				internal void StackDuplicated(ICalculoDeEstimuloBuffeador calculo, InteraccionesEnScena.Interaccion existente, InteraccionesEnScena.Interaccion nueva, ref UmbralBasico.Estado estado, int cantidadDePartesEstimuladas)
				{
					OnInteractionStackHandler onInteractionStackHandler = this.onStackingInteraction;
					if (onInteractionStackHandler != null)
					{
						onInteractionStackHandler(ref existente.toReport, this);
					}
					existente.canProduceBuff &= ((calculo != null) ? new bool?(calculo.canProduceBuff) : null).GetValueOrDefault(true);
					existente.toReport.times = existente.toReport.times + 1;
					existente.toReport.stacks = existente.toReport.stacks + 1;
					existente.toReport.emotionAtMaxValueTimes = (existente.toReport.emotionAtMaxValue ? (existente.toReport.emotionAtMaxValueTimes + 1) : existente.toReport.emotionAtMaxValueTimes);
					existente.toReport.triggerMaxValueTimes = (existente.toReport.triggerMaxValue ? (existente.toReport.triggerMaxValueTimes + 1) : existente.toReport.triggerMaxValueTimes);
					existente.toReport.damagePercentageDone = existente.toReport.damagePercentageDone + estado.estimulacionGeneradaEnFrame / (float)cantidadDePartesEstimuladas;
					existente.toReport.overshootOrUndershootTotal = existente.toReport.overshootOrUndershootTotal + estado.offsetMod;
					existente.toReport.damageScoreTotal = existente.toReport.damageScoreTotal + estado.spotScore.SpotScoreToWeight();
					ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key = existente.GetKey();
					Guid guid = this.m_bindedEstimuloIDDeKey[key];
					InteraccionesEnScena.AddKeyConbinationsToSingle(nueva, ref key, ref guid, this.m_singleBufferedDeKeyCombinations, null, false, false, this.m_self.m_owner.m_poolDeInteracciones, null);
					OnInteractionStackHandler onInteractionStackHandler2 = this.onInteractionStacked;
					if (onInteractionStackHandler2 == null)
					{
						return;
					}
					onInteractionStackHandler2(ref existente.toReport, this);
				}

				// Token: 0x06000443 RID: 1091 RVA: 0x00011838 File Offset: 0x0000FA38
				internal void Stack(ICalculoDeEstimuloBuffeador calculo, InteraccionesEnScena.Interaccion existente, InteraccionesEnScena.Interaccion nueva, ref UmbralBasico.Estado estado, int cantidadDePartesEstimuladas)
				{
					OnInteractionStackHandler onInteractionStackHandler = this.onStackingInteraction;
					if (onInteractionStackHandler != null)
					{
						onInteractionStackHandler(ref existente.toReport, this);
					}
					existente.canProduceBuff &= ((calculo != null) ? new bool?(calculo.canProduceBuff) : null).GetValueOrDefault(true);
					existente.toReport.times = existente.toReport.times + 1;
					existente.toReport.stacks = existente.toReport.stacks + 1;
					existente.toReport.endTime = this.m_self.m_owner.sceneTime;
					existente.toReport.endFrame = this.m_self.m_owner.sceneFrames;
					existente.toReport.emotionAtMaxValueTimes = (existente.toReport.emotionAtMaxValue ? (existente.toReport.emotionAtMaxValueTimes + 1) : existente.toReport.emotionAtMaxValueTimes);
					existente.toReport.triggerMaxValueTimes = (existente.toReport.triggerMaxValue ? (existente.toReport.triggerMaxValueTimes + 1) : existente.toReport.triggerMaxValueTimes);
					existente.toReport.damagePercentageDone = existente.toReport.damagePercentageDone + estado.estimulacionGeneradaEnFrame / (float)cantidadDePartesEstimuladas;
					existente.toReport.overshootOrUndershootTotal = existente.toReport.overshootOrUndershootTotal + estado.offsetMod;
					existente.toReport.damageScoreTotal = existente.toReport.damageScoreTotal + estado.spotScore.SpotScoreToWeight();
					ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key = existente.GetKey();
					Guid guid = this.m_bindedEstimuloIDDeKey[key];
					InteraccionesEnScena.AddKeyConbinationsToSingle(nueva, ref key, ref guid, this.m_singleBufferedDeKeyCombinations, null, false, false, this.m_self.m_owner.m_poolDeInteracciones, null);
					OnInteractionStackHandler onInteractionStackHandler2 = this.onInteractionStacked;
					if (onInteractionStackHandler2 == null)
					{
						return;
					}
					onInteractionStackHandler2(ref existente.toReport, this);
				}

				// Token: 0x06000444 RID: 1092 RVA: 0x000119F0 File Offset: 0x0000FBF0
				public void Clear()
				{
					for (int i = 0; i < this.m_buffered.Count; i++)
					{
						this.m_self.m_owner.m_poolDeInteracciones.ReturnItem(this.m_buffered[i]);
					}
					this.m_buffered.Clear();
					this.m_bufferedDeKey.Clear();
					this.m_inactiveTimes.Clear();
					this.m_allBufferedDeKeyCombinations.Clear();
					foreach (KeyValuePair<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> keyValuePair in this.m_singleBufferedDeKeyCombinations)
					{
						this.m_self.m_owner.m_poolDeInteracciones.ReturnItem(keyValuePair.Value);
					}
					this.m_singleBufferedDeKeyCombinations.Clear();
				}

				// Token: 0x06000445 RID: 1093 RVA: 0x00011AC8 File Offset: 0x0000FCC8
				public IReadOnlyList<Interaction> Peek()
				{
					return this.m_buffered.Select((InteraccionesEnScena.Interaccion i) => i.toReport).ToArray<Interaction>();
				}

				// Token: 0x06000446 RID: 1094 RVA: 0x00011AFC File Offset: 0x0000FCFC
				internal void Peek(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue, out InteraccionesEnScena.Interaccion interaction)
				{
					InteraccionesEnScena.Interaccion interaccion;
					if (this.m_singleBufferedDeKeyCombinations.TryGetValue(new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue), out interaccion))
					{
						interaction = interaccion;
						return;
					}
					interaction = null;
				}

				// Token: 0x06000447 RID: 1095 RVA: 0x00011B30 File Offset: 0x0000FD30
				public void Peek(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue, out Interaction interaction)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					interaction = ((interaccion == null) ? default(Interaction) : interaccion.toReport);
				}

				// Token: 0x06000448 RID: 1096 RVA: 0x00011B68 File Offset: 0x0000FD68
				public int PeekTimes(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.times;
					}
					return 0;
				}

				// Token: 0x06000449 RID: 1097 RVA: 0x00011B94 File Offset: 0x0000FD94
				public bool PeekIsValid(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					return interaccion != null && interaccion.toReport.isValid;
				}

				// Token: 0x0600044A RID: 1098 RVA: 0x00011BC0 File Offset: 0x0000FDC0
				public int PeekEndFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.endFrame;
					}
					return 0;
				}

				// Token: 0x0600044B RID: 1099 RVA: 0x00011BEC File Offset: 0x0000FDEC
				public int PeekStartFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.startFrame;
					}
					return 0;
				}

				// Token: 0x0600044C RID: 1100 RVA: 0x00011C18 File Offset: 0x0000FE18
				public float PeekDuration(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.duration;
					}
					return 0f;
				}

				// Token: 0x0600044D RID: 1101 RVA: 0x00011C48 File Offset: 0x0000FE48
				public float PeekDamagePercentageDone(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.damagePercentageDone;
					}
					return 0f;
				}

				// Token: 0x0600044E RID: 1102 RVA: 0x00011C78 File Offset: 0x0000FE78
				[Obsolete("", true)]
				public IReadOnlyList<Interaction> PeekMany(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					if (fromPart != TriggeringBodyPart.All && toPart != SensitiveBodyPart.All && interationReceivedType != InterationReceivedType.All && emotion != Emotion.All)
					{
						Interaction interaction;
						this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaction);
						return new Interaction[] { interaction };
					}
					ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue);
					HashSet<InteraccionesEnScena.Interaccion> hashSet;
					if (this.m_allBufferedDeKeyCombinations.TryGetValue(valueTuple, out hashSet))
					{
						return hashSet.Select((InteraccionesEnScena.Interaccion i) => i.toReport).ToArray<Interaction>();
					}
					return Array.Empty<Interaction>();
				}

				// Token: 0x040002F3 RID: 755
				private InteraccionesEnScena.InteraccionesEntreCharacters m_self;

				// Token: 0x040002F4 RID: 756
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, Guid> m_bindedEstimuloIDDeKey = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, Guid>();

				// Token: 0x040002F5 RID: 757
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, Guid> m_lastBindedEstimuloIDDeKey = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, Guid>();

				// Token: 0x040002F6 RID: 758
				private Dictionary<Guid, int> m_cantidadDeUsosActualesDeEstimuloID = new Dictionary<Guid, int>();

				// Token: 0x040002F7 RID: 759
				[SerializeField]
				private List<InteraccionesEnScena.Interaccion> m_buffered = new List<InteraccionesEnScena.Interaccion>();

				// Token: 0x040002F8 RID: 760
				[SerializeField]
				private List<float> m_inactiveTimes = new List<float>();

				// Token: 0x040002F9 RID: 761
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> m_singleBufferedDeKeyCombinations = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion>();

				// Token: 0x040002FA RID: 762
				[Obsolete]
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, HashSet<InteraccionesEnScena.Interaccion>> m_allBufferedDeKeyCombinations = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, HashSet<InteraccionesEnScena.Interaccion>>();

				// Token: 0x040002FB RID: 763
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> m_bufferedDeKey = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion>();
			}

			// Token: 0x020000BF RID: 191
			[Serializable]
			public class Stacked : ICharactersSceneInteractionsArchived, ICharactersSceneInteractionsClearable, ICharactersSceneInteractions
			{
				// Token: 0x06000453 RID: 1107 RVA: 0x00011D18 File Offset: 0x0000FF18
				public Stacked(InteraccionesEnScena.InteraccionesEntreCharacters self)
				{
					this.m_self = self;
					this.m_onCombination = new InteraccionesEnScena.OnCombinationHandler(this.CallOnCombinationEvent);
				}

				// Token: 0x06000454 RID: 1108 RVA: 0x00011D86 File Offset: 0x0000FF86
				private void CallOnCombinationEvent(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> combination, InteraccionesEnScena.Interaccion interaction, InteraccionesEnScena.Interaccion result)
				{
					this.m_self.m_owner.CallOnCombinationEvent(ref combination, interaction, result, this.m_self, this);
					InteraccionesEnScena.OnCombinationHandler onCombinationHandler = this.onCombination;
					if (onCombinationHandler == null)
					{
						return;
					}
					onCombinationHandler(ref combination, interaction, result);
				}

				// Token: 0x1400001B RID: 27
				// (add) Token: 0x06000455 RID: 1109 RVA: 0x00011DB8 File Offset: 0x0000FFB8
				// (remove) Token: 0x06000456 RID: 1110 RVA: 0x00011DF0 File Offset: 0x0000FFF0
				public event OnInteractionHandler onInteraction;

				// Token: 0x1400001C RID: 28
				// (add) Token: 0x06000457 RID: 1111 RVA: 0x00011E28 File Offset: 0x00010028
				// (remove) Token: 0x06000458 RID: 1112 RVA: 0x00011E60 File Offset: 0x00010060
				public event OnInteractionStackHandler onStackingInteraction;

				// Token: 0x1400001D RID: 29
				// (add) Token: 0x06000459 RID: 1113 RVA: 0x00011E98 File Offset: 0x00010098
				// (remove) Token: 0x0600045A RID: 1114 RVA: 0x00011ED0 File Offset: 0x000100D0
				public event OnInteractionStackHandler onInteractionStacked;

				// Token: 0x1400001E RID: 30
				// (add) Token: 0x0600045B RID: 1115 RVA: 0x00011F08 File Offset: 0x00010108
				// (remove) Token: 0x0600045C RID: 1116 RVA: 0x00011F40 File Offset: 0x00010140
				internal event InteraccionesEnScena.OnCombinationHandler onCombination;

				// Token: 0x0600045D RID: 1117 RVA: 0x00011F75 File Offset: 0x00010175
				internal bool IsStacked(ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, out InteraccionesEnScena.Interaccion interaccion)
				{
					return this.m_stackedDeKey.TryGetValue(key, out interaccion);
				}

				// Token: 0x0600045E RID: 1118 RVA: 0x00011F84 File Offset: 0x00010184
				public void Clear()
				{
					foreach (InteraccionesEnScena.Interaccion interaccion in this.m_stackedDeKey.Values)
					{
						this.m_self.m_owner.m_poolDeInteracciones.ReturnItem(interaccion);
					}
					this.m_stackedDeKey.Clear();
					this.m_allStackedDeKeyCombinations.Clear();
					this.m_stackedEmotionDamagePairs.Clear();
					foreach (KeyValuePair<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> keyValuePair in this.m_singleStackedDeKeyCombinations)
					{
						this.m_self.m_owner.m_poolDeInteracciones.ReturnItem(keyValuePair.Value);
					}
					this.m_singleStackedDeKeyCombinations.Clear();
				}

				// Token: 0x0600045F RID: 1119 RVA: 0x00012070 File Offset: 0x00010270
				internal bool Add(ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key, InteraccionesEnScena.Interaccion interaccion)
				{
					return this.m_stackedDeKey.TryAdd(key, interaccion);
				}

				// Token: 0x06000460 RID: 1120 RVA: 0x00012084 File Offset: 0x00010284
				internal void Stack(InteraccionesEnScena.Interaccion stackedInteraccion, InteraccionesEnScena.Interaccion buffered, ref Guid EstimuloIDBindedToIK, ref EmocionesHumanasValues emocionesHumanasValues)
				{
					OnInteractionHandler onInteractionHandler = this.onInteraction;
					if (onInteractionHandler != null)
					{
						onInteractionHandler(ref buffered.toReport, this);
					}
					OnInteractionStackHandler onInteractionStackHandler = this.onStackingInteraction;
					if (onInteractionStackHandler != null)
					{
						onInteractionStackHandler(ref stackedInteraccion.toReport, this);
					}
					stackedInteraccion.StackOnMe(buffered, true, true);
					if (emocionesHumanasValues.loaded)
					{
						Emotion emotion = buffered.toReport.emotion;
						float num = this.EmotionMod(emotion, ref emocionesHumanasValues) * 100f;
						EmotionPercentageRange range = this.GetRange(num, buffered.toReport.triggerMaxValue);
						float damagePercentageDone = buffered.toReport.damagePercentageDone;
						float damageScoreTotal = buffered.toReport.damageScoreTotal;
						for (int i = 0; i < EmotionExt.femaleEmotions.Length; i++)
						{
							Emotion emotion2 = EmotionExt.femaleEmotions[i];
							float num2 = this.EmotionMod(emotion2, ref emocionesHumanasValues) * 100f;
							EmotionPercentageRange range2 = this.GetRange(num2, false);
							EmotionDamagePair emotionDamagePair = new EmotionDamagePair
							{
								main = emotion,
								mainRange = range,
								secondary = emotion2,
								secondaryRange = range2,
								times = 1,
								damagePercentageTotal = damagePercentageDone,
								damageScoreTotal = damageScoreTotal
							};
							ValueTuple<Emotion, EmotionPercentageRange, Emotion, EmotionPercentageRange> valueTuple = new ValueTuple<Emotion, EmotionPercentageRange, Emotion, EmotionPercentageRange>(emotion, range, emotion2, range2);
							EmotionDamagePair emotionDamagePair2;
							if (!this.m_stackedEmotionDamagePairs.TryGetValue(valueTuple, out emotionDamagePair2))
							{
								this.m_stackedEmotionDamagePairs.Add(valueTuple, emotionDamagePair);
							}
							else
							{
								emotionDamagePair2.StackToSelf(ref emotionDamagePair);
								this.m_stackedEmotionDamagePairs[valueTuple] = emotionDamagePair2;
							}
						}
					}
					ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key = buffered.GetKey();
					InteraccionesEnScena.AddKeyConbinationsToSingle(buffered, ref key, ref EstimuloIDBindedToIK, this.m_singleStackedDeKeyCombinations, this.m_lastEstimuloIDDeCombinacion, true, true, this.m_self.m_owner.m_poolDeInteracciones, this.m_onCombination);
					OnInteractionStackHandler onInteractionStackHandler2 = this.onInteractionStacked;
					if (onInteractionStackHandler2 == null)
					{
						return;
					}
					onInteractionStackHandler2(ref stackedInteraccion.toReport, this);
				}

				// Token: 0x06000461 RID: 1121 RVA: 0x0001223C File Offset: 0x0001043C
				public IReadOnlyList<Interaction> Peek()
				{
					return this.m_stackedDeKey.Values.Select((InteraccionesEnScena.Interaccion i) => i.toReport).ToArray<Interaction>();
				}

				// Token: 0x06000462 RID: 1122 RVA: 0x00012272 File Offset: 0x00010472
				[Obsolete("", true)]
				public IList<Interaction> Get()
				{
					IList<Interaction> list = this.m_stackedDeKey.Values.Select((InteraccionesEnScena.Interaccion i) => i.toReport).ToList<Interaction>();
					this.Clear();
					return list;
				}

				// Token: 0x06000463 RID: 1123 RVA: 0x000122B0 File Offset: 0x000104B0
				internal void Peek(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue, out InteraccionesEnScena.Interaccion interaction)
				{
					InteraccionesEnScena.Interaccion interaccion;
					if (this.m_singleStackedDeKeyCombinations.TryGetValue(new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue), out interaccion))
					{
						interaction = interaccion;
						return;
					}
					interaction = null;
				}

				// Token: 0x06000464 RID: 1124 RVA: 0x000122E4 File Offset: 0x000104E4
				public void Peek(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue, out Interaction interaction)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					interaction = ((interaccion == null) ? default(Interaction) : interaccion.toReport);
				}

				// Token: 0x06000465 RID: 1125 RVA: 0x0001231C File Offset: 0x0001051C
				public int PeekTimes(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.times;
					}
					return 0;
				}

				// Token: 0x06000466 RID: 1126 RVA: 0x00012348 File Offset: 0x00010548
				public float PeekDuration(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.duration;
					}
					return 0f;
				}

				// Token: 0x06000467 RID: 1127 RVA: 0x00012378 File Offset: 0x00010578
				public float PeekDamagePercentageDone(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.damagePercentageDone;
					}
					return 0f;
				}

				// Token: 0x06000468 RID: 1128 RVA: 0x000123A8 File Offset: 0x000105A8
				public bool PeekIsValid(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					return interaccion != null && interaccion.toReport.isValid;
				}

				// Token: 0x06000469 RID: 1129 RVA: 0x000123D4 File Offset: 0x000105D4
				public int PeekEndFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.endFrame;
					}
					return 0;
				}

				// Token: 0x0600046A RID: 1130 RVA: 0x00012400 File Offset: 0x00010600
				public int PeekStartFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					InteraccionesEnScena.Interaccion interaccion;
					this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaccion);
					if (interaccion != null)
					{
						return interaccion.toReport.startFrame;
					}
					return 0;
				}

				// Token: 0x0600046B RID: 1131 RVA: 0x0001242C File Offset: 0x0001062C
				public int PeekTriggeringBodyPartCount(SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					int num = 0;
					foreach (object obj in typeof(TriggeringBodyPart).GetEnumValoresLimpiosObject())
					{
						TriggeringBodyPart triggeringBodyPart = (TriggeringBodyPart)obj;
						if (this.m_singleStackedDeKeyCombinations.ContainsKey(new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(triggeringBodyPart, toPart, interationReceivedType, emotion, reachedMaxValue)))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x0600046C RID: 1132 RVA: 0x000124A8 File Offset: 0x000106A8
				public int PeekSensitiveBodyPartCount(TriggeringBodyPart fromPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					int num = 0;
					foreach (object obj in typeof(SensitiveBodyPart).GetEnumValoresLimpiosObject())
					{
						SensitiveBodyPart sensitiveBodyPart = (SensitiveBodyPart)obj;
						if (this.m_singleStackedDeKeyCombinations.ContainsKey(new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, sensitiveBodyPart, interationReceivedType, emotion, reachedMaxValue)))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x0600046D RID: 1133 RVA: 0x00012524 File Offset: 0x00010724
				public int PeekInterationReceivedTypeCount(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, Emotion emotion, bool reachedMaxValue)
				{
					int num = 0;
					foreach (object obj in typeof(InterationReceivedType).GetEnumValoresLimpiosObject())
					{
						InterationReceivedType interationReceivedType = (InterationReceivedType)obj;
						if (this.m_singleStackedDeKeyCombinations.ContainsKey(new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue)))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x0600046E RID: 1134 RVA: 0x000125A0 File Offset: 0x000107A0
				public int PeekEmotionCount(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, bool reachedMaxValue)
				{
					int num = 0;
					foreach (object obj in typeof(Emotion).GetEnumValoresLimpiosObject())
					{
						Emotion emotion = (Emotion)obj;
						if (this.m_singleStackedDeKeyCombinations.ContainsKey(new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue)))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x0600046F RID: 1135 RVA: 0x0001261C File Offset: 0x0001081C
				[Obsolete("", true)]
				public IReadOnlyList<Interaction> PeekMany(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					if (fromPart != TriggeringBodyPart.All && toPart != SensitiveBodyPart.All && interationReceivedType != InterationReceivedType.All && emotion != Emotion.All)
					{
						Interaction interaction;
						this.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaction);
						return new Interaction[] { interaction };
					}
					ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue);
					HashSet<InteraccionesEnScena.Interaccion> hashSet;
					if (this.m_allStackedDeKeyCombinations.TryGetValue(valueTuple, out hashSet))
					{
						return hashSet.Select((InteraccionesEnScena.Interaccion i) => i.toReport).ToArray<Interaction>();
					}
					return Array.Empty<Interaction>();
				}

				// Token: 0x06000470 RID: 1136 RVA: 0x000126A8 File Offset: 0x000108A8
				public void PeekEmotionDamagePair(Emotion main, EmotionPercentageRange mainRange, Emotion secondary, EmotionPercentageRange secondaryRange, out EmotionDamagePair emotionDamagePair)
				{
					if (main == Emotion.All || secondary == Emotion.All || mainRange == EmotionPercentageRange.All || secondaryRange == EmotionPercentageRange.All)
					{
						throw new InvalidOperationException();
					}
					ValueTuple<Emotion, EmotionPercentageRange, Emotion, EmotionPercentageRange> valueTuple = new ValueTuple<Emotion, EmotionPercentageRange, Emotion, EmotionPercentageRange>(main, mainRange, secondary, secondaryRange);
					this.m_stackedEmotionDamagePairs.TryGetValue(valueTuple, out emotionDamagePair);
				}

				// Token: 0x06000471 RID: 1137 RVA: 0x000126E8 File Offset: 0x000108E8
				private float EmotionMod(Emotion emo, ref EmocionesHumanasValues emocionesHumanasValues)
				{
					switch (emo)
					{
					case Emotion.enjoyment:
						return emocionesHumanasValues.alegria;
					case Emotion.relief:
						return emocionesHumanasValues.alivio;
					case Emotion.favorability:
						return emocionesHumanasValues.consentToHero;
					case Emotion.pleasure:
						return emocionesHumanasValues.placer;
					case Emotion.arousal:
						return emocionesHumanasValues.arousal;
					case Emotion.disappointment:
						return emocionesHumanasValues.decepcion;
					case Emotion.rage:
						return emocionesHumanasValues.rage;
					case Emotion.pain:
						return emocionesHumanasValues.dolor;
					case Emotion.fear:
						return emocionesHumanasValues.fear;
					case Emotion.disgust:
						return emocionesHumanasValues.fear;
					default:
						throw new ArgumentOutOfRangeException(emo.ToString());
					}
				}

				// Token: 0x06000472 RID: 1138 RVA: 0x00012780 File Offset: 0x00010980
				private EmotionPercentageRange GetRange(float emoValue, bool triggerMaxValue)
				{
					if (triggerMaxValue)
					{
						return EmotionPercentageRange.oneHundred;
					}
					if (emoValue <= 0f)
					{
						return EmotionPercentageRange.zero;
					}
					if (emoValue > 0f && emoValue < 10f)
					{
						return EmotionPercentageRange.zeroToTen;
					}
					if (emoValue >= 10f && emoValue < 20f)
					{
						return EmotionPercentageRange.tenToTwenty;
					}
					if (emoValue >= 20f && emoValue < 30f)
					{
						return EmotionPercentageRange.twentyToThirty;
					}
					if (emoValue >= 30f && emoValue < 40f)
					{
						return EmotionPercentageRange.thirtyToForty;
					}
					if (emoValue >= 40f && emoValue < 50f)
					{
						return EmotionPercentageRange.fortyToFifty;
					}
					if (emoValue >= 50f && emoValue < 60f)
					{
						return EmotionPercentageRange.fiftyToSixty;
					}
					if (emoValue >= 60f && emoValue < 70f)
					{
						return EmotionPercentageRange.sixtyToSeventy;
					}
					if (emoValue >= 70f && emoValue < 80f)
					{
						return EmotionPercentageRange.seventyToEighty;
					}
					if (emoValue >= 80f && emoValue < 90f)
					{
						return EmotionPercentageRange.eightyToNinety;
					}
					if (emoValue >= 90f && emoValue <= 100f)
					{
						return EmotionPercentageRange.ninetyToOneHundred;
					}
					throw new ArgumentOutOfRangeException();
				}

				// Token: 0x06000473 RID: 1139 RVA: 0x00012884 File Offset: 0x00010A84
				private EmotionPercentageRange GetRange(Emocion emo, bool triggerMaxValue)
				{
					float value = emo.value.value;
					float num = value;
					if (num <= 0f)
					{
						return EmotionPercentageRange.zero;
					}
					float num2 = num;
					if (num2 > 0f && num2 < 10f)
					{
						return EmotionPercentageRange.zeroToTen;
					}
					float num3 = num;
					if (num3 >= 10f && num3 < 20f)
					{
						return EmotionPercentageRange.tenToTwenty;
					}
					float num4 = num;
					if (num4 >= 20f && num4 < 30f)
					{
						return EmotionPercentageRange.twentyToThirty;
					}
					float num5 = num;
					if (num5 >= 30f && num5 < 40f)
					{
						return EmotionPercentageRange.thirtyToForty;
					}
					float num6 = num;
					if (num6 >= 40f && num6 < 50f)
					{
						return EmotionPercentageRange.fortyToFifty;
					}
					float num7 = num;
					if (num7 >= 50f && num7 < 60f)
					{
						return EmotionPercentageRange.fiftyToSixty;
					}
					float num8 = num;
					if (num8 >= 60f && num8 < 70f)
					{
						return EmotionPercentageRange.sixtyToSeventy;
					}
					float num9 = num;
					if (num9 >= 70f && num9 < 80f)
					{
						return EmotionPercentageRange.seventyToEighty;
					}
					float num10 = num;
					if (num10 >= 80f && num10 < 90f)
					{
						return EmotionPercentageRange.eightyToNinety;
					}
					float num11 = num;
					if (num11 < 90f || num11 > 100f)
					{
						throw new ArgumentOutOfRangeException(emo.value.value.ToString());
					}
					if (value >= 100f && triggerMaxValue)
					{
						return EmotionPercentageRange.oneHundred;
					}
					return EmotionPercentageRange.ninetyToOneHundred;
				}

				// Token: 0x06000474 RID: 1140 RVA: 0x000129BF File Offset: 0x00010BBF
				[Obsolete("", true)]
				private Emocion GetToEmotion(Emotion emo)
				{
					return this.m_self.m_ToEmocionesFemeninas.ObtenerEmocion(this.Parse(emo));
				}

				// Token: 0x06000475 RID: 1141 RVA: 0x000129D8 File Offset: 0x00010BD8
				[Obsolete("", true)]
				private ReaccionHumana Parse(Emotion emo)
				{
					switch (emo)
					{
					case Emotion.All:
						return ReaccionHumana.All;
					case Emotion.None:
						return ReaccionHumana.None;
					case Emotion.enjoyment:
						return ReaccionHumana.alegria;
					case Emotion.relief:
						return ReaccionHumana.alivio;
					case Emotion.favorability:
						return ReaccionHumana.concentToHero;
					case Emotion.pleasure:
						return ReaccionHumana.placer;
					case Emotion.arousal:
						return ReaccionHumana.arousal;
					case Emotion.disappointment:
						return ReaccionHumana.decepcion;
					case Emotion.rage:
						return ReaccionHumana.rabia;
					case Emotion.pain:
						return ReaccionHumana.dolor;
					case Emotion.fear:
						return ReaccionHumana.miedo;
					case Emotion.disgust:
						return ReaccionHumana.asco;
					default:
						throw new ArgumentOutOfRangeException(emo.ToString());
					}
				}

				// Token: 0x04000302 RID: 770
				private InteraccionesEnScena.InteraccionesEntreCharacters m_self;

				// Token: 0x04000303 RID: 771
				private InteraccionesEnScena.OnCombinationHandler m_onCombination;

				// Token: 0x04000304 RID: 772
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, Guid> m_lastEstimuloIDDeCombinacion = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, Guid>();

				// Token: 0x04000305 RID: 773
				[SerializeField]
				private List<InteraccionesEnScena.Interaccion> m_stackedEDITOR = new List<InteraccionesEnScena.Interaccion>();

				// Token: 0x04000306 RID: 774
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> m_singleStackedDeKeyCombinations = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion>();

				// Token: 0x04000307 RID: 775
				[Obsolete]
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, HashSet<InteraccionesEnScena.Interaccion>> m_allStackedDeKeyCombinations = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, HashSet<InteraccionesEnScena.Interaccion>>();

				// Token: 0x04000308 RID: 776
				private Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion> m_stackedDeKey = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, InteraccionesEnScena.Interaccion>();

				// Token: 0x04000309 RID: 777
				private Dictionary<ValueTuple<Emotion, EmotionPercentageRange, Emotion, EmotionPercentageRange>, EmotionDamagePair> m_stackedEmotionDamagePairs = new Dictionary<ValueTuple<Emotion, EmotionPercentageRange, Emotion, EmotionPercentageRange>, EmotionDamagePair>();
			}

			// Token: 0x020000C1 RID: 193
			[Serializable]
			public class StackedMainSec : ICharactersSceneInteractionsArchived, ICharactersSceneInteractionsClearable, ICharactersSceneInteractions
			{
				// Token: 0x0600047B RID: 1147 RVA: 0x00012A68 File Offset: 0x00010C68
				public StackedMainSec(InteraccionesEnScena.InteraccionesEntreCharacters self, InteraccionesEnScena.InteraccionesEntreCharacters.Stacked Main, InteraccionesEnScena.InteraccionesEntreCharacters.Stacked Sec)
				{
					this.m_self = self;
					this.m_Main = Main;
					this.m_Sec = Sec;
				}

				// Token: 0x1400001F RID: 31
				// (add) Token: 0x0600047C RID: 1148 RVA: 0x00012A88 File Offset: 0x00010C88
				// (remove) Token: 0x0600047D RID: 1149 RVA: 0x00012AC0 File Offset: 0x00010CC0
				public event OnInteractionHandler onInteraction;

				// Token: 0x14000020 RID: 32
				// (add) Token: 0x0600047E RID: 1150 RVA: 0x00012AF8 File Offset: 0x00010CF8
				// (remove) Token: 0x0600047F RID: 1151 RVA: 0x00012B30 File Offset: 0x00010D30
				public event OnInteractionStackHandler onStackingInteraction;

				// Token: 0x14000021 RID: 33
				// (add) Token: 0x06000480 RID: 1152 RVA: 0x00012B68 File Offset: 0x00010D68
				// (remove) Token: 0x06000481 RID: 1153 RVA: 0x00012BA0 File Offset: 0x00010DA0
				public event OnInteractionStackHandler onInteractionStacked;

				// Token: 0x06000482 RID: 1154 RVA: 0x00012BD5 File Offset: 0x00010DD5
				public IReadOnlyList<Interaction> Peek()
				{
					return this.m_Main.Peek().Concat(this.m_Sec.Peek()).ToArray<Interaction>();
				}

				// Token: 0x06000483 RID: 1155 RVA: 0x00012BF8 File Offset: 0x00010DF8
				public void Peek(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue, out Interaction interaction)
				{
					Interaction interaction2;
					this.m_Main.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaction2);
					Interaction interaction3;
					this.m_Sec.Peek(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue, out interaction3);
					if (interaction2.isValid && interaction3.isValid)
					{
						interaction = interaction2;
						Interaction.AddFromSameRecording(ref interaction, ref interaction3);
						return;
					}
					if (interaction2.isValid)
					{
						interaction = interaction2;
						return;
					}
					if (interaction3.isValid)
					{
						interaction = interaction3;
						return;
					}
					interaction = default(Interaction);
				}

				// Token: 0x06000484 RID: 1156 RVA: 0x00012C80 File Offset: 0x00010E80
				public void PeekEmotionDamagePair(Emotion main, EmotionPercentageRange mainRange, Emotion secondary, EmotionPercentageRange secondaryRange, out EmotionDamagePair emotionDamagePair)
				{
					EmotionDamagePair emotionDamagePair2;
					this.m_Main.PeekEmotionDamagePair(main, mainRange, secondary, secondaryRange, out emotionDamagePair2);
					EmotionDamagePair emotionDamagePair3;
					this.m_Sec.PeekEmotionDamagePair(main, mainRange, secondary, secondaryRange, out emotionDamagePair3);
					if (emotionDamagePair2.isValid && emotionDamagePair3.isValid)
					{
						emotionDamagePair = emotionDamagePair2;
						emotionDamagePair.StackToSelf(ref emotionDamagePair3);
						return;
					}
					if (emotionDamagePair2.isValid)
					{
						emotionDamagePair = emotionDamagePair2;
						return;
					}
					if (emotionDamagePair3.isValid)
					{
						emotionDamagePair = emotionDamagePair3;
						return;
					}
					emotionDamagePair = default(EmotionDamagePair);
				}

				// Token: 0x06000485 RID: 1157 RVA: 0x00012D01 File Offset: 0x00010F01
				public int PeekTimes(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return this.m_Main.PeekTimes(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue) + this.m_Sec.PeekTimes(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue);
				}

				// Token: 0x06000486 RID: 1158 RVA: 0x00012D28 File Offset: 0x00010F28
				public float PeekDuration(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return this.m_Main.PeekDuration(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue) + this.m_Sec.PeekDuration(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue);
				}

				// Token: 0x06000487 RID: 1159 RVA: 0x00012D4F File Offset: 0x00010F4F
				public float PeekDamagePercentageDone(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return this.m_Main.PeekDamagePercentageDone(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue) + this.m_Sec.PeekDamagePercentageDone(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue);
				}

				// Token: 0x06000488 RID: 1160 RVA: 0x00012D76 File Offset: 0x00010F76
				public bool PeekIsValid(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return this.m_Main.PeekIsValid(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue) || this.m_Sec.PeekIsValid(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue);
				}

				// Token: 0x06000489 RID: 1161 RVA: 0x00012DA0 File Offset: 0x00010FA0
				public int PeekEndFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return Mathf.Max(this.m_Main.PeekEndFrame(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue), this.m_Sec.PeekEndFrame(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue));
				}

				// Token: 0x0600048A RID: 1162 RVA: 0x00012DCB File Offset: 0x00010FCB
				public int PeekTriggeringBodyPartCount(SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return this.m_Main.PeekTriggeringBodyPartCount(toPart, interationReceivedType, emotion, reachedMaxValue) + this.m_Sec.PeekTriggeringBodyPartCount(toPart, interationReceivedType, emotion, reachedMaxValue);
				}

				// Token: 0x0600048B RID: 1163 RVA: 0x00012DEE File Offset: 0x00010FEE
				public int PeekSensitiveBodyPartCount(TriggeringBodyPart fromPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return this.m_Main.PeekSensitiveBodyPartCount(fromPart, interationReceivedType, emotion, reachedMaxValue) + this.m_Sec.PeekSensitiveBodyPartCount(fromPart, interationReceivedType, emotion, reachedMaxValue);
				}

				// Token: 0x0600048C RID: 1164 RVA: 0x00012E11 File Offset: 0x00011011
				public int PeekInterationReceivedTypeCount(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, Emotion emotion, bool reachedMaxValue)
				{
					return this.m_Main.PeekInterationReceivedTypeCount(fromPart, toPart, emotion, reachedMaxValue) + this.m_Sec.PeekInterationReceivedTypeCount(fromPart, toPart, emotion, reachedMaxValue);
				}

				// Token: 0x0600048D RID: 1165 RVA: 0x00012E34 File Offset: 0x00011034
				public int PeekEmotionCount(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, bool reachedMaxValue)
				{
					return this.m_Main.PeekEmotionCount(fromPart, toPart, interationReceivedType, reachedMaxValue) + this.m_Sec.PeekEmotionCount(fromPart, toPart, interationReceivedType, reachedMaxValue);
				}

				// Token: 0x0600048E RID: 1166 RVA: 0x00012E57 File Offset: 0x00011057
				[Obsolete("", true)]
				public IReadOnlyList<Interaction> PeekMany(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return this.m_Main.PeekMany(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue).Concat(this.m_Sec.PeekMany(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue)).ToArray<Interaction>();
				}

				// Token: 0x0600048F RID: 1167 RVA: 0x00012E87 File Offset: 0x00011087
				public void Clear()
				{
					InteraccionesEnScena.InteraccionesEntreCharacters.Stacked main = this.m_Main;
					if (main != null)
					{
						main.Clear();
					}
					InteraccionesEnScena.InteraccionesEntreCharacters.Stacked sec = this.m_Sec;
					if (sec == null)
					{
						return;
					}
					sec.Clear();
				}

				// Token: 0x06000490 RID: 1168 RVA: 0x00012EAA File Offset: 0x000110AA
				public int PeekStartFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
				{
					return Mathf.Max(this.m_Main.PeekStartFrame(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue), this.m_Sec.PeekStartFrame(fromPart, toPart, interationReceivedType, emotion, reachedMaxValue));
				}

				// Token: 0x04000312 RID: 786
				private InteraccionesEnScena.InteraccionesEntreCharacters m_self;

				// Token: 0x04000313 RID: 787
				private InteraccionesEnScena.InteraccionesEntreCharacters.Stacked m_Main;

				// Token: 0x04000314 RID: 788
				private InteraccionesEnScena.InteraccionesEntreCharacters.Stacked m_Sec;
			}
		}

		// Token: 0x020000C2 RID: 194
		[Serializable]
		internal class Interaccion : IClearable
		{
			// Token: 0x06000491 RID: 1169 RVA: 0x00012ED8 File Offset: 0x000110D8
			internal void Initiate(ICharacterUnico From, ICharacterUnico To)
			{
				SceneCharacter componentInChildren = From.GetComponentInChildren<SceneCharacter>();
				SceneCharacter componentInChildren2 = To.GetComponentInChildren<SceneCharacter>();
				if (componentInChildren == null)
				{
					throw new ArgumentNullException("m_fromSceneCharacter", "m_fromSceneCharacter null reference.");
				}
				if (componentInChildren2 == null)
				{
					throw new ArgumentNullException("m_toSceneCharacter", "m_toSceneCharacter null reference.");
				}
				this.Initiate(componentInChildren, componentInChildren2);
			}

			// Token: 0x06000492 RID: 1170 RVA: 0x00012F30 File Offset: 0x00011130
			internal void Initiate(SceneCharacter From, SceneCharacter To)
			{
				if (this.m_init)
				{
					Debug.LogError("Interaccion ya estaba iniciada y se intento usar nueva mente");
					throw new InvalidOperationException();
				}
				this.m_from = new SceneCharacterWrapper(From);
				this.m_to = new SceneCharacterWrapper(To);
				this.m_fromID = From.stringID;
				this.m_toID = To.stringID;
				this.m_init = true;
			}

			// Token: 0x17000113 RID: 275
			// (get) Token: 0x06000493 RID: 1171 RVA: 0x00012F8C File Offset: 0x0001118C
			public SceneCharacter from
			{
				get
				{
					return this.m_from.sceneCharacter;
				}
			}

			// Token: 0x17000114 RID: 276
			// (get) Token: 0x06000494 RID: 1172 RVA: 0x00012F99 File Offset: 0x00011199
			public SceneCharacter to
			{
				get
				{
					return this.m_to.sceneCharacter;
				}
			}

			// Token: 0x17000115 RID: 277
			// (get) Token: 0x06000495 RID: 1173 RVA: 0x00012FA6 File Offset: 0x000111A6
			public string fromID
			{
				get
				{
					return this.m_fromID;
				}
			}

			// Token: 0x17000116 RID: 278
			// (get) Token: 0x06000496 RID: 1174 RVA: 0x00012FAE File Offset: 0x000111AE
			public string toID
			{
				get
				{
					return this.m_toID;
				}
			}

			// Token: 0x06000497 RID: 1175 RVA: 0x00012FB6 File Offset: 0x000111B6
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> GetKey()
			{
				return new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.toReport.fromPart, this.toReport.toPart, this.toReport.interationReceivedType, this.toReport.emotion, this.toReport.triggerMaxValue);
			}

			// Token: 0x06000498 RID: 1176 RVA: 0x00012FF4 File Offset: 0x000111F4
			public void Clear()
			{
				this.m_fromID = null;
				this.m_toID = null;
				this.m_init = false;
				this.canProduceBuff = true;
				this.m_from = null;
				this.m_to = null;
				this.toReport.fromID = null;
				this.toReport.toID = null;
			}

			// Token: 0x06000499 RID: 1177 RVA: 0x00013044 File Offset: 0x00011244
			public void CheckIDs()
			{
				if (this.m_fromID != this.toReport.fromID)
				{
					Debug.LogError("ids de from no son iguales");
				}
				if (this.m_toID != this.toReport.toID)
				{
					Debug.LogError("ids de from no son iguales");
				}
			}

			// Token: 0x0600049A RID: 1178 RVA: 0x00013095 File Offset: 0x00011295
			public void StackOnMe(InteraccionesEnScena.Interaccion newInteraccion, bool addTimes, bool fixStartTime)
			{
				Interaction.StackFromSameRecording(ref this.toReport, ref newInteraccion.toReport, addTimes, fixStartTime);
			}

			// Token: 0x0600049B RID: 1179 RVA: 0x000130AA File Offset: 0x000112AA
			public void UnStackOnMe(InteraccionesEnScena.Interaccion oldInteraccion, bool removeTimes)
			{
				Interaction.UnStack(ref this.toReport, ref oldInteraccion.toReport, removeTimes);
			}

			// Token: 0x04000318 RID: 792
			[ReadOnlyUI]
			[SerializeField]
			private bool m_init;

			// Token: 0x04000319 RID: 793
			private SceneCharacterWrapper m_from;

			// Token: 0x0400031A RID: 794
			private SceneCharacterWrapper m_to;

			// Token: 0x0400031B RID: 795
			[ReadOnlyUI]
			[SerializeField]
			private string m_fromID;

			// Token: 0x0400031C RID: 796
			[ReadOnlyUI]
			[SerializeField]
			private string m_toID;

			// Token: 0x0400031D RID: 797
			public Interaction toReport;

			// Token: 0x0400031E RID: 798
			public bool canProduceBuff = true;
		}

		// Token: 0x020000C3 RID: 195
		public class Combonaciones
		{
			// Token: 0x0600049D RID: 1181 RVA: 0x000130D0 File Offset: 0x000112D0
			public Combonaciones(ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> Key)
			{
				this.key = Key;
				this.aaaa = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, Emotion.All, this.key.Item5);
				this.aaab = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, this.key.Item4, this.key.Item5);
				this.aaba = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(TriggeringBodyPart.All, SensitiveBodyPart.All, this.key.Item3, Emotion.All, this.key.Item5);
				this.aabb = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(TriggeringBodyPart.All, SensitiveBodyPart.All, this.key.Item3, this.key.Item4, this.key.Item5);
				this.abaa = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(TriggeringBodyPart.All, this.key.Item2, InterationReceivedType.All, Emotion.All, this.key.Item5);
				this.abab = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(TriggeringBodyPart.All, this.key.Item2, InterationReceivedType.All, this.key.Item4, this.key.Item5);
				this.abba = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(TriggeringBodyPart.All, this.key.Item2, this.key.Item3, Emotion.All, this.key.Item5);
				this.abbb = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(TriggeringBodyPart.All, this.key.Item2, this.key.Item3, this.key.Item4, this.key.Item5);
				this.baaa = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.key.Item1, SensitiveBodyPart.All, InterationReceivedType.All, Emotion.All, this.key.Item5);
				this.baab = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.key.Item1, SensitiveBodyPart.All, InterationReceivedType.All, this.key.Item4, this.key.Item5);
				this.baba = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.key.Item1, SensitiveBodyPart.All, this.key.Item3, Emotion.All, this.key.Item5);
				this.babb = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.key.Item1, SensitiveBodyPart.All, this.key.Item3, this.key.Item4, this.key.Item5);
				this.bbaa = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.key.Item1, this.key.Item2, InterationReceivedType.All, Emotion.All, this.key.Item5);
				this.bbab = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.key.Item1, this.key.Item2, InterationReceivedType.All, this.key.Item4, this.key.Item5);
				this.bbba = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.key.Item1, this.key.Item2, this.key.Item3, Emotion.All, this.key.Item5);
				this.bbbb = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.key.Item1, this.key.Item2, this.key.Item3, this.key.Item4, this.key.Item5);
			}

			// Token: 0x0400031F RID: 799
			public readonly ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key;

			// Token: 0x04000320 RID: 800
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> aaaa;

			// Token: 0x04000321 RID: 801
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> aaab;

			// Token: 0x04000322 RID: 802
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> aaba;

			// Token: 0x04000323 RID: 803
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> aabb;

			// Token: 0x04000324 RID: 804
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> abaa;

			// Token: 0x04000325 RID: 805
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> abab;

			// Token: 0x04000326 RID: 806
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> abba;

			// Token: 0x04000327 RID: 807
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> abbb;

			// Token: 0x04000328 RID: 808
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> baaa;

			// Token: 0x04000329 RID: 809
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> baab;

			// Token: 0x0400032A RID: 810
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> baba;

			// Token: 0x0400032B RID: 811
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> babb;

			// Token: 0x0400032C RID: 812
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> bbaa;

			// Token: 0x0400032D RID: 813
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> bbab;

			// Token: 0x0400032E RID: 814
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> bbba;

			// Token: 0x0400032F RID: 815
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> bbbb;
		}
	}
}
