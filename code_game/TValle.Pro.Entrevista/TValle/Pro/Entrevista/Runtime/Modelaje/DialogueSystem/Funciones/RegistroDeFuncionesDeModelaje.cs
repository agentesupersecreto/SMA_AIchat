using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.CharacterMemoria;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem.Funciones
{
	// Token: 0x020000A5 RID: 165
	public class RegistroDeFuncionesDeModelaje : CustomMonobehaviour
	{
		// Token: 0x0600060F RID: 1551 RVA: 0x00022E5C File Offset: 0x0002105C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("ModeloActualInteresadaEnModelajeScore", this, base.GetType().GetMethod("ModeloActualInteresadaEnModelajeScore"));
			Lua.RegisterFunction("ModeloActualInteresadaEnModelajeUnderScore", this, base.GetType().GetMethod("ModeloActualInteresadaEnModelajeUnderScore"));
			Lua.RegisterFunction("ModeloActualInteresadaEnModelajeEroScore", this, base.GetType().GetMethod("ModeloActualInteresadaEnModelajeEroScore"));
			Lua.RegisterFunction("ModeloActualInteresadaEnModelaje", this, base.GetType().GetMethod("ModeloActualInteresadaEnModelaje"));
			Lua.RegisterFunction("ModeloActualInteresadaEnModelajeUnder", this, base.GetType().GetMethod("ModeloActualInteresadaEnModelajeUnder"));
			Lua.RegisterFunction("ModeloActualInteresadaEnModelajeEro", this, base.GetType().GetMethod("ModeloActualInteresadaEnModelajeEro"));
			Lua.RegisterFunction("ModeloHabloSobreTipoDeModelaje", this, base.GetType().GetMethod("ModeloHabloSobreTipoDeModelaje"));
			Lua.RegisterFunction("AceptoModelajeFotografias", this, base.GetType().GetMethod("AceptoModelajeFotografias"));
			Lua.RegisterFunction("AceptoModelaje", this, base.GetType().GetMethod("AceptoModelaje"));
			Lua.RegisterFunction("AceptoModelajeUndies", this, base.GetType().GetMethod("AceptoModelajeUndies"));
			Lua.RegisterFunction("AceptoModelajeEro", this, base.GetType().GetMethod("AceptoModelajeEro"));
			Lua.RegisterFunction("ModeloQuierePasarDeModelajeFotograficoAModelajePoses", this, base.GetType().GetMethod("ModeloQuierePasarDeModelajeFotograficoAModelajePoses"));
			Lua.RegisterFunction("ModeloQuierePasarDeModelajePosesAModelajeUndies", this, base.GetType().GetMethod("ModeloQuierePasarDeModelajePosesAModelajeUndies"));
			Lua.RegisterFunction("ModeloQuierePasarDeModelajeUndiesAModelajeEro", this, base.GetType().GetMethod("ModeloQuierePasarDeModelajeUndiesAModelajeEro"));
			Lua.RegisterFunction("YaPreguntoModelajeFotosAPoses", this, base.GetType().GetMethod("YaPreguntoModelajeFotosAPoses"));
			Lua.RegisterFunction("ResgistrarPreguntoModelajeFotosAPoses", this, base.GetType().GetMethod("ResgistrarPreguntoModelajeFotosAPoses"));
			Lua.RegisterFunction("YaPreguntoModelajePosesAUndies", this, base.GetType().GetMethod("YaPreguntoModelajePosesAUndies"));
			Lua.RegisterFunction("ResgistrarPreguntoModelajePosesAUndies", this, base.GetType().GetMethod("ResgistrarPreguntoModelajePosesAUndies"));
			Lua.RegisterFunction("YaPreguntoModelajeUndiesAEro", this, base.GetType().GetMethod("YaPreguntoModelajeUndiesAEro"));
			Lua.RegisterFunction("ResgistrarPreguntoModelajeUndiesAEro", this, base.GetType().GetMethod("ResgistrarPreguntoModelajeUndiesAEro"));
			Lua.RegisterFunction("AceptoAvanzarModelajeFotografiasAPoses", this, base.GetType().GetMethod("AceptoAvanzarModelajeFotografiasAPoses"));
			Lua.RegisterFunction("AceptoAvanzarModelajePoseAUndies", this, base.GetType().GetMethod("AceptoAvanzarModelajePoseAUndies"));
			Lua.RegisterFunction("AceptoAvanzarModelajeUndiesAEro", this, base.GetType().GetMethod("AceptoAvanzarModelajeUndiesAEro"));
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x000230DC File Offset: 0x000212DC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("ModeloActualInteresadaEnModelajeScore");
			Lua.UnregisterFunction("ModeloActualInteresadaEnModelajeUnderScore");
			Lua.UnregisterFunction("ModeloActualInteresadaEnModelajeEroScore");
			Lua.UnregisterFunction("ModeloActualInteresadaEnModelaje");
			Lua.UnregisterFunction("ModeloActualInteresadaEnModelajeUnder");
			Lua.UnregisterFunction("ModeloActualInteresadaEnModelajeEro");
			Lua.UnregisterFunction("ModeloHabloSobreTipoDeModelaje");
			Lua.UnregisterFunction("AceptoModelajeFotografias");
			Lua.UnregisterFunction("AceptoModelaje");
			Lua.UnregisterFunction("AceptoModelajeUndies");
			Lua.UnregisterFunction("AceptoModelajeEro");
			Lua.UnregisterFunction("ModeloQuierePasarDeModelajeFotograficoAModelajePoses");
			Lua.UnregisterFunction("ModeloQuierePasarDeModelajePosesAModelajeUndies");
			Lua.UnregisterFunction("ModeloQuierePasarDeModelajeUndiesAModelajeEro");
			Lua.UnregisterFunction("YaPreguntoModelajeFotosAPoses");
			Lua.UnregisterFunction("ResgistrarPreguntoModelajeFotosAPoses");
			Lua.UnregisterFunction("YaPreguntoModelajePosesAUndies");
			Lua.UnregisterFunction("ResgistrarPreguntoModelajePosesAUndies");
			Lua.UnregisterFunction("YaPreguntoModelajeUndiesAEro");
			Lua.UnregisterFunction("ResgistrarPreguntoModelajeUndiesAEro");
			Lua.UnregisterFunction("AceptoAvanzarModelajeFotografiasAPoses");
			Lua.UnregisterFunction("AceptoAvanzarModelajePoseAUndies");
			Lua.UnregisterFunction("AceptoAvanzarModelajeUndiesAEro");
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x000231D8 File Offset: 0x000213D8
		public float ModeloActualInteresadaEnModelajeScore()
		{
			float num2;
			try
			{
				float num;
				RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().InterestedInModeling(out num);
				num2 = num;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num2 = 0f;
			}
			return num2;
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00023218 File Offset: 0x00021418
		public float ModeloActualInteresadaEnModelajeUnderScore()
		{
			float num2;
			try
			{
				float num;
				RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().InterestedInLingerieModeling(out num);
				num2 = num;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num2 = 0f;
			}
			return num2;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00023258 File Offset: 0x00021458
		public float ModeloActualInteresadaEnModelajeEroScore()
		{
			float num2;
			try
			{
				float num;
				RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().InterestedInEroticModeling(out num);
				num2 = num;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num2 = 0f;
			}
			return num2;
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00023298 File Offset: 0x00021498
		public bool ModeloActualInteresadaEnModelaje()
		{
			bool flag;
			try
			{
				Personalidad personalidad = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic();
				float num;
				float num2;
				if (personalidad.InterestedInEroticModeling(out num))
				{
					flag = false;
				}
				else if (personalidad.InterestedInLingerieModeling(out num2))
				{
					flag = false;
				}
				else
				{
					float num3;
					flag = personalidad.InterestedInModeling(out num3);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x000232F4 File Offset: 0x000214F4
		public bool ModeloActualInteresadaEnModelajeUnder()
		{
			bool flag;
			try
			{
				Personalidad personalidad = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic();
				float num;
				if (personalidad.InterestedInEroticModeling(out num))
				{
					flag = false;
				}
				else
				{
					float num2;
					flag = personalidad.InterestedInLingerieModeling(out num2);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0002333C File Offset: 0x0002153C
		public bool ModeloActualInteresadaEnModelajeEro()
		{
			bool flag;
			try
			{
				float num;
				flag = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().InterestedInEroticModeling(out num);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00023374 File Offset: 0x00021574
		public bool ModeloHabloSobreTipoDeModelaje()
		{
			bool flag;
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				flag = MemoriaDeSMAModelosFemeninas.HabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, asString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x000233C0 File Offset: 0x000215C0
		public void AceptoModelajeFotografias()
		{
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ConsentPorGustosDeModelaje componentInChildren = character.GetComponentInChildren<ConsentPorGustosDeModelaje>();
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple4;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple5;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple6;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple7;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple8;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple9;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple10;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple11;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple12;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple13;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple14;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple15;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple16;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeFotografias(out valueTuple, out valueTuple2, out valueTuple3, out valueTuple4, out valueTuple5, out valueTuple6, out valueTuple7, out valueTuple8, out valueTuple9, out valueTuple10, out valueTuple11, out valueTuple12, out valueTuple13, out valueTuple14, out valueTuple15, out valueTuple16);
				componentInChildren.Change(new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] { valueTuple }, new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[]
				{
					valueTuple2, valueTuple3, valueTuple4, valueTuple5, valueTuple6, valueTuple7, valueTuple8, valueTuple9, valueTuple10, valueTuple11,
					valueTuple12, valueTuple13, valueTuple14, valueTuple15, valueTuple16
				});
				MemoriaDeSMAModelosFemeninas.RegistrarHabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0002350C File Offset: 0x0002170C
		public void AceptoModelaje()
		{
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ConsentPorGustosDeModelaje componentInChildren = character.GetComponentInChildren<ConsentPorGustosDeModelaje>();
				character.GetComponentInChildren<DesHielo>();
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeFotografias(out valueTuple);
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple4;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple5;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple6;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple7;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple8;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple9;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple10;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple11;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple12;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple13;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple14;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple15;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple16;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelaje(out valueTuple2, out valueTuple3, out valueTuple4, out valueTuple5, out valueTuple6, out valueTuple7, out valueTuple8, out valueTuple9, out valueTuple10, out valueTuple11, out valueTuple12, out valueTuple13, out valueTuple14, out valueTuple15, out valueTuple16);
				componentInChildren.Change(new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] { valueTuple, valueTuple2, valueTuple3 }, new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[]
				{
					valueTuple4, valueTuple5, valueTuple6, valueTuple7, valueTuple8, valueTuple9, valueTuple10, valueTuple11, valueTuple12, valueTuple13,
					valueTuple14, valueTuple15, valueTuple16
				});
				MemoriaDeSMAModelosFemeninas.RegistrarHabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00023670 File Offset: 0x00021870
		public void AceptoModelajeUndies()
		{
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ConsentPorGustosDeModelaje componentInChildren = character.GetComponentInChildren<ConsentPorGustosDeModelaje>();
				character.GetComponentInChildren<DesHielo>();
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeFotografias(out valueTuple);
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelaje(out valueTuple2, out valueTuple3);
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple4;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple5;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple6;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple7;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple8;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple9;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple10;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple11;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple12;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple13;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple14;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelajeUndies(out valueTuple4, out valueTuple5, out valueTuple6, out valueTuple7, out valueTuple8, out valueTuple9, out valueTuple10, out valueTuple11, out valueTuple12, out valueTuple13, out valueTuple14);
				componentInChildren.Change(new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] { valueTuple, valueTuple2, valueTuple3, valueTuple4 }, new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] { valueTuple5, valueTuple6, valueTuple7, valueTuple8, valueTuple9, valueTuple10, valueTuple11, valueTuple12, valueTuple13, valueTuple14 });
				MemoriaDeSMAModelosFemeninas.RegistrarHabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x000237D0 File Offset: 0x000219D0
		public void AceptoModelajeEro()
		{
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ConsentPorGustosDeModelaje componentInChildren = character.GetComponentInChildren<ConsentPorGustosDeModelaje>();
				character.GetComponentInChildren<DesHielo>();
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeFotografias(out valueTuple);
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelaje(out valueTuple2, out valueTuple3);
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple4;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelajeUndies(out valueTuple4);
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple5;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple6;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple7;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple8;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple9;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple10;
				ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple11;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelajeEro(out valueTuple5, out valueTuple6, out valueTuple7, out valueTuple8, out valueTuple9, out valueTuple10, out valueTuple11);
				componentInChildren.Change(new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] { valueTuple, valueTuple2, valueTuple3, valueTuple4, valueTuple5, valueTuple6, valueTuple7, valueTuple8 }, new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] { valueTuple9, valueTuple10, valueTuple11 });
				MemoriaDeSMAModelosFemeninas.RegistrarHabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoErotico(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00023924 File Offset: 0x00021B24
		public int ModeloQuierePasarDeModelajeFotograficoAModelajePoses()
		{
			int num2;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ConsentNecesario componentInChildren = character.GetComponentInChildren<ConsentNecesario>();
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelaje(out valueTuple, out valueTuple2);
				float maxConsentNecesarioParaInteraccion = RegistroDeFuncionesDeModelaje.GetMaxConsentNecesarioParaInteraccion(componentInChildren, valueTuple);
				float maxConsentNecesarioParaInteraccion2 = RegistroDeFuncionesDeModelaje.GetMaxConsentNecesarioParaInteraccion(componentInChildren, valueTuple2);
				float num = Mathf.Max(maxConsentNecesarioParaInteraccion, maxConsentNecesarioParaInteraccion2);
				if (componentInChildren.consentActual >= num * 1.01f)
				{
					num2 = 1;
				}
				else
				{
					bool flag = false;
					foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in character.GetComponentsEnRoot(true).Where(delegate(GizmoDeBoneRMInfo b)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano2;
						return b.humanBone.TryParceToParteDelCuerpoHumano(out parteDelCuerpoHumano2);
					}).Select(delegate(GizmoDeBoneRMInfo b)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano3;
						b.humanBone.TryParceToParteDelCuerpoHumano(out parteDelCuerpoHumano3);
						return parteDelCuerpoHumano3;
					})
						.Distinct<ParteDelCuerpoHumano>()
						.ToArray<ParteDelCuerpoHumano>())
					{
						float num3;
						float num4;
						if (componentInChildren.EsConsentidoConJerarquia(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, out num3, out num4, 1f, null, null, null) && num3 >= 1.01f)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						num2 = 0;
					}
					else
					{
						num2 = -1;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num2 = -1;
			}
			return num2;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00023A80 File Offset: 0x00021C80
		public int ModeloQuierePasarDeModelajePosesAModelajeUndies()
		{
			int num;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ConsentNecesario componentInChildren = character.GetComponentInChildren<ConsentNecesario>();
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelajeUndies(out valueTuple);
				float maxConsentNecesarioParaInteraccion = RegistroDeFuncionesDeModelaje.GetMaxConsentNecesarioParaInteraccion(componentInChildren, valueTuple);
				if (componentInChildren.consentActual >= maxConsentNecesarioParaInteraccion * 1.01f)
				{
					num = 1;
				}
				else
				{
					bool flag = false;
					int cubriendoFlags = (int)character.GetComponentEnRoot<IRopaManager>().cubriendoFlags;
					foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in (from enumInt in typeof(RopaCubre).GetEnumValoresInt()
						where cubriendoFlags.HasFlag(enumInt)
						select ((RopaCubre)enumInt).ParceToParteDelCuerpoHumano()).Distinct<ParteDelCuerpoHumano>())
					{
						float num2;
						float num3;
						if ((parteDelCuerpoHumano.EsPrivadaSocialmenteVisual() || parteDelCuerpoHumano.EsSemiPrivadaSocialmenteVisual()) && componentInChildren.EsConsentidoConJerarquia(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, out num2, out num3, 1f, null, null, null) && num2 >= 1.01f)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						num = 0;
					}
					else
					{
						num = -1;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = -1;
			}
			return num;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00023C04 File Offset: 0x00021E04
		public int ModeloQuierePasarDeModelajeUndiesAModelajeEro()
		{
			int num4;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				ConsentNecesario componentInChildren = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<ConsentNecesario>();
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
				ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple4;
				RegistroDeFuncionesDeModelaje.GetInteracionesDeModelajeEro(out valueTuple, out valueTuple2, out valueTuple3, out valueTuple4);
				float maxConsentNecesarioParaInteraccion = RegistroDeFuncionesDeModelaje.GetMaxConsentNecesarioParaInteraccion(componentInChildren, valueTuple);
				float maxConsentNecesarioParaInteraccion2 = RegistroDeFuncionesDeModelaje.GetMaxConsentNecesarioParaInteraccion(componentInChildren, valueTuple2);
				float maxConsentNecesarioParaInteraccion3 = RegistroDeFuncionesDeModelaje.GetMaxConsentNecesarioParaInteraccion(componentInChildren, valueTuple3);
				float maxConsentNecesarioParaInteraccion4 = RegistroDeFuncionesDeModelaje.GetMaxConsentNecesarioParaInteraccion(componentInChildren, valueTuple4);
				float num = Mathf.Max(maxConsentNecesarioParaInteraccion, maxConsentNecesarioParaInteraccion2);
				float num2 = Mathf.Max(maxConsentNecesarioParaInteraccion3, maxConsentNecesarioParaInteraccion4);
				float num3 = Mathf.Max(num, num2);
				if (componentInChildren.consentActual >= num3 * 1.01f)
				{
					num4 = 1;
				}
				else
				{
					bool flag = false;
					foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
						if (parteDelCuerpoHumano.EsPrivadaSocialmenteTactil() || parteDelCuerpoHumano.EsSemiPrivadaSocialmenteTactil())
						{
							float num5;
							float num6;
							if (componentInChildren.EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.manos, out num5, out num6, 1f, null, null, null) && num5 >= 1.01f)
							{
								flag = true;
								break;
							}
							float num7;
							if (componentInChildren.EsConsentidoConJerarquia(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.manos, out num7, out num6, 1f, null, null, null) && num7 >= 1.01f)
							{
								flag = true;
								break;
							}
							float num8;
							if (componentInChildren.EsConsentidoConJerarquia(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.manos, out num8, out num6, 1f, null, null, null) && num8 >= 1.01f)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						num4 = 0;
					}
					else
					{
						num4 = -1;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num4 = -1;
			}
			return num4;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00023DE8 File Offset: 0x00021FE8
		public bool YaPreguntoModelajeFotosAPoses()
		{
			bool flag;
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				Guid guid = Guid.Parse(asString);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				flag = MemoriaDeCharacterBase.LeerDeepBoolean(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString), null, "TalkedAboutPicsToPoses", false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00023E4C File Offset: 0x0002204C
		public void ResgistrarPreguntoModelajeFotosAPoses()
		{
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				Guid guid = Guid.Parse(asString);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString), null, "TalkedAboutPicsToPoses", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00023EAC File Offset: 0x000220AC
		public bool YaPreguntoModelajePosesAUndies()
		{
			bool flag;
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				Guid guid = Guid.Parse(asString);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				flag = MemoriaDeCharacterBase.LeerDeepBoolean(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString), null, "TalkedAboutPosesToUndies", false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00023F10 File Offset: 0x00022110
		public void ResgistrarPreguntoModelajePosesAUndies()
		{
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				Guid guid = Guid.Parse(asString);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString), null, "TalkedAboutPosesToUndies", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00023F70 File Offset: 0x00022170
		public bool YaPreguntoModelajeUndiesAEro()
		{
			bool flag;
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				Guid guid = Guid.Parse(asString);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				flag = MemoriaDeCharacterBase.LeerDeepBoolean(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString), null, "TalkedAboutUndiesToEro", false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00023FD4 File Offset: 0x000221D4
		public void ResgistrarPreguntoModelajeUndiesAEro()
		{
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				Guid guid = Guid.Parse(asString);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString), null, "TalkedAboutUndiesToEro", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00024034 File Offset: 0x00022234
		public void AceptoAvanzarModelajeFotografiasAPoses()
		{
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x000240A0 File Offset: 0x000222A0
		public void AceptoAvanzarModelajePoseAUndies()
		{
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0002411C File Offset: 0x0002231C
		public void AceptoAvanzarModelajeUndiesAEro()
		{
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoErotico(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x000241A8 File Offset: 0x000223A8
		private static float GetMaxConsentNecesarioParaInteraccion(ConsentNecesario consentNecesario, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusion)
		{
			float num = float.MinValue;
			EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
			for (int i = 0; i < inclusion.Item4.Count; i++)
			{
				float num2 = consentNecesario.ParaConJerarquia(inclusion.Item1, inclusion.Item2, inclusion.Item4[i], inclusion.Item3, new EmocionesFemeninasValues?(emptyValid), null, null);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0002420C File Offset: 0x0002240C
		private static void GetInteracionesDeFotografias([TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusion)
		{
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple4;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple5;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple6;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple7;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple8;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple9;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple10;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple11;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple12;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple13;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple14;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple15;
			RegistroDeFuncionesDeModelaje.GetInteracionesDeFotografias(out inclusion, out valueTuple, out valueTuple2, out valueTuple3, out valueTuple4, out valueTuple5, out valueTuple6, out valueTuple7, out valueTuple8, out valueTuple9, out valueTuple10, out valueTuple11, out valueTuple12, out valueTuple13, out valueTuple14, out valueTuple15);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00024240 File Offset: 0x00022440
		private static void GetInteracionesDeFotografias([TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusion, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionVisualOjos, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionVisualCamera, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionPeticionPose, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionGuiaBone, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionPeticionDesvestidura, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilManos, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilDedo, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilPene, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilSemen, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionPose, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionManipularBone, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionDesvestidura, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalPene, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalDedo, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalProp)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			DireccionDeEstimulo direccionDeEstimulo = DireccionDeEstimulo.recibida;
			TipoDeEstimulo tipoDeEstimulo = TipoDeEstimulo.visual;
			ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimular.propSexToy;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (!parteDelCuerpoHumano.EsPrivadaSocialmenteVisual())
				{
					list.Add(parteDelCuerpoHumano);
				}
			}
			inclusion = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(tipoDeEstimulo, direccionDeEstimulo, parteQuePuedeEstimular, list);
			List<ParteDelCuerpoHumano> list2 = new List<ParteDelCuerpoHumano>();
			List<ParteDelCuerpoHumano> list3 = new List<ParteDelCuerpoHumano>();
			List<ParteDelCuerpoHumano> list4 = new List<ParteDelCuerpoHumano>();
			foreach (object obj2 in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = (ParteDelCuerpoHumano)obj2;
				if (parteDelCuerpoHumano2.EsPrivadaSocialmenteVisual())
				{
					list2.Add(parteDelCuerpoHumano2);
				}
				if (parteDelCuerpoHumano2.EsSemiPrivadaSocialmenteTactil() || parteDelCuerpoHumano2.EsPrivadaSocialmenteTactil())
				{
					list3.Add(parteDelCuerpoHumano2);
				}
				if (parteDelCuerpoHumano2.EsHole())
				{
					list4.Add(parteDelCuerpoHumano2);
				}
			}
			exclusionVisualOjos = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0001f, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.ojos, list2);
			exclusionVisualCamera = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0001f, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.propSexToy, list2);
			exclusionPeticionPose = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0002f, TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, list2);
			exclusionGuiaBone = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0002f, TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, list2);
			exclusionPeticionDesvestidura = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0002f, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, list2);
			exclusionTactilManos = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0005f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list3);
			exclusionTactilDedo = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0006f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.dedo, list3);
			exclusionTactilPene = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0007f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list3);
			exclusionTactilSemen = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0008f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.semen, list3);
			exclusionPose = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.001f, TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list3);
			exclusionManipularBone = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.001f, TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list3);
			exclusionDesvestidura = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.001f, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list3);
			exclusionCoitalPene = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0016f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list4);
			exclusionCoitalDedo = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0015f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.dedo, list4);
			exclusionCoitalProp = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0017f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.propSexToy, list4);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x000244E4 File Offset: 0x000226E4
		private static void GetInteracionesDeModelaje([TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionA, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionB)
		{
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple4;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple5;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple6;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple7;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple8;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple9;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple10;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple11;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple12;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple13;
			RegistroDeFuncionesDeModelaje.GetInteracionesDeModelaje(out inclusionA, out inclusionB, out valueTuple, out valueTuple2, out valueTuple3, out valueTuple4, out valueTuple5, out valueTuple6, out valueTuple7, out valueTuple8, out valueTuple9, out valueTuple10, out valueTuple11, out valueTuple12, out valueTuple13);
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00024514 File Offset: 0x00022714
		private static void GetInteracionesDeModelaje([TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionA, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionB, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionVisualOjos, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionVisualCamera, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionPeticionDesvestidura, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilManos, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilDedo, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilPene, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilSemen, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionPose, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionManipularBone, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionDesvestidura, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalPene, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalDedo, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalProp)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			DireccionDeEstimulo direccionDeEstimulo = DireccionDeEstimulo.recibida;
			TipoDeEstimulo tipoDeEstimulo = TipoDeEstimulo.guiandoBone;
			ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimular.boca;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsSkeleto())
				{
					list.Add(parteDelCuerpoHumano);
				}
			}
			inclusionA = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(tipoDeEstimulo, direccionDeEstimulo, parteQuePuedeEstimular, list);
			List<ParteDelCuerpoHumano> list2 = new List<ParteDelCuerpoHumano>();
			DireccionDeEstimulo direccionDeEstimulo2 = DireccionDeEstimulo.recibida;
			TipoDeEstimulo tipoDeEstimulo2 = TipoDeEstimulo.peticionEjecucionDePose;
			ParteQuePuedeEstimular parteQuePuedeEstimular2 = ParteQuePuedeEstimular.boca;
			foreach (object obj2 in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = (ParteDelCuerpoHumano)obj2;
				list2.Add(parteDelCuerpoHumano2);
			}
			inclusionB = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(tipoDeEstimulo2, direccionDeEstimulo2, parteQuePuedeEstimular2, list2);
			List<ParteDelCuerpoHumano> list3 = new List<ParteDelCuerpoHumano>();
			List<ParteDelCuerpoHumano> list4 = new List<ParteDelCuerpoHumano>();
			List<ParteDelCuerpoHumano> list5 = new List<ParteDelCuerpoHumano>();
			foreach (object obj3 in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano3 = (ParteDelCuerpoHumano)obj3;
				if (parteDelCuerpoHumano3.EsPrivadaSocialmenteVisual())
				{
					list3.Add(parteDelCuerpoHumano3);
				}
				if (parteDelCuerpoHumano3.EsSemiPrivadaSocialmenteTactil() || parteDelCuerpoHumano3.EsPrivadaSocialmenteTactil())
				{
					list4.Add(parteDelCuerpoHumano3);
				}
				if (parteDelCuerpoHumano3.EsHole())
				{
					list5.Add(parteDelCuerpoHumano3);
				}
			}
			exclusionVisualOjos = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0001f, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.ojos, list3);
			exclusionVisualCamera = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0001f, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.propSexToy, list3);
			exclusionPeticionDesvestidura = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0002f, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, list3);
			exclusionTactilManos = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0005f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list4);
			exclusionTactilDedo = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0006f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.dedo, list4);
			exclusionTactilPene = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0007f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list4);
			exclusionTactilSemen = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0008f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.semen, list4);
			exclusionPose = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.001f, TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list4);
			exclusionManipularBone = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.001f, TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list4);
			exclusionDesvestidura = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.001f, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list4);
			exclusionCoitalPene = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0016f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list5);
			exclusionCoitalDedo = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0015f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.dedo, list5);
			exclusionCoitalProp = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0017f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.propSexToy, list5);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00024808 File Offset: 0x00022A08
		private static void GetInteracionesDeModelajeUndies([TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusion)
		{
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple4;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple5;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple6;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple7;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple8;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple9;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple10;
			RegistroDeFuncionesDeModelaje.GetInteracionesDeModelajeUndies(out inclusion, out valueTuple, out valueTuple2, out valueTuple3, out valueTuple4, out valueTuple5, out valueTuple6, out valueTuple7, out valueTuple8, out valueTuple9, out valueTuple10);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x00024830 File Offset: 0x00022A30
		private static void GetInteracionesDeModelajeUndies([TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusion, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilManos, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilDedo, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilPene, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionTactilSemen, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionPose, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionManipularBone, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionDesvestidura, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalPene, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalDedo, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalProp)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			DireccionDeEstimulo direccionDeEstimulo = DireccionDeEstimulo.recibida;
			TipoDeEstimulo tipoDeEstimulo = TipoDeEstimulo.peticionDesvestidura;
			ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimular.boca;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (!parteDelCuerpoHumano.EsMuyPrivadaSocialmenteVisual())
				{
					list.Add(parteDelCuerpoHumano);
				}
			}
			inclusion = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(tipoDeEstimulo, direccionDeEstimulo, parteQuePuedeEstimular, list);
			List<ParteDelCuerpoHumano> list2 = new List<ParteDelCuerpoHumano>();
			List<ParteDelCuerpoHumano> list3 = new List<ParteDelCuerpoHumano>();
			foreach (object obj2 in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = (ParteDelCuerpoHumano)obj2;
				if (parteDelCuerpoHumano2.EsSemiPrivadaSocialmenteTactil() || parteDelCuerpoHumano2.EsPrivadaSocialmenteTactil())
				{
					list2.Add(parteDelCuerpoHumano2);
				}
				if (parteDelCuerpoHumano2.EsHole())
				{
					list3.Add(parteDelCuerpoHumano2);
				}
			}
			exclusionTactilManos = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0001f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list2);
			exclusionTactilDedo = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0002f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.dedo, list2);
			exclusionTactilPene = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0003f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list2);
			exclusionTactilSemen = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0004f, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.semen, list2);
			exclusionPose = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0005f, TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list2);
			exclusionManipularBone = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0005f, TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list2);
			exclusionDesvestidura = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0005f, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list2);
			exclusionCoitalPene = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0011f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list3);
			exclusionCoitalDedo = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.001f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.dedo, list3);
			exclusionCoitalProp = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0012f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.propSexToy, list3);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00024A3C File Offset: 0x00022C3C
		private static void GetInteracionesDeModelajeEro([TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionA, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionB, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionC, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionD)
		{
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple2;
			ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> valueTuple3;
			RegistroDeFuncionesDeModelaje.GetInteracionesDeModelajeEro(out inclusionA, out inclusionB, out inclusionC, out inclusionD, out valueTuple, out valueTuple2, out valueTuple3);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00024A58 File Offset: 0x00022C58
		private static void GetInteracionesDeModelajeEro([TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionA, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionB, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionC, [TupleElementNames(new string[] { "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> inclusionD, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalPene, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalDedo, [TupleElementNames(new string[] { "w", "tipo", "direccion", "estiulante", "estimuladas" })] out ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> exclusionCoitalProp)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			List<ParteDelCuerpoHumano> list2 = list;
			DireccionDeEstimulo direccionDeEstimulo = DireccionDeEstimulo.recibida;
			TipoDeEstimulo tipoDeEstimulo = TipoDeEstimulo.manipulandoBone;
			TipoDeEstimulo tipoDeEstimulo2 = TipoDeEstimulo.ejecucionDePose;
			TipoDeEstimulo tipoDeEstimulo3 = TipoDeEstimulo.desvestidura;
			TipoDeEstimulo tipoDeEstimulo4 = TipoDeEstimulo.tactil;
			ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimular.manos;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (!parteDelCuerpoHumano.EsPrivadaSocialmenteTactil())
				{
					list.Add(parteDelCuerpoHumano);
				}
			}
			inclusionA = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(tipoDeEstimulo, direccionDeEstimulo, parteQuePuedeEstimular, list2);
			inclusionB = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(tipoDeEstimulo2, direccionDeEstimulo, parteQuePuedeEstimular, list2);
			inclusionC = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(tipoDeEstimulo3, direccionDeEstimulo, parteQuePuedeEstimular, list2);
			inclusionD = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(tipoDeEstimulo4, direccionDeEstimulo, parteQuePuedeEstimular, list2);
			List<ParteDelCuerpoHumano> list3 = new List<ParteDelCuerpoHumano>();
			foreach (object obj2 in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = (ParteDelCuerpoHumano)obj2;
				if (parteDelCuerpoHumano2.EsHole())
				{
					list3.Add(parteDelCuerpoHumano2);
				}
			}
			exclusionCoitalPene = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0011f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list3);
			exclusionCoitalDedo = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.001f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.dedo, list3);
			exclusionCoitalProp = new ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>(1.0012f, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.propSexToy, list3);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00024BDC File Offset: 0x00022DDC
		[Obsolete("debe ser buff, ademas siempre esta quitando hielo cuando no deberia hacerlo", true)]
		private static float ConsentNecesarioParaModelajeFotografias(ConsentNecesario consentNecesario, DesHielo deshielo)
		{
			float num = float.MinValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsFacial() && deshielo != null)
				{
					deshielo.SetVisualTo(100f, parteDelCuerpoHumano, DireccionDeEstimulo.recibida, TipoDeEstimuloVisual.fotografiada);
				}
				if (!parteDelCuerpoHumano.EsPrivadaSocialmenteVisual())
				{
					float num2 = consentNecesario.ParaConJerarquia(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.propSexToy, null, null, null);
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00024C80 File Offset: 0x00022E80
		[Obsolete("debe ser buff, ademas siempre esta quitando hielo cuando no deberia hacerlo", true)]
		private static float ConsentNecesarioParaModelaje(ConsentNecesario consentNecesario, DesHielo deshielo)
		{
			float num = float.MinValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionAnalSet.Contains((int)parteDelCuerpoHumano) && !ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginalSet.Contains((int)parteDelCuerpoHumano))
				{
					if (deshielo != null)
					{
						deshielo.SetCambioDePoseTo(100f, parteDelCuerpoHumano, DireccionDeEstimulo.recibida, TipoDeEstimuloCambiarPose.None);
					}
					float num2 = consentNecesario.ParaConJerarquia(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, null, null, null);
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00024D34 File Offset: 0x00022F34
		[Obsolete("debe ser buff, ademas siempre esta quitando hielo cuando no deberia hacerlo", true)]
		private static float ConsentNecesarioParaModelajeUndies(ConsentNecesario consentNecesario, DesHielo deshielo)
		{
			float num = float.MinValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (!parteDelCuerpoHumano.EsMuyPrivadaSocialmenteVisual())
				{
					if (deshielo != null)
					{
						deshielo.SetDesvestiduraTo(100f, parteDelCuerpoHumano, DireccionDeEstimulo.recibida, 0);
					}
					float num2 = consentNecesario.ParaConJerarquia(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, null, null, null);
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00024DD4 File Offset: 0x00022FD4
		[Obsolete("debe ser buff, ademas siempre esta quitando hielo cuando no deberia hacerlo, a;adir forzar poses de partes todas y forzar desvestir de todo menos holes y pezones", true)]
		private static float ConsentNecesarioParaModelajeEro(ConsentNecesario consentNecesario, DesHielo deshielo)
		{
			float num = float.MinValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (!parteDelCuerpoHumano.EsPrivadaSocialmenteTactil())
				{
					if (deshielo != null)
					{
						deshielo.SetTactilTo(100f, parteDelCuerpoHumano, DireccionDeEstimulo.recibida, TipoDeEstimuloTactil.caricia);
					}
					float num2 = consentNecesario.ParaConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.manos, null, null, null);
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			return num;
		}
	}
}
