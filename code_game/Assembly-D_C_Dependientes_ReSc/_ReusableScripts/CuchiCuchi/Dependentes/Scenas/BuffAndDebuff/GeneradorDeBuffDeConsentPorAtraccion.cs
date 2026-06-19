using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Auras;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff
{
	// Token: 0x02000096 RID: 150
	[RequireComponent(typeof(ConcentToHeroMinimoDeFemale))]
	public class GeneradorDeBuffDeConsentPorAtraccion : CustomMonobehaviour
	{
		// Token: 0x06000322 RID: 802 RVA: 0x00013C50 File Offset: 0x00011E50
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConcentToHeroMinimoDeFemale = base.GetComponent<ConcentToHeroMinimoDeFemale>();
			this.m_self = this.GetComponentEnRoot(false);
			if (this.m_self == null)
			{
				throw new ArgumentNullException("m_self", "m_self null reference.");
			}
			this.m_BuffDeCharacter = this.m_self.GetComponentEnRoot<BuffDeCharacter>();
			if (this.m_BuffDeCharacter == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00013CCE File Offset: 0x00011ECE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ConcentToHeroMinimoDeFemale.updated += this.M_ConcentToHeroMinimoDeFemale_updated;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00013CED File Offset: 0x00011EED
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_ConcentToHeroMinimoDeFemale.updated -= this.M_ConcentToHeroMinimoDeFemale_updated;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00013D10 File Offset: 0x00011F10
		private void M_ConcentToHeroMinimoDeFemale_updated()
		{
			if (this.m_BuffDeCharacter.isStared)
			{
				ConcentToHeroMinimoDeFemale concentToHeroMinimoDeFemale = this.m_ConcentToHeroMinimoDeFemale;
				if (!(((concentToHeroMinimoDeFemale != null) ? concentToHeroMinimoDeFemale.targetCharacter : null) == null))
				{
					string text = BuffMap.GenerateBuffID(this.m_buffName, this.m_ConcentToHeroMinimoDeFemale.targetCharacter.ID_UnicoString);
					if (this.m_buff == null || !this.m_BuffDeCharacter.eventos.Contains(text))
					{
						if (this.m_BuffDeCharacter.eventos.Contains(text))
						{
							this.m_BuffDeCharacter.eventos.Remove(text);
						}
						this.m_buff = this.GenerarBuffDeConsent();
						this.m_BuffDeCharacter.eventos.AddOrStackUp(this.m_buff, false, false);
					}
					if (this.UpdateArgumento(this.m_buff.efectoArgumento as BuffOnFavorabilityTowardCharacterValueArg))
					{
						if (this.m_buff.isRunning)
						{
							this.m_buff.ForceRemoverEfecto();
						}
						this.m_buff.ForceApplyEfecto();
					}
					return;
				}
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00013E00 File Offset: 0x00012000
		private bool UpdateArgumento(BuffOnFavorabilityTowardCharacterValueArg arg)
		{
			if (arg.add != this.m_ConcentToHeroMinimoDeFemale.gusto || arg.towardID != this.m_ConcentToHeroMinimoDeFemale.targetCharacter.ID_UnicoString)
			{
				arg.add = this.m_ConcentToHeroMinimoDeFemale.gusto;
				arg.towardID = this.m_ConcentToHeroMinimoDeFemale.targetCharacter.ID_UnicoString;
				return true;
			}
			return false;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00013E68 File Offset: 0x00012068
		private DisplayableBuff GenerarBuffDeConsent()
		{
			BuffMap map = Singleton<BuffManager>.instance.GetMap(this.m_buffName);
			if (map == null)
			{
				Debug.LogException(new ArgumentNullException("map", "map null reference."));
			}
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
			BuffOnFavorabilityTowardCharacterValueArg buffOnFavorabilityTowardCharacterValueArg;
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnFavorabilityTowardCharacterValueArg>(efecto.argumentoID, out buffOnFavorabilityTowardCharacterValueArg))
			{
				Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			this.UpdateArgumento(buffOnFavorabilityTowardCharacterValueArg);
			DisplayableBuff eventoBuff = map.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, this.m_ConcentToHeroMinimoDeFemale.targetCharacter.ID_UnicoString, buffOnFavorabilityTowardCharacterValueArg, null);
			if (eventoBuff == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
			}
			eventoBuff.showSmallMsgOnApplied = true;
			eventoBuff.showSmallMsgOnEnd = false;
			eventoBuff.showSmallMsgOnStart = false;
			return eventoBuff;
		}

		// Token: 0x0400031C RID: 796
		private Character m_self;

		// Token: 0x0400031D RID: 797
		private ConcentToHeroMinimoDeFemale m_ConcentToHeroMinimoDeFemale;

		// Token: 0x0400031E RID: 798
		private BuffDeCharacter m_BuffDeCharacter;

		// Token: 0x0400031F RID: 799
		[SerializeReference]
		private DisplayableBuff m_buff;

		// Token: 0x04000320 RID: 800
		[NonSerialized]
		private string m_buffName = "Tvalle.Buff.FavorabilityByAttraction";
	}
}
