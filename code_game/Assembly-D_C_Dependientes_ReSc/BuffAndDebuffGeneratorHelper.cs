using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using UnityEngine;

// Token: 0x02000002 RID: 2
public static class BuffAndDebuffGeneratorHelper
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static void RemoveBuffImmediately(BuffDeCharacter buffDeCharacter, string buffMapId, Object context, params string[] idsSegundarias)
	{
		string text = BuffMap.GenerateIdSegundaria(idsSegundarias);
		BuffAndDebuffGeneratorHelper.RemoveBuffImmediately(buffDeCharacter, buffMapId, context, text);
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002070 File Offset: 0x00000270
	public static void RemoveBuffImmediately(BuffDeCharacter buffDeCharacter, string buffMapId, Object context, string idSegundaria = null)
	{
		BuffMap map = Singleton<BuffManager>.instance.GetMap(buffMapId);
		if (map == null)
		{
			Debug.LogException(new ArgumentNullException("map", "map null reference."), context);
		}
		string text = BuffMap.GenerateBuffID(map, idSegundaria ?? string.Empty);
		if (!buffDeCharacter.eventos.Contains(text))
		{
			return;
		}
		BuffEvento buffEvento = buffDeCharacter.eventos.Get(text);
		buffEvento.ForceRemoverEfecto();
		buffDeCharacter.eventos.Remover(buffEvento);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020E8 File Offset: 0x000002E8
	public static TBuff AddOrUpdateBuff<TBuff, TArg>(BuffDeCharacter buffDeCharacter, string buffMapId, Object context, BuffAndDebuffGeneratorHelper.UpdateArgumentDataHandler<TArg> argumentUpdater = null, BuffAndDebuffGeneratorHelper.UpdateBuffConfigHandler<TBuff> buffUpdater = null, BuffMap.Duracion duracionOverride = null, params string[] idsSegundarias) where TBuff : BuffEvento, new() where TArg : ArgumentoDeEfecto
	{
		string text = BuffMap.GenerateIdSegundaria(idsSegundarias);
		return BuffAndDebuffGeneratorHelper.AddOrUpdateBuff<TBuff, TArg>(buffDeCharacter, buffMapId, context, argumentUpdater, buffUpdater, text, duracionOverride);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x0000210C File Offset: 0x0000030C
	public static TBuff AddOrUpdateBuff<TBuff, TArg>(BuffDeCharacter buffDeCharacter, string buffMapId, Object context, BuffAndDebuffGeneratorHelper.UpdateArgumentDataHandler<TArg> argumentUpdater = null, BuffAndDebuffGeneratorHelper.UpdateBuffConfigHandler<TBuff> buffUpdater = null, string idSegundaria = null, BuffMap.Duracion duracionOverride = null) where TBuff : BuffEvento, new() where TArg : ArgumentoDeEfecto
	{
		BuffMap map = Singleton<BuffManager>.instance.GetMap(buffMapId);
		if (map == null)
		{
			Debug.LogException(new ArgumentNullException("map", "map null reference."), context);
		}
		string text = BuffMap.GenerateBuffID(map, idSegundaria ?? string.Empty);
		if (!buffDeCharacter.eventos.Contains(text))
		{
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
			TArg targ;
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<TArg>(efecto.argumentoID, out targ))
			{
				Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			if (argumentUpdater != null)
			{
				argumentUpdater(targ, true);
			}
			TBuff eventoBuff = map.GetEventoBuff<TBuff>(Singleton<TiempoDeJuego>.instance.now, idSegundaria ?? string.Empty, targ, duracionOverride);
			if (eventoBuff == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), context);
			}
			if (buffUpdater != null)
			{
				buffUpdater(eventoBuff, true);
			}
			buffDeCharacter.eventos.AddOrStackUp(eventoBuff, false, false);
			return eventoBuff;
		}
		TBuff tbuff = buffDeCharacter.eventos.Get(text) as TBuff;
		if (tbuff is DisplayableBuff)
		{
			(tbuff as DisplayableBuff).ForceUpdateLocalizedText();
		}
		tbuff.ForceRemoverEfecto();
		TArg targ2 = (TArg)((object)tbuff.efectoArgumento);
		if (argumentUpdater != null)
		{
			argumentUpdater(targ2, false);
		}
		if (targ2 is IDisplayableArgumentoDeEfecto)
		{
			(targ2 as IDisplayableArgumentoDeEfecto).flagUpdateNonLocalizedTextV2 = true;
		}
		if (buffUpdater != null)
		{
			buffUpdater(tbuff, false);
		}
		tbuff.ForceApplyEfecto();
		return tbuff;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000022B8 File Offset: 0x000004B8
	public static void GenerarBuffMap<T_arg>(string buffMapID, out BuffMap map, out T_arg painArgument) where T_arg : ArgumentoDeEfecto
	{
		map = Singleton<BuffManager>.instance.GetMap(buffMapID);
		if (map == null)
		{
			Debug.LogException(new ArgumentNullException(buffMapID, buffMapID + " map is null reference."));
		}
		Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
		if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<T_arg>(efecto.argumentoID, out painArgument))
		{
			Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002334 File Offset: 0x00000534
	public static void AddNoStackBuff<T_arg>(BuffDeCharacter buffDeCharacter, BuffMap map, string idSegundaria, T_arg argument, BuffMap.Duracion duracionOverride = null) where T_arg : ArgumentoDeEfecto
	{
		string text = BuffMap.GenerateBuffID(map, idSegundaria);
		buffDeCharacter.eventos.Remove(text);
		DisplayableBuff eventoBuff = map.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, idSegundaria, argument, duracionOverride);
		if (eventoBuff == null)
		{
			Debug.LogException(new ArgumentNullException("buff", "buff null reference."), buffDeCharacter);
		}
		eventoBuff.showSmallMsgOnApplied = false;
		eventoBuff.showSmallMsgOnEnd = false;
		eventoBuff.showSmallMsgOnStart = false;
		buffDeCharacter.eventos.AddOrStackUp(eventoBuff, false, false);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000023AC File Offset: 0x000005AC
	public static void GenerarAgreementBuffes<T_arg>(BuffDeCharacter buffDeCharacter, string buffMapID, out BuffMap map, out T_arg painArgument) where T_arg : ArgumentoDeEfecto
	{
		string text = BuffMap.GenerateBuffID(buffMapID, string.Empty);
		buffDeCharacter.eventos.Remove(text);
		map = Singleton<BuffManager>.instance.GetMap(text);
		if (map == null)
		{
			Debug.LogException(new ArgumentNullException(buffMapID, buffMapID + " map is null reference."), buffDeCharacter);
		}
		Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
		if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<T_arg>(efecto.argumentoID, out painArgument))
		{
			Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto", buffDeCharacter);
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002440 File Offset: 0x00000640
	public static void AddBuff<T_arg>(BuffDeCharacter buffDeCharacter, BuffMap map, T_arg argument) where T_arg : ArgumentoDeEfecto
	{
		DisplayableBuff eventoBuff = map.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, string.Empty, argument, null);
		if (eventoBuff == null)
		{
			Debug.LogException(new ArgumentNullException("buff", "buff null reference."), buffDeCharacter);
		}
		eventoBuff.showSmallMsgOnApplied = false;
		eventoBuff.showSmallMsgOnEnd = false;
		eventoBuff.showSmallMsgOnStart = false;
		buffDeCharacter.eventos.AddOrStackUp(eventoBuff, false, false);
	}

	// Token: 0x02000003 RID: 3
	// (Invoke) Token: 0x0600000A RID: 10
	public delegate void UpdateArgumentDataHandler<TArg>(TArg argument, bool justInstantiated) where TArg : ArgumentoDeEfecto;

	// Token: 0x02000004 RID: 4
	// (Invoke) Token: 0x0600000E RID: 14
	public delegate void UpdateBuffConfigHandler<TBuff>(TBuff buff, bool justInstantiated) where TBuff : BuffEvento;
}
